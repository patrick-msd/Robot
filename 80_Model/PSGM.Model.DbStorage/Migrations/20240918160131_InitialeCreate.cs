using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PSGM.Model.DbStorage.Migrations
{
    /// <inheritdoc />
    public partial class InitialeCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "psgm");

            migrationBuilder.CreateTable(
                name: "File_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileAuthorization_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "integer", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileAuthorization_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileAuthorization_User_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileAuthorization_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileAuthorization_UserGroup",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "integer", nullable: false),
                    UserGroupIdExt = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileAuthorization_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileAuthorization_UserGroup_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileAuthorization_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileAuthorization_UserGroupLink_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileAuthorization_UserGroupLink_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileAuthorization_UserLink_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileAuthorization_UserLink_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileMetadata",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    Value = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    Description = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false),
                    EditAll = table.Column<bool>(type: "boolean", nullable: false),
                    ViewAll = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileMetadata", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileMetadata_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileMetadata_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileMetadataAuthorization_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "integer", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileMetadataAuthorization_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileMetadataAuthorization_User_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileMetadataAuthorization_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileMetadataAuthorization_UserGroup",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "integer", nullable: false),
                    UserGroupIdExt = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileMetadataAuthorization_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileMetadataAuthorization_UserGroup_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileMetadataAuthorization_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileMetadataAuthorization_UserGroupLink_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileMetadataAuthorization_UserGroupLink_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileMetadataAuthorization_UserLink_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileMetadataAuthorization_UserLink_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileMetadataLink_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileMetadataLink_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileNotification_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    NotificationType = table.Column<int>(type: "integer", nullable: false),
                    EMail = table.Column<bool>(type: "boolean", nullable: false),
                    Slack = table.Column<bool>(type: "boolean", nullable: false),
                    Teams = table.Column<bool>(type: "boolean", nullable: false),
                    SMS = table.Column<bool>(type: "boolean", nullable: false),
                    WhatsApp = table.Column<bool>(type: "boolean", nullable: false),
                    Telegram = table.Column<bool>(type: "boolean", nullable: false),
                    Gotify = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileNotification_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileNotification_User_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileNotification_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileNotification_UserGroup",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    UserGroupIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    NotificationType = table.Column<int>(type: "integer", nullable: false),
                    EMail = table.Column<bool>(type: "boolean", nullable: false),
                    Slack = table.Column<bool>(type: "boolean", nullable: false),
                    Teams = table.Column<bool>(type: "boolean", nullable: false),
                    SMS = table.Column<bool>(type: "boolean", nullable: false),
                    WhatsApp = table.Column<bool>(type: "boolean", nullable: false),
                    Telegram = table.Column<bool>(type: "boolean", nullable: false),
                    Gotify = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileNotification_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileNotification_UserGroup_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileNotification_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileNotification_UserGroupLink_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileNotification_UserGroupLink_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileNotification_UserLink_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileNotification_UserLink_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileQuality_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileQuality_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QrCode_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QrCode_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Suffix = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Prefix = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    SuffixProjectOwner = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    NameProjectOwner = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PrefixProjectOwner = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DescriptionProjectOwner = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    Stars = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    DirectoryState = table.Column<long>(type: "bigint", nullable: false),
                    DirectoryLocked = table.Column<bool>(type: "boolean", nullable: false),
                    JobIdsExtString = table.Column<string>(type: "character varying(65532)", maxLength: 65532, nullable: false),
                    WorkflowItemIdsExtString = table.Column<string>(type: "character varying(65532)", maxLength: 65532, nullable: false),
                    BackupIdsExtString = table.Column<string>(type: "character varying(32766)", maxLength: 32766, nullable: false),
                    ObjectsAutofill = table.Column<int>(type: "integer", nullable: false),
                    DirectorySizeAutofill = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectoryAuthorization_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "integer", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectoryAuthorization_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectoryAuthorization_UserGroup",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "integer", nullable: false),
                    UserGroupIdExt = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectoryAuthorization_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectoryAuthorization_UserGroupLink_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectoryAuthorization_UserGroupLink_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectoryAuthorization_UserLink_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectoryAuthorization_UserLink_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectoryMetadata",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    Value = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    Description = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false),
                    EditAll = table.Column<bool>(type: "boolean", nullable: false),
                    ViewAll = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectoryMetadata", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectoryMetadata_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectoryMetadata_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectoryMetadataAuthorization_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "integer", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectoryMetadataAuthorization_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectoryMetadataAuthorization_User_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectoryMetadataAuthorization_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectoryMetadataAuthorization_UserGroup",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "integer", nullable: false),
                    UserGroupIdExt = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectoryMetadataAuthorization_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectoryMetadataAuthorization_UserGroup_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectoryMetadataAuthorization_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectoryMetadataAuthorization_UserGroupLink_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectoryMetadataAuthorization_UserGroupLink_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectoryMetadataAuthorization_UserLink_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectoryMetadataAuthorization_UserLink_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectoryMetadataLink_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectoryMetadataLink_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectoryNotification_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    NotificationType = table.Column<int>(type: "integer", nullable: false),
                    EMail = table.Column<bool>(type: "boolean", nullable: false),
                    Slack = table.Column<bool>(type: "boolean", nullable: false),
                    Teams = table.Column<bool>(type: "boolean", nullable: false),
                    SMS = table.Column<bool>(type: "boolean", nullable: false),
                    WhatsApp = table.Column<bool>(type: "boolean", nullable: false),
                    Telegram = table.Column<bool>(type: "boolean", nullable: false),
                    Gotify = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectoryNotification_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectoryNotification_UserGroup",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    UserGroupIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    NotificationType = table.Column<int>(type: "integer", nullable: false),
                    EMail = table.Column<bool>(type: "boolean", nullable: false),
                    Slack = table.Column<bool>(type: "boolean", nullable: false),
                    Teams = table.Column<bool>(type: "boolean", nullable: false),
                    SMS = table.Column<bool>(type: "boolean", nullable: false),
                    WhatsApp = table.Column<bool>(type: "boolean", nullable: false),
                    Telegram = table.Column<bool>(type: "boolean", nullable: false),
                    Gotify = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectoryNotification_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectoryNotification_UserGroupLink_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectoryNotification_UserGroupLink_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectoryNotification_UserLink_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectoryNotification_UserLink_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectoryAuthorization_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "integer", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectoryAuthorization_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectoryAuthorization_UserGroup",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "integer", nullable: false),
                    UserGroupIdExt = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectoryAuthorization_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectoryAuthorization_UserGroupLink_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectoryAuthorization_UserGroupLink_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectoryAuthorization_UserLink_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectoryAuthorization_UserLink_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectoryMetadata",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    Value = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    Description = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    Hidden = table.Column<bool>(type: "boolean", nullable: false),
                    EditAll = table.Column<bool>(type: "boolean", nullable: false),
                    ViewAll = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectoryMetadata", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectoryMetadata_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectoryMetadata_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectoryMetadataAuthorization_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "integer", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectoryMetadataAuthorization_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectoryMetadataAuthorization_User_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectoryMetadataAuthorization_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectoryMetadataAuthorization_UserGroup",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "integer", nullable: false),
                    UserGroupIdExt = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectoryMetadataAuthorization_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectoryMetadataAuthorization_UserGroup_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectoryMetadataAuthorization_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectoryMetadataAuthorization_UserGroupLink_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectoryMetadataAuthorization_UserGroupLink_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectoryMetadataAuthorization_UserLink_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectoryMetadataAuthorization_UserLink_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectoryMetadataLink_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectoryMetadataLink_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectoryNotification_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    NotificationType = table.Column<int>(type: "integer", nullable: false),
                    EMail = table.Column<bool>(type: "boolean", nullable: false),
                    Slack = table.Column<bool>(type: "boolean", nullable: false),
                    Teams = table.Column<bool>(type: "boolean", nullable: false),
                    SMS = table.Column<bool>(type: "boolean", nullable: false),
                    WhatsApp = table.Column<bool>(type: "boolean", nullable: false),
                    Telegram = table.Column<bool>(type: "boolean", nullable: false),
                    Gotify = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectoryNotification_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectoryNotification_UserGroup",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    UserGroupIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    NotificationType = table.Column<int>(type: "integer", nullable: false),
                    EMail = table.Column<bool>(type: "boolean", nullable: false),
                    Slack = table.Column<bool>(type: "boolean", nullable: false),
                    Teams = table.Column<bool>(type: "boolean", nullable: false),
                    SMS = table.Column<bool>(type: "boolean", nullable: false),
                    WhatsApp = table.Column<bool>(type: "boolean", nullable: false),
                    Telegram = table.Column<bool>(type: "boolean", nullable: false),
                    Gotify = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectoryNotification_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectoryNotification_UserGroupLink_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectoryNotification_UserGroupLink_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectoryNotification_UserLink_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectoryNotification_UserLink_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileMetadataAuthorization_UserLink",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileMetadataId = table.Column<Guid>(type: "uuid", nullable: true),
                    FileMetadataAuthorization_UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileMetadataAuthorization_UserLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileMetadataAuthorization_UserLink_FileMetadataAuthorizatio~",
                        column: x => x.FileMetadataAuthorization_UserId,
                        principalSchema: "psgm",
                        principalTable: "FileMetadataAuthorization_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FileMetadataAuthorization_UserLink_FileMetadata_FileMetadat~",
                        column: x => x.FileMetadataId,
                        principalSchema: "psgm",
                        principalTable: "FileMetadata",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FileMetadataAuthorization_UserGroupLink",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileMetadataId = table.Column<Guid>(type: "uuid", nullable: true),
                    FileMetadataAuthorization_UserGroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileMetadataAuthorization_UserGroupLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileMetadataAuthorization_UserGroupLink_FileMetadataAuthori~",
                        column: x => x.FileMetadataAuthorization_UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "FileMetadataAuthorization_UserGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FileMetadataAuthorization_UserGroupLink_FileMetadata_FileMe~",
                        column: x => x.FileMetadataId,
                        principalSchema: "psgm",
                        principalTable: "FileMetadata",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Suffix = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Prefix = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    SuffixProjectOwner = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    NameProjectOwner = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PrefixProjectOwner = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DescriptionProjectOwner = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    Stars = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    DirectoryState = table.Column<long>(type: "bigint", nullable: false),
                    DirectoryLocked = table.Column<bool>(type: "boolean", nullable: false),
                    JobIdsExtString = table.Column<string>(type: "character varying(65532)", maxLength: 65532, nullable: false),
                    WorkflowItemIdsExtString = table.Column<string>(type: "character varying(65532)", maxLength: 65532, nullable: false),
                    BackupIdsExtString = table.Column<string>(type: "character varying(32766)", maxLength: 32766, nullable: false),
                    ObjectsAutofill = table.Column<int>(type: "integer", nullable: false),
                    DirectorySizeAutofill = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    RootDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    ParentSubDirectoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_RootDirectory_RootDirectoryId",
                        column: x => x.RootDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubDirectory_SubDirectory_ParentSubDirectoryId",
                        column: x => x.ParentSubDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectoryAuthorization_UserLink",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RootDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    RootDirectoryAuthorization_UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectoryAuthorization_UserLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectoryAuthorization_UserLink_RootDirectoryAuthorizat~",
                        column: x => x.RootDirectoryAuthorization_UserId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectoryAuthorization_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RootDirectoryAuthorization_UserLink_RootDirectory_RootDirec~",
                        column: x => x.RootDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectoryAuthorization_UserGroupLink",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RootDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    RootDirectoryAuthorization_UserGroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectoryAuthorization_UserGroupLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectoryAuthorization_UserGroupLink_RootDirectoryAutho~",
                        column: x => x.RootDirectoryAuthorization_UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectoryAuthorization_UserGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RootDirectoryAuthorization_UserGroupLink_RootDirectory_Root~",
                        column: x => x.RootDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectoryMetadataLink",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RootDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    RootDirectoryMetadataId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectoryMetadataLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectoryMetadataLink_RootDirectoryMetadata_RootDirecto~",
                        column: x => x.RootDirectoryMetadataId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectoryMetadata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RootDirectoryMetadataLink_RootDirectory_RootDirectoryId",
                        column: x => x.RootDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectoryMetadataAuthorization_UserLink",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RootDirectoryMetadataId = table.Column<Guid>(type: "uuid", nullable: true),
                    RootDirectoryMetadataAuthorization_UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectoryMetadataAuthorization_UserLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectoryMetadataAuthorization_UserLink_RootDirectoryMe~",
                        column: x => x.RootDirectoryMetadataAuthorization_UserId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectoryMetadataAuthorization_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RootDirectoryMetadataAuthorization_UserLink_RootDirectoryM~1",
                        column: x => x.RootDirectoryMetadataId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectoryMetadata",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectoryMetadataAuthorization_UserGroupLink",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RootDirectoryMetadataId = table.Column<Guid>(type: "uuid", nullable: true),
                    RootDirectoryMetadataAuthorization_UserGroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectoryMetadataAuthorization_UserGroupLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectoryMetadataAuthorization_UserGroupLink_RootDirect~",
                        column: x => x.RootDirectoryMetadataAuthorization_UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectoryMetadataAuthorization_UserGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RootDirectoryMetadataAuthorization_UserGroupLink_RootDirec~1",
                        column: x => x.RootDirectoryMetadataId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectoryMetadata",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectoryNotification_UserLink",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RootDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    RootDirectoryNotification_UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectoryNotification_UserLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectoryNotification_UserLink_RootDirectoryNotificatio~",
                        column: x => x.RootDirectoryNotification_UserId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectoryNotification_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RootDirectoryNotification_UserLink_RootDirectory_RootDirect~",
                        column: x => x.RootDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectoryNotification_UserGroupLink",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RootDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    RootDirectoryNotification_UserGroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectoryNotification_UserGroupLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectoryNotification_UserGroupLink_RootDirectoryNotifi~",
                        column: x => x.RootDirectoryNotification_UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectoryNotification_UserGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RootDirectoryNotification_UserGroupLink_RootDirectory_RootD~",
                        column: x => x.RootDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DbStorage_SubDirectoryMetadataAuthorization_UserLink",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubDirectoryMetadataId = table.Column<Guid>(type: "uuid", nullable: true),
                    SubDirectoryMetadataAuthorization_UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbStorage_SubDirectoryMetadataAuthorization_UserLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbStorage_SubDirectoryMetadataAuthorization_UserLink_SubDir~",
                        column: x => x.SubDirectoryMetadataAuthorization_UserId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectoryMetadataAuthorization_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DbStorage_SubDirectoryMetadataAuthorization_UserLink_SubDi~1",
                        column: x => x.SubDirectoryMetadataId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectoryMetadata",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectoryMetadataAuthorization_UserGroupLink",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubDirectoryMetadataId = table.Column<Guid>(type: "uuid", nullable: true),
                    SubDirectoryMetadataAuthorization_UserGroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectoryMetadataAuthorization_UserGroupLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectoryMetadataAuthorization_UserGroupLink_SubDirector~",
                        column: x => x.SubDirectoryMetadataAuthorization_UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectoryMetadataAuthorization_UserGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubDirectoryMetadataAuthorization_UserGroupLink_SubDirecto~1",
                        column: x => x.SubDirectoryMetadataId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectoryMetadata",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Suffix = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Prefix = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    SuffixProjectOwner = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    NameProjectOwner = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PrefixProjectOwner = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DescriptionProjectOwner = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    Stars = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    ObjectExtension = table.Column<long>(type: "bigint", nullable: false),
                    ObjectSize = table.Column<long>(type: "bigint", nullable: false),
                    StorageObjectName = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    StorageObjectVersion = table.Column<int>(type: "integer", nullable: false),
                    StorageObjectUrl = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    StorageObjectUrlPublic = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    ExtId1 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ExtId2 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ExtId3 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ExtId4 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ExtId5 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ExtId6 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ExtId7 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ExtId8 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ExtId9 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ExtId10 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    MachineIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    DeviceIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    RawFileIdsString = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: false),
                    JobIdsExtString = table.Column<string>(type: "character varying(65532)", maxLength: 65532, nullable: false),
                    WorkflowItemIdsExtString = table.Column<string>(type: "character varying(65532)", maxLength: 65532, nullable: false),
                    BackupIdsExtString = table.Column<string>(type: "character varying(32766)", maxLength: 32766, nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    RootDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    SubDirectoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_RootDirectory_RootDirectoryId",
                        column: x => x.RootDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_File_SubDirectory_SubDirectoryId",
                        column: x => x.SubDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectoryAuthorization_UserGroupLink",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    SubDirectoryAuthorization_UserGroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectoryAuthorization_UserGroupLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectoryAuthorization_UserGroupLink_SubDirectoryAuthori~",
                        column: x => x.SubDirectoryAuthorization_UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectoryAuthorization_UserGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubDirectoryAuthorization_UserGroupLink_SubDirectory_SubDir~",
                        column: x => x.SubDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectoryAuthorization_UserLink",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    SubDirectoryAuthorization_UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectoryAuthorization_UserLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectoryAuthorization_UserLink_SubDirectoryAuthorizatio~",
                        column: x => x.SubDirectoryAuthorization_UserId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectoryAuthorization_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubDirectoryAuthorization_UserLink_SubDirectory_SubDirector~",
                        column: x => x.SubDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectoryMetadataLink",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    SubDirectoryMetadataId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectoryMetadataLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectoryMetadataLink_SubDirectoryMetadata_SubDirectoryM~",
                        column: x => x.SubDirectoryMetadataId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectoryMetadata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubDirectoryMetadataLink_SubDirectory_SubDirectoryId",
                        column: x => x.SubDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectoryNotification_UserGroupLink",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    SubDirectoryNotification_UserGroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectoryNotification_UserGroupLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectoryNotification_UserGroupLink_SubDirectoryNotifica~",
                        column: x => x.SubDirectoryNotification_UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectoryNotification_UserGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubDirectoryNotification_UserGroupLink_SubDirectory_SubDire~",
                        column: x => x.SubDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectoryNotification_UserLink",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    SubDirectoryNotification_UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectoryNotification_UserLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectoryNotification_UserLink_SubDirectoryNotification_~",
                        column: x => x.SubDirectoryNotification_UserId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectoryNotification_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubDirectoryNotification_UserLink_SubDirectory_SubDirectory~",
                        column: x => x.SubDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FileAuthorization_UserGroupLink",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: true),
                    FileAuthorization_UserGroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileAuthorization_UserGroupLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileAuthorization_UserGroupLink_FileAuthorization_UserGroup~",
                        column: x => x.FileAuthorization_UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "FileAuthorization_UserGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FileAuthorization_UserGroupLink_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "psgm",
                        principalTable: "File",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FileAuthorization_UserLink",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: true),
                    FileAuthorization_UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileAuthorization_UserLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileAuthorization_UserLink_FileAuthorization_User_FileAutho~",
                        column: x => x.FileAuthorization_UserId,
                        principalSchema: "psgm",
                        principalTable: "FileAuthorization_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FileAuthorization_UserLink_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "psgm",
                        principalTable: "File",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FileMetadataLink",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: true),
                    FileMetadataId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileMetadataLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileMetadataLink_FileMetadata_FileMetadataId",
                        column: x => x.FileMetadataId,
                        principalSchema: "psgm",
                        principalTable: "FileMetadata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FileMetadataLink_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "psgm",
                        principalTable: "File",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FileNotification_UserGroupLink",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: true),
                    FileNotification_UserGroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileNotification_UserGroupLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileNotification_UserGroupLink_FileNotification_UserGroup_F~",
                        column: x => x.FileNotification_UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "FileNotification_UserGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FileNotification_UserGroupLink_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "psgm",
                        principalTable: "File",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FileNotification_UserLink",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: true),
                    FileNotification_UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileNotification_UserLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileNotification_UserLink_FileNotification_User_FileNotific~",
                        column: x => x.FileNotification_UserId,
                        principalSchema: "psgm",
                        principalTable: "FileNotification_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FileNotification_UserLink_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "psgm",
                        principalTable: "File",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QrCode",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    QrCodeType = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: true),
                    RootDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    SubDirectoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QrCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QrCode_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "psgm",
                        principalTable: "File",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QrCode_RootDirectory_RootDirectoryId",
                        column: x => x.RootDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QrCode_SubDirectory_SubDirectoryId",
                        column: x => x.SubDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Quality",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QualityState = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: true),
                    SubDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    RootDirectoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quality", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quality_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "psgm",
                        principalTable: "File",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Quality_RootDirectory_RootDirectoryId",
                        column: x => x.RootDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Quality_SubDirectory_SubDirectoryId",
                        column: x => x.SubDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbStorage_SubDirectoryMetadataAuthorization_UserLink_SubDi~1",
                schema: "psgm",
                table: "DbStorage_SubDirectoryMetadataAuthorization_UserLink",
                column: "SubDirectoryMetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_DbStorage_SubDirectoryMetadataAuthorization_UserLink_SubDir~",
                schema: "psgm",
                table: "DbStorage_SubDirectoryMetadataAuthorization_UserLink",
                column: "SubDirectoryMetadataAuthorization_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_File_RootDirectoryId",
                schema: "psgm",
                table: "File",
                column: "RootDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_File_SubDirectoryId",
                schema: "psgm",
                table: "File",
                column: "SubDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FileAuthorization_UserGroupLink_FileAuthorization_UserGroup~",
                schema: "psgm",
                table: "FileAuthorization_UserGroupLink",
                column: "FileAuthorization_UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_FileAuthorization_UserGroupLink_FileId",
                schema: "psgm",
                table: "FileAuthorization_UserGroupLink",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_FileAuthorization_UserLink_FileAuthorization_UserId",
                schema: "psgm",
                table: "FileAuthorization_UserLink",
                column: "FileAuthorization_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FileAuthorization_UserLink_FileId",
                schema: "psgm",
                table: "FileAuthorization_UserLink",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_FileMetadataAuthorization_UserGroupLink_FileMetadataAuthori~",
                schema: "psgm",
                table: "FileMetadataAuthorization_UserGroupLink",
                column: "FileMetadataAuthorization_UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_FileMetadataAuthorization_UserGroupLink_FileMetadataId",
                schema: "psgm",
                table: "FileMetadataAuthorization_UserGroupLink",
                column: "FileMetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_FileMetadataAuthorization_UserLink_FileMetadataAuthorizatio~",
                schema: "psgm",
                table: "FileMetadataAuthorization_UserLink",
                column: "FileMetadataAuthorization_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FileMetadataAuthorization_UserLink_FileMetadataId",
                schema: "psgm",
                table: "FileMetadataAuthorization_UserLink",
                column: "FileMetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_FileMetadataLink_FileId",
                schema: "psgm",
                table: "FileMetadataLink",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_FileMetadataLink_FileMetadataId",
                schema: "psgm",
                table: "FileMetadataLink",
                column: "FileMetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_FileNotification_UserGroupLink_FileId",
                schema: "psgm",
                table: "FileNotification_UserGroupLink",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_FileNotification_UserGroupLink_FileNotification_UserGroupId",
                schema: "psgm",
                table: "FileNotification_UserGroupLink",
                column: "FileNotification_UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_FileNotification_UserLink_FileId",
                schema: "psgm",
                table: "FileNotification_UserLink",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_FileNotification_UserLink_FileNotification_UserId",
                schema: "psgm",
                table: "FileNotification_UserLink",
                column: "FileNotification_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_QrCode_FileId",
                schema: "psgm",
                table: "QrCode",
                column: "FileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QrCode_RootDirectoryId",
                schema: "psgm",
                table: "QrCode",
                column: "RootDirectoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QrCode_SubDirectoryId",
                schema: "psgm",
                table: "QrCode",
                column: "SubDirectoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quality_FileId",
                schema: "psgm",
                table: "Quality",
                column: "FileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quality_RootDirectoryId",
                schema: "psgm",
                table: "Quality",
                column: "RootDirectoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quality_SubDirectoryId",
                schema: "psgm",
                table: "Quality",
                column: "SubDirectoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectoryAuthorization_UserGroupLink_RootDirectoryAutho~",
                schema: "psgm",
                table: "RootDirectoryAuthorization_UserGroupLink",
                column: "RootDirectoryAuthorization_UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectoryAuthorization_UserGroupLink_RootDirectoryId",
                schema: "psgm",
                table: "RootDirectoryAuthorization_UserGroupLink",
                column: "RootDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectoryAuthorization_UserLink_RootDirectoryAuthorizat~",
                schema: "psgm",
                table: "RootDirectoryAuthorization_UserLink",
                column: "RootDirectoryAuthorization_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectoryAuthorization_UserLink_RootDirectoryId",
                schema: "psgm",
                table: "RootDirectoryAuthorization_UserLink",
                column: "RootDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectoryMetadataAuthorization_UserGroupLink_RootDirec~1",
                schema: "psgm",
                table: "RootDirectoryMetadataAuthorization_UserGroupLink",
                column: "RootDirectoryMetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectoryMetadataAuthorization_UserGroupLink_RootDirect~",
                schema: "psgm",
                table: "RootDirectoryMetadataAuthorization_UserGroupLink",
                column: "RootDirectoryMetadataAuthorization_UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectoryMetadataAuthorization_UserLink_RootDirectoryM~1",
                schema: "psgm",
                table: "RootDirectoryMetadataAuthorization_UserLink",
                column: "RootDirectoryMetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectoryMetadataAuthorization_UserLink_RootDirectoryMe~",
                schema: "psgm",
                table: "RootDirectoryMetadataAuthorization_UserLink",
                column: "RootDirectoryMetadataAuthorization_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectoryMetadataLink_RootDirectoryId",
                schema: "psgm",
                table: "RootDirectoryMetadataLink",
                column: "RootDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectoryMetadataLink_RootDirectoryMetadataId",
                schema: "psgm",
                table: "RootDirectoryMetadataLink",
                column: "RootDirectoryMetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectoryNotification_UserGroupLink_RootDirectoryId",
                schema: "psgm",
                table: "RootDirectoryNotification_UserGroupLink",
                column: "RootDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectoryNotification_UserGroupLink_RootDirectoryNotifi~",
                schema: "psgm",
                table: "RootDirectoryNotification_UserGroupLink",
                column: "RootDirectoryNotification_UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectoryNotification_UserLink_RootDirectoryId",
                schema: "psgm",
                table: "RootDirectoryNotification_UserLink",
                column: "RootDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectoryNotification_UserLink_RootDirectoryNotificatio~",
                schema: "psgm",
                table: "RootDirectoryNotification_UserLink",
                column: "RootDirectoryNotification_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_ParentSubDirectoryId",
                schema: "psgm",
                table: "SubDirectory",
                column: "ParentSubDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_RootDirectoryId",
                schema: "psgm",
                table: "SubDirectory",
                column: "RootDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectoryAuthorization_UserGroupLink_SubDirectoryAuthori~",
                schema: "psgm",
                table: "SubDirectoryAuthorization_UserGroupLink",
                column: "SubDirectoryAuthorization_UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectoryAuthorization_UserGroupLink_SubDirectoryId",
                schema: "psgm",
                table: "SubDirectoryAuthorization_UserGroupLink",
                column: "SubDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectoryAuthorization_UserLink_SubDirectoryAuthorizatio~",
                schema: "psgm",
                table: "SubDirectoryAuthorization_UserLink",
                column: "SubDirectoryAuthorization_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectoryAuthorization_UserLink_SubDirectoryId",
                schema: "psgm",
                table: "SubDirectoryAuthorization_UserLink",
                column: "SubDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectoryMetadataAuthorization_UserGroupLink_SubDirecto~1",
                schema: "psgm",
                table: "SubDirectoryMetadataAuthorization_UserGroupLink",
                column: "SubDirectoryMetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectoryMetadataAuthorization_UserGroupLink_SubDirector~",
                schema: "psgm",
                table: "SubDirectoryMetadataAuthorization_UserGroupLink",
                column: "SubDirectoryMetadataAuthorization_UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectoryMetadataLink_SubDirectoryId",
                schema: "psgm",
                table: "SubDirectoryMetadataLink",
                column: "SubDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectoryMetadataLink_SubDirectoryMetadataId",
                schema: "psgm",
                table: "SubDirectoryMetadataLink",
                column: "SubDirectoryMetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectoryNotification_UserGroupLink_SubDirectoryId",
                schema: "psgm",
                table: "SubDirectoryNotification_UserGroupLink",
                column: "SubDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectoryNotification_UserGroupLink_SubDirectoryNotifica~",
                schema: "psgm",
                table: "SubDirectoryNotification_UserGroupLink",
                column: "SubDirectoryNotification_UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectoryNotification_UserLink_SubDirectoryId",
                schema: "psgm",
                table: "SubDirectoryNotification_UserLink",
                column: "SubDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectoryNotification_UserLink_SubDirectoryNotification_~",
                schema: "psgm",
                table: "SubDirectoryNotification_UserLink",
                column: "SubDirectoryNotification_UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbStorage_SubDirectoryMetadataAuthorization_UserLink",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileAuthorization_User_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileAuthorization_UserGroup_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileAuthorization_UserGroupLink",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileAuthorization_UserGroupLink_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileAuthorization_UserLink",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileAuthorization_UserLink_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileMetadata_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileMetadataAuthorization_User_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileMetadataAuthorization_UserGroup_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileMetadataAuthorization_UserGroupLink",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileMetadataAuthorization_UserGroupLink_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileMetadataAuthorization_UserLink",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileMetadataAuthorization_UserLink_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileMetadataLink",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileMetadataLink_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileNotification_User_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileNotification_UserGroup_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileNotification_UserGroupLink",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileNotification_UserGroupLink_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileNotification_UserLink",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileNotification_UserLink_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileQuality_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "QrCode",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "QrCode_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Quality",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectoryAuthorization_UserGroupLink",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectoryAuthorization_UserGroupLink_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectoryAuthorization_UserLink",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectoryAuthorization_UserLink_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectoryMetadata_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectoryMetadataAuthorization_User_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectoryMetadataAuthorization_UserGroup_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectoryMetadataAuthorization_UserGroupLink",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectoryMetadataAuthorization_UserGroupLink_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectoryMetadataAuthorization_UserLink",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectoryMetadataAuthorization_UserLink_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectoryMetadataLink",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectoryMetadataLink_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectoryNotification_UserGroupLink",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectoryNotification_UserGroupLink_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectoryNotification_UserLink",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectoryNotification_UserLink_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectoryAuthorization_UserGroupLink",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectoryAuthorization_UserGroupLink_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectoryAuthorization_UserLink",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectoryAuthorization_UserLink_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectoryMetadata_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectoryMetadataAuthorization_User_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectoryMetadataAuthorization_UserGroup_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectoryMetadataAuthorization_UserGroupLink",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectoryMetadataAuthorization_UserGroupLink_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectoryMetadataAuthorization_UserLink_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectoryMetadataLink",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectoryMetadataLink_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectoryNotification_UserGroupLink",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectoryNotification_UserGroupLink_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectoryNotification_UserLink",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectoryNotification_UserLink_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectoryMetadataAuthorization_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileAuthorization_UserGroup",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileAuthorization_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileMetadataAuthorization_UserGroup",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileMetadataAuthorization_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileMetadata",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileNotification_UserGroup",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileNotification_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectoryAuthorization_UserGroup",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectoryAuthorization_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectoryMetadataAuthorization_UserGroup",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectoryMetadataAuthorization_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectoryMetadata",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectoryNotification_UserGroup",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectoryNotification_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectoryAuthorization_UserGroup",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectoryAuthorization_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectoryMetadataAuthorization_UserGroup",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectoryMetadata",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectoryNotification_UserGroup",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectoryNotification_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory",
                schema: "psgm");
        }
    }
}
