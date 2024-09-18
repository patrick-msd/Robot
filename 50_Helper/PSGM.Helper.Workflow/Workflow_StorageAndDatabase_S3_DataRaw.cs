using Minio.DataModel.Args;
using PSGM.Model.DbStorage;
using PSGM.Model.DbWorkflow;
using Serilog;

namespace PSGM.Helper.Workflow
{
    public partial class Workflow
    {
        public void Storage_S3AndDatabase_Save_DataRaw_V1_0_0(DbWorkflow_WorkflowItemLink workflowItemLink)
        {
            ConfigurationSaveImageV1_0_0 configuration = workflowItemLink.GetSaveImageV1_0_0Configuration();

            #region Create folder for imageset on database DataRaw
            DbStorage_SubDirectory dbStorage_subDirectory = new DbStorage_SubDirectory()
            {
                Id = Guid.NewGuid(),
                Suffix = string.Empty,

                Name = string.Empty,
                Description = string.Empty,

                Objects = 0,
                DirectorySize = 0,

                SubDirectories = null,
                Files = null,

                AuthorizationUser = null,
                AuthorizationUserGroup = null,

                NotificationUser = null,
                NotificationUserGroup = null,

                Orders = null,
                OrderTemplate = null,

                SubDirectoryParameter = null,

                JobsIdExt = null,
                WorkflowItemsExt = null,
                BackupsExt = null,

                LastModificationChanges = string.Empty,

                // FK 
                //RootDirectory = storage.First(),
                ParentSubDirectory = _subDirectory_StorageDataRaw,
            };
            _dbStorage_DataRaw_Context.SubDirectories.Add(dbStorage_subDirectory);
            _dbStorage_DataRaw_Context.SaveChanges();
            #endregion

            #region Get complete sub dirctory path
            string subdirectory = dbStorage_subDirectory.Id.ToString();
            DbStorage_SubDirectory subdirectoryWhile = dbStorage_subDirectory;

            while (subdirectoryWhile.ParentSubDirectory != null)
            {
                subdirectory = subdirectoryWhile.ParentSubDirectoryId.ToString() + "/" + subdirectory;

                subdirectoryWhile = _dbStorage_DataRaw_Context.SubDirectories.Where(p => p.Id == subdirectoryWhile.ParentSubDirectoryId).FirstOrDefault();
            }
            #endregion

            foreach (ImageHelperMat_Workflow image in _images_DataRaw)
            {
                byte[] byteArray = image.Image.ToBytes(".Bmp");

                string objectName = subdirectory + "/" + image.FileId + ".Bmp";

                PutObjectArgs putObjectArgs = new PutObjectArgs().WithBucket(_storageConnector_DataRaw.ObjectBucket)
                                                                    .WithObject(objectName)
                                                                    .WithStreamData(new MemoryStream(byteArray))
                                                                    .WithObjectSize(byteArray.Length)
                                                                    //.WithContentType("image/" + image.Bitmap.RawFormat.ToString().ToLower());
                                                                    .WithContentType("image/bmp");

                _storageConnector_DataRaw.MinioClient.PutObjectAsync(putObjectArgs).Wait();

                try
                {
                    StatObjectArgs statObjectArgs = new StatObjectArgs().WithBucket(_storageConnector_DataRaw.ObjectBucket)
                                                                        .WithObject(objectName);

                    _storageConnector_DataRaw.MinioClient.StatObjectAsync(statObjectArgs).Wait();

                    _unsavedWorkflowItems.Last().Finished = DateTime.UtcNow;

                    #region Create image on database
                    DbStorage_File fileDb = new DbStorage_File()
                    {
                        Id = image.FileId,
                        Suffix = string.Empty,

                        RawFileIds = null,

                        Name = "Image",
                        Description = string.Empty,

                        ObjectExtension = FileExtension.BMP,
                        ObjectSize = byteArray.Length,

                        SubDirectory = dbStorage_subDirectory,
                        RootDirectory = null,

                        AuthorizationUsers = null,
                        AuthorizationUserGroups = null,

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
                    fileDb.SetImageMetadata(image);
                    _dbStorage_DataRaw_Context.Files.Add(fileDb);
                    #endregion
                }
                catch (Minio.Exceptions.MinioException ex)
                {
                    Log.Error("Object upload error: " + ex.Message);
                }
            }

            _dbStorage_DataRaw_Context.SaveChanges();
        }
    }
}
