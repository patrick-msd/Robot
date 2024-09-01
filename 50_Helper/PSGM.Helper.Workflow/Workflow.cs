using Microsoft.EntityFrameworkCore;
using Minio;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using PSGM.Model.DbMain;
using PSGM.Model.DbStorage;
using PSGM.Model.DbWorkflow;
using Serilog;
using System.Diagnostics;
using System.Drawing;

namespace PSGM.Helper.Workflow
{
    public partial class Workflow
    {
        #region Database
        private DbMain_Context _dbMain_Context;
        private DbWorkflow_Context _dbWorkflow_Context;
        private DbStorage_Context _dbStorage_Data_Context;
        private DbStorage_Context _dbStorage_DataRaw_Context;
        #endregion

        #region Global variables
        private Guid _workfowId;

        private Guid _userId;
        private Guid _machineId;
        private Guid _softwareId;

        private DbMain_Project _dbMain_Project;

        private DbStorage_SubDirectory _subDirectory_StorageData;
        private DbStorage_SubDirectory _subDirectory_StorageDataRaw;

        private List<WorkflowItemLog> _unsavedWorkflowItems;

        private string _workingPath;

        private StorageConnector _storageConnector_DataMain;

        private StorageConnector _storageConnector_DataRaw;
        private List<ImageHelperMat_Workflow> _images_DataRaw;
        public List<ImageHelperMat_Workflow> Images_DataRaw { get { return _images_DataRaw; } }

        private StorageConnector _storageConnector_DataRawThumbnail;

        private StorageConnector _storageConnectors_DataRawThumbnail;
        private List<ImageHelperMat_Workflow> _image_DataRawThumbnail;

        private StorageConnector _storageConnector_Data;
        private StorageConnector _storageConnectors_DataThumbnail;
        private ImageHelperMat_Workflow _image_Data;
        public ImageHelperMat_Workflow Image_Data { get { return _image_Data; } }
        private ExifDataRaw _exifDataRaw_Data;
        private string _image_Data_ExifImageDescription;

        private DbStorage_QrCode? _qrCode;
        #endregion

