using Microsoft.EntityFrameworkCore;
using Minio;
using Minio.DataModel;
using Minio.DataModel.Args;
using Minio.Exceptions;
using Newtonsoft.Json;
using OpenCvSharp;
using PSGM.Helper;
using PSGM.Helper.Workflow;
using PSGM.Model.DbJob;
using PSGM.Model.DbMachine;
using PSGM.Model.DbMain;
using PSGM.Model.DbSoftware;
using PSGM.Model.DbStorage;
using PSGM.Model.DbUser;
using PSGM.Model.DbWorkflow;
using Serilog;
using Serilog.Debugging;
using Serilog.Sinks.Grafana.Loki;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;

namespace PSGM.MultiTestApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        List<LokiLabel> _lokiLabels;
        string _lokiUri;
        string _lokiOutputTemplate;




        private DbJob_Context _dbJobContext;
        private DbMachine_Context _dbMachineContext;
        private DbMain_Context _dbMain_Context;
        private DbSoftware_Context _dbSoftwareContext;
        private DbStorage_Context _dbStorage_Data_Context;
        private DbStorage_Context _dbStorage_DataRaw_Context;
        //private DbStorage_Context _dbStorageThumbnailsContext;
        private DbUser_Context _dbUserContext;
        private DbWorkflow_Context _dbWorkflow_Context;

        Guid _softwareId;
        Guid _machineId;

        Guid _patrickSchoeneggerId;
        Guid _guenterMuehlbergerId;
        Guid _gertraudZeindlId;
        Guid _christophHaidacherId;

        public MainWindow()
        {
            InitializeComponent();

            _machineId = ComputerInfo.GetComputerUUID();

            #region Initialize golbal variables ...

            //LokiLabels = new List<LokiLabel>()
            //{
            //    new LokiLabel()
            //    {
            //        Key = "Software",
            //        Value = Globals.ApplicationTitle
            //    },
            //    new LokiLabel()
            //    {
            //        Key = "Version",
            //        Value = Globals.ApplicationVersion.ToString()
            //    }
            //};
            _lokiUri = "http://10.31.40.101:3100";
            _lokiOutputTemplate = "[{Timestamp:dd.MM.yyyy - HH:mm:ss.ffff} {Level:u3}] {Message:lj}{NewLine}{Exception}";
            //_lokiOutputTemplate  = "[{Timestamp:dd.MM.yyyy - HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}";
            #endregion

            #region Inizialize logger
            // https://github.com/serilog-contrib/serilog-sinks-richtextbox
            SelfLog.Enable(message => Trace.WriteLine($"INTERNAL ERROR: {message}"));

#if DEBUG
            Log.Logger = new LoggerConfiguration()
                                .MinimumLevel.Verbose()
                                .WriteTo.Debug(outputTemplate: _lokiOutputTemplate)
                                .WriteTo.GrafanaLoki(_lokiUri, labels: _lokiLabels)
                                //.WriteTo.GrafanaLoki(Globals.LokiUri, labels: Globals.LokiLabels, textFormatter: new ExpressionTemplate("{ {@t, @mt, @l:u3}, @i, @x, @p} }\n"))
                                .Enrich.WithThreadId()
                                .Enrich.WithThreadName()
                                .CreateLogger();
#else
            Log.Logger = new LoggerConfiguration()
                                .MinimumLevel.Verbose()
                                .WriteTo.GrafanaLoki(Globals.LokiUri, labels: Globals.LokiLabels)
                                .Enrich.WithThreadId()
                                .Enrich.WithThreadName()
                                .CreateLogger();
#endif

            //Log.Information($"Application \"{Globals.ApplicationTitle} V{Globals.ApplicationVersion.ToString()}\" start...");
            #endregion

            #region Database initialization
            _dbJobContext = new DbJob_Context();
            _dbMachineContext = new DbMachine_Context();
            _dbMain_Context = new DbMain_Context();
            _dbSoftwareContext = new DbSoftware_Context();
            _dbUserContext = new DbUser_Context();
            _dbWorkflow_Context = new DbWorkflow_Context();

            _dbStorage_Data_Context = new DbStorage_Context();
            _dbStorage_DataRaw_Context = new DbStorage_Context();

            //string envDatabaseType=Environment.GetEnvironmentVariable("PSGM_DBMAIN_DATABSETYPE");

            //_dbMainContext.ConnectionStringSQLite="C:\\ProgramData\\PSGM\\Test\\DbMain.db";
            //_dbMainContext.ConnectionStringSQLite="Data Source=C:\\Git\\PSGM\\PSGM_-_PSGM.Model\\80_Model\\PSGM.Model.MainDB\\DbMain.db";

            string[] dbFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.db");

            foreach (string file in dbFiles)
            {
                File.Delete(file);
            }

            _dbJobContext.ConnectionStringSQLite = "Data Source=" + Directory.GetCurrentDirectory() + "\\DbJob.db";
            _dbMachineContext.ConnectionStringSQLite = "Data Source=" + Directory.GetCurrentDirectory() + "\\DbMachine.db";
            _dbMain_Context.ConnectionStringSQLite = "Data Source=" + Directory.GetCurrentDirectory() + "\\DbMain.db";
            _dbSoftwareContext.ConnectionStringSQLite = "Data Source=" + Directory.GetCurrentDirectory() + "\\DbSoftware.db";
            _dbUserContext.ConnectionStringSQLite = "Data Source=" + Directory.GetCurrentDirectory() + "\\DbUser.db";
            _dbWorkflow_Context.ConnectionStringSQLite = "Data Source=" + Directory.GetCurrentDirectory() + "\\DbWorkflow.db";

            _dbJobContext.DatabaseType = DatabaseType.SQLite;
            _dbMachineContext.DatabaseType = DatabaseType.SQLite;
            _dbMain_Context.DatabaseType = DatabaseType.SQLite;
            _dbSoftwareContext.DatabaseType = DatabaseType.SQLite;
            _dbUserContext.DatabaseType = DatabaseType.SQLite;
            _dbWorkflow_Context.DatabaseType = DatabaseType.SQLite;

            _dbJobContext.Database.EnsureCreated();
            _dbMachineContext.Database.EnsureCreated();
            _dbMain_Context.Database.EnsureCreated();
            _dbSoftwareContext.Database.EnsureCreated();
            _dbUserContext.Database.EnsureCreated();
            _dbWorkflow_Context.Database.EnsureCreated();

            _dbJobContext.Database.OpenConnection();
            _dbMachineContext.Database.OpenConnection();
            _dbMain_Context.Database.OpenConnection();
            _dbSoftwareContext.Database.OpenConnection();
            _dbUserContext.Database.OpenConnection();
            _dbWorkflow_Context.Database.OpenConnection();

            // Connection to storage databases is done later, due to that the storage database information ist storred in the project







            //_dbJobContext.ConnectionStringSQLite = "Data Source=C:\\Git\\MSD\\Robot\\80_Model\\PSGM.Model.DBJob\\DBJob.db";
            //_dbMachineContext.ConnectionStringSQLite = "Data Source=C:\\Git\\MSD\\Robot\\80_Model\\PSGM.Model.DBMachine\\DBMachine.db";
            //_dbMainContext.ConnectionStringSQLite = "Data Source=C:\\Git\\MSD\\Robot\\80_Model\\PSGM.Model.DBMain\\DBMain.db";
            //_dbSoftwareContext.ConnectionStringSQLite = "Data Source=C:\\Git\\MSD\\Robot\\80_Model\\PSGM.Model.DBSoftware\\DBSoftware.db";
            //_dbStorageContext.ConnectionStringSQLite = "Data Source=C:\\Git\\MSD\\Robot\\80_Model\\PSGM.Model.DBStorage\\DBStorage.db";
            //_dbStorageRawContext.ConnectionStringSQLite = "Data Source=C:\\Git\\MSD\\Robot\\80_Model\\PSGM.Model.DBStorageRaw\\DBStorageRaw.db";
            //_dbStorageThumbnailsContext.ConnectionStringSQLite = "Data Source=C:\\Git\\MSD\\Robot\\80_Model\\PSGM.Model.DBStorageThumbnails\\DBStorageThumbnails.db";
            //_dbUserContext.ConnectionStringSQLite = "Data Source=C:\\Git\\MSD\\Robot\\80_Model\\PSGM.Model.DBUser\\DBUser.db";
            //_dbWorkflowContext.ConnectionStringSQLite = "Data Source=C:\\Git\\MSD\\Robot\\80_Model\\PSGM.Model.DBWorkflow\\DBWorkflow.db";

            //_dbMainContext.ConnectionStringPostgreSQL="Host=db-clu001.branch31.psgm.at;Port=50001;Database=MainDB;Username=ef.core;Password=Ulexxubih4LOdKuhC8Hx33d4zA4";
            //_dbMainContext.ConnectionStringSQLServer="Server=(localdb)\\mssqllocaldb;Database=database;Trusted_Connection=True;";

            #endregion

            #region Initialize Databases
            btnDbCreateUser_Click(null, null);
            btnDbCreateMachine_Click(null, null);
            btnDbCreateWorkflow_Click(null, null);
            btnDbCreateOrganizationAndProject_Click(null, null);
            btnConnectToStorageDatabase_Click(null, null);
            btnSetupStorageAndStorageDb_Click(null, null);

            //btnSetupStorage_Click(null, null);
            #endregion
        }

        private void btnDbCreateUser_Click(object sender, RoutedEventArgs e)
        {
            #region Add User to DBUser
            DbUser_User dbUser_UserPatrickSchoenegger = new DbUser_User()
            {
                Id = Guid.Empty,

                LoginName = "patrick.schoenegger",
                Password = BCrypt.Net.BCrypt.HashPassword("!!!password!!!"),

                FirstName = "Patrick",
                LastName = "Schoenegger",

                MailAddress = "patrick.schoenegger@uibk.ac.at",

                PhoneNumber = string.Empty,
                MobilePhoneNumber = "+43 664 4851263",

                UserKeyCloakUserId = Guid.Empty,

                UserGroups = null,
            };
            _dbUserContext.Users.Add(dbUser_UserPatrickSchoenegger);
            _dbUserContext.SaveChanges();

            DbUser_User dbUser_UserGuentrtMuehlberger = new DbUser_User()
            {
                Id = Guid.Empty,

                LoginName = "guenter.muehlberger",
                Password = BCrypt.Net.BCrypt.HashPassword("!!!password!!!"),

                FirstName = "Guenter",
                LastName = "Muehlberger",

                MailAddress = "guenter.muehlberger@uibk.ac.at",

                PhoneNumber = string.Empty,
                MobilePhoneNumber = "+43 ",

                UserKeyCloakUserId = Guid.Empty,

                UserGroups = null
            };
            _dbUserContext.Users.Add(dbUser_UserGuentrtMuehlberger);
            _dbUserContext.SaveChanges();

            DbUser_User dbUser_UserGertraudZeindl = new DbUser_User()
            {
                Id = Guid.Empty,

                LoginName = "gertraud.zeindl",
                Password = BCrypt.Net.BCrypt.HashPassword("!!!password!!!"),

                FirstName = "Mag. Dr. Gertraud",
                LastName = "Zeindl",

                MailAddress = "gertraud.zeindl@tirol.gv.att",

                PhoneNumber = string.Empty,
                MobilePhoneNumber = "+43 ",

                UserKeyCloakUserId = Guid.Empty,
                UserGroups = null
            };
            _dbUserContext.Users.Add(dbUser_UserGertraudZeindl);
            _dbUserContext.SaveChanges();

            DbUser_User dbUser_UserChristophHaidacher = new DbUser_User()
            {
                Id = Guid.Empty,

                LoginName = "christoph.haidacher",
                Password = BCrypt.Net.BCrypt.HashPassword("!!!password!!!"),

                FirstName = "Dr. Christoph",
                LastName = "Haidacher",

                MailAddress = "christoph.haidacher@tirol.gv.att",

                PhoneNumber = string.Empty,
                MobilePhoneNumber = "+43 ",

                UserKeyCloakUserId = Guid.Empty,

                UserGroups = null
            };
            _dbUserContext.Users.Add(dbUser_UserChristophHaidacher);
            _dbUserContext.SaveChanges();
            #endregion

            #region Verify Password
            //public bool VerifyPassword(string username, string password)
            //{
            //    // Holen Sie den Benutzer und den Passwort-Hash aus der Datenbank
            //    // Zum Beispiel: var user=dbContext.Users.FirstOrDefault(u => u.Username == username);
            //    var user=/* Code zum Abrufen des Benutzers aus der Datenbank */;

            //    if (user != null)
            //    {
            //        return BCrypt.Verify(password, user.PasswordHash);
            //    }

            //    return false;
            //}
            #endregion

            #region Read Guids
            _patrickSchoeneggerId = _dbUserContext.Users.Where(u => u.LoginName == "patrick.schoenegger").FirstOrDefault().Id;
            _guenterMuehlbergerId = _dbUserContext.Users.Where(u => u.LoginName == "guenter.muehlberger").FirstOrDefault().Id;
            _gertraudZeindlId = _dbUserContext.Users.Where(u => u.LoginName == "gertraud.zeindl").FirstOrDefault().Id;
            _christophHaidacherId = _dbUserContext.Users.Where(u => u.LoginName == "christoph.haidacher").FirstOrDefault().Id;
            #endregion          
        }

        private void btnDbCreateMachine_Click(object sender, RoutedEventArgs e)
        {
            #region Add Addressesd to DBMachine
            DbMachine_Address DBMachine_addressUIBK = new DbMachine_Address()
            {
                Id = Guid.NewGuid(),

                Line1 = "Innrain 52d",
                Line2 = "Stock 3",

                City = "Innsbruck",
                State = "Tirol",
                CountryCode = "AT",
                CountryName = "Austria",
                PostalCode = "6020",
                RegionCode = string.Empty,
                RegionName = string.Empty,

                GpsAltitude = 574,
                GpsLatitudeDegree = 47,
                GpsLatitudeMinute = 15,
                GpsLatitudeSecond = 50.8428m,
                GpsLatitudeCardinalPoint = 'N',
                GpsLongitudeDegree = 11,
                GpsLongitudeMinute = 23,
                GpsLongitudeSecond = 3.0876m,
                GpsLongitudeCardinalPoint = 'E',

                // FK
                //Location=null,
            };
            _dbMachineContext.Addresses.Add(DBMachine_addressUIBK);
            _dbMachineContext.SaveChanges();
            #endregion

            #region Add Locations to DBMachine
            DbMachine_Location DBMachine_location = new DbMachine_Location()
            {
                Id = new Guid(),

                Name = "GEIWI Turm - 3. Stocker (DEA Büro)",
                Description = "",

                Address = DBMachine_addressUIBK,

                //FK
                //Machine=null
            };
            _dbMachineContext.Locations.Add(DBMachine_location);
            _dbMachineContext.SaveChanges();
            #endregion

            #region Add DeviceGroupes to DBMachine
            DbMachine_DeviceGroup DBMachine_deviceGroup_mainFrame = new DbMachine_DeviceGroup()
            {
                Id = new Guid(),

                Name = "Main Frame",
                Description = "",

                Location = string.Empty,

                DeviceGroupeType = DeviceGroupeType.MainFrame,
                Configuration = string.Empty,

                Devices = new List<DbMachine_Device>()
                {
                    //Control_001(),

                    //PowerSupply_001(),
                    //PowerSupply_002(),

                    Robot_001(),
                    Robot_002(),

                    Vision2D_001(),
                    Vision2D_002(),

                    Motion_001()
                },

                //FK
                //Machine=null
            };
            _dbMachineContext.DeviceGroups.Add(DBMachine_deviceGroup_mainFrame);
            _dbMachineContext.SaveChanges();

            //DbMachine_DeviceGroup DBMachine_deviceGroup_sheetCradle = new DbMachine_DeviceGroup()
            //{
            //    Id = new Guid(),

            //    Name = "Sheet Crale",
            //    Description = "",
            //    Location = string.Empty,
            //    DeviceGroupeType = DeviceGroupeType.SheetCradle,
            //    Configuration = string.Empty,

            //    Devices = new List<DbMachine_Device>()
            //    {
            //        Control_002(),
            //    },

            //    //FK
            //    //Machine=null
            //};
            //_dbMachineContext.DeviceGroups.Add(DBMachine_deviceGroup_sheetCradle);
            //_dbMachineContext.SaveChanges();
            #endregion

            #region Add Machines to DBMachine
            DbMachine_Machine DBMachine_machine = new DbMachine_Machine()
            {
                Id = _machineId,

                Name = "Heja",
                Description = "Sheet scanning robot ...",

                ApplicationName = "Heja Scanning Software",

                InitialzeAtSplashscreen = true,
                ConnectAtSplashscreen = true,
                AutoStartAtSplashscreen = true,
                HomingAtSplashscreen = true,

                Location = DBMachine_location,

                DeviceGroups = new List<DbMachine_DeviceGroup>()
                {
                    DBMachine_deviceGroup_mainFrame,
                    //DBMachine_deviceGroup_sheetCradle
                },

                // FK
            };
            _dbMachineContext.Machines.Add(DBMachine_machine);
            _dbMachineContext.SaveChanges();
            #endregion
        }

        private void btnDbCreateWorkflow_Click(object sender, RoutedEventArgs e)
        {
            #region Add WorkflowItems
            // Workflows set on database initialisation
            #endregion

            #region WorkflowItemLinks
            #region Raw images
            DbWorkflow_WorkflowItemLink dbWorkflowItemLink_Vision2D_GrabImage_DataRaw = new DbWorkflow_WorkflowItemLink()
            {
                Id = Guid.NewGuid(),

                Order = 1,
                ApplyLevel = WorkflowApplyLevel.Organization,

                StorageType = StorageType.S3,
                StorageClass = StorageClass.DataRaw,

                Configuration = string.Empty,

                //WorkflowItem = null,
                WorkflowItemId = WorkflowItem_Id.Vision2D_GrabImage_V1_0_0,

                // FK
                //Workflow = null,
                //WorkflowId = null
            };

            DbWorkflow_WorkflowItemLink dbWorkflowItemLink_Vision2D_SaveObjectToStorageAndDatabase_DataRaw = new DbWorkflow_WorkflowItemLink()
            {
                Id = Guid.NewGuid(),

                Order = 4,
                ApplyLevel = WorkflowApplyLevel.Organization,

                StorageType = StorageType.S3,
                StorageClass = StorageClass.DataRaw,
                //StorageClass = StorageClass.DataRawAndDataRawThumbnail, 

                Configuration = string.Empty,

                //WorkflowItem = null,
                WorkflowItemId = WorkflowItem_Id.StorageAndDatabase_Save_V1_0_0,

                // FK
                //Workflow = null,
                //WorkflowId = null
            };
            dbWorkflowItemLink_Vision2D_SaveObjectToStorageAndDatabase_DataRaw.SetSaveImageV1_0_0Configuration(new Configuration_SaveImageV1_0_0() { Quality = 100, ThumbnailWidth = 512, ThumbnailHeight = 0, ThumbnailQuality = 90 });
            #endregion

            #region HDR Image
            DbWorkflow_WorkflowItemLink dbWorkflowItemLink_HDR_CreateImage_Data = new DbWorkflow_WorkflowItemLink()
            {
                Id = Guid.NewGuid(),

                Order = 5,
                ApplyLevel = WorkflowApplyLevel.Organization,

                StorageType = StorageType.S3,
                StorageClass = StorageClass.Data,

                Configuration = string.Empty,

                //WorkflowItem = null,
                WorkflowItemId = WorkflowItem_Id.Image_HDR_V1_0_0,

                // FK
                //Workflow = null,
                //WorkflowId = null
            };

            DbWorkflow_WorkflowItemLink dbWorkflowItemLink_HDR_SaveObjectToStorageAndDatabase_Data_DataThumbnail = new DbWorkflow_WorkflowItemLink()
            {
                Id = Guid.NewGuid(),

                Order = 8,
                ApplyLevel = WorkflowApplyLevel.Organization,

                StorageType = StorageType.S3,
                StorageClass = StorageClass.DataAndDataThumbnail,

                Configuration = string.Empty,

                //WorkflowItem = null,
                WorkflowItemId = WorkflowItem_Id.StorageAndDatabase_Save_V1_0_0,

                // FK
                //Workflow = null,
                //WorkflowId = null
            };
            dbWorkflowItemLink_HDR_SaveObjectToStorageAndDatabase_Data_DataThumbnail.SetSaveImageV1_0_0Configuration(new Configuration_SaveImageV1_0_0() { Quality = 100, ThumbnailWidth = 512, ThumbnailHeight = 0, ThumbnailQuality = 90 });
            #endregion

            #region Darktable Image
            DbWorkflow_WorkflowItemLink dbWorkflowItemLink_Darktable_CreateImage_Data = new DbWorkflow_WorkflowItemLink()
            {
                Id = Guid.NewGuid(),

                Order = 9,
                ApplyLevel = WorkflowApplyLevel.Organization,

                StorageType = StorageType.S3,
                StorageClass = StorageClass.Data,

                Configuration = string.Empty,

                //WorkflowItem = null,
                WorkflowItemId = WorkflowItem_Id.Image_Darktable_V1_0_0,

                // FK
                //Workflow = null,
                //WorkflowId = null
            };
            dbWorkflowItemLink_Darktable_CreateImage_Data.SetDarktableV1_0_0Configuration(new List<Configuration_DarktableV1_0_0>()
            {
                new Configuration_DarktableV1_0_0()
                {
                    CameraId = _dbMachineContext.Devices.Where(d => d.DeviceName == "Vision 2D Right").FirstOrDefault().Id,
                    DarktableExecutePath = "C:/Program Files/darktable/bin/darktable-cli.exe",
                    DarktableExecuteArgumetns = "\"INPUT_FILE_PATH\" \"SIDECAR_FILE_PATH\" \"Output_FILE_PATH\" --verbose --out-ext jpg",
                    DarktableSidecarFile = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n<x:xmpmeta xmlns:x=\"adobe:ns:meta/\" x:xmptk=\"XMP Core 4.4.0-Exiv2\">\r\n <rdf:RDF xmlns:rdf=\"http://www.w3.org/1999/02/22-rdf-syntax-ns#\">\r\n  <rdf:Description rdf:about=\"\"\r\n    xmlns:exif=\"http://ns.adobe.com/exif/1.0/\"\r\n    xmlns:xmp=\"http://ns.adobe.com/xap/1.0/\"\r\n    xmlns:xmpMM=\"http://ns.adobe.com/xap/1.0/mm/\"\r\n    xmlns:darktable=\"http://darktable.sf.net/\"\r\n   exif:DateTimeOriginal=\"2024:04:12 10:50:30.000\"\r\n   xmp:Rating=\"1\"\r\n   xmpMM:DerivedFrom=\"fusion_mertens_8.jpg\"\r\n   darktable:import_timestamp=\"63848515846079968\"\r\n   darktable:change_timestamp=\"63848515852593962\"\r\n   darktable:export_timestamp=\"-1\"\r\n   darktable:print_timestamp=\"-1\"\r\n   darktable:xmp_version=\"5\"\r\n   darktable:raw_params=\"0\"\r\n   darktable:auto_presets_applied=\"1\"\r\n   darktable:history_end=\"7\"\r\n   darktable:iop_order_version=\"3\"\r\n   darktable:history_basic_hash=\"8921fe8edb66aeacff411f85c52c8f4a\"\r\n   darktable:history_current_hash=\"5746e8e023517a2df85554f13a0cb807\">\r\n   <darktable:masks_history>\r\n    <rdf:Seq/>\r\n   </darktable:masks_history>\r\n   <darktable:history>\r\n    <rdf:Seq>\r\n     <rdf:li\r\n      darktable:num=\"0\"\r\n      darktable:operation=\"gamma\"\r\n      darktable:enabled=\"1\"\r\n      darktable:modversion=\"1\"\r\n      darktable:params=\"0000000000000000\"\r\n      darktable:multi_name=\"\"\r\n      darktable:multi_name_hand_edited=\"0\"\r\n      darktable:multi_priority=\"0\"\r\n      darktable:blendop_version=\"13\"\r\n      darktable:blendop_params=\"gz11eJxjYIAACQYYOOHEgAZY0QWAgBGLGANDgz0Ej1Q+dcF/IADRAGpyHQU=\"/>\r\n     <rdf:li\r\n      darktable:num=\"1\"\r\n      darktable:operation=\"flip\"\r\n      darktable:enabled=\"1\"\r\n      darktable:modversion=\"2\"\r\n      darktable:params=\"ffffffff\"\r\n      darktable:multi_name=\"auto\"\r\n      darktable:multi_name_hand_edited=\"0\"\r\n      darktable:multi_priority=\"0\"\r\n      darktable:blendop_version=\"13\"\r\n      darktable:blendop_params=\"gz11eJxjYIAACQYYOOHEgAZY0QWAgBGLGANDgz0Ej1Q+dcF/IADRAGpyHQU=\"/>\r\n     <rdf:li\r\n      darktable:num=\"2\"\r\n      darktable:operation=\"colorin\"\r\n      darktable:enabled=\"1\"\r\n      darktable:modversion=\"7\"\r\n      darktable:params=\"gz48eJxjZBgFowABWAbaAaNgwAEAEDgABg==\"\r\n      darktable:multi_name=\"\"\r\n      darktable:multi_name_hand_edited=\"0\"\r\n      darktable:multi_priority=\"0\"\r\n      darktable:blendop_version=\"13\"\r\n      darktable:blendop_params=\"gz11eJxjYIAACQYYOOHEgAZY0QWAgBGLGANDgz0Ej1Q+dcF/IADRAGpyHQU=\"/>\r\n     <rdf:li\r\n      darktable:num=\"3\"\r\n      darktable:operation=\"colorout\"\r\n      darktable:enabled=\"1\"\r\n      darktable:modversion=\"5\"\r\n      darktable:params=\"gz35eJxjZBgFo4CBAQAEEAAC\"\r\n      darktable:multi_name=\"\"\r\n      darktable:multi_name_hand_edited=\"0\"\r\n      darktable:multi_priority=\"0\"\r\n      darktable:blendop_version=\"13\"\r\n      darktable:blendop_params=\"gz11eJxjYIAACQYYOOHEgAZY0QWAgBGLGANDgz0Ej1Q+dcF/IADRAGpyHQU=\"/>\r\n     <rdf:li\r\n      darktable:num=\"4\"\r\n      darktable:operation=\"ashift\"\r\n      darktable:enabled=\"1\"\r\n      darktable:modversion=\"5\"\r\n      darktable:params=\"gz18eJz7/3/zIQYU8MCRgaHBnoHhhBOEZmBghMqUr6mzt+iLtvr5v96eYRSMglFAEQAA/z4NDw==\"\r\n      darktable:multi_name=\"\"\r\n      darktable:multi_name_hand_edited=\"0\"\r\n      darktable:multi_priority=\"0\"\r\n      darktable:blendop_version=\"13\"\r\n      darktable:blendop_params=\"gz11eJxjYIAACQYYOOHEgAZY0QWAgBGLGANDgz0Ej1Q+dcF/IADRAGpyHQU=\"/>\r\n     <rdf:li\r\n      darktable:num=\"5\"\r\n      darktable:operation=\"crop\"\r\n      darktable:enabled=\"1\"\r\n      darktable:modversion=\"1\"\r\n      darktable:params=\"ead17a3d5832ee3d2b4f743f3c2c693f0000000000000000\"\r\n      darktable:multi_name=\"\"\r\n      darktable:multi_name_hand_edited=\"0\"\r\n      darktable:multi_priority=\"0\"\r\n      darktable:blendop_version=\"13\"\r\n      darktable:blendop_params=\"gz11eJxjYIAACQYYOOHEgAZY0QWAgBGLGANDgz0Ej1Q+dcF/IADRAGpyHQU=\"/>\r\n     <rdf:li\r\n      darktable:num=\"6\"\r\n      darktable:operation=\"sharpen\"\r\n      darktable:enabled=\"1\"\r\n      darktable:modversion=\"1\"\r\n      darktable:params=\"feffff3ffeffdf3f00000000\"\r\n      darktable:multi_name=\"\"\r\n      darktable:multi_name_hand_edited=\"0\"\r\n      darktable:multi_priority=\"0\"\r\n      darktable:blendop_version=\"13\"\r\n      darktable:blendop_params=\"gz10eJxjYGBgYAJiCQYYOOHEgAZY0QWAgBGLGANDgz0Ej1Q+dcF/IADRAG2yHQc=\"/>\r\n    </rdf:Seq>\r\n   </darktable:history>\r\n  </rdf:Description>\r\n </rdf:RDF>\r\n</x:xmpmeta>\r\n"
                },
                new Configuration_DarktableV1_0_0()
                {
                    CameraId = _dbMachineContext.Devices.Where(d => d.DeviceName == "Vision 2D Left").FirstOrDefault().Id,
                    DarktableExecutePath = "C:/Program Files/darktable/bin/darktable-cli.exe",
                    DarktableExecuteArgumetns = "\"INPUT_FILE_PATH\" \"SIDECAR_FILE_PATH\" \"Output_FILE_PATH\" --verbose --out-ext jpg",
                    DarktableSidecarFile = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n<x:xmpmeta xmlns:x=\"adobe:ns:meta/\" x:xmptk=\"XMP Core 4.4.0-Exiv2\">\r\n <rdf:RDF xmlns:rdf=\"http://www.w3.org/1999/02/22-rdf-syntax-ns#\">\r\n  <rdf:Description rdf:about=\"\"\r\n    xmlns:exif=\"http://ns.adobe.com/exif/1.0/\"\r\n    xmlns:xmp=\"http://ns.adobe.com/xap/1.0/\"\r\n    xmlns:xmpMM=\"http://ns.adobe.com/xap/1.0/mm/\"\r\n    xmlns:darktable=\"http://darktable.sf.net/\"\r\n   exif:DateTimeOriginal=\"2024:04:12 11:03:19.000\"\r\n   xmp:Rating=\"1\"\r\n   xmpMM:DerivedFrom=\"fusion_mertens_9.jpg\"\r\n   darktable:import_timestamp=\"63848516613724363\"\r\n   darktable:change_timestamp=\"63848517214557125\"\r\n   darktable:export_timestamp=\"-1\"\r\n   darktable:print_timestamp=\"-1\"\r\n   darktable:xmp_version=\"5\"\r\n   darktable:raw_params=\"0\"\r\n   darktable:auto_presets_applied=\"1\"\r\n   darktable:history_end=\"7\"\r\n   darktable:iop_order_version=\"3\"\r\n   darktable:history_basic_hash=\"8921fe8edb66aeacff411f85c52c8f4a\"\r\n   darktable:history_current_hash=\"a4fc649dce00b7dd6023ea8e10ae64ba\">\r\n   <darktable:masks_history>\r\n    <rdf:Seq/>\r\n   </darktable:masks_history>\r\n   <darktable:history>\r\n    <rdf:Seq>\r\n     <rdf:li\r\n      darktable:num=\"0\"\r\n      darktable:operation=\"gamma\"\r\n      darktable:enabled=\"1\"\r\n      darktable:modversion=\"1\"\r\n      darktable:params=\"0000000000000000\"\r\n      darktable:multi_name=\"\"\r\n      darktable:multi_name_hand_edited=\"0\"\r\n      darktable:multi_priority=\"0\"\r\n      darktable:blendop_version=\"13\"\r\n      darktable:blendop_params=\"gz11eJxjYIAACQYYOOHEgAZY0QWAgBGLGANDgz0Ej1Q+dcF/IADRAGpyHQU=\"/>\r\n     <rdf:li\r\n      darktable:num=\"1\"\r\n      darktable:operation=\"flip\"\r\n      darktable:enabled=\"1\"\r\n      darktable:modversion=\"2\"\r\n      darktable:params=\"ffffffff\"\r\n      darktable:multi_name=\"auto\"\r\n      darktable:multi_name_hand_edited=\"0\"\r\n      darktable:multi_priority=\"0\"\r\n      darktable:blendop_version=\"13\"\r\n      darktable:blendop_params=\"gz11eJxjYIAACQYYOOHEgAZY0QWAgBGLGANDgz0Ej1Q+dcF/IADRAGpyHQU=\"/>\r\n     <rdf:li\r\n      darktable:num=\"2\"\r\n      darktable:operation=\"colorin\"\r\n      darktable:enabled=\"1\"\r\n      darktable:modversion=\"7\"\r\n      darktable:params=\"gz48eJxjZBgFowABWAbaAaNgwAEAEDgABg==\"\r\n      darktable:multi_name=\"\"\r\n      darktable:multi_name_hand_edited=\"0\"\r\n      darktable:multi_priority=\"0\"\r\n      darktable:blendop_version=\"13\"\r\n      darktable:blendop_params=\"gz11eJxjYIAACQYYOOHEgAZY0QWAgBGLGANDgz0Ej1Q+dcF/IADRAGpyHQU=\"/>\r\n     <rdf:li\r\n      darktable:num=\"3\"\r\n      darktable:operation=\"colorout\"\r\n      darktable:enabled=\"1\"\r\n      darktable:modversion=\"5\"\r\n      darktable:params=\"gz35eJxjZBgFo4CBAQAEEAAC\"\r\n      darktable:multi_name=\"\"\r\n      darktable:multi_name_hand_edited=\"0\"\r\n      darktable:multi_priority=\"0\"\r\n      darktable:blendop_version=\"13\"\r\n      darktable:blendop_params=\"gz11eJxjYIAACQYYOOHEgAZY0QWAgBGLGANDgz0Ej1Q+dcF/IADRAGpyHQU=\"/>\r\n     <rdf:li\r\n      darktable:num=\"4\"\r\n      darktable:operation=\"ashift\"\r\n      darktable:enabled=\"1\"\r\n      darktable:modversion=\"5\"\r\n      darktable:params=\"gz18eJz7/3+zEwMKeODIwNBgz8BwwglCMzAwAnG9grzV7//1YL4SK4QeBaNgFJAPANsDCzM=\"\r\n      darktable:multi_name=\"\"\r\n      darktable:multi_name_hand_edited=\"0\"\r\n      darktable:multi_priority=\"0\"\r\n      darktable:blendop_version=\"13\"\r\n      darktable:blendop_params=\"gz11eJxjYIAACQYYOOHEgAZY0QWAgBGLGANDgz0Ej1Q+dcF/IADRAGpyHQU=\"/>\r\n     <rdf:li\r\n      darktable:num=\"5\"\r\n      darktable:operation=\"crop\"\r\n      darktable:enabled=\"1\"\r\n      darktable:modversion=\"1\"\r\n      darktable:params=\"ead17a3d5832ee3d2b4f743f3c2c693f0000000000000000\"\r\n      darktable:multi_name=\"\"\r\n      darktable:multi_name_hand_edited=\"0\"\r\n      darktable:multi_priority=\"0\"\r\n      darktable:blendop_version=\"13\"\r\n      darktable:blendop_params=\"gz11eJxjYIAACQYYOOHEgAZY0QWAgBGLGANDgz0Ej1Q+dcF/IADRAGpyHQU=\"/>\r\n     <rdf:li\r\n      darktable:num=\"6\"\r\n      darktable:operation=\"sharpen\"\r\n      darktable:enabled=\"1\"\r\n      darktable:modversion=\"1\"\r\n      darktable:params=\"feffff3ffeffdf3f00000000\"\r\n      darktable:multi_name=\"\"\r\n      darktable:multi_name_hand_edited=\"0\"\r\n      darktable:multi_priority=\"0\"\r\n      darktable:blendop_version=\"13\"\r\n      darktable:blendop_params=\"gz10eJxjYGBgYAJiCQYYOOHEgAZY0QWAgBGLGANDgz0Ej1Q+dcF/IADRAG2yHQc=\"/>\r\n    </rdf:Seq>\r\n   </darktable:history>\r\n  </rdf:Description>\r\n </rdf:RDF>\r\n</x:xmpmeta>\r\n"
                }
            });

            DbWorkflow_WorkflowItemLink dbWorkflowItemLink_Darktable_SaveObjectToStorageAndDatabase_Thumbnail = new DbWorkflow_WorkflowItemLink()
            {
                Id = Guid.NewGuid(),

                Order = 12,
                ApplyLevel = WorkflowApplyLevel.Organization,

                StorageType = StorageType.S3,
                StorageClass = StorageClass.DataAndDataThumbnail,

                Configuration = string.Empty,

                //WorkflowItem = null,
                WorkflowItemId = WorkflowItem_Id.StorageAndDatabase_Save_V1_0_0,

                // FK
                //Workflow = null,
                //WorkflowId = null
            };
            dbWorkflowItemLink_Darktable_SaveObjectToStorageAndDatabase_Thumbnail.SetSaveImageV1_0_0Configuration(new Configuration_SaveImageV1_0_0() { Quality = 100, ThumbnailWidth = 512, ThumbnailHeight = 0, ThumbnailQuality = 90 });
            #endregion

            #region Workflow 1 Image
            DbWorkflow_WorkflowItemLink dbWorkflowItemLink_Workflow1_CropImage_Data = new DbWorkflow_WorkflowItemLink()
            {
                Id = Guid.NewGuid(),

                Order = 13,
                ApplyLevel = WorkflowApplyLevel.Organization,

                StorageType = StorageType.S3,
                StorageClass = StorageClass.Data,

                Configuration = string.Empty,

                //WorkflowItem = null,
                WorkflowItemId = WorkflowItem_Id.Image_Crop_V1_0_0,

                // FK
                //Workflow = null,
                //WorkflowId = null
            };
            dbWorkflowItemLink_Workflow1_CropImage_Data.SetCropV1_0_0Configuration(new List<Configuration_CropV1_0_0>()
            {
                new Configuration_CropV1_0_0()
                {
                    CameraId = _dbMachineContext.Devices.Where(d => d.DeviceName == "Vision 2D Right").FirstOrDefault().Id,

                    // Width
                    ColumnStart = 220,
                    ColumnEnd = 2180,

                    // Height
                    RowStart = 160,
                    RowEnd = 2850,
                },
                new Configuration_CropV1_0_0()
                {
                    CameraId = _dbMachineContext.Devices.Where(d => d.DeviceName == "Vision 2D Left").FirstOrDefault().Id,

                    // Width
                    ColumnStart = 280,
                    ColumnEnd = 2220,

                    // Height
                    RowStart = 130,
                    RowEnd = 2850,
                }
            });

            DbWorkflow_WorkflowItemLink dbWorkflowItemLink_Workflow1_Rotate1Image_Data = new DbWorkflow_WorkflowItemLink()
            {
                Id = Guid.NewGuid(),

                Order = 14,
                ApplyLevel = WorkflowApplyLevel.Organization,

                StorageType = StorageType.S3,
                StorageClass = StorageClass.Data,

                Configuration = string.Empty,

                //WorkflowItem = null,
                WorkflowItemId = WorkflowItem_Id.Image_Rotate_V1_0_0,

                // FK
                //Workflow = null,
                //WorkflowId = null
            };
            dbWorkflowItemLink_Workflow1_Rotate1Image_Data.SetRotateV1_0_0Configuration(new List<Configuration_RotateV1_0_0>()
            {
                new Configuration_RotateV1_0_0()
                {
                    CameraId = _dbMachineContext.Devices.Where(d => d.DeviceName == "Vision 2D Right").FirstOrDefault().Id,

                    Rotate = RotateFlags.Rotate90Clockwise
                },
                new Configuration_RotateV1_0_0()
                {
                    CameraId = _dbMachineContext.Devices.Where(d => d.DeviceName == "Vision 2D Left").FirstOrDefault().Id,

                    Rotate = RotateFlags.Rotate90Counterclockwise
                }
            });

            DbWorkflow_WorkflowItemLink dbWorkflowItemLink_Workflow1_Rotate2Image_Data = new DbWorkflow_WorkflowItemLink()
            {
                Id = Guid.NewGuid(),

                Order = 15,
                ApplyLevel = WorkflowApplyLevel.Organization,

                StorageType = StorageType.S3,
                StorageClass = StorageClass.Data,

                Configuration = string.Empty,

                //WorkflowItem = null,
                WorkflowItemId = WorkflowItem_Id.Image_Rotate_V2_0_0,

                // FK
                //Workflow = null,
                //WorkflowId = null
            };
            dbWorkflowItemLink_Workflow1_Rotate2Image_Data.SetRotateV2_0_0Configuration(new List<Configuration_RotateV2_0_0>()
            {
                new Configuration_RotateV2_0_0()
                {
                    CameraId = _dbMachineContext.Devices.Where(d => d.DeviceName == "Vision 2D Right").FirstOrDefault().Id,

                    angle = -90
                },
                new Configuration_RotateV2_0_0()
                {
                    CameraId = _dbMachineContext.Devices.Where(d => d.DeviceName == "Vision 2D Left").FirstOrDefault().Id,

                    angle = 90
                }
            });

            DbWorkflow_WorkflowItemLink dbWorkflowItemLink_Workflow1_Sharpen1Image_Data = new DbWorkflow_WorkflowItemLink()
            {
                Id = Guid.NewGuid(),

                Order = 16,
                ApplyLevel = WorkflowApplyLevel.Organization,

                StorageType = StorageType.S3,
                StorageClass = StorageClass.Data,

                Configuration = string.Empty,

                //WorkflowItem = null,
                WorkflowItemId = WorkflowItem_Id.Image_Sharpen_V1_0_0,

                // FK
                //Workflow = null,
                //WorkflowId = null
            };
            dbWorkflowItemLink_Workflow1_Sharpen1Image_Data.SetSharpenV1_0_0Configuration(new List<Configuration_SharpenV1_0_0>()
            {
                new Configuration_SharpenV1_0_0()
                {
                    CameraId = _dbMachineContext.Devices.Where(d => d.DeviceName == "Vision 2D Right").FirstOrDefault().Id,

                    Filter = new float[,] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } }
                    //Filter = new float[,] { { 0, 0, 0 }, { 0, 1, 0 }, { 0, 0, 0 } }
                    //Filter = new float[,] { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } }
                },
                new Configuration_SharpenV1_0_0()
                {
                    CameraId = _dbMachineContext.Devices.Where(d => d.DeviceName == "Vision 2D Left").FirstOrDefault().Id,

                    Filter = new float[,] { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } }
                    //Filter = new float[,] { { 0, 0, 0 }, { 0, 1, 0 }, { 0, 0, 0 } }
                    //Filter = new float[,] { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } }
                }
            });

            DbWorkflow_WorkflowItemLink dbWorkflowItemLink_Workflow1_Sharpen2Image_Data = new DbWorkflow_WorkflowItemLink()
            {
                Id = Guid.NewGuid(),

                Order = 17,
                ApplyLevel = WorkflowApplyLevel.Organization,

                StorageType = StorageType.S3,
                StorageClass = StorageClass.Data,

                Configuration = string.Empty,

                //WorkflowItem = null,
                WorkflowItemId = WorkflowItem_Id.Image_Sharpen_V2_0_0,

                // FK
                //Workflow = null,
                //WorkflowId = null
            };
            dbWorkflowItemLink_Workflow1_Sharpen2Image_Data.SetSharpenV2_0_0Configuration(new List<Configuration_SharpenV2_0_0>()
            {
                 new Configuration_SharpenV2_0_0()
                {
                    CameraId = _dbMachineContext.Devices.Where(d => d.DeviceName == "Vision 2D Right").FirstOrDefault().Id,

                    SigmaS = 2.000f,
                    SigmaR = 1.000f
                },
                new Configuration_SharpenV2_0_0()
                {
                    CameraId = _dbMachineContext.Devices.Where(d => d.DeviceName == "Vision 2D Left").FirstOrDefault().Id,

                    SigmaS = 2.000f,
                    SigmaR = 1.000f
                }
            });

            DbWorkflow_WorkflowItemLink dbWorkflowItemLink_Workflow1_SaveObjectToStorageAndDatabase_DataThumbnail = new DbWorkflow_WorkflowItemLink()
            {
                Id = Guid.NewGuid(),

                Order = 20,
                ApplyLevel = WorkflowApplyLevel.Organization,

                StorageType = StorageType.S3,
                StorageClass = StorageClass.DataAndDataThumbnail,

                Configuration = string.Empty,

                //WorkflowItem = null,
                WorkflowItemId = WorkflowItem_Id.StorageAndDatabase_Save_V1_0_0,

                // FK
                //Workflow = null,
                //WorkflowId = null
            };
            dbWorkflowItemLink_Workflow1_SaveObjectToStorageAndDatabase_DataThumbnail.SetSaveImageV1_0_0Configuration(new Configuration_SaveImageV1_0_0() { Quality = 100, ThumbnailWidth = 512, ThumbnailHeight = 0, ThumbnailQuality = 90 });
            #endregion
            #endregion

            #region Add Workflow
            DbWorkflow_Workflow dBWorkflow_Workflow = new DbWorkflow_Workflow()
            {
                Id = Guid.NewGuid(),

                Name = "Meldezettel TLA",
                Description = "Workflow for the sheet scanner (HDR, ...)",

                WorkflowItemLinks = new List<DbWorkflow_WorkflowItemLink>()
                {
                    // Grab Image
                    dbWorkflowItemLink_Vision2D_GrabImage_DataRaw,
                    dbWorkflowItemLink_Vision2D_SaveObjectToStorageAndDatabase_DataRaw,

                    // HDR Image
                    dbWorkflowItemLink_HDR_CreateImage_Data,
                    dbWorkflowItemLink_HDR_SaveObjectToStorageAndDatabase_Data_DataThumbnail,

                    //// Darktable Image
                    //dbWorkflowItemLink_Darktable_CreateImage_Data,
                    //dbWorkflowItemLink_Darktable_SaveObjectToStorageAndDatabase_DataThumbnail,

                    // Workflow 1
                    dbWorkflowItemLink_Workflow1_CropImage_Data,
                    dbWorkflowItemLink_Workflow1_Rotate1Image_Data,
                    //dbWorkflowItemLink_Workflow1_Rotate2Image_Data,
                    //dbWorkflowItemLink_Workflow1_Sharpen1Image_Data,
                    dbWorkflowItemLink_Workflow1_Sharpen2Image_Data,
                    dbWorkflowItemLink_Workflow1_SaveObjectToStorageAndDatabase_DataThumbnail
                }
            };
            _dbWorkflow_Context.Workflows.Add(dBWorkflow_Workflow);
            _dbWorkflow_Context.SaveChanges();
            #endregion 
        }

        private void btnDbCreateOrganizationAndProject_Click(object sender, RoutedEventArgs e)
        {
            #region Add Addresses to DBMain
            DbMain_Address dbMain_addressTLA = new DbMain_Address()
            {
                Id = Guid.NewGuid(),

                Line1 = "Michael-Gaismair-Straße 1",
                Line2 = string.Empty,

                City = "Innsbruck",
                State = "Tirol",
                CountryCode = "AT",
                CountryName = "Austria",
                PostalCode = "6020",
                RegionCode = string.Empty,
                RegionName = string.Empty,

                GpsAltitude = 574,
                GpsLatitudeDegree = 47,
                GpsLatitudeMinute = 15,
                GpsLatitudeSecond = 35.1684m,
                GpsLatitudeCardinalPoint = 'N',
                GpsLongitudeDegree = 11,
                GpsLongitudeMinute = 23,
                GpsLongitudeSecond = 40.5024m,
                GpsLongitudeCardinalPoint = 'E',

                // FK
                //Location=null,
            };
            _dbMain_Context.Addresses.Add(dbMain_addressTLA);
            _dbMain_Context.SaveChanges();

            DbMain_Address dbMain_addressUIBK = new DbMain_Address()
            {
                Id = Guid.NewGuid(),

                Line1 = "Innrain 52d",
                Line2 = "Stock 3",

                City = "Innsbruck",
                State = "Tirol",
                CountryCode = "AT",
                CountryName = "Austria",
                PostalCode = "6020",
                RegionCode = string.Empty,
                RegionName = string.Empty,

                GpsAltitude = 574,
                GpsLatitudeDegree = 47,
                GpsLatitudeMinute = 15,
                GpsLatitudeSecond = 50.8428m,
                GpsLatitudeCardinalPoint = 'N',
                GpsLongitudeDegree = 11,
                GpsLongitudeMinute = 23,
                GpsLongitudeSecond = 3.0876m,
                GpsLongitudeCardinalPoint = 'E',

                // FK
                //Location=null,
            };
            _dbMain_Context.Addresses.Add(dbMain_addressUIBK);
            _dbMain_Context.SaveChanges();
            #endregion

            #region Add Organizations to DBMain
            DbMain_Organization dbMain_organizationTLA = new DbMain_Organization()
            {
                Id = Guid.NewGuid(),

                Name = "Tiroler Landesarchiv",
                Description = "Das Tiroler Landesarchiv (TLA) ist ein öffentliches Archiv des Bundeslandes Tirol und befindet sich in Innsbruck. Es bildet eine Abteilung des Amtes der Tiroler Landesregierung.",
                Acronym = "TLA",

                EMail = "",
                Homepage = "",

                DaytimePhoneNumber = "+43 512 123456789",
                EveningPhoneNumber = "+43 512 123456789",

                Locations = new List<DbMain_Location>()
                {
                    new DbMain_Location()
                    {
                        Id=new Guid(),

                        Name="Headquarter",
                        Address=dbMain_addressTLA,
                        
                        // FK
                        //Project=null,
                        //Organization=null,                        
                    }
                },

                AuthorizationUser = new List<DbMain_Organization_Employee>()
                {
                    new DbMain_Organization_Employee()
                    {
                        Id = Guid.NewGuid(),

                        UserId_Ext = _gertraudZeindlId,
                        Permissions = EmployeeType.Owner,

                        // FK
                        //Project=null,
                    },
                    new DbMain_Organization_Employee()
                    {
                        Id = Guid.NewGuid(),

                        UserId_Ext = _christophHaidacherId,
                        Permissions = EmployeeType.Admin,

                        // FK
                        //Project=null,
                    },
                },
                AuthorizationUserGroup = null,

                NotificationUser = new List<DbMain_Organization_Employee_Notification>()
                {
                    new DbMain_Organization_Employee_Notification()
                    {
                        Id = Guid.NewGuid(),

                        UserIdExt = _gertraudZeindlId,
                        Notifications = new List<Notification>
                        {
                            new Notification() { NotificationType = NotificationType.None, EMail = false, Slack = false, Teams = false, SMS = false, WhatsApp = false, Telegram = false, Gotify = false },
                        },    
                        
                        // FK
                        //Project=null,
                    },
                    new DbMain_Organization_Employee_Notification()
                    {
                        Id = Guid.NewGuid(),

                        UserIdExt = _christophHaidacherId,
                        Notifications = new List<Notification>
                        {
                            new Notification() { NotificationType = NotificationType.None, EMail = false, Slack = false, Teams = false, SMS = false, WhatsApp = false, Telegram = false, Gotify = false },
                        },    
                        
                        // FK
                        //Project=null,
                    },

                },
                NotificationUserGroup = null,

                Contributors = null,

                // FK
                //Project=null
            };
            _dbMain_Context.Organizations.Add(dbMain_organizationTLA);
            _dbMain_Context.SaveChanges();

            DbMain_Organization dbMain_organizationUIBK = new DbMain_Organization()
            {
                Id = Guid.NewGuid(),

                Name = "University Innsbruck (DEA)",
                Description = "",
                Acronym = "UIBK",

                EMail = "",
                Homepage = "",

                DaytimePhoneNumber = "+43 512 123456789",
                EveningPhoneNumber = "+43 512 123456789",

                Locations = new List<DbMain_Location>()
                {
                    new DbMain_Location()
                    {
                        Id=new Guid(),

                        Name="Headquarter",
                        Address=dbMain_addressUIBK,
                    
                        // FK
                        //Project=null,
                        //Organization=null,        
                    }
                },

                AuthorizationUser = new List<DbMain_Organization_Employee>()
                {
                    new DbMain_Organization_Employee()
                    {
                        Id = Guid.NewGuid(),

                        UserId_Ext = _patrickSchoeneggerId,
                        Permissions = EmployeeType.Owner,

                        // FK
                        //Project=null,
                    },

                    new DbMain_Organization_Employee()
                    {
                        Id = Guid.NewGuid(),

                        UserId_Ext = _guenterMuehlbergerId,
                        Permissions = EmployeeType.Admin,

                        // FK
                        //Project=null,
                    }
                },
                AuthorizationUserGroup = null,

                NotificationUser = new List<DbMain_Organization_Employee_Notification>()
                {
                    new DbMain_Organization_Employee_Notification()
                    {
                        Id = Guid.NewGuid(),

                        UserIdExt = _patrickSchoeneggerId,
                        Notifications = new List<Notification>
                        {
                            new Notification() { NotificationType = NotificationType.All, EMail = true, Slack = true, Teams = true, SMS = true, WhatsApp = true, Telegram = true, Gotify = true },
                        },    
                        
                        // FK
                        //Project=null,
                    },
                    new DbMain_Organization_Employee_Notification()
                    {
                        Id = Guid.NewGuid(),

                        UserIdExt = _guenterMuehlbergerId,
                        Notifications = new List<Notification>
                        {
                            new Notification() { NotificationType = NotificationType.None, EMail = false, Slack = false, Teams = false, SMS = false, WhatsApp = false, Telegram = false, Gotify = false },
                        },    
                        
                        // FK
                        //Project=null,
                    },
                },
                NotificationUserGroup = null,

                Contributors = null,

                // FK
                //Project=null
            };
            _dbMain_Context.Organizations.Add(dbMain_organizationUIBK);
            _dbMain_Context.SaveChanges();
            #endregion

            #region Add Project to DBMain
            // Root Verzeichnis (Bucket) ist ProjectId\\DirectoryIds{1...n}\\FileId ...
            DbMain_Project dbMain_project = new DbMain_Project()
            {
                Id = Guid.NewGuid(),

                Name = "Meldezettel",
                Description = "Digitalisierung der Meldezettel von ...",

                //Locations = new List<DbMain_Location>()
                //{
                //    new  DbMain_Location()
                //    {
                //        Id = Guid.NewGuid(),

                //        Name = "Headquarter",

                //        Address = dbMain_addressTLA,

                //        // FK
                //        //Project=null,
                //        //Organization=null
                //    },

                //    new  DbMain_Location()
                //    {
                //        Id = Guid.NewGuid(),

                //        Name = "Universität Innsbruck (DEA)",

                //        Address = dbMain_addressUIBK,

                //        // FK
                //        //Project=null,
                //        //Organization=null
                //    }
                //},

                Organization = dbMain_organizationTLA,
                Contributors = new List<DbMain_Contributors>()
                {
                    new  DbMain_Contributors()
                    {
                        Id = Guid.NewGuid(),

                        Name = "Scanning",
                        Description = "",

                        ContributorType = ContributorType.ServiceProviderScanning,

                        Organization = dbMain_organizationUIBK,

                        // FK
                        //Project=null,
                    }
                },

                Status = ProjectStatus.Created,
                Started = DateTime.UtcNow,
                Finished = DateTime.MinValue,

                WorkflowIdExt = _dbWorkflow_Context.Workflows.FirstOrDefault().Id,
                WorkflowApplyLevel = WorkflowApplyLevel.File,

                ProjectParameter = new DbMain_ProjectParameter()
                {
                    Id = Guid.NewGuid(),

                    Storages = new List<DbMain_ProjectParameterStorage>()
                    {
                        new DbMain_ProjectParameterStorage()
                        {
                            Id = Guid.NewGuid(),

                            DatabaseType = DatabaseType.SQLite,
                            DatabaseFilePath = $"Data Source=\"{Directory.GetCurrentDirectory()}/DBStorageDataMain.db\"",
                            DatabaseConnectionString = string.Empty,

                            StorageType=StorageType.S3,
                            StorageClass = StorageClass.DataMain,
                            StorageTier = StorageTier.Hot,

                            StorageFilePath = string.Empty,

                            StorageS3Endpoint = "s3-clu001.branch31.psgm.at",
                            StorageS3BucketName = string.Empty,
                            StorageS3AccessKey = "xVnwqfNWGqblg1dmA33j",
                            StorageS3SecretKey = "1Xq3G7az3QC3R0wKTBbwNHPNawhA16j1cx0n0a",
                            StorageS3Secure = false,
                            StorageS3Region = "eu-central-1",

                            Url = "https://s3-clu001.branch31.psgm.at:9000",
                            UrlPublic = "https://s3-clu001.psgm.at",
                            
                            // FK
                            //ProjectParameter = null,
                        },
                        new DbMain_ProjectParameterStorage()
                        {
                            Id = Guid.NewGuid(),

                            DatabaseType = DatabaseType.SQLite,
                            DatabaseFilePath = $"Data Source=\"{Directory.GetCurrentDirectory()}/DBStorageDataRaw.db\"",
                            DatabaseConnectionString = string.Empty,

                            StorageType=StorageType.S3,
                            StorageClass = StorageClass.DataRaw,
                            StorageTier = StorageTier.Hot,

                            StorageFilePath = string.Empty,

                            StorageS3Endpoint = "s3-clu100.branch31.psgm.at",
                            StorageS3BucketName = string.Empty,                         // Root Verzeichnis ist OrganizationId\\ProjectId\\DirectiryIds\\FileId
                            StorageS3AccessKey = "lXbKy82C7lIkNRRQXaoq",
                            StorageS3SecretKey = "iuVv7TMZA0Oaky7bgXE6mdejI9Xnu40KGMrFve",
                            StorageS3Secure = false,
                            StorageS3Region = "eu-central-1",

                            Url = "https://s3-clu001.branch31.psgm.at:9000",
                            UrlPublic = "https://s3-clu001.psgm.at",
                            
                            // FK
                            //ProjectParameter = null,
                        },
                        new DbMain_ProjectParameterStorage()
                        {
                            Id = Guid.NewGuid(),

                            DatabaseType = DatabaseType.Undefined,
                            DatabaseFilePath = string.Empty,
                            DatabaseConnectionString = string.Empty,

                            StorageType=StorageType.S3,
                            StorageClass = StorageClass.DataRawThumbnail,
                            StorageTier = StorageTier.Hot,

                            StorageFilePath = string.Empty,

                            StorageS3Endpoint = "s3-clu101.branch31.psgm.at",
                            StorageS3BucketName = string.Empty,                         // Root Verzeichnis ist OrganizationId\\ProjectId\\DirectiryIds\\FileId
                            StorageS3AccessKey = "Mq5A3CCxUMcUxW9xP0Nw",
                            StorageS3SecretKey = "YCVcvjFidGNneQVPTJ0LUhDM1Nxj9Y5fD5RMCh",
                            StorageS3Secure = false,
                            StorageS3Region = "eu-central-1",

                            Url = "https://s3-clu003.branch31.psgm.at:9000",
                            UrlPublic = "https://s3-clu003.psgm.at",

                            // FK
                            //ProjectParameter = null,
                        },
                        new DbMain_ProjectParameterStorage()
                        {
                            Id = Guid.NewGuid(),

                            DatabaseType = DatabaseType.SQLite,
                            DatabaseFilePath = $"Data Source=\"{Directory.GetCurrentDirectory()}/DBStorageData.db\"",
                            DatabaseConnectionString = string.Empty,

                            StorageType=StorageType.S3,
                            StorageClass = StorageClass.Data,
                            StorageTier = StorageTier.Hot,

                            StorageFilePath = string.Empty,

                            StorageS3Endpoint = "s3-clu102.branch31.psgm.at",
                            StorageS3BucketName = string.Empty,                         // Root Verzeichnis ist OrganizationId\\ProjectId\\DirectiryIds\\FileId
                            StorageS3AccessKey = "cIm3AkV6LpnR47v7vP68",
                            StorageS3SecretKey = "LcBxrCot4ekVhNXOQ5pF6cXakToEilbEmXpX3G",
                            StorageS3Secure = false,
                            StorageS3Region = "eu-central-1",

                            Url = "https://s3-clu002.branch31.psgm.at:9000",
                            UrlPublic = "https://s3-clu002.psgm.at",

                            // FK
                            //ProjectParameter = null,
                        },
                        new DbMain_ProjectParameterStorage()
                        {
                            Id = Guid.NewGuid(),

                            DatabaseType = DatabaseType.Undefined,
                            DatabaseFilePath = string.Empty,
                            DatabaseConnectionString = string.Empty,

                            StorageType=StorageType.S3,
                            StorageClass = StorageClass.DataThumbnail,
                            StorageTier = StorageTier.Hot,

                            StorageFilePath = string.Empty,

                            StorageS3Endpoint = "s3-clu103.branch31.psgm.at",
                            StorageS3BucketName = string.Empty,                         // Root Verzeichnis ist OrganizationId\\ProjectId\\DirectiryIds\\FileId
                            StorageS3AccessKey = "iPM6Iklm5dcyJVq9z3Vr",
                            StorageS3SecretKey = "jgn0MHMHgMg9MtldqVVCPuNU2ahOVDdQpvm4g9",
                            StorageS3Secure = false,
                            StorageS3Region = "eu-central-1",

                            Url = "https://s3-clu003.branch31.psgm.at:9000",
                            UrlPublic = "https://s3-clu003.psgm.at",

                            // FK
                            //ProjectParameter = null,
                        },
                    }

                    // FK
                    //Project=null,
                },

                AuthorizationUser = new List<DbMain_Project_Authorization_User>()
                {
                    new DbMain_Project_Authorization_User()
                    {
                        Id = Guid.NewGuid(),

                        UserIdExt = _gertraudZeindlId,
                        Permissions = EmployeeType.Owner,

                        // FK
                        //Project=null,
                    },
                    new DbMain_Project_Authorization_User()
                    {
                        Id = Guid.NewGuid(),

                        UserIdExt = _christophHaidacherId,
                        Permissions = EmployeeType.Admin,

                        // FK
                        //Project=null,
                    },
                    new DbMain_Project_Authorization_User()
                    {
                        Id = Guid.NewGuid(),

                        UserIdExt = _patrickSchoeneggerId,
                        Permissions = EmployeeType.ServiceProviderInfrastructure,

                        // FK
                        //Project=null,
                    },

                    new DbMain_Project_Authorization_User()
                    {
                        Id = Guid.NewGuid(),

                        UserIdExt = _guenterMuehlbergerId,
                        Permissions = EmployeeType.ServiceProviderInfrastructure,

                        // FK
                        //Project=null,
                    }
                },
                AuthorizationUserGroup = null,

                NotificationUser = new List<DbMain_Project_Notification_User>()
                {
                    new DbMain_Project_Notification_User()
                    {
                        Id = Guid.NewGuid(),

                        UserIdExt = _gertraudZeindlId,
                        Notifications = new List<Notification>
                        {
                            new Notification() { NotificationType = NotificationType.None, EMail = false, Slack = false, Teams = false, SMS = false, WhatsApp = false, Telegram = false, Gotify = false },
                        }, 
                        
                        // FK
                        //Project=null,
                    },
                    new DbMain_Project_Notification_User()
                    {
                        Id = Guid.NewGuid(),

                        UserIdExt = _christophHaidacherId,
                        Notifications = new List<Notification>
                        {
                            new Notification() { NotificationType = NotificationType.None, EMail = false, Slack = false, Teams = false, SMS = false, WhatsApp = false, Telegram = false, Gotify = false },
                        },    
                        
                        // FK
                        //Project=null,
                    },
                    new DbMain_Project_Notification_User()
                    {
                        Id = Guid.NewGuid(),

                        UserIdExt = _patrickSchoeneggerId,
                        Notifications = new List<Notification>
                        {
                            new Notification() { NotificationType = NotificationType.All, EMail = true, Slack = true, Teams = true, SMS = true, WhatsApp = true, Telegram = true, Gotify = true },
                        },    
                        
                        // FK
                        //Project=null,
                    },
                    new DbMain_Project_Notification_User()
                    {
                        Id = Guid.NewGuid(),

                        UserIdExt = _guenterMuehlbergerId,
                        Notifications = new List<Notification>
                        {
                            new Notification() { NotificationType = NotificationType.All, EMail = true, Slack = false, Teams = false, SMS = false, WhatsApp = false, Telegram = false, Gotify = false },
                        },    

                        // FK
                        //Project=null,
                    },
                },
                NotificationUserGroup = null,

                Machines_Ext = new List<Guid>()
                {
                    _machineId
                },

                // FK
            };
            _dbMain_Context.Projects.Add(dbMain_project);
            _dbMain_Context.SaveChanges();
            #endregion

            //#region Add Workflow to Project
            //DbWorkflow_Workflow dBWorkflow_Workflow = _dbWorkflow_Context.Workflows.FirstOrDefault();

            //dbMain_project.WorkflowIdExt = dBWorkflow_Workflow.Id;

            //_dbMain_Context.Update(dbMain_project);
            //_dbMain_Context.SaveChanges();
            //#endregion
        }

        private void btnConnectToStorageDatabase_Click(object sender, RoutedEventArgs e)
        {
            List<DbMain_Project> projects = _dbMain_Context.Projects.Where(p => p.Machines_Ext.Contains(_machineId))
                                                        .Include(p => p.ProjectParameter)
                                                           .ThenInclude(p => p.Storages)
                                                        .Include(p => p.Organization)
                                                        .Include(p => p.Contributors)
                                                        //.Include(p => p.Locations)
                                                        .ToList();

            _dbStorage_Data_Context.ConnectionStringSQLite = projects[0].ProjectParameter.Storages.Where(p => p.StorageClass == StorageClass.Data).FirstOrDefault().DatabaseFilePath;
            _dbStorage_DataRaw_Context.ConnectionStringSQLite = projects[0].ProjectParameter.Storages.Where(p => p.StorageClass == StorageClass.DataRaw).FirstOrDefault().DatabaseFilePath;

            _dbStorage_Data_Context.DatabaseType = projects[0].ProjectParameter.Storages.Where(p => p.StorageClass == StorageClass.Data).FirstOrDefault().DatabaseType;
            _dbStorage_DataRaw_Context.DatabaseType = projects[0].ProjectParameter.Storages.Where(p => p.StorageClass == StorageClass.DataRaw).FirstOrDefault().DatabaseType;

            _dbStorage_Data_Context.Database.EnsureCreated();
            _dbStorage_DataRaw_Context.Database.EnsureCreated();

            _dbStorage_Data_Context.Database.OpenConnection();
            _dbStorage_DataRaw_Context.Database.OpenConnection();
        }

        private void btnSetupStorageAndStorageDb_Click(object sender, RoutedEventArgs e)
        {
            DbMain_Project projects = _dbMain_Context.Projects.Where(p => p.Machines_Ext.Contains(_machineId))
                                                               .Include(p => p.ProjectParameter)
                                                          .Include(p => p.Organization)
                                                               .Include(p => p.Contributors)
                                                               //.Include(p => p.Locations)
                                                               .FirstOrDefault();

            #region Add main directory (ProjectId) to DbStorage, DbStorageRaw & DbStorageThumbnails
            DbStorage_RootDirectory dbStorage_directoryMain = new DbStorage_RootDirectory()
            {
                Id = projects.Id,
                Suffix = string.Empty,

                Name = projects.Name,
                Description = projects.Description,

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

                RootDirectoryParameter = null,

                JobsIdExt = null,
                WorkflowItemsExt = null,
                BackupsExt = null,

                // FK                
            };
            _dbStorage_Data_Context.RootDirectories.Add(dbStorage_directoryMain);
            _dbStorage_Data_Context.SaveChanges();
            _dbStorage_DataRaw_Context.RootDirectories.Add(dbStorage_directoryMain);
            _dbStorage_DataRaw_Context.SaveChanges();
            #endregion

            #region Add subdirectory 1 to main directory (ProjectId) to DbStorage, DbStorageRaw & DbStorageThumbnails
            DbStorage_SubDirectory dbStorage_subDirectory1 = new DbStorage_SubDirectory()
            {
                Id = Guid.NewGuid(),
                Suffix = string.Empty,

                Name = "001_A-Abz",
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

                // FK 
                RootDirectory = dbStorage_directoryMain,
                //ParentSubDirectory = null,
            };
            _dbStorage_Data_Context.SubDirectories.Add(dbStorage_subDirectory1);
            _dbStorage_Data_Context.SaveChanges();
            _dbStorage_DataRaw_Context.SubDirectories.Add(dbStorage_subDirectory1);
            _dbStorage_DataRaw_Context.SaveChanges();
            #endregion

            #region Add subdirectory 2 to main directory (ProjectId) to DbStorage, DbStorageRaw & DbStorageThumbnails
            DbStorage_SubDirectory dbStorage_subDirectory2 = new DbStorage_SubDirectory()
            {
                Id = Guid.NewGuid(),
                Suffix = string.Empty,

                Name = "002_Ala-Adler",
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

                // FK 
                RootDirectory = dbStorage_directoryMain,
                //ParentSubDirectory = null,
            };
            _dbStorage_Data_Context.SubDirectories.Add(dbStorage_subDirectory2);
            _dbStorage_Data_Context.SaveChanges();
            _dbStorage_DataRaw_Context.SubDirectories.Add(dbStorage_subDirectory2);
            _dbStorage_DataRaw_Context.SaveChanges();
            #endregion

            #region Add subdirectory 3 to main directory (ProjectId) to DbStorage, DbStorageRaw & DbStorageThumbnails
            DbStorage_SubDirectory dbStorage_subDirectory3 = new DbStorage_SubDirectory()
            {
                Id = Guid.NewGuid(),
                Suffix = string.Empty,

                Name = "003_Adlerh-Alber",
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

                // FK 
                RootDirectory = dbStorage_directoryMain,
                //ParentSubDirectory = null,
            };
            _dbStorage_Data_Context.SubDirectories.Add(dbStorage_subDirectory3);
            _dbStorage_Data_Context.SaveChanges();
            _dbStorage_DataRaw_Context.SubDirectories.Add(dbStorage_subDirectory3);
            _dbStorage_DataRaw_Context.SaveChanges();
            #endregion

            #region Add subdirectory 4 to main directory (ProjectId) to DbStorage, DbStorageRaw & DbStorageThumbnails
            DbStorage_SubDirectory dbStorage_subDirectory4 = new DbStorage_SubDirectory()
            {
                Id = Guid.NewGuid(),
                Suffix = string.Empty,

                Name = "004_Albera-Alles",
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

                // FK 
                RootDirectory = dbStorage_directoryMain,
                //ParentSubDirectory = null,
            };
            _dbStorage_Data_Context.SubDirectories.Add(dbStorage_subDirectory4);
            _dbStorage_Data_Context.SaveChanges();
            _dbStorage_DataRaw_Context.SubDirectories.Add(dbStorage_subDirectory4);
            _dbStorage_DataRaw_Context.SaveChanges();
            #endregion       
        }

        private void btnDbReadInfo_Click(object sender, RoutedEventArgs e)
        {
            List<DbMain_Project> projects = _dbMain_Context.Projects.Where(p => p.Machines_Ext.Contains(_machineId))
                                                                    .Include(p => p.ProjectParameter)
                                                                    .Include(p => p.Organization)
                                                                    .Include(p => p.Contributors)
                                                                    //.Include(p => p.Locations)
                                                                    .ToList();

            List<DbStorage_RootDirectory> storage = _dbStorage_Data_Context.RootDirectories.Where(p => p.Id == projects.FirstOrDefault().Id)
                                                                                        .Include(p => p.SubDirectories)
                                                                                            .ThenInclude(d => d.Files)
                                                                                                .ThenInclude(f => f.QrCode)
                                                                                        .Include(p => p.Files)
                                                                                            .ThenInclude(f => f.QrCode)
                                                                                        .ToList();

            cmbOrganization.ItemsSource = projects.Select(p => p.Organization.Name).ToList();
            cmbOrganization.SelectedIndex = 0;

            cmbProjects.ItemsSource = projects.Select(p => p.Name).ToList();
            cmbProjects.SelectedIndex = 0;

            cmbDirectory.ItemsSource = storage.SelectMany(p => p.SubDirectories).Select(d => d.Name).ToList();
            cmbDirectory.SelectedIndex = 0;
            var asds = cmbDirectory.SelectedValue;

            //#region
            //List<DirectoryItem> directoryItems = new List<DirectoryItem>();

            //foreach (DBStorage_SubDirectory directory in storage.First().SubDirectories)
            //{
            //    DirectoryItem directoryItem = new DirectoryItem
            //    {
            //        Name = directory.Name,
            //        Id = directory.DirectoryId
            //    };

            //    directoryItems.Add(directoryItem);
            //}

            //cmbDirectory.ItemsSource = directoryItems;
            //cmbDirectory.SelectedIndex = 0;

            //// Zugriff auf den ausgewählten DirectoryItem
            //DirectoryItem selectedDirectory = cmbDirectory.SelectedItem as DirectoryItem;
            //if (selectedDirectory != null)
            //{
            //    Guid selectedDirectoryId = selectedDirectory.Id;
            //    // Verwende die selectedDirectoryId, um das entsprechende Verzeichnis in der Datenbank zu finden
            //}
            //#endregion

            //#region
            //List<FolderItem> folderItems = new List<FolderItem>();

            //foreach (DBStorage_SubDirectory directory in storage.First().SubDirectories)
            //{
            //    FolderItem folderItem = new FolderItem
            //    {
            //        Name = directory.Name,
            //        //Size=directory.Size,
            //        //LastModified=directory.LastModified
            //    };

            //    folderItems.Add(folderItem);
            //}

            //grdFolder.ItemsSource = folderItems;
            //#endregion

            //#region
            //List<FileItem> fileItems = new List<FileItem>();

            //foreach (var filee in storage.First().SubDirectories.FirstOrDefault().Files.ToList())
            //{
            //    FileItem fileItem = new FileItem
            //    {
            //        Name = filee.Name,
            //        //Size=directory.Size,
            //        //LastModified=directory.LastModified
            //    };

            //    fileItems.Add(fileItem);
            //}

            //fileItems.Sort((x, y) => x.Name.CompareTo(y.Name));

            //Dispatcher.Invoke(() => { grdFile.ItemsSource = fileItems; });
            //#endregion
        }









        private async void btnSetupStorage_Click(object sender, RoutedEventArgs e)
        {
            IMinioClient minioClient;

            string endpoint = string.Empty;
            string accessKey = string.Empty;
            string secretKey = string.Empty;
            bool secure = true;

            string bucketName = string.Empty;
            string region = string.Empty;
            string objectName = string.Empty;

            string filePath = string.Empty;
            string contentType = string.Empty;

            List<DbMain_Project> projects = _dbMain_Context.Projects.Where(p => p.Machines_Ext.Contains(_machineId))
                                                                    .Include(p => p.ProjectParameter)
                                                                        .ThenInclude(p => p.Storages)
                                                                    .Include(p => p.Organization)
                                                                    .Include(p => p.Contributors)
                                                                    //.Include(p => p.Locations)
                                                                    .ToList();
            DbMain_ProjectParameterStorage config;

            #region DBStorageData
            config = projects[0].ProjectParameter.Storages.Where(p => p.StorageClass == StorageClass.Data).FirstOrDefault();
            bucketName = projects[0].Id.ToString();

            endpoint = config.StorageS3Endpoint;
            accessKey = config.StorageS3AccessKey;
            secretKey = config.StorageS3SecretKey;
            secure = config.StorageS3Secure;
            region = config.StorageS3Region;

            //bucketName = string.Empty;
            //objectName = string.Empty;

            filePath = string.Empty;
            contentType = string.Empty;

            // Initialize the client with access credentials.
            minioClient = new MinioClient().WithEndpoint(endpoint)
                                            .WithCredentials(accessKey, secretKey)
                                            .WithSSL(secure)
                                            .WithRegion(region)
                                            .Build();

            #region List and remove all buckets
            try
            {
                var list = await minioClient.ListBucketsAsync();

                if (list.Buckets is not null)
                {
                    if (list.Buckets.Count > 0)
                    {
                        foreach (Bucket bucket in list.Buckets)
                        {
                            Log.Information("Bucket: " + bucket.Name + " " + bucket.CreationDateDateTime);

                            List<Tuple<string, string>> objects1 = await PSGM.Helper.ListObjectsWithVersions.Run(minioClient, bucket.Name, null, true);

                            PSGM.Helper.RemoveObjectsWithVersions.Run(minioClient, bucket.Name, objects1).Wait();

                            List<Tuple<string, string>> objects2 = await PSGM.Helper.ListObjectsWithVersions.Run(minioClient, bucket.Name, null, false);
                            PSGM.Helper.RemoveObjectsWithVersions.Run(minioClient, bucket.Name, objects2).Wait();

                            List<string> objects3 = await PSGM.Helper.ListObjectsWithoutVersion.Run(minioClient, bucket.Name, null, false);
                            PSGM.Helper.RemoveObjectsWithoutVersions.Run(minioClient, bucket.Name, objects3).Wait();

                            PSGM.Helper.RemoveBucket.Run(minioClient, bucket.Name).Wait();
                        }
                    }
                }
            }
            catch (MinioException ex)
            {
                Debug.WriteLine("Error occurred: " + ex);
            }
            #endregion

            #region Add project bucket
            try
            {
                bool found = await minioClient.BucketExistsAsync(new BucketExistsArgs().WithBucket(bucketName));

                if (found)
                {
                    Debug.WriteLine($"{bucketName} already exists");
                }
                else
                {
                    await PSGM.Helper.MakeBucket.Run(minioClient, bucketName, region);
                }
            }
            catch (MinioException ex)
            {
                Debug.WriteLine("Error occurred: " + ex);
            }
            #endregion
            #endregion

            #region DBStorageDataRaw
            config = projects[0].ProjectParameter.Storages.Where(p => p.StorageClass == StorageClass.DataRaw).FirstOrDefault();
            bucketName = projects[0].Id.ToString();

            endpoint = config.StorageS3Endpoint;
            accessKey = config.StorageS3AccessKey;
            secretKey = config.StorageS3SecretKey;
            secure = config.StorageS3Secure;
            region = config.StorageS3Region;

            //bucketName = string.Empty;
            //objectName = string.Empty;

            filePath = string.Empty;
            contentType = string.Empty;

            // Initialize the client with access credentials.
            minioClient = new MinioClient().WithEndpoint(endpoint)
                                             .WithCredentials(accessKey, secretKey)
                                             .WithSSL(secure)
                                             .WithRegion(region)
                                             .Build();

            #region List and remove all buckets
            try
            {
                var list = await minioClient.ListBucketsAsync();

                if (list.Buckets is not null)
                {
                    if (list.Buckets.Count > 0)
                    {
                        foreach (Bucket bucket in list.Buckets)
                        {
                            Log.Information("Bucket: " + bucket.Name + " " + bucket.CreationDateDateTime);

                            List<Tuple<string, string>> objects1 = await PSGM.Helper.ListObjectsWithVersions.Run(minioClient, bucket.Name, null, true);

                            PSGM.Helper.RemoveObjectsWithVersions.Run(minioClient, bucket.Name, objects1).Wait();

                            List<Tuple<string, string>> objects2 = await PSGM.Helper.ListObjectsWithVersions.Run(minioClient, bucket.Name, null, false);
                            PSGM.Helper.RemoveObjectsWithVersions.Run(minioClient, bucket.Name, objects2).Wait();

                            List<string> objects3 = await PSGM.Helper.ListObjectsWithoutVersion.Run(minioClient, bucket.Name, null, false);
                            PSGM.Helper.RemoveObjectsWithoutVersions.Run(minioClient, bucket.Name, objects3).Wait();

                            PSGM.Helper.RemoveBucket.Run(minioClient, bucket.Name).Wait();
                        }
                    }
                }
            }
            catch (MinioException ex)
            {
                Debug.WriteLine("Error occurred: " + ex);
            }
            #endregion

            #region Add project bucket
            try
            {
                bool found = await minioClient.BucketExistsAsync(new BucketExistsArgs().WithBucket(bucketName));

                if (found)
                {
                    Debug.WriteLine($"{bucketName} already exists");
                }
                else
                {
                    await PSGM.Helper.MakeBucket.Run(minioClient, bucketName, region);
                }
            }
            catch (MinioException ex)
            {
                Debug.WriteLine("Error occurred: " + ex);
            }
            #endregion
            #endregion

            #region DBStorageDataThumbnail
            config = projects[0].ProjectParameter.Storages.Where(p => p.StorageClass == StorageClass.DataThumbnail).FirstOrDefault();
            bucketName = projects[0].Id.ToString();

            endpoint = config.StorageS3Endpoint;
            accessKey = config.StorageS3AccessKey;
            secretKey = config.StorageS3SecretKey;
            secure = config.StorageS3Secure;
            region = config.StorageS3Region;

            //bucketName = string.Empty;
            //objectName = string.Empty;

            filePath = string.Empty;
            contentType = string.Empty;

            // Initialize the client with access credentials.
            minioClient = new MinioClient().WithEndpoint(endpoint)
                                            .WithCredentials(accessKey, secretKey)
                                            .WithSSL(secure)
                                            .WithRegion(region)
                                            .Build();

            #region List and remove all buckets
            try
            {
                var list = await minioClient.ListBucketsAsync();

                if (list.Buckets is not null)
                {
                    if (list.Buckets.Count > 0)
                    {
                        foreach (Bucket bucket in list.Buckets)
                        {
                            Log.Information("Bucket: " + bucket.Name + " " + bucket.CreationDateDateTime);

                            List<Tuple<string, string>> objects1 = await PSGM.Helper.ListObjectsWithVersions.Run(minioClient, bucket.Name, null, true);

                            PSGM.Helper.RemoveObjectsWithVersions.Run(minioClient, bucket.Name, objects1).Wait();

                            List<Tuple<string, string>> objects2 = await PSGM.Helper.ListObjectsWithVersions.Run(minioClient, bucket.Name, null, false);
                            PSGM.Helper.RemoveObjectsWithVersions.Run(minioClient, bucket.Name, objects2).Wait();

                            List<string> objects3 = await PSGM.Helper.ListObjectsWithoutVersion.Run(minioClient, bucket.Name, null, false);
                            PSGM.Helper.RemoveObjectsWithoutVersions.Run(minioClient, bucket.Name, objects3).Wait();

                            PSGM.Helper.RemoveBucket.Run(minioClient, bucket.Name).Wait();
                        }
                    }
                }
            }
            catch (MinioException ex)
            {
                Debug.WriteLine("Error occurred: " + ex);
            }
            #endregion

            #region Add project bucket
            try
            {
                bool found = await minioClient.BucketExistsAsync(new BucketExistsArgs().WithBucket(bucketName));

                if (found)
                {
                    Debug.WriteLine($"{bucketName} already exists");
                }
                else
                {
                    await PSGM.Helper.MakeBucket.Run(minioClient, bucketName, region);
                }
            }
            catch (MinioException ex)
            {
                Debug.WriteLine("Error occurred: " + ex);
            }
            #endregion
            #endregion

            // Nicht nötig, da Bucket das Bucket die unterste Ebene in der S3 Storage bildet und somit das Bucket mit der Project ID erstellt wird
            //#region Create organization
            //try
            //{
            //    bool found=await minioClient.BucketExistsAsync(new BucketExistsArgs().WithBucket(bucketName));
            //    if (found)
            //    {
            //        Debug.WriteLine($"{bucketName} already exists");
            //    }
            //    else
            //    {
            //        await minioClient.MakeBucketAsync(new MakeBucketArgs().WithBucket(bucketName));
            //        Debug.WriteLine($"{bucketName} is created successfully");
            //    }
            //}
            //catch (MinioException ex)
            //{
            //    Debug.WriteLine("Error occurred: " + ex);
            //}
            //#endregion

            //#region List all buckets
            //try
            //{
            //    var list = await minioClient.ListBucketsAsync();

            //    foreach (Bucket bucket in list.Buckets)
            //    {
            //        Debug.WriteLine(bucket.Name + " " + bucket.CreationDateDateTime);
            //    }
            //}
            //catch (MinioException ex)
            //{
            //    Debug.WriteLine("Error occurred: " + ex);
            //}
            //#endregion
        }

        private async void btnUploadFilesToBucket_Click(object sender, RoutedEventArgs e)
        {
#if DEBUG
            Stopwatch swProcessingTime = new Stopwatch();
            swProcessingTime.Start();
#endif

            IMinioClient minioClient;

            string endpoint = string.Empty;
            string accessKey = string.Empty;
            string secretKey = string.Empty;
            bool secure = true;

            string bucketName = string.Empty;
            string location = string.Empty;
            string objectName = string.Empty;

            string filePath = string.Empty;
            string contentType = string.Empty;

            FileInfo fileInfo;

            List<DbMain_Project> projects = _dbMain_Context.Projects.Where(p => p.Machines_Ext.Contains(_machineId))
                                                                    .Include(p => p.ProjectParameter)
                                                                    .Include(p => p.Organization)
                                                                    .Include(p => p.Contributors)
                                                                    //.Include(p => p.Locations)
                                                                    .ToList();

            List<DbStorage_RootDirectory> storage = _dbStorage_Data_Context.RootDirectories.Where(p => p.Id == projects.FirstOrDefault().Id)
                                                                                            .Include(p => p.SubDirectories)
                                                                                                .ThenInclude(d => d.Files)
                                                                                                    .ThenInclude(f => f.QrCode)
                                                                                            .Include(p => p.Files)
                                                                                                .ThenInclude(f => f.QrCode)
                                                                                            .ToList();

            #region DBStorage
            endpoint = "10.31.40.110:9000";                         // s3-clu001.branch31.psgm.at
            accessKey = "IUFyD1CjieWTrQIbANfP";
            secretKey = "p4ekYNxSBRnqbouJIXkMJU1C3Tm2wrqGDbFeABbd";
            secure = false;

            bucketName = string.Empty;
            location = "eu-central-1";
            objectName = string.Empty;

            filePath = Directory.GetCurrentDirectory() + "\\..\\..\\..\\Files\\1_15000_Index2.bmp";
            contentType = "image/bmp";

            // Initialize the client with access credentials.
            minioClient = new MinioClient().WithEndpoint(endpoint)
                                            .WithCredentials(accessKey, secretKey)
                                            .WithSSL(secure)
                                            .Build();

            string folderPath = "S:\\000_Verarbeitet\\001_A-Abz\\darktable"; // Ersetze "Pfad_zum_Ordner" durch den tatsächlichen Pfad zu deinem Ordner
            string[] files = Directory.GetFiles(folderPath);
            int i = 0;

            foreach (string file in files)
            {
                Debug.WriteLine(file);
                fileInfo = new FileInfo(file);

                #region Add file to database
                DbStorage_File fileDb = new DbStorage_File()
                {
                    Id = Guid.NewGuid(),
                    Suffix = string.Empty,

                    RawFileIds = null,

                    Name = $"Image{i}",
                    Description = string.Empty,

                    ObjectExtension = FileExtension.JPEG,
                    ObjectSize = fileInfo.Length,

                    SubDirectory = storage.First().SubDirectories.FirstOrDefault(),
                    RootDirectory = null,

                    AuthorizationUsers = null,
                    AuthorizationUserGroups = null,

                    NotificationUser = null,
                    NotificationUserGroup = null,

                    StorageObjectName = string.Empty,
                    StorageObjectUrlPublic = string.Empty,

                    FileParameter = null,

                    QrCode = null,

                    DeviceIdExt = Guid.Empty,
                    MachineIdExt = Guid.Empty,
                    JobsIdExt = null,
                    WorkflowItemsExt = null,
                    BackupsExt = null,

                    //// Not used done automatically, if parameters " DatabaseSessionParameter_UserId, DatabaseSessionParameter_MachienId, DatabaseSessionParameter_SoftwareId" are set
                    //CreatedDateTime = DateTime.UtcNow,
                    //CreatedByUserIdExt = _patrickSchoenegger,
                    //ModifiedDateTime = DateTime.MinValue,
                    //ModifiedByUserIdExt = Guid.Empty,
                    //LastChanges = string.Empty,


                    // FK                    
                };
                #endregion

                #region Upload file to S3 bucket
                bucketName = projects.FirstOrDefault().Id.ToString();
                objectName = fileDb.SubDirectoryId + "/" + fileDb.Id + ".bmp";



                Image image = Image.FromFile(file);

                // Resize image
                int newWidth = 512;
                int newHeight = (int)(((double)image.Height / image.Width) * newWidth);
                Bitmap resizedImage = new Bitmap(newWidth, newHeight);
                using (Graphics graphics = Graphics.FromImage(resizedImage))
                {
                    graphics.DrawImage(image, 0, 0, newWidth, newHeight);
                }











                // Erstelle einen MemoryStream
                MemoryStream stream = new MemoryStream();

                // Speichere das Bitmap im MemoryStream im gewünschten Format (z.B. JPEG)
                resizedImage.Save(stream, ImageFormat.Jpeg);

                // Konvertiere den MemoryStream in ein Byte-Array
                byte[] byteArray = stream.ToArray();

                // Schließe den MemoryStream
                stream.Close();





                try
                {
                    PutObjectArgs putObjectArgs = new PutObjectArgs().WithBucket(bucketName)
                                                                        .WithObject(objectName)
                                                                        //.WithFileName(filePath)
                                                                        .WithStreamData(new MemoryStream(byteArray))
                                                                        .WithObjectSize(byteArray.Length)
                                                                        .WithContentType(contentType);

                    //minioClient.PutObjectAsync(putObjectArgs);
                    await minioClient.PutObjectAsync(putObjectArgs).ConfigureAwait(false);

                    _dbStorage_Data_Context.Files.Add(fileDb);

                    Debug.WriteLine($"Uploaded object Nr:{i} Name:{objectName} to Bucket:{bucketName}");
                }
                catch (MinioException ex)
                {
                    Debug.WriteLine("Error occurred: " + ex);
                }
                #endregion


                // Du kannst den Stream auch weiterverwenden oder schließen, wenn du ihn nicht mehr benötigst
                stream.Close();


                i++;
            }

            _dbStorage_Data_Context.SaveChanges();



            //for (int i = 0; i < 10; i++)
            //{
            //    fileInfo = new FileInfo(filePath);

            //    #region Add file to database
            //    DbStorage_File file = new DbStorage_File()
            //    {
            //        Id = Guid.NewGuid(),

            //        Name = $"Image{i}",
            //        Description = string.Empty,

            //        Extension = FileExtension.JPEG,
            //        FileSize = fileInfo.Length,

            //        SubDirectory = storage.First().SubDirectories.FirstOrDefault(),
            //        RootDirectory = null,

            //        AuthorizedUsersExt = null,
            //        AuthorizedUserGroupsExt = null,

            //        StorageType = StorageType.Inherited,
            //        StoragePath = string.Empty,
            //        StorageUrl = string.Empty,
            //        StorageUrlPublic = string.Empty,

            //        StorageEndpoint = string.Empty,
            //        StorageBucketName = string.Empty,
            //        StorageAccessKey = string.Empty,
            //        StorageSecretKey = string.Empty,
            //        StorageSecure = true,
            //        StorageLocation = string.Empty,

            //        QrCode = null,

            //        DeviceIdExt = Guid.Empty,
            //        MachineIdExt = Guid.Empty,
            //        JobIdExt = Guid.Empty,
            //        WorkflowItemExt = Guid.Empty,

            //        CreatedDateTime = DateTime.UtcNow,
            //        CreatedUserIdExt = _patrickSchoenegger,

            //        UpdatedLastDateTime = null,
            //        UpdatedLastUserIdExt = Guid.Empty,

            //        LastChanges = string.Empty,

            //        // FK
            //    };
            //    #endregion

            //    #region Upload file to S3 bucket
            //    bucketName = projects.FirstOrDefault().Id.ToString();
            //    objectName = file.SubDirectoryId + "/" + file.Id + ".bmp";

            //    try
            //    {
            //        PutObjectArgs putObjectArgs = new PutObjectArgs().WithBucket(bucketName)
            //                                                            .WithObject(objectName)
            //                                                            .WithFileName(filePath)
            //                                                            .WithContentType(contentType);

            //        //minioClient.PutObjectAsync(putObjectArgs);
            //        await minioClient.PutObjectAsync(putObjectArgs).ConfigureAwait(false);

            //        _dbStorageContext.Files.Add(file);

            //        Debug.WriteLine($"Uploaded object Nr:{i} Name:{objectName} to Bucket:{bucketName}");
            //    }
            //    catch (MinioException ex)
            //    {
            //        Debug.WriteLine("Error occurred: " + ex);
            //    }
            //    #endregion
            //}
            //_dbStorageContext.SaveChanges();
            #endregion

            var fileAuditLog = _dbStorage_Data_Context.File_AuditLog.Where(f => f.SourceId == storage.First().SubDirectories.FirstOrDefault().Files.FirstOrDefault().Id).FirstOrDefault();
            DbStorage_File ads = JsonConvert.DeserializeObject<DbStorage_File>(fileAuditLog.Changes);
            DbStorage_File adasdasds = fileAuditLog.GetChanges();
            #region

            List<FileItem> fileItems = new List<FileItem>();

            foreach (var filee in storage.First().SubDirectories.FirstOrDefault().Files.ToList())
            {
                FileItem fileItem = new FileItem
                {
                    Name = filee.Name,
                    Size = filee.ObjectSize / 1024 / 1024,
                    LastModified = filee.CreatedDateTimeAutoFill
                };

                fileItems.Add(fileItem);
            }

            fileItems.Sort((x, y) => x.Name.CompareTo(y.Name));

            Dispatcher.Invoke(() => { grdFile.ItemsSource = fileItems; });
            #endregion

#if DEBUG
            Log.Debug($"Upload file processing time: {swProcessingTime.ElapsedMilliseconds}ms ...");
            swProcessingTime.Stop();
#endif
        }








        private async void btnVisionHDR_Click(object sender, RoutedEventArgs e)
        {
#if DEBUG
            Stopwatch swProcessingTime = new Stopwatch();
            swProcessingTime.Start();
#endif

            Workflow workflow;

            List<DbMain_Project> projects = _dbMain_Context.Projects.Where(p => p.Machines_Ext.Contains(_machineId))
                                                                      .Include(p => p.ProjectParameter)
                                                                      .Include(p => p.Organization)
                                                                      .Include(p => p.Contributors)
                                                                      //.Include(p => p.Locations)
                                                                      .ToList();

            List<DbStorage_RootDirectory> storage = _dbStorage_Data_Context.RootDirectories.Where(p => p.Id == projects.FirstOrDefault().Id)
                                                                                            .Include(p => p.SubDirectories)
                                                                                                .ThenInclude(d => d.Files)
                                                                                                    .ThenInclude(f => f.QrCode)
                                                                                            .Include(p => p.Files)
                                                                                                .ThenInclude(f => f.QrCode)
                                                                                            .ToList();

            DbMain_Project projectSelected = projects.FirstOrDefault();                                                         // To specified (Select box)
            DbStorage_SubDirectory? dataSubdirectorySelected = storage.FirstOrDefault().SubDirectories.FirstOrDefault();            // To specified (Select box)

            workflow = new Workflow(projectSelected.WorkflowIdExt, _patrickSchoeneggerId, _machineId, _softwareId, _dbMain_Context.ConnectionStringSQLite, _dbMain_Context.DatabaseType, projectSelected.Id, _dbWorkflow_Context.ConnectionStringSQLite, _dbWorkflow_Context.DatabaseType);

            #region Grab image (Due to the reason that the camera is not connected to the computer, the images are loaded from the hard drive)

            //string directoryPath = "S:\\000_Verarbeitet\\001_A-Abz\\original";
            string directoryPath = "C:\\WorkDir_RoboticScanner\\000_VerarbeitetCopy\\001_A-Abz\\original";
            string[] directories = Directory.GetDirectories(directoryPath);

            List<ImageHelper> imagesHelper = new List<ImageHelper>();
            List<Bitmap> imagesHelperBitmap = new List<Bitmap>();

            Guid cameraRight = _dbMachineContext.Devices.Where(d => d.DeviceName == "Vision 2D Right").FirstOrDefault().Id;
            Guid cameraLeft = _dbMachineContext.Devices.Where(d => d.DeviceName == "Vision 2D Left").FirstOrDefault().Id;

            int fileCount = 5;
            //int fileCount = directories.Length;

            for (int i = 0; i < fileCount; i++)
            {
                string[] files = Directory.GetFiles(directories[i]);

                for (int j = 0; j < files.Length; j++)
                {
                    Console.WriteLine(files[j]);

                    string input = Path.GetFileName(files[j]); ;
                    string[] parts = input.Split('_');

                    string camera = parts[0];
                    string exposureTime = parts[1];
                    string index = parts[2].Substring(0, parts[2].IndexOf("."));

                    Guid cameraId = Guid.Empty;

                    if (camera.Contains("0"))
                    {
                        cameraId = cameraRight;
                    }

                    if (camera.Contains("1"))
                    {
                        cameraId = cameraLeft;
                    }

                    imagesHelper.Add(new ImageHelper() { FileId = Guid.NewGuid(), FileRawIds = null, ExposureTime = 27.500f, DateDigitized = DateTime.UtcNow, CameraDeviceId = cameraId });
                    imagesHelperBitmap.Add(new Bitmap(files[j]));
                }

                //DbStorage_QrCode dbStorage_QrCode = new DbStorage_QrCode();

                #region Run workflow
                workflow.RunWithCapturedImages(imagesHelper, imagesHelperBitmap, "C:/tmp", dataSubdirectorySelected.Id, "Meldezettel TLA / UIBK", null);
                #endregion

                imagesHelper.RemoveAll(x => true);
                imagesHelperBitmap.RemoveAll(x => true);
            }
            #endregion

#if DEBUG
            Log.Debug($"Workflow processing time: {swProcessingTime.ElapsedMilliseconds}ms for {fileCount} files --> {swProcessingTime.ElapsedMilliseconds / fileCount}ms per file ...");
            swProcessingTime.Stop();
#endif
        }

        private void btnMotion1_Click(object sender, RoutedEventArgs e)
        {
            double motorGearRatio = 13.000;
            double motorStepsPerRevolution = 4096.000;

            double leadScrewPitch = 5.000;

            double decenterDistance = 200.000;




            double[] test1 = CalculateMotorSteps(0, 0, 0, motorGearRatio, motorStepsPerRevolution, leadScrewPitch, decenterDistance);
            double[] test2 = CalculateMotorSteps(0, 0, 45, motorGearRatio, motorStepsPerRevolution, leadScrewPitch, decenterDistance);
            double[] test3 = CalculateMotorSteps(0, 0, 90, motorGearRatio, motorStepsPerRevolution, leadScrewPitch, decenterDistance);
            double[] test4 = CalculateMotorSteps(0, 0, -45, motorGearRatio, motorStepsPerRevolution, leadScrewPitch, decenterDistance);
            double[] test5 = CalculateMotorSteps(0, 0, -90, motorGearRatio, motorStepsPerRevolution, leadScrewPitch, decenterDistance);
            double[] test6 = CalculateMotorSteps(-200, 0, 0, motorGearRatio, motorStepsPerRevolution, leadScrewPitch, decenterDistance);



            ;
        }


        public double[] CalculateMotorSteps(double x, double z, double b, double motorGearRatio, double motorStepsPerRevolution, double leadScrewPitch, double decenterDistance)
        {
            double xDelta = Math.Abs(Math.Cos((Math.PI / 180) * b) * decenterDistance);
            double zDelta = Math.Sin((Math.PI / 180) * b) * decenterDistance;

            double xOffset = decenterDistance / leadScrewPitch * motorStepsPerRevolution;

            double tx = (((x - xDelta) / leadScrewPitch) * motorStepsPerRevolution) + xOffset;
            double tz = (((z - zDelta) / leadScrewPitch) * motorStepsPerRevolution);
            double tb = b * (motorGearRatio * motorStepsPerRevolution / 360);

            return new double[] { tx, tz, tb };
        }








    }
}

// Create a class to represent the data for each item in the grid
public class FolderItem
{
    public string Name { get; set; }
    public long Size { get; set; }
    public DateTime LastModified { get; set; }
    // Add more properties as needed
}

public class FileItem
{
    public string Name { get; set; }
    public long Size { get; set; }
    public DateTime? LastModified { get; set; }
    // Add more properties as needed
}



class DirectoryItem
{
    public string Name { get; set; }
    public Guid Id { get; set; }

    public override string ToString()
    {
        return Name;
    }
}
