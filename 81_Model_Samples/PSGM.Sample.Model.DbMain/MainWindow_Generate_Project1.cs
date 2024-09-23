using PSGM.Helper;
using PSGM.Model.DbMain;

namespace PSGM.Sample.Model.DbStorage
{
    public partial class MainWindow : System.Windows.Window
    {
        public List<DbMain_Project> Generate_Project1(List<DbMain_Location> locations, List<DbMain_Organization> organizations)
        {
            Random random = new Random();

            Array values1 = Enum.GetValues(typeof(NotificationType));

            #region WorkflowItemLinks
            #region Raw images
            DbMain_WorkflowItem_Link dbWorkflowItemLink_Vision2D_GrabImage_DataRaw = new DbMain_WorkflowItem_Link()
            {
                Id = Guid.NewGuid(),

                Order = 1,
                ApplyLevel = WorkflowApplyLevel.Organization,

                StorageType = StorageType.S3,
                StorageClass = StorageClass.DataRaw,

                Permissions = EmployeeType.None,
                WorkflowExecutionLevel = WorkflowExecutionLevel.Automatically,

                Configuration = string.Empty,

                // FK
                //WorkflowItem = null,
                WorkflowItemId = Workflow_DbMain_RootDirectories.Vision2D_GrabImage_V1_0_0,

                WorkflowGroup = null,
                WorkflowGroupId = null
            };

            DbMain_WorkflowItem_Link dbWorkflowItemLink_Vision2D_SaveObjectToStorageAndDatabase_DataRaw = new DbMain_WorkflowItem_Link()
            {
                Id = Guid.NewGuid(),

                Order = 4,
                ApplyLevel = WorkflowApplyLevel.Organization,

                StorageType = StorageType.S3,
                StorageClass = StorageClass.DataRaw,
                //StorageClass = StorageClass.DataRawAndDataRawThumbnail, 

                Permissions = EmployeeType.None,
                WorkflowExecutionLevel = WorkflowExecutionLevel.Automatically,

                Configuration = string.Empty,

                // FK
                //WorkflowItem = null,
                WorkflowItemId = Workflow_DbMain_RootDirectories.StorageAndDatabase_Save_V1_0_0,

                WorkflowGroup = null,
                WorkflowGroupId = null
            };
            dbWorkflowItemLink_Vision2D_SaveObjectToStorageAndDatabase_DataRaw.SetSaveImageV1_0_0Configuration(new ConfigurationSaveImageV1_0_0() { Quality = 100, ThumbnailWidth = 512, ThumbnailHeight = 0, ThumbnailQuality = 90 });
            #endregion

            #region HDR Image
            DbMain_WorkflowItem_Link dbWorkflowItemLink_HDR_CreateImage_Data = new DbMain_WorkflowItem_Link()
            {
                Id = Guid.NewGuid(),

                Order = 5,
                ApplyLevel = WorkflowApplyLevel.Organization,

                StorageType = StorageType.S3,
                StorageClass = StorageClass.Data,

                Permissions = EmployeeType.None,
                WorkflowExecutionLevel = WorkflowExecutionLevel.Automatically,

                Configuration = string.Empty,

                // FK
                //WorkflowItem = null,
                WorkflowItemId = Workflow_DbMain_RootDirectories.Image_HDR_V1_0_0,

                WorkflowGroup = null,
                WorkflowGroupId = null
            };

            DbMain_WorkflowItem_Link dbWorkflowItemLink_HDR_SaveObjectToStorageAndDatabase_Data_DataThumbnail = new DbMain_WorkflowItem_Link()
            {
                Id = Guid.NewGuid(),

                Order = 8,
                ApplyLevel = WorkflowApplyLevel.Organization,

                StorageType = StorageType.S3,
                StorageClass = StorageClass.DataAndDataThumbnail,

                Permissions = EmployeeType.None,
                WorkflowExecutionLevel = WorkflowExecutionLevel.Automatically,

                Configuration = string.Empty,

                // FK
                //WorkflowItem = null,
                WorkflowItemId = Workflow_DbMain_RootDirectories.StorageAndDatabase_Save_V1_0_0,

                WorkflowGroup = null,
                WorkflowGroupId = null
            };
            dbWorkflowItemLink_HDR_SaveObjectToStorageAndDatabase_Data_DataThumbnail.SetSaveImageV1_0_0Configuration(new ConfigurationSaveImageV1_0_0() { Quality = 100, ThumbnailWidth = 512, ThumbnailHeight = 0, ThumbnailQuality = 90 });
            #endregion

            #region Darktable Image
            DbMain_WorkflowItem_Link dbWorkflowItemLink_Darktable_CreateImage_Data = new DbMain_WorkflowItem_Link()
            {
                Id = Guid.NewGuid(),

                Order = 9,
                ApplyLevel = WorkflowApplyLevel.Organization,

                StorageType = StorageType.S3,
                StorageClass = StorageClass.Data,

                Permissions = EmployeeType.None,
                WorkflowExecutionLevel = WorkflowExecutionLevel.Automatically,

                Configuration = string.Empty,

                // FK
                //WorkflowItem = null,
                WorkflowItemId = Workflow_DbMain_RootDirectories.Image_Darktable_V1_0_0,

                WorkflowGroup = null,
                WorkflowGroupId = null
            };
            //dbWorkflowItemLink_Darktable_CreateImage_Data.SetDarktableV1_0_0Configuration(new List<ConfigurationDarktableV1_0_0>()
            //{
            //    new ConfigurationDarktableV1_0_0()
            //    {
            //        CameraId = _dbMachineContext.Devices.Where(d => d.DeviceName == "Vision 2D Right").FirstOrDefault().Id,
            //        DarktableExecutePath = "C:/Program Files/darktable/bin/darktable-cli.exe",
            //        DarktableExecuteArgumetns = "\"INPUT_FILE_PATH\" \"SIDECAR_FILE_PATH\" \"Output_FILE_PATH\" --verbose --out-ext jpg",
            //        DarktableSidecarFile = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n<x:xmpmeta xmlns:x=\"adobe:ns:meta/\" x:xmptk=\"XMP Core 4.4.0-Exiv2\">\r\n <rdf:RDF xmlns:rdf=\"http://www.w3.org/1999/02/22-rdf-syntax-ns#\">\r\n  <rdf:Description rdf:about=\"\"\r\n    xmlns:exif=\"http://ns.adobe.com/exif/1.0/\"\r\n    xmlns:xmp=\"http://ns.adobe.com/xap/1.0/\"\r\n    xmlns:xmpMM=\"http://ns.adobe.com/xap/1.0/mm/\"\r\n    xmlns:darktable=\"http://darktable.sf.net/\"\r\n   exif:DateTimeOriginal=\"2024:04:12 10:50:30.000\"\r\n   xmp:Rating=\"1\"\r\n   xmpMM:DerivedFrom=\"fusion_mertens_8.jpg\"\r\n   darktable:import_timestamp=\"63848515846079968\"\r\n   darktable:change_timestamp=\"63848515852593962\"\r\n   darktable:export_timestamp=\"-1\"\r\n   darktable:print_timestamp=\"-1\"\r\n   darktable:xmp_version=\"5\"\r\n   darktable:raw_params=\"0\"\r\n   darktable:auto_presets_applied=\"1\"\r\n   darktable:history_end=\"7\"\r\n   darktable:iop_order_version=\"3\"\r\n   darktable:history_basic_hash=\"8921fe8edb66aeacff411f85c52c8f4a\"\r\n   darktable:history_current_hash=\"5746e8e023517a2df85554f13a0cb807\">\r\n   <darktable:masks_history>\r\n    <rdf:Seq/>\r\n   </darktable:masks_history>\r\n   <darktable:history>\r\n    <rdf:Seq>\r\n     <rdf:li\r\n      darktable:num=\"0\"\r\n      darktable:operation=\"gamma\"\r\n      darktable:enabled=\"1\"\r\n      darktable:modversion=\"1\"\r\n      darktable:params=\"0000000000000000\"\r\n      darktable:multi_name=\"\"\r\n      darktable:multi_name_hand_edited=\"0\"\r\n      darktable:multi_priority=\"0\"\r\n      darktable:blendop_version=\"13\"\r\n      darktable:blendop_params=\"gz11eJxjYIAACQYYOOHEgAZY0QWAgBGLGANDgz0Ej1Q+dcF/IADRAGpyHQU=\"/>\r\n     <rdf:li\r\n      darktable:num=\"1\"\r\n      darktable:operation=\"flip\"\r\n      darktable:enabled=\"1\"\r\n      darktable:modversion=\"2\"\r\n      darktable:params=\"ffffffff\"\r\n      darktable:multi_name=\"auto\"\r\n      darktable:multi_name_hand_edited=\"0\"\r\n      darktable:multi_priority=\"0\"\r\n      darktable:blendop_version=\"13\"\r\n      darktable:blendop_params=\"gz11eJxjYIAACQYYOOHEgAZY0QWAgBGLGANDgz0Ej1Q+dcF/IADRAGpyHQU=\"/>\r\n     <rdf:li\r\n      darktable:num=\"2\"\r\n      darktable:operation=\"colorin\"\r\n      darktable:enabled=\"1\"\r\n      darktable:modversion=\"7\"\r\n      darktable:params=\"gz48eJxjZBgFowABWAbaAaNgwAEAEDgABg==\"\r\n      darktable:multi_name=\"\"\r\n      darktable:multi_name_hand_edited=\"0\"\r\n      darktable:multi_priority=\"0\"\r\n      darktable:blendop_version=\"13\"\r\n      darktable:blendop_params=\"gz11eJxjYIAACQYYOOHEgAZY0QWAgBGLGANDgz0Ej1Q+dcF/IADRAGpyHQU=\"/>\r\n     <rdf:li\r\n      darktable:num=\"3\"\r\n      darktable:operation=\"colorout\"\r\n      darktable:enabled=\"1\"\r\n      darktable:modversion=\"5\"\r\n      darktable:params=\"gz35eJxjZBgFo4CBAQAEEAAC\"\r\n      darktable:multi_name=\"\"\r\n      darktable:multi_name_hand_edited=\"0\"\r\n      darktable:multi_priority=\"0\"\r\n      darktable:blendop_version=\"13\"\r\n      darktable:blendop_params=\"gz11eJxjYIAACQYYOOHEgAZY0QWAgBGLGANDgz0Ej1Q+dcF/IADRAGpyHQU=\"/>\r\n     <rdf:li\r\n      darktable:num=\"4\"\r\n      darktable:operation=\"ashift\"\r\n      darktable:enabled=\"1\"\r\n      darktable:modversion=\"5\"\r\n      darktable:params=\"gz18eJz7/3/zIQYU8MCRgaHBnoHhhBOEZmBghMqUr6mzt+iLtvr5v96eYRSMglFAEQAA/z4NDw==\"\r\n      darktable:multi_name=\"\"\r\n      darktable:multi_name_hand_edited=\"0\"\r\n      darktable:multi_priority=\"0\"\r\n      darktable:blendop_version=\"13\"\r\n      darktable:blendop_params=\"gz11eJxjYIAACQYYOOHEgAZY0QWAgBGLGANDgz0Ej1Q+dcF/IADRAGpyHQU=\"/>\r\n     <rdf:li\r\n      darktable:num=\"5\"\r\n      darktable:operation=\"crop\"\r\n      darktable:enabled=\"1\"\r\n      darktable:modversion=\"1\"\r\n      darktable:params=\"ead17a3d5832ee3d2b4f743f3c2c693f0000000000000000\"\r\n      darktable:multi_name=\"\"\r\n      darktable:multi_name_hand_edited=\"0\"\r\n      darktable:multi_priority=\"0\"\r\n      darktable:blendop_version=\"13\"\r\n      darktable:blendop_params=\"gz11eJxjYIAACQYYOOHEgAZY0QWAgBGLGANDgz0Ej1Q+dcF/IADRAGpyHQU=\"/>\r\n     <rdf:li\r\n      darktable:num=\"6\"\r\n      darktable:operation=\"sharpen\"\r\n      darktable:enabled=\"1\"\r\n      darktable:modversion=\"1\"\r\n      darktable:params=\"feffff3ffeffdf3f00000000\"\r\n      darktable:multi_name=\"\"\r\n      darktable:multi_name_hand_edited=\"0\"\r\n      darktable:multi_priority=\"0\"\r\n      darktable:blendop_version=\"13\"\r\n      darktable:blendop_params=\"gz10eJxjYGBgYAJiCQYYOOHEgAZY0QWAgBGLGANDgz0Ej1Q+dcF/IADRAG2yHQc=\"/>\r\n    </rdf:Seq>\r\n   </darktable:history>\r\n  </rdf:Description>\r\n </rdf:RDF>\r\n</x:xmpmeta>\r\n"
            //    },
            //    new ConfigurationDarktableV1_0_0()
            //    {
            //        CameraId = _dbMachineContext.Devices.Where(d => d.DeviceName == "Vision 2D Left").FirstOrDefault().Id,
            //        DarktableExecutePath = "C:/Program Files/darktable/bin/darktable-cli.exe",
            //        DarktableExecuteArgumetns = "\"INPUT_FILE_PATH\" \"SIDECAR_FILE_PATH\" \"Output_FILE_PATH\" --verbose --out-ext jpg",
            //        DarktableSidecarFile = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n<x:xmpmeta xmlns:x=\"adobe:ns:meta/\" x:xmptk=\"XMP Core 4.4.0-Exiv2\">\r\n <rdf:RDF xmlns:rdf=\"http://www.w3.org/1999/02/22-rdf-syntax-ns#\">\r\n  <rdf:Description rdf:about=\"\"\r\n    xmlns:exif=\"http://ns.adobe.com/exif/1.0/\"\r\n    xmlns:xmp=\"http://ns.adobe.com/xap/1.0/\"\r\n    xmlns:xmpMM=\"http://ns.adobe.com/xap/1.0/mm/\"\r\n    xmlns:darktable=\"http://darktable.sf.net/\"\r\n   exif:DateTimeOriginal=\"2024:04:12 11:03:19.000\"\r\n   xmp:Rating=\"1\"\r\n   xmpMM:DerivedFrom=\"fusion_mertens_9.jpg\"\r\n   darktable:import_timestamp=\"63848516613724363\"\r\n   darktable:change_timestamp=\"63848517214557125\"\r\n   darktable:export_timestamp=\"-1\"\r\n   darktable:print_timestamp=\"-1\"\r\n   darktable:xmp_version=\"5\"\r\n   darktable:raw_params=\"0\"\r\n   darktable:auto_presets_applied=\"1\"\r\n   darktable:history_end=\"7\"\r\n   darktable:iop_order_version=\"3\"\r\n   darktable:history_basic_hash=\"8921fe8edb66aeacff411f85c52c8f4a\"\r\n   darktable:history_current_hash=\"a4fc649dce00b7dd6023ea8e10ae64ba\">\r\n   <darktable:masks_history>\r\n    <rdf:Seq/>\r\n   </darktable:masks_history>\r\n   <darktable:history>\r\n    <rdf:Seq>\r\n     <rdf:li\r\n      darktable:num=\"0\"\r\n      darktable:operation=\"gamma\"\r\n      darktable:enabled=\"1\"\r\n      darktable:modversion=\"1\"\r\n      darktable:params=\"0000000000000000\"\r\n      darktable:multi_name=\"\"\r\n      darktable:multi_name_hand_edited=\"0\"\r\n      darktable:multi_priority=\"0\"\r\n      darktable:blendop_version=\"13\"\r\n      darktable:blendop_params=\"gz11eJxjYIAACQYYOOHEgAZY0QWAgBGLGANDgz0Ej1Q+dcF/IADRAGpyHQU=\"/>\r\n     <rdf:li\r\n      darktable:num=\"1\"\r\n      darktable:operation=\"flip\"\r\n      darktable:enabled=\"1\"\r\n      darktable:modversion=\"2\"\r\n      darktable:params=\"ffffffff\"\r\n      darktable:multi_name=\"auto\"\r\n      darktable:multi_name_hand_edited=\"0\"\r\n      darktable:multi_priority=\"0\"\r\n      darktable:blendop_version=\"13\"\r\n      darktable:blendop_params=\"gz11eJxjYIAACQYYOOHEgAZY0QWAgBGLGANDgz0Ej1Q+dcF/IADRAGpyHQU=\"/>\r\n     <rdf:li\r\n      darktable:num=\"2\"\r\n      darktable:operation=\"colorin\"\r\n      darktable:enabled=\"1\"\r\n      darktable:modversion=\"7\"\r\n      darktable:params=\"gz48eJxjZBgFowABWAbaAaNgwAEAEDgABg==\"\r\n      darktable:multi_name=\"\"\r\n      darktable:multi_name_hand_edited=\"0\"\r\n      darktable:multi_priority=\"0\"\r\n      darktable:blendop_version=\"13\"\r\n      darktable:blendop_params=\"gz11eJxjYIAACQYYOOHEgAZY0QWAgBGLGANDgz0Ej1Q+dcF/IADRAGpyHQU=\"/>\r\n     <rdf:li\r\n      darktable:num=\"3\"\r\n      darktable:operation=\"colorout\"\r\n      darktable:enabled=\"1\"\r\n      darktable:modversion=\"5\"\r\n      darktable:params=\"gz35eJxjZBgFo4CBAQAEEAAC\"\r\n      darktable:multi_name=\"\"\r\n      darktable:multi_name_hand_edited=\"0\"\r\n      darktable:multi_priority=\"0\"\r\n      darktable:blendop_version=\"13\"\r\n      darktable:blendop_params=\"gz11eJxjYIAACQYYOOHEgAZY0QWAgBGLGANDgz0Ej1Q+dcF/IADRAGpyHQU=\"/>\r\n     <rdf:li\r\n      darktable:num=\"4\"\r\n      darktable:operation=\"ashift\"\r\n      darktable:enabled=\"1\"\r\n      darktable:modversion=\"5\"\r\n      darktable:params=\"gz18eJz7/3+zEwMKeODIwNBgz8BwwglCMzAwAnG9grzV7//1YL4SK4QeBaNgFJAPANsDCzM=\"\r\n      darktable:multi_name=\"\"\r\n      darktable:multi_name_hand_edited=\"0\"\r\n      darktable:multi_priority=\"0\"\r\n      darktable:blendop_version=\"13\"\r\n      darktable:blendop_params=\"gz11eJxjYIAACQYYOOHEgAZY0QWAgBGLGANDgz0Ej1Q+dcF/IADRAGpyHQU=\"/>\r\n     <rdf:li\r\n      darktable:num=\"5\"\r\n      darktable:operation=\"crop\"\r\n      darktable:enabled=\"1\"\r\n      darktable:modversion=\"1\"\r\n      darktable:params=\"ead17a3d5832ee3d2b4f743f3c2c693f0000000000000000\"\r\n      darktable:multi_name=\"\"\r\n      darktable:multi_name_hand_edited=\"0\"\r\n      darktable:multi_priority=\"0\"\r\n      darktable:blendop_version=\"13\"\r\n      darktable:blendop_params=\"gz11eJxjYIAACQYYOOHEgAZY0QWAgBGLGANDgz0Ej1Q+dcF/IADRAGpyHQU=\"/>\r\n     <rdf:li\r\n      darktable:num=\"6\"\r\n      darktable:operation=\"sharpen\"\r\n      darktable:enabled=\"1\"\r\n      darktable:modversion=\"1\"\r\n      darktable:params=\"feffff3ffeffdf3f00000000\"\r\n      darktable:multi_name=\"\"\r\n      darktable:multi_name_hand_edited=\"0\"\r\n      darktable:multi_priority=\"0\"\r\n      darktable:blendop_version=\"13\"\r\n      darktable:blendop_params=\"gz10eJxjYGBgYAJiCQYYOOHEgAZY0QWAgBGLGANDgz0Ej1Q+dcF/IADRAG2yHQc=\"/>\r\n    </rdf:Seq>\r\n   </darktable:history>\r\n  </rdf:Description>\r\n </rdf:RDF>\r\n</x:xmpmeta>\r\n"
            //    }
            //});

            DbMain_WorkflowItem_Link dbWorkflowItemLink_Darktable_SaveObjectToStorageAndDatabase_Thumbnail = new DbMain_WorkflowItem_Link()
            {
                Id = Guid.NewGuid(),

                Order = 12,
                ApplyLevel = WorkflowApplyLevel.Organization,

                StorageType = StorageType.S3,
                StorageClass = StorageClass.DataAndDataThumbnail,

                Permissions = EmployeeType.None,
                WorkflowExecutionLevel = WorkflowExecutionLevel.Automatically,

                Configuration = string.Empty,

                // FK
                //WorkflowItem = null,
                WorkflowItemId = Workflow_DbMain_RootDirectories.StorageAndDatabase_Save_V1_0_0,

                WorkflowGroup = null,
                WorkflowGroupId = null
            };
            dbWorkflowItemLink_Darktable_SaveObjectToStorageAndDatabase_Thumbnail.SetSaveImageV1_0_0Configuration(new ConfigurationSaveImageV1_0_0() { Quality = 100, ThumbnailWidth = 512, ThumbnailHeight = 0, ThumbnailQuality = 90 });
            #endregion

            #region Workflow 1 Image
            DbMain_WorkflowItem_Link dbWorkflowItemLink_Workflow1_CropImage_Data = new DbMain_WorkflowItem_Link()
            {
                Id = Guid.NewGuid(),

                Order = 13,
                ApplyLevel = WorkflowApplyLevel.Organization,

                StorageType = StorageType.S3,
                StorageClass = StorageClass.Data,

                Permissions = EmployeeType.None,
                WorkflowExecutionLevel = WorkflowExecutionLevel.Automatically,

                Configuration = string.Empty,

                // FK
                //WorkflowItem = null,
                WorkflowItemId = Workflow_DbMain_RootDirectories.Image_Crop_V1_0_0,

                WorkflowGroup = null,
                WorkflowGroupId = null
            };
            //dbWorkflowItemLink_Workflow1_CropImage_Data.SetCropV1_0_0Configuration(new List<ConfigurationCropV1_0_0>()
            //{
            //    new ConfigurationCropV1_0_0()
            //    {
            //        CameraId = _dbMachineContext.Devices.Where(d => d.DeviceName == "Vision 2D Right").FirstOrDefault().Id,

            //        // Width
            //        ColumnStart = 220,
            //        ColumnEnd = 2180,

            //        // Height
            //        RowStart = 160,
            //        RowEnd = 2850,
            //    },
            //    new ConfigurationCropV1_0_0()
            //    {
            //        CameraId = _dbMachineContext.Devices.Where(d => d.DeviceName == "Vision 2D Left").FirstOrDefault().Id,

            //        // Width
            //        ColumnStart = 280,
            //        ColumnEnd = 2220,

            //        // Height
            //        RowStart = 130,
            //        RowEnd = 2850,
            //    }
            //});

            DbMain_WorkflowItem_Link dbWorkflowItemLink_Workflow1_Rotate1Image_Data = new DbMain_WorkflowItem_Link()
            {
                Id = Guid.NewGuid(),

                Order = 14,
                ApplyLevel = WorkflowApplyLevel.Organization,

                StorageType = StorageType.S3,
                StorageClass = StorageClass.Data,

                Permissions = EmployeeType.None,
                WorkflowExecutionLevel = WorkflowExecutionLevel.Automatically,

                Configuration = string.Empty,

                // FK
                //WorkflowItem = null,
                WorkflowItemId = Workflow_DbMain_RootDirectories.Image_Rotate_V1_0_0,

                WorkflowGroup = null,
                WorkflowGroupId = null
            };
            //dbWorkflowItemLink_Workflow1_Rotate1Image_Data.SetRotateV1_0_0Configuration(new List<ConfigurationRotateV1_0_0>()
            //{
            //    new ConfigurationRotateV1_0_0()
            //    {
            //        CameraId = _dbMachineContext.Devices.Where(d => d.DeviceName == "Vision 2D Right").FirstOrDefault().Id,

            //        Rotate = RotateFlags.Rotate90Clockwise
            //    },
            //    new ConfigurationRotateV1_0_0()
            //    {
            //        CameraId = _dbMachineContext.Devices.Where(d => d.DeviceName == "Vision 2D Left").FirstOrDefault().Id,

            //        Rotate = RotateFlags.Rotate90Counterclockwise
            //    }
            //});

            DbMain_WorkflowItem_Link dbWorkflowItemLink_Workflow1_Rotate2Image_Data = new DbMain_WorkflowItem_Link()
            {
                Id = Guid.NewGuid(),

                Order = 15,
                ApplyLevel = WorkflowApplyLevel.Organization,

                StorageType = StorageType.S3,
                StorageClass = StorageClass.Data,

                Permissions = EmployeeType.None,
                WorkflowExecutionLevel = WorkflowExecutionLevel.Automatically,

                Configuration = string.Empty,

                // FK
                //WorkflowItem = null,
                WorkflowItemId = Workflow_DbMain_RootDirectories.Image_Rotate_V2_0_0,

                WorkflowGroup = null,
                WorkflowGroupId = null
            };
            //dbWorkflowItemLink_Workflow1_Rotate2Image_Data.SetRotateV2_0_0Configuration(new List<ConfigurationRotateV2_0_0>()
            //{
            //    new ConfigurationRotateV2_0_0()
            //    {
            //        CameraId = _dbMachineContext.Devices.Where(d => d.DeviceName == "Vision 2D Right").FirstOrDefault().Id,

            //        angle = 90
            //    },
            //    new ConfigurationRotateV2_0_0()
            //    {
            //        CameraId = _dbMachineContext.Devices.Where(d => d.DeviceName == "Vision 2D Left").FirstOrDefault().Id,

            //        angle = -90
            //    }
            //});

            DbMain_WorkflowItem_Link dbWorkflowItemLink_Workflow1_Sharpen1Image_Data = new DbMain_WorkflowItem_Link()
            {
                Id = Guid.NewGuid(),

                Order = 16,
                ApplyLevel = WorkflowApplyLevel.Organization,

                StorageType = StorageType.S3,
                StorageClass = StorageClass.Data,

                Permissions = EmployeeType.None,
                WorkflowExecutionLevel = WorkflowExecutionLevel.Automatically,

                Configuration = string.Empty,

                // FK
                //WorkflowItem = null,
                WorkflowItemId = Workflow_DbMain_RootDirectories.Image_Sharpen_V1_0_0,

                WorkflowGroup = null,
                WorkflowGroupId = null
            };
            //dbWorkflowItemLink_Workflow1_Sharpen1Image_Data.SetSharpenV1_0_0Configuration(new List<ConfigurationSharpenV1_0_0>()
            //{
            //    new ConfigurationSharpenV1_0_0()
            //    {
            //        CameraId = _dbMachineContext.Devices.Where(d => d.DeviceName == "Vision 2D Right").FirstOrDefault().Id,

            //        Filter = new float[,] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } }
            //        //Filter = new float[,] { { 0, 0, 0 }, { 0, 1, 0 }, { 0, 0, 0 } }
            //        //Filter = new float[,] { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } }
            //    },
            //    new ConfigurationSharpenV1_0_0()
            //    {
            //        CameraId = _dbMachineContext.Devices.Where(d => d.DeviceName == "Vision 2D Left").FirstOrDefault().Id,

            //        Filter = new float[,] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } }
            //        //Filter = new float[,] { { 0, 0, 0 }, { 0, 1, 0 }, { 0, 0, 0 } }
            //        //Filter = new float[,] { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } }
            //    }
            //});

            DbMain_WorkflowItem_Link dbWorkflowItemLink_Workflow1_Sharpen2Image_Data = new DbMain_WorkflowItem_Link()
            {
                Id = Guid.NewGuid(),

                Order = 17,
                ApplyLevel = WorkflowApplyLevel.Organization,

                StorageType = StorageType.S3,
                StorageClass = StorageClass.Data,

                Permissions = EmployeeType.None,
                WorkflowExecutionLevel = WorkflowExecutionLevel.Automatically,

                Configuration = string.Empty,

                // FK
                //WorkflowItem = null,
                WorkflowItemId = Workflow_DbMain_RootDirectories.Image_Sharpen_V2_0_0,

                WorkflowGroup = null,
                WorkflowGroupId = null
            };
            //dbWorkflowItemLink_Workflow1_Sharpen2Image_Data.SetSharpenV2_0_0Configuration(new List<ConfigurationSharpenV2_0_0>()
            //{
            //     new ConfigurationSharpenV2_0_0()
            //     {
            //        CameraId = _dbMachineContext.Devices.Where(d => d.DeviceName == "Vision 2D Right").FirstOrDefault().Id,

            //        SigmaS = 2.000f,
            //        SigmaR = 1.000f
            //    },
            //    new ConfigurationSharpenV2_0_0()
            //    {
            //        CameraId = _dbMachineContext.Devices.Where(d => d.DeviceName == "Vision 2D Left").FirstOrDefault().Id,

            //        SigmaS = 2.000f,
            //        SigmaR = 1.000f
            //    }
            //});

            DbMain_WorkflowItem_Link dbWorkflowItemLink_Workflow1_SaveObjectToStorageAndDatabase_DataThumbnail = new DbMain_WorkflowItem_Link()
            {
                Id = Guid.NewGuid(),

                Order = 20,
                ApplyLevel = WorkflowApplyLevel.Organization,

                StorageType = StorageType.S3,
                StorageClass = StorageClass.DataAndDataThumbnail,

                Permissions = EmployeeType.None,
                WorkflowExecutionLevel = WorkflowExecutionLevel.Automatically,

                Configuration = string.Empty,

                // FK
                //WorkflowItem = null,
                WorkflowItemId = Workflow_DbMain_RootDirectories.StorageAndDatabase_Save_V1_0_0,

                WorkflowGroup = null,
                WorkflowGroupId = null
            };
            dbWorkflowItemLink_Workflow1_SaveObjectToStorageAndDatabase_DataThumbnail.SetSaveImageV1_0_0Configuration(new ConfigurationSaveImageV1_0_0() { Quality = 100, ThumbnailWidth = 512, ThumbnailHeight = 0, ThumbnailQuality = 90 });
            #endregion

            // ToDo: More Workflow Items ...
            // 	        --> Freigabe Management (Sharing)
            // 	        --> Transfer
            // 	           --> Family Search
            // 	           --> Archiv
            #endregion

            // Root Directory (Bucket) --> ProjectId\\DirectoryIds{1...n}\\FileId ...
            DbMain_Project project = new DbMain_Project()
            {
                Id = Guid.NewGuid(),
                
                Name = "Meldezettel",
                Description = "Digitalisierung der Meldezettel von ...",

                Permissions = ProjectPermissions.Private,

                Organization = organizations.Where(p => p.Acronym.Contains("TLA")).First(),
                Contributors = new List<DbMain_Contributors>()
                {
                    new  DbMain_Contributors()
                    {
                        Id = Guid.NewGuid(),

                        Name = "Scanning",
                        Description = "",

                        ContributorType = ContributorType.ServiceProviderScanning,

                        // FK
                        Organization = organizations.Where(p => p.Acronym.Contains("UIBK")).First(),
                        //OrganizationId = null,
                 
                        Project = null,
                        ProjectId = null
                    }
                },

                Status = ProjectStatus.Created,
                Started = DateTime.MinValue,
                Finished = DateTime.MinValue,

                MaxDirectorySize = 125000000,

                AqlQuantityImage = AqlQuantity.PerNaturalUnit,
                AqlInspectionLevelImage = AqlInspectionLevel.I,
                AqlAcceptableQualityLevelImage = AcceptableQualityLevel.ZeroPointZeroSixtyFive,
                AqlStateImage = AqlState.None,
                AqlStateLastChangeImage = DateTime.MinValue,

                AqlQuantityTranscription = AqlQuantity.PerNaturalUnit,
                AqlInspectionLevelTranscription = AqlInspectionLevel.I,
                AqlAcceptableQualityLevelTranscription = AcceptableQualityLevel.ZeroPointZeroSixtyFive,
                AqlStateTranscription = AqlState.None,
                AqlStateLastChangeTranscription = DateTime.MinValue,

                WorkflowGroups = new List<DbMain_WorkflowGroup>()
                {
                    new DbMain_WorkflowGroup()
                    {
                        Id = Guid.NewGuid(),

                        Name = "Workflow Group 1",
                        Description = "Workflow Group 1",

                        WorkflowItem_Links = new List<DbMain_WorkflowItem_Link>()
                        {
                            // Grab Image
                            dbWorkflowItemLink_Vision2D_GrabImage_DataRaw,
                            dbWorkflowItemLink_Vision2D_SaveObjectToStorageAndDatabase_DataRaw,
                    
                            // HDR Image
                            dbWorkflowItemLink_HDR_CreateImage_Data,
                            dbWorkflowItemLink_HDR_SaveObjectToStorageAndDatabase_Data_DataThumbnail,

                            // Darktable Image
                            //dbWorkflowItemLink_Darktable_CreateImage_Data,
                            //dbWorkflowItemLink_Darktable_SaveObjectToStorageAndDatabase_DataThumbnail,

                            // Workflow 1
                            dbWorkflowItemLink_Workflow1_CropImage_Data,
                            dbWorkflowItemLink_Workflow1_Rotate1Image_Data,
                            //dbWorkflowItemLink_Workflow1_Rotate2Image_Data,
                            //dbWorkflowItemLink_Workflow1_Sharpen1Image_Data,
                            dbWorkflowItemLink_Workflow1_Sharpen2Image_Data,
                            dbWorkflowItemLink_Workflow1_SaveObjectToStorageAndDatabase_DataThumbnail

                            // ToDo: More Workflow Items ...
                            // 	        --> Sharpening
                            // 	        --> Exposure
                            // 	        --> ...
                            // 	        --> Freigabe Management (Sharing)
                            // 	        --> Transfer
                            // 	           --> Family Search
                            // 	           --> Archiv
                        },
                        
                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,   
                        
                        // FK
                        DeliverySlip = null,
                        DeliverySlipId = null,
                        
                        Unit = null,
                        UnitId  = null,                        

                        Project = null,
                        ProjectId = null
                    }
                    // More Workflow Groups ...
                },

                DeliverySlips = null,

                VirtualRootUnits = null,
                
                ArchiveJobLinks = null,
                LastArchiveJobStarted = DateTime.MinValue,
                LastArchiveJobFinished = DateTime.MinValue,
                
                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,               
            };

            // Create first Delivery Slip --> TLA
            project.DeliverySlips = new List<DbMain_DeliverySlip>()
            {
                new DbMain_DeliverySlip()
                {
                    Id = Guid.NewGuid(),

                    Name = "Delivery Slip 1",

                    Description = "Delivery Slip 1 Description",

                    DeliverySlipState = DeliverySlipType.Created,

                    CreatedWithDeliverySlipTemplate = null, // ToDo: ...
                    
                    DeliverySlipCreatorUserId_Ext = _gertraudZeindlId,
                    DeliverySlipCreatorOrganization = organizations.Where(p => p.Acronym.Contains("TLA")).First(),

                    DeliverySlipRecipientUserId_Ext = _patrickSchoeneggerId,
                    DeliverySlipRecipientOrganization = organizations.Where(p => p.Acronym.Contains("UIBK")).First(),               
                    
                    Units = null,

                    NumberOfUnits = 12,
                    UnitDescription = "Unit Description",

                    Notes = "Notes",

                    ApplicableWorkflowGroup = null,

                    DeliverySlipIsDirectory = false,

                    ProcessingStartedDateTime = DateTime.MinValue,
                    ProcessingStartedUserId_Ext = Guid.Empty,

                    ProcessingFinishedDateTime = DateTime.MinValue,
                    ProcessingFinishedUserId_Ext = Guid.Empty,
                        
                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,   
                    
                    // FK
                    Project = null,
                    ProjectId = null
                }
                // More Delivery Slips
            };

            // Create First Boxen und Schieber per Delivery Slip for processing with parameter --> PSGM    
            project.DeliverySlips.First().Units = new List<DbMain_Unit>()
            {
                new DbMain_Unit()
                {
                    Id = Guid.NewGuid(),
                    
                    Suffix = "",
                    Name = "Box 1",
                    Prefix = "",
                    Description = "Box 1 Description",

                    SuffixProjectOwner = "",
                    NameProjectOwner = "Box 1",
                    PrefixProjectOwner = "",
                    DescriptionProjectOwner = "Box 1 Description",

                    Stars = 4,
                    
                    Order = -1,

                    NaturalUnit = false,

                    PreparationDateTime = DateTime.MinValue,
                    PreparationUserId_Ext = Guid.Empty,

                    DetectedDefectsDuringPreparation = 0,
                    PreparationNotes = "Detected Notes During Preparation ...",

                    AqlStateImage = AqlState.None,
                    AqlStateLastChangeImage = DateTime.MinValue,

                    AqlStateTranscription = AqlState.None,
                    AqlStateLastChangeTranscription = DateTime.MinValue,
                    
                    ObjectsOnStorageInUnit = 0,
                    DirectorySizeOnStorageInUnit = 0,

                    ApplicableWorkflowGroup = null,

                    Locked = false,

                    ArchiveJobLinks = null,
                    LastArchiveJobStarted = DateTime.MinValue,
                    LastArchiveJobFinished = DateTime.MinValue,

                    Unit = new List<DbMain_Unit>()
                    {
                        new DbMain_Unit()
                        {
                            Id = Guid.NewGuid(),

                            Suffix = "",
                            Name = "Schieber 1",
                            Prefix = "",
                            Description = "Schieber 1 Description",

                            SuffixProjectOwner = "",
                            NameProjectOwner = "Box 1",
                            PrefixProjectOwner = "",
                            DescriptionProjectOwner = "Schieber 1 Description",

                            Stars = 4,

                            Order = -1,
                            
                            NaturalUnit = true,

                            PreparationDateTime = DateTime.MinValue,
                            PreparationUserId_Ext = Guid.Empty,

                            DetectedDefectsDuringPreparation = 0,
                            PreparationNotes = "Detected Notes During Preparation ...",

                            AqlStateImage = AqlState.None,
                            AqlStateLastChangeImage = DateTime.MinValue,

                            AqlStateTranscription = AqlState.None,
                            AqlStateLastChangeTranscription = DateTime.MinValue,

                            ObjectsOnStorageInUnit = 0,
                            DirectorySizeOnStorageInUnit = 0,

                            ApplicableWorkflowGroup = null,

                            Locked = false,

                            ArchiveJobLinks = null,
                            LastArchiveJobStarted = DateTime.MinValue,
                            LastArchiveJobFinished = DateTime.MinValue,

                            Unit = null,
                            
                            //CreatedByUserIdExtAutoFill = Guid.Empty,
                            //CreatedDateTimeAutoFill = DateTime.Now,
                            //ModifiedByUserIdExtAutoFill = Guid.Empty,
                            //ModifiedDateTimeAutoFill = DateTime.Now,   
                             
                            // FK
                            DeliverySlip = null,
                            DeliverySlipId = null,

                            ParentUnit = null,
                            ParentUnitId = null,
                        },
                        new DbMain_Unit()
                        {
                            Id = Guid.NewGuid(),

                            Suffix = "",
                            Name = "Schieber 1",
                            Prefix = "",
                            Description = "Schieber 1 Description",

                            SuffixProjectOwner = "",
                            NameProjectOwner = "Box 1",
                            PrefixProjectOwner = "",
                            DescriptionProjectOwner = "Box 1 Description",

                            Stars = 4,

                            Order = -1,

                            NaturalUnit = true,

                            PreparationDateTime = DateTime.MinValue,
                            PreparationUserId_Ext = Guid.Empty,

                            DetectedDefectsDuringPreparation = 0,
                            PreparationNotes = "Detected Notes During Preparation ...",

                            AqlStateImage = AqlState.None,
                            AqlStateLastChangeImage = DateTime.MinValue,

                            AqlStateTranscription = AqlState.None,
                            AqlStateLastChangeTranscription = DateTime.MinValue,

                            ObjectsOnStorageInUnit = 0,
                            DirectorySizeOnStorageInUnit = 0,

                            ApplicableWorkflowGroup = null,

                            Locked = false,

                            ArchiveJobLinks = null,
                            LastArchiveJobStarted = DateTime.MinValue,
                            LastArchiveJobFinished = DateTime.MinValue,

                            Unit = null,

                            //CreatedByUserIdExtAutoFill = Guid.Empty,
                            //CreatedDateTimeAutoFill = DateTime.Now,
                            //ModifiedByUserIdExtAutoFill = Guid.Empty,
                            //ModifiedDateTimeAutoFill = DateTime.Now,   
                             
                            // FK
                            DeliverySlip = null,
                            DeliverySlipId = null,
                            
                            ParentUnit = null,
                            ParentUnitId = null,
                        },
                    },

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,   
                             
                    // FK
                    DeliverySlip = null,
                    DeliverySlipId = null,
                    
                    ParentUnit = null,
                    ParentUnitId = null,
                },
            };
            project.DeliverySlips.First().ApplicableWorkflowGroup = project.WorkflowGroups.First();

            List<DbMain_Project> tmp = new List<DbMain_Project>()
            {
                project
            };

            return tmp;
        }
    }
}