        public Workflow(Guid workflowId, Guid userId, Guid machineId, Guid softwareId, string databaseMainConnectionstring, DatabaseType databaseMainDatabaseType, Guid projectId, string databaseWorkflowConnectionstring, DatabaseType databaseWorkflowDatabaseType)
        {
            _workfowId = workflowId;

            _userId = userId;
            _machineId = machineId;
            _softwareId = softwareId;

            _unsavedWorkflowItems = new List<WorkflowItemLog>();

            _dbMain_Context = new DbMain_Context();
            _dbMain_Context.ConnectionStringSQLite = databaseMainConnectionstring;
            _dbMain_Context.DatabaseType = databaseMainDatabaseType;
            _dbMain_Context.Database.OpenConnection();

            _dbMain_Project = _dbMain_Context.Projects.Where(p => p.Id == projectId)
                                                        .Include(p => p.ProjectParameter)
                                                            .ThenInclude(p => p.Storages)
                                                        .Include(p => p.Organization)
                                                        .Include(p => p.Contributors)
                                                        //.Include(p => p.Locations)
                                                        .FirstOrDefault();

            _dbWorkflow_Context = new DbWorkflow_Context();
            _dbWorkflow_Context.ConnectionStringSQLite = databaseWorkflowConnectionstring;
            _dbWorkflow_Context.DatabaseType = databaseWorkflowDatabaseType;
            _dbWorkflow_Context.Database.OpenConnection();

            _dbStorage_Data_Context = new DbStorage_Context();
            _dbStorage_DataRaw_Context = new DbStorage_Context();

            _dbStorage_Data_Context.ConnectionStringSQLite = _dbMain_Project.ProjectParameter.Storages.Where(p => p.StorageClass == StorageClass.Data).FirstOrDefault().DatabaseFilePath;
            _dbStorage_DataRaw_Context.ConnectionStringSQLite = _dbMain_Project.ProjectParameter.Storages.Where(p => p.StorageClass == StorageClass.DataRaw).FirstOrDefault().DatabaseFilePath;

            _dbStorage_Data_Context.DatabaseType = _dbMain_Project.ProjectParameter.Storages.Where(p => p.StorageClass == StorageClass.Data).FirstOrDefault().DatabaseType;
            _dbStorage_DataRaw_Context.DatabaseType = _dbMain_Project.ProjectParameter.Storages.Where(p => p.StorageClass == StorageClass.DataRaw).FirstOrDefault().DatabaseType;

            _dbStorage_Data_Context.Database.OpenConnection();
            _dbStorage_DataRaw_Context.Database.OpenConnection();

            _exifDataRaw_Data = CreateExifDataRaw();

            foreach (DbMain_ProjectParameterStorage storage in _dbMain_Project.ProjectParameter.Storages)
            {
                if (storage.StorageClass == StorageClass.DataMain)
                {
                    _storageConnector_DataMain = new StorageConnector()
                    {
                        StorageClass = storage.StorageClass,

                        FilePath = string.Empty,

                        ObjectBucket = _dbMain_Project.Id.ToString(),

                        MinioClient = new MinioClient().WithEndpoint(storage.StorageS3Endpoint)
                                                        .WithCredentials(storage.StorageS3AccessKey, storage.StorageS3SecretKey)
                                                        .WithRegion(storage.StorageS3Region)
                                                        .WithSSL(storage.StorageS3Secure)
                                                        .Build(),
                    };
                }

                else if (storage.StorageClass == StorageClass.DataRaw)
                {
                    _storageConnector_DataRaw = new StorageConnector()
                    {
                        StorageClass = storage.StorageClass,

                        FilePath = string.Empty,

                        ObjectBucket = _dbMain_Project.Id.ToString(),

                        MinioClient = new MinioClient().WithEndpoint(storage.StorageS3Endpoint)
                                                        .WithCredentials(storage.StorageS3AccessKey, storage.StorageS3SecretKey)
                                                        .WithRegion(storage.StorageS3Region)
                                                        .WithSSL(storage.StorageS3Secure)
                                                        .Build(),
                    };
                }

                else if (storage.StorageClass == StorageClass.DataRawThumbnail)
                {
                    _storageConnector_DataRawThumbnail = new StorageConnector()
                    {
                        StorageClass = storage.StorageClass,

                        FilePath = string.Empty,

                        ObjectBucket = _dbMain_Project.Id.ToString(),

                        MinioClient = new MinioClient().WithEndpoint(storage.StorageS3Endpoint)
                                                        .WithCredentials(storage.StorageS3AccessKey, storage.StorageS3SecretKey)
                                                        .WithRegion(storage.StorageS3Region)
                                                        .WithSSL(storage.StorageS3Secure)
                                                        .Build(),
                    };
                }

                else if (storage.StorageClass == StorageClass.Data)
                {
                    _storageConnector_Data = new StorageConnector()
                    {
                        StorageClass = storage.StorageClass,

                        FilePath = string.Empty,

                        ObjectBucket = _dbMain_Project.Id.ToString(),

                        MinioClient = new MinioClient().WithEndpoint(storage.StorageS3Endpoint)
                                                        .WithCredentials(storage.StorageS3AccessKey, storage.StorageS3SecretKey)
                                                        .WithRegion(storage.StorageS3Region)
                                                        .WithSSL(storage.StorageS3Secure)
                                                        .Build(),
                    };
                }

                else if (storage.StorageClass == StorageClass.DataThumbnail)
                {
                    _storageConnectors_DataThumbnail = new StorageConnector()
                    {
                        StorageClass = storage.StorageClass,

                        FilePath = string.Empty,

                        ObjectBucket = _dbMain_Project.Id.ToString(),

                        MinioClient = new MinioClient().WithEndpoint(storage.StorageS3Endpoint)
                                                        .WithCredentials(storage.StorageS3AccessKey, storage.StorageS3SecretKey)
                                                        .WithRegion(storage.StorageS3Region)
                                                        .WithSSL(storage.StorageS3Secure)
                                                        .Build(),
                    };
                }

                else
                {
                    throw new Exception("Storage class not supported");
                }
            }
        }

        public void RunWithImageGrabbing(string workingPath, Guid subdirectory, string exifImageDescription)
        {
#if DEBUG
            Stopwatch swProcessingTime = new Stopwatch();
            swProcessingTime.Start();
#endif

            // ToDo:  ...

#if DEBUG
            Log.Debug($"Whole workflow (Run without Captured Images) processing time: {swProcessingTime.ElapsedMilliseconds}ms ...");
            swProcessingTime.Stop();
#endif
        }

