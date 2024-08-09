using Minio.DataModel.Args;
using OpenCvSharp;
using PSGM.Lib.ExifData;
using PSGM.Model.DbStorage;
using PSGM.Model.DbWorkflow;
using Serilog;
using System.Drawing;

namespace PSGM.Helper.Workflow
{
    public partial class Workflow
    {
        public void Storage_S3AndDatabase_Save_Data_V1_0_0(DbWorkflow_WorkflowItemLink workflowItemLink)
        {
            Bitmap image;
            ConfigurationSaveImageV1_0_0 configuration = workflowItemLink.GetSaveImageV1_0_0Configuration();

            // Folder for image set is not required for data, due to that it should only be one image or the suffix is used

            #region Get complete sub dirctory path
            string subdirectory = _subDirectory_StorageData.Id.ToString();
            DbStorage_SubDirectory subdirectoryWhile = _subDirectory_StorageData;

            while (subdirectoryWhile.ParentSubDirectory != null)
            {
                subdirectory = subdirectoryWhile.ParentSubDirectoryId.ToString() + "/" + subdirectory;

                subdirectoryWhile = _dbStorage_Data_Context.SubDirectories.Where(p => p.Id == subdirectoryWhile.ParentSubDirectoryId).FirstOrDefault();
            }
            #endregion

            try
            {
                #region Create Thumbnail
                if (configuration is not null)
                {
                    // Thumbnail for storage (Software preview)
                    _image_Data.Thumbnail = Vision2D.ResizeImage(_image_Data.Image, configuration.ThumbnailWidth, configuration.ThumbnailHeight);
                }
                else
                {
                    Log.Debug("Crop V1.0.0 configuration not found ...");
                }
                #endregion

                #region Create image with metadata and thumbnail
                ExifData exifData;
                MemoryStream imageStreamSource;
                MemoryStream imageStreamDestination = new MemoryStream();

                byte[] byteArraySource = _image_Data.Image.ToBytes(".Jpeg", new ImageEncodingParam(ImwriteFlags.JpegQuality, configuration.Quality));
                imageStreamSource = new MemoryStream(byteArraySource);

                imageStreamSource.Position = 0;
                exifData = new ExifData(imageStreamSource, ExifLoadOptions.CreateEmptyBlock);

                exifData.ReplaceAllTagsBy(_exifDataRaw_Data.Convert2ExifData());
                exifData.SetDateTaken(_image_Data.DateDigitized);
                exifData.SetDateDigitized(_image_Data.DateDigitized);
                exifData.SetDateChanged(DateTime.UtcNow);
                exifData.SetTagValue(ExifTag.ImageDescription, _image_Data_ExifImageDescription, StringCoding.Utf8);    // ToDo: form database, ...

                if (_image_Data.Thumbnail is not null)
                {
                    // Thumbnail for metadata (image)
                    Mat tmp = Vision2D.ResizeImage(_image_Data.Thumbnail, 256, 0);

                    byte[] thumbnailByteArray = tmp.ToBytes(".Jpeg", new ImageEncodingParam(ImwriteFlags.JpegQuality, 90));
                    exifData.SetThumbnailImage(thumbnailByteArray, 0, thumbnailByteArray.Count());
                }

                imageStreamSource.Position = 0;
                imageStreamDestination.Position = 0;

                exifData.Save(imageStreamSource, imageStreamDestination);

                //Vision2D.SaveBitmapAsJpeg(new Bitmap(imageStreamDestination), $"{_workingPath}/../{_image_Data.FileId}_Metadata.jpeg", 100L);

                byte[] byteArray = imageStreamDestination.ToArray();

                imageStreamSource.Close();
                imageStreamDestination.Close();
                #endregion

                string objectName = subdirectory + "/" + _image_Data.FileId + ".Jpeg";

                PutObjectArgs putObjectArgs = new PutObjectArgs().WithBucket(_storageConnector_Data.ObjectBucket)
                                                                    .WithObject(objectName)
                                                                    .WithStreamData(new MemoryStream(byteArray))
                                                                    .WithObjectSize(byteArray.Length)
                                                                    //.WithContentType("image/" + image.Bitmap.RawFormat.ToString().ToLower());
                                                                    .WithContentType("image/Jpeg");

                _storageConnector_Data.MinioClient.PutObjectAsync(putObjectArgs).Wait();

                try
                {
                    StatObjectArgs statObjectArgs = new StatObjectArgs().WithBucket(_storageConnector_Data.ObjectBucket)
                                                                        .WithObject(objectName);

                    _storageConnector_Data.MinioClient.StatObjectAsync(statObjectArgs).Wait();

                    _unsavedWorkflowItems.Last().Finished = DateTime.UtcNow;

                    #region Create image on database
                    if (_image_Data.DatabaseEntity == null)
                    {
                        _image_Data.DatabaseEntity = new DbStorage_File()
                        {
                            Id = _image_Data.FileId,
                            Suffix = string.Empty,

                            RawFileIds = _image_Data.FileRawIds,

                            Name = "Image",
                            Description = string.Empty,

                            ObjectExtension = FileExtension.JPEG,
                            ObjectSize = byteArray.Length,

                            SubDirectory = _subDirectory_StorageData,
                            RootDirectory = null,

                            AuthorizationUser = null,
                            AuthorizationUserGroup = null,

                            NotificationUser = null,
                            NotificationUserGroup = null,

                            StorageObjectName = objectName,
                            StorageObjectUrlPublic = string.Empty,

                            FileParameter = null,

                            QrCode = _qrCode,

                            DeviceIdExt = Guid.Empty,
                            MachineIdExt = Guid.Empty,
                            JobsIdExt = null,
                            WorkflowItemsExt = _unsavedWorkflowItems,
                            BackupsExt = null,

                            LastModificationChanges = string.Empty,

                            // FK 
                        };
                        _image_Data.DatabaseEntity.SetImageMetadata(_image_Data);
                        _dbStorage_Data_Context.Files.Add(_image_Data.DatabaseEntity);
                    }
                    else
                    {
                        _image_Data.DatabaseEntity.RawFileIds = new List<Guid>() { _image_Data.DatabaseEntity.Id };

                        _image_Data.DatabaseEntity.Name = "Image";
                        _image_Data.DatabaseEntity.Description = string.Empty;

                        _image_Data.DatabaseEntity.ObjectExtension = FileExtension.JPEG;
                        _image_Data.DatabaseEntity.ObjectSize = byteArray.Length;

                        _image_Data.DatabaseEntity.StorageObjectName = objectName;
                        _image_Data.DatabaseEntity.StorageObjectUrlPublic = string.Empty;

                        _image_Data.DatabaseEntity.QrCode = _qrCode;

                        _image_Data.DatabaseEntity.WorkflowItemsExt = _unsavedWorkflowItems;

                        _image_Data.DatabaseEntity.SetImageMetadata(_image_Data);
                        _dbStorage_Data_Context.Files.Update(_image_Data.DatabaseEntity);
                    }
                    #endregion

                    _dbStorage_Data_Context.SaveChanges();
                }
                catch (Minio.Exceptions.MinioException ex)
                {
                    Log.Error("Object upload error: " + ex.Message);
                };
            }
            catch (Exception ex)
            {

            }
        }
    }
}
