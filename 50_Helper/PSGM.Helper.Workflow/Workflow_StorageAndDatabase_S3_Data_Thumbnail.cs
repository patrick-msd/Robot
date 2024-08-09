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
        public void Storage_S3AndDatabase_Save_DataThumbnail_V1_0_0(DbWorkflow_WorkflowItemLink workflowItemLink)
        {
            ConfigurationSaveImageV1_0_0 configuration = workflowItemLink.GetSaveImageV1_0_0Configuration();

            // Folder for imageset is not required for thumbnail, due to that it should only be one image or the suffix is used 

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
                #region Create image with metadata and thumbnail
                ExifData exifData;
                MemoryStream imageStreamSource;
                MemoryStream imageStreamDestination = new MemoryStream();

                byte[] byteArraySource = _image_Data.Thumbnail.ToBytes(".Jpeg", new ImageEncodingParam(ImwriteFlags.JpegQuality, configuration.ThumbnailQuality));
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
                    Mat tmp = Vision2D.ResizeImage(_image_Data.Thumbnail, 128, 0);

                    byte[] thumbnailByteArray = tmp.ToBytes(".Jpeg", new ImageEncodingParam(ImwriteFlags.JpegQuality, 90));
                    exifData.SetThumbnailImage(thumbnailByteArray, 0, thumbnailByteArray.Count());
                }

                imageStreamSource.Position = 0;
                imageStreamDestination.Position = 0;

                exifData.Save(imageStreamSource, imageStreamDestination);

                Vision2D.SaveBitmapAsJpeg(new Bitmap(imageStreamDestination), $"{_workingPath}/../{_image_Data.FileId}_Metadata.jpeg", 100L);

                byte[] byteArray = imageStreamDestination.ToArray();

                imageStreamSource.Close();
                imageStreamDestination.Close();
                #endregion

                string objectName = subdirectory + "/" + _image_Data.FileId + ".Jpeg";

                PutObjectArgs putObjectArgs = new PutObjectArgs().WithBucket(_storageConnectors_DataThumbnail.ObjectBucket)
                                                                    .WithObject(objectName)
                                                                    .WithStreamData(new MemoryStream(byteArray))
                                                                    .WithObjectSize(byteArray.Length)
                                                                    //.WithContentType("image/" + image.Bitmap.RawFormat.ToString().ToLower());
                                                                    .WithContentType("image/Jpeg");

                _storageConnectors_DataThumbnail.MinioClient.PutObjectAsync(putObjectArgs).Wait();

                try
                {
                    StatObjectArgs statObjectArgs = new StatObjectArgs().WithBucket(_storageConnectors_DataThumbnail.ObjectBucket)
                                                                        .WithObject(objectName);

                    _storageConnectors_DataThumbnail.MinioClient.StatObjectAsync(statObjectArgs).Wait();

                    // No database entry is required for thumbnails, due to the fact that the thumbnails are linked to the original image
                }
                catch (Minio.Exceptions.MinioException ex)
                {
                    Log.Error("Object upload error: " + ex.Message);
                }
            }
            catch (Minio.Exceptions.MinioException ex)
            {
                Log.Error("Object upload error: " + ex.Message);
            }
        }
    }
}