        public void RunWithCapturedImages(List<ImageHelper> imagesDataRaw, List<Bitmap> imagesDataRawBitmap, string workingPath, Guid subdirectory, string exifImageDescription, DbStorage_QrCode? qrCode)
        {
#if DEBUG
            Stopwatch swProcessingTime = new Stopwatch();
            swProcessingTime.Start();
#endif

            _images_DataRaw = new List<ImageHelperMat_Workflow>();

            _image_Data = new ImageHelperMat_Workflow();

            _subDirectory_StorageData = _dbStorage_Data_Context.SubDirectories.Where(p => p.Id == subdirectory).FirstOrDefault();
            _subDirectory_StorageDataRaw = _dbStorage_DataRaw_Context.SubDirectories.Where(p => p.Id == subdirectory).FirstOrDefault();

            _image_Data_ExifImageDescription = exifImageDescription;

            _qrCode = qrCode;

            _workingPath = $"{workingPath}/{Guid.NewGuid().ToString()}";
            Directory.CreateDirectory(_workingPath);

            if (imagesDataRaw.Count != imagesDataRawBitmap.Count)
            {
                throw new Exception("Count of imagesDataRaw and imagesDataRawBitmap must be equal");
            }
            else
            {
                for (int i = 0; i < imagesDataRaw.Count; i++)
                {
                    _images_DataRaw.Add(new ImageHelperMat_Workflow()
                    {
                        FileId = imagesDataRaw[i].FileId,
                        FileRawIds = imagesDataRaw[i].FileRawIds,

                        Image = BitmapConverter.ToMat(imagesDataRawBitmap[i]).CvtColor(ColorConversionCodes.RGBA2RGB),
                        ExposureTime = imagesDataRaw[i].ExposureTime,
                        DateDigitized = imagesDataRaw[i].DateDigitized,

                        CameraDeviceId = imagesDataRaw[i].CameraDeviceId
                    });
                }
            }

            if (_workfowId != null)
            {
                // Load workflow from database
                List<DbWorkflow_WorkflowItemLink> workflowItemLinks = Database_LoadData_V1_0_0(_workfowId);

                // Run Workflow
                foreach (DbWorkflow_WorkflowItemLink workflowItemLink in workflowItemLinks)
                {
                    // No image grabbing for this workflow
                    if (!string.Equals(workflowItemLink.WorkflowItemId.ToString(), Guid.Parse("F03093F8-6EA8-4BEE-9875-30D1FC7975F3").ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        RunWorkflowItem(workflowItemLink);
                    }
                    else
                    {
                        Log.Information("Image was allready grabbed!!!");
                    }
                }
            }

            // Delete working directory and all files in that directory
            try
            {
                Directory.Delete(_workingPath, true);
            }
            catch (Exception ex)
            {
                ;
            }

#if DEBUG
            Log.Debug($"Whole workflow (Run with Captured Images) processing time: {swProcessingTime.ElapsedMilliseconds}ms ...");
            swProcessingTime.Stop();
#endif
        }

        public void RunWorkflowItem(DbWorkflow_WorkflowItemLink workflowItemLink)
        {
#if DEBUG
            Stopwatch swProcessingTime = new Stopwatch();
            swProcessingTime.Start();
#endif

            Log.Information($"Run workflow item \"{workflowItemLink.WorkflowItem.Id}\" - \"{workflowItemLink.WorkflowItem.Name}\" ...");

            // Add workflow item to list of unsaved workflow items               
            _unsavedWorkflowItems.Add(new WorkflowItemLog()
            {
                WorkflowItemId = workflowItemLink.WorkflowItem.Id,

                Started = DateTime.UtcNow
            });

            switch (workflowItemLink.WorkflowItem.Id)
            {
                #region Storage
                #endregion

                #region Database
                #endregion

                #region Storage & Database
                case Guid guid when guid == Workflow_DbMain_RootDirectories.StorageAndDatabase_Save_V1_0_0:
                    StorageAndDatabase_Save_V1_0_0(workflowItemLink);

                    // Reset the list of unsaved workflow items
                    _unsavedWorkflowItems = new List<WorkflowItemLog>();
                    break;
                #endregion

                #region Vison2D
                case Guid guid when guid == Workflow_DbMain_RootDirectories.Vision2D_GrabImage_V1_0_0:
                    Vision2D_GrabImage_V1_0_0();
                    break;
                #endregion

                #region Images
                case Guid guid when guid == Workflow_DbMain_RootDirectories.Image_Resize_V1_0_0:
                    Image_Resize_V1_0_0(workflowItemLink);
                    break;

                case Guid guid when guid == Workflow_DbMain_RootDirectories.Image_HDR_V1_0_0:
                    Image_HDR_V1_0_0();
                    break;

                case Guid guid when guid == Workflow_DbMain_RootDirectories.Image_Darktable_V1_0_0:
                    Image_Darktable_V1_0_0(workflowItemLink);
                    break;

                case Guid guid when guid == Workflow_DbMain_RootDirectories.Image_Crop_V1_0_0:
                    Image_Crop_V1_0_0(workflowItemLink);
                    break;

                case Guid guid when guid == Workflow_DbMain_RootDirectories.Image_Rotate_V1_0_0:
                    Image_Rotate_V1_0_0(workflowItemLink);
                    break;

                case Guid guid when guid == Workflow_DbMain_RootDirectories.Image_Rotate_V2_0_0:
                    Image_Rotate_V2_0_0(workflowItemLink);
                    break;

                case Guid guid when guid == Workflow_DbMain_RootDirectories.Image_Sharpen_V1_0_0:
                    Image_Sharpen_V1_0_0(workflowItemLink);
                    break;

                case Guid guid when guid == Workflow_DbMain_RootDirectories.Image_Sharpen_V2_0_0:
                    Image_Sharpen_V2_0_0(workflowItemLink);
                    break;
                #endregion

                default:
                    break;
            }

            if (_unsavedWorkflowItems.Count > 0)
            {
                _unsavedWorkflowItems.Last().Finished = DateTime.UtcNow;
            }

#if DEBUG
            Log.Debug($"Finished workflow item \"{workflowItemLink.WorkflowItem.Id}\" - \"{workflowItemLink.WorkflowItem.Name}\" with processing time: {swProcessingTime.ElapsedMilliseconds}ms ...");
            swProcessingTime.Stop();
#endif
        }
    }
}
