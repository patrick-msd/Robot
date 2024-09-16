using Microsoft.EntityFrameworkCore;
using PSGM.Helper;
using PSGM.Model.DbStorage;
using Serilog;
using Serilog.Debugging;
using Serilog.Sinks.Grafana.Loki;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace PSGM.Sample.Model.DbStorage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<LokiLabel> _lokiLabels;
        string _lokiUri;
        string _lokiOutputTemplate;


        ConfigFile _configFile;

        private DbStorage_Context _dbStorage_Data_Context;

        Guid _softwareId;
        Guid _machineId;

        Guid _projectId;

        Guid _patrickSchoeneggerId;
        Guid _guenterMuehlbergerId;
        Guid _gertraudZeindlId;
        Guid _christophHaidacherId;

        public MainWindow()
        {
            InitializeComponent();

            _machineId = MachineInfo.GetMachineUUID();

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

            _configFile = new ConfigFile();

            if (_configFile.ConfigFileExists(Directory.GetCurrentDirectory() + "\\ConfigFile.json"))
            {
                _configFile.ReadFromFile(Directory.GetCurrentDirectory() + "\\ConfigFile.json");
            }

            #region Initialize Databases
            if (_configFile.ConfigFileExists(Directory.GetCurrentDirectory() + "\\ConfigFile.json"))
            {
                _dbStorage_Data_Context = new DbStorage_Context();
                _dbStorage_Data_Context.ConnectionString = _configFile.StorageStructureDatabaseConnectionString;
                _dbStorage_Data_Context.DatabaseType = _configFile.StorageStructureDatabaseType;
                //_dbStorage_Data_Context.Database.EnsureCreated();
                _dbStorage_Data_Context.Database.OpenConnection();
            }
            #endregion
        }

        private void btnDbCreateConfigFile_Click(object sender, RoutedEventArgs e)
        {
            _configFile = new ConfigFile()
            {
                StorageStructureDatabaseConnectionString = "Host=db-clu001.branch31.psgm.at:50001;Database=DbStorage;Username=postgres;Password=fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V",
                StorageStructureDatabaseType = DatabaseType.PostgreSQL,
            };

            _configFile.WriteToFile(Directory.GetCurrentDirectory() + "\\ConfigFile.json");
        }

        private void btnDbReadConfigFileAndInit_Click(object sender, RoutedEventArgs e)
        {
            _dbStorage_Data_Context = new DbStorage_Context();
            _dbStorage_Data_Context.ConnectionString = _configFile.StorageStructureDatabaseConnectionString;
            _dbStorage_Data_Context.DatabaseType = _configFile.StorageStructureDatabaseType;
            _dbStorage_Data_Context.Database.EnsureCreated();
            _dbStorage_Data_Context.Database.OpenConnection();
        }

        private void btnDbGenerateData_Click(object sender, RoutedEventArgs e)
        {
            #region Initialize variables ...  
            List<Authorization_User> users = new List<Authorization_User>()
            {
                new Authorization_User() { UserIdExt = Guid.NewGuid(), Permissions = PermissionType.Admin },
                new Authorization_User() { UserIdExt = Guid.NewGuid(), Permissions = PermissionType.None },
                new Authorization_User() { UserIdExt = Guid.NewGuid(), Permissions = PermissionType.Owner },
                new Authorization_User() { UserIdExt = Guid.NewGuid(), Permissions = PermissionType.Inherited },
                new Authorization_User() { UserIdExt = Guid.NewGuid(), Permissions = PermissionType.ServiceProviderScanning },
            };

            List<Authorization_UserGroup> userGroups = new List<Authorization_UserGroup>()
            {
                new Authorization_UserGroup() { UserGroupIdExt = Guid.NewGuid(), Permissions = PermissionType.Admin },
                new Authorization_UserGroup() { UserGroupIdExt = Guid.NewGuid(), Permissions = PermissionType.None },
                new Authorization_UserGroup() { UserGroupIdExt = Guid.NewGuid(), Permissions = PermissionType.Owner },
                new Authorization_UserGroup() { UserGroupIdExt = Guid.NewGuid(), Permissions = PermissionType.Inherited },
                new Authorization_UserGroup() { UserGroupIdExt = Guid.NewGuid(), Permissions = PermissionType.ServiceProviderScanning },
            };

            List<Notification_User> notificationUsers = new List<Notification_User>()
            {
                new Notification_User() { UserIdExt = Guid.NewGuid(), NotificationChannels = new List<NotificationChannel> { NotificationChannel.EMail, NotificationChannel.SMS, NotificationChannel.Teams }, NotificationType = NotificationType.StatusChange },
                new Notification_User() { UserIdExt = Guid.NewGuid(), NotificationChannels = new List<NotificationChannel> { NotificationChannel.EMail, NotificationChannel.Telegram , NotificationChannel.SMS }, NotificationType = NotificationType.All },
                new Notification_User() { UserIdExt = Guid.NewGuid(), NotificationChannels = new List<NotificationChannel> { NotificationChannel.Gotify, NotificationChannel.Slack, NotificationChannel.SMS }, NotificationType = NotificationType.StatusChange },
                new Notification_User() { UserIdExt = Guid.NewGuid(), NotificationChannels = new List<NotificationChannel> { NotificationChannel.EMail, NotificationChannel.Gotify, NotificationChannel.Teams }, NotificationType = NotificationType.None },
                new Notification_User() { UserIdExt = Guid.NewGuid(), NotificationChannels = new List<NotificationChannel> { NotificationChannel.None }, NotificationType = NotificationType.None },
                new Notification_User() { UserIdExt = Guid.NewGuid(), NotificationChannels = new List<NotificationChannel> { NotificationChannel.Teams, NotificationChannel.Gotify, NotificationChannel.SMS }, NotificationType = NotificationType.StatusChange },
                new Notification_User() { UserIdExt = Guid.NewGuid(), NotificationChannels = new List<NotificationChannel> { NotificationChannel.SMS, NotificationChannel.Slack, NotificationChannel.Gotify }, NotificationType = NotificationType.Inherited },
            };

            List<Notification_UserGroup> notificationUserGroups = new List<Notification_UserGroup>()
            {
                new Notification_UserGroup() { UserGroupIdExt = Guid.NewGuid(), NotificationChannels = new List<NotificationChannel> { NotificationChannel.EMail, NotificationChannel.SMS, NotificationChannel.Teams }, NotificationType = NotificationType.StatusChange },
                new Notification_UserGroup() { UserGroupIdExt = Guid.NewGuid(), NotificationChannels = new List<NotificationChannel> { NotificationChannel.EMail, NotificationChannel.Telegram , NotificationChannel.SMS }, NotificationType = NotificationType.All },
                new Notification_UserGroup() { UserGroupIdExt = Guid.NewGuid(), NotificationChannels = new List<NotificationChannel> { NotificationChannel.Gotify, NotificationChannel.Slack, NotificationChannel.SMS }, NotificationType = NotificationType.StatusChange },
                new Notification_UserGroup() { UserGroupIdExt = Guid.NewGuid(), NotificationChannels = new List<NotificationChannel> { NotificationChannel.EMail, NotificationChannel.Gotify, NotificationChannel.Teams }, NotificationType = NotificationType.None },
                new Notification_UserGroup() { UserGroupIdExt = Guid.NewGuid(), NotificationChannels = new List<NotificationChannel> { NotificationChannel.None }, NotificationType = NotificationType.None },
                new Notification_UserGroup() { UserGroupIdExt = Guid.NewGuid(), NotificationChannels = new List<NotificationChannel> { NotificationChannel.Teams, NotificationChannel.Gotify, NotificationChannel.SMS }, NotificationType = NotificationType.StatusChange },
                new Notification_UserGroup() { UserGroupIdExt = Guid.NewGuid(), NotificationChannels = new List<NotificationChannel> { NotificationChannel.SMS, NotificationChannel.Slack, NotificationChannel.Gotify }, NotificationType = NotificationType.Inherited },
            };

            List<DbStorage_FileMetadata> fileMetadata = new List<DbStorage_FileMetadata>()
            {
                new DbStorage_FileMetadata() { Id = Guid.NewGuid(), Key = "RootDirectory Metadata 1", Value = "afdsgffhjdhgf ghtgfgjgsh", Description = "asdfadsfdsf", Hidden = false, EditAll = false, ViewAll = false, AuthorizationUsers = users, AuthorizationUserGroups = userGroups },
                new DbStorage_FileMetadata() { Id = Guid.NewGuid(), Key = "RootDirectoryjfgh Metadata 1", Value = "afdsgffdhgf ghghjtghgsh", Description = "asdfadsfdsf", Hidden = true, EditAll = true, ViewAll = false, AuthorizationUsers = users, AuthorizationUserGroups = userGroups },
                new DbStorage_FileMetadata() { Id = Guid.NewGuid(), Key = "RootDirfghgdectory Metadata 1", Value = "afdsgjfhjffdhhjhgghjjgf ghtghgsh", Description = "asdfadsfdsf", Hidden = false, EditAll = false, ViewAll = true, AuthorizationUsers = users, AuthorizationUserGroups = userGroups },
                new DbStorage_FileMetadata() { Id = Guid.NewGuid(), Key = "RootDirecdffhtory Mghjetagdata 1", Value = "afdsgjfffjfdhgf ghhgjtghgsh", Description = "asdfadsfdsf", Hidden = true, EditAll = true, ViewAll = false, AuthorizationUsers = users, AuthorizationUserGroups = userGroups },
                new DbStorage_FileMetadata() { Id = Guid.NewGuid(), Key = "RootDirectory Metadata 1", Value = "afdsgffdhgf hjghtghgjhgsh", Description = "asdfadsfdsf", Hidden = false, EditAll = false, ViewAll = false, AuthorizationUsers = users, AuthorizationUserGroups = userGroups },
                new DbStorage_FileMetadata() { Id = Guid.NewGuid(), Key = "RootDirhgjgjhjectory Metadata 1", Value = "afdsgfgjhgfjhdhgf ghtghgsh", Description = "asdfadsfdsf", Hidden = false, EditAll = true, ViewAll = true, AuthorizationUsers = users, AuthorizationUserGroups = userGroups },
                new DbStorage_FileMetadata() { Id = Guid.NewGuid(), Key = "RootDirehjhgtory Metadata 1", Value = "afdsgffdjhgjhhgf ghtghgsh", Description = "asdfadsfdsf", Hidden = true, EditAll = true, ViewAll = true, AuthorizationUsers = users, AuthorizationUserGroups = userGroups },
                new DbStorage_FileMetadata() { Id = Guid.NewGuid(), Key = "RootDirectojhg Meghjtadata 1", Value = "afdsgfjfhgjfdhgf jghgjhtghgsh", Description = "asdfadsfdsf", Hidden = true, EditAll = true, ViewAll = true, AuthorizationUsers = users, AuthorizationUserGroups = userGroups },
            };
            _dbStorage_Data_Context.FileMetadata.AddRange(fileMetadata);
            _dbStorage_Data_Context.SaveChanges();

            List<DbStorage_RootDirectoryMetadata> rootDirectoryMetadata = new List<DbStorage_RootDirectoryMetadata>()
            {
                new DbStorage_RootDirectoryMetadata() { Id = Guid.NewGuid(), Key = "RootDirectory Metadata 1", Value = "afdsgffhjdhgf ghtgfgjgsh", Description = "asdfadsfdsf", Hidden = false, EditAll = false, ViewAll = false, AuthorizationUsers = users, AuthorizationUserGroups = userGroups },
                new DbStorage_RootDirectoryMetadata() { Id = Guid.NewGuid(), Key = "RootDirectoryjfgh Metadata 1", Value = "afdsgffdhgf ghghjtghgsh", Description = "asdfadsfdsf", Hidden = true, EditAll = true, ViewAll = false, AuthorizationUsers = users, AuthorizationUserGroups = userGroups },
                new DbStorage_RootDirectoryMetadata() { Id = Guid.NewGuid(), Key = "RootDirfghgdectory Metadata 1", Value = "afdsgjfhjffdhhjhgghjjgf ghtghgsh", Description = "asdfadsfdsf", Hidden = false, EditAll = false, ViewAll = true, AuthorizationUsers = users, AuthorizationUserGroups = userGroups },
                new DbStorage_RootDirectoryMetadata() { Id = Guid.NewGuid(), Key = "RootDirecdffhtory Mghjetagdata 1", Value = "afdsgjfffjfdhgf ghhgjtghgsh", Description = "asdfadsfdsf", Hidden = true, EditAll = true, ViewAll = false, AuthorizationUsers = users, AuthorizationUserGroups = userGroups },
                new DbStorage_RootDirectoryMetadata() { Id = Guid.NewGuid(), Key = "RootDirectory Metadata 1", Value = "afdsgffdhgf hjghtghgjhgsh", Description = "asdfadsfdsf", Hidden = false, EditAll = false, ViewAll = false, AuthorizationUsers = users, AuthorizationUserGroups = userGroups },
                new DbStorage_RootDirectoryMetadata() { Id = Guid.NewGuid(), Key = "RootDirhgjgjhjectory Metadata 1", Value = "afdsgfgjhgfjhdhgf ghtghgsh", Description = "asdfadsfdsf", Hidden = false, EditAll = true, ViewAll = true, AuthorizationUsers = users, AuthorizationUserGroups = userGroups },
                new DbStorage_RootDirectoryMetadata() { Id = Guid.NewGuid(), Key = "RootDirehjhgtory Metadata 1", Value = "afdsgffdjhgjhhgf ghtghgsh", Description = "asdfadsfdsf", Hidden = true, EditAll = true, ViewAll = true, AuthorizationUsers = users, AuthorizationUserGroups = userGroups },
                new DbStorage_RootDirectoryMetadata() { Id = Guid.NewGuid(), Key = "RootDirectojhg Meghjtadata 1", Value = "afdsgfjfhgjfdhgf jghgjhtghgsh", Description = "asdfadsfdsf", Hidden = true, EditAll = true, ViewAll = true, AuthorizationUsers = users, AuthorizationUserGroups = userGroups },
            };
            _dbStorage_Data_Context.RootDirectoryMetadata.AddRange(rootDirectoryMetadata);
            _dbStorage_Data_Context.SaveChanges();

            List<DbStorage_SubDirectoryMetadata> subDirectoryMetadata = new List<DbStorage_SubDirectoryMetadata>()
            {
                new DbStorage_SubDirectoryMetadata() { Id = Guid.NewGuid(), Key = "RootDirectory Metadata 1", Value = "afdsgffhjdhgf ghtgfgjgsh", Description = "asdfadsfdsf", Hidden = false, EditAll = false, ViewAll = false, AuthorizationUsers = users, AuthorizationUserGroups = userGroups },
                new DbStorage_SubDirectoryMetadata() { Id = Guid.NewGuid(), Key = "RootDirectoryjfgh Metadata 1", Value = "afdsgffdhgf ghghjtghgsh", Description = "asdfadsfdsf", Hidden = true, EditAll = true, ViewAll = false, AuthorizationUsers = users, AuthorizationUserGroups = userGroups },
                new DbStorage_SubDirectoryMetadata() { Id = Guid.NewGuid(), Key = "RootDirfghgdectory Metadata 1", Value = "afdsgjfhjffdhhjhgghjjgf ghtghgsh", Description = "asdfadsfdsf", Hidden = false, EditAll = false, ViewAll = true, AuthorizationUsers = users, AuthorizationUserGroups = userGroups },
                new DbStorage_SubDirectoryMetadata() { Id = Guid.NewGuid(), Key = "RootDirecdffhtory Mghjetagdata 1", Value = "afdsgjfffjfdhgf ghhgjtghgsh", Description = "asdfadsfdsf", Hidden = true, EditAll = true, ViewAll = false, AuthorizationUsers = users, AuthorizationUserGroups = userGroups },
                new DbStorage_SubDirectoryMetadata() { Id = Guid.NewGuid(), Key = "RootDirectory Metadata 1", Value = "afdsgffdhgf hjghtghgjhgsh", Description = "asdfadsfdsf", Hidden = false, EditAll = false, ViewAll = false, AuthorizationUsers = users, AuthorizationUserGroups = userGroups },
                new DbStorage_SubDirectoryMetadata() { Id = Guid.NewGuid(), Key = "RootDirhgjgjhjectory Metadata 1", Value = "afdsgfgjhgfjhdhgf ghtghgsh", Description = "asdfadsfdsf", Hidden = false, EditAll = true, ViewAll = true, AuthorizationUsers = users, AuthorizationUserGroups = userGroups },
                new DbStorage_SubDirectoryMetadata() { Id = Guid.NewGuid(), Key = "RootDirehjhgtory Metadata 1", Value = "afdsgffdjhgjhhgf ghtghgsh", Description = "asdfadsfdsf", Hidden = true, EditAll = true, ViewAll = true, AuthorizationUsers = users, AuthorizationUserGroups = userGroups },
                new DbStorage_SubDirectoryMetadata() { Id = Guid.NewGuid(), Key = "RootDirectojhg Meghjtadata 1", Value = "afdsgfjfhgjfdhgf jghgjhtghgsh", Description = "asdfadsfdsf", Hidden = true, EditAll = true, ViewAll = true, AuthorizationUsers = users, AuthorizationUserGroups = userGroups },
            };
            _dbStorage_Data_Context.SubDirectoryMetadata.AddRange(subDirectoryMetadata);
            _dbStorage_Data_Context.SaveChanges();
            #endregion

            #region Add root directories ...
            List<DbStorage_RootDirectory> rootDirectory = Create_RootDirectories(100, users, userGroups, notificationUsers, notificationUserGroups, rootDirectoryMetadata);
            _dbStorage_Data_Context.RootDirectories.AddRange(rootDirectory);
            _dbStorage_Data_Context.SaveChanges();
            #endregion

            #region Add sub directories ...
            List<DbStorage_SubDirectory> subDirectories = Create_SubDirectories(10000, users, userGroups, notificationUsers, notificationUserGroups, rootDirectory, subDirectoryMetadata);
            _dbStorage_Data_Context.SubDirectories.AddRange(subDirectories);
            _dbStorage_Data_Context.SaveChanges();
            #endregion

            #region Add sub sub directories ...
            List<DbStorage_SubDirectory> subsubDirectories = Create_SubSubDirectories(100, users, userGroups, notificationUsers, notificationUserGroups, rootDirectory, subDirectoryMetadata);
            _dbStorage_Data_Context.SubDirectories.AddRange(subsubDirectories);
            _dbStorage_Data_Context.SaveChanges();
            #endregion

            #region Add files ...
            for (int i = 0; i < 100; i++)
            {
                List<DbStorage_File> files1 = Create_Files1(10000, users, userGroups, notificationUsers, notificationUserGroups, subDirectories, rootDirectory, fileMetadata);
                _dbStorage_Data_Context.Files.AddRange(files1);
                _dbStorage_Data_Context.SaveChanges();
            }

            List<DbStorage_File> files2 = Create_Files2(1000, users, userGroups, notificationUsers, notificationUserGroups, subsubDirectories, rootDirectory, fileMetadata);
            _dbStorage_Data_Context.Files.AddRange(files2);
            _dbStorage_Data_Context.SaveChanges();
            #endregion
        }

        private void btnDbReadData1_Click(object sender, RoutedEventArgs e)
        {
            ;

            //var asdasd = _dbStorage_Data_Context.Files.ToList();

            var asd = _dbStorage_Data_Context.Files.Where(f => f.ExtId3.Contains("e7b"))
                                                    .Include(p => p.SubDirectory)
                                                        .ThenInclude(p => p.RootDirectory)
                                                    .Include(p => p.RootDirectory)
                                                    .Include(p => p.FileMetadataLinks)
                                                        .ThenInclude(p => p.FileMetadata)
                                                    .Include(p => p.QrCode)
                                                    .ToList();

            var asdsa = asd[0].AuthorizationUsersIdExt;
            var asddsdfsa = asd[0].NotificationUserGroupIdsExt;
            var asadfdsa = asd[0].JobIdsExt;
            //var asdadssa = asd[0].GetLastModificationChanges();


            var asd2 = _dbStorage_Data_Context.RootDirectories.ToList();
            var asdasd2 = _dbStorage_Data_Context.SubDirectories.OrderBy(item => item.Id)
                                                                .Take(100)
                                                                .ToList();

            ;
        }
    }
}
