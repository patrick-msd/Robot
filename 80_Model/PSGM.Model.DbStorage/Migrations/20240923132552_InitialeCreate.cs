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
                name: "File_Authorization_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "integer", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_Authorization_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Authorization_User_AuditLog",
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
                    table.PrimaryKey("PK_File_Authorization_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Authorization_User_Link_AuditLog",
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
                    table.PrimaryKey("PK_File_Authorization_User_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Authorization_UserGroup",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "integer", nullable: false),
                    UserGroupIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_Authorization_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Authorization_UserGroup_AuditLog",
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
                    table.PrimaryKey("PK_File_Authorization_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Authorization_UserGroup_Link_AuditLog",
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
                    table.PrimaryKey("PK_File_Authorization_UserGroup_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Metadata",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    Value = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    Description = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    MetadataType = table.Column<int>(type: "integer", nullable: false),
                    MetadataPermissions = table.Column<int>(type: "integer", nullable: false),
                    ApplicableForFiles = table.Column<bool>(type: "boolean", nullable: false),
                    Stars = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_Metadata", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Metadata_AuditLog",
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
                    table.PrimaryKey("PK_File_Metadata_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Metadata_Authorization_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "integer", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_Metadata_Authorization_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Metadata_Authorization_User_AuditLog",
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
                    table.PrimaryKey("PK_File_Metadata_Authorization_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Metadata_Authorization_User_Link_AuditLog",
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
                    table.PrimaryKey("PK_File_Metadata_Authorization_User_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Metadata_Authorization_UserGroup",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "integer", nullable: false),
                    UserGroupIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_Metadata_Authorization_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Metadata_Authorization_UserGroup_AuditLog",
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
                    table.PrimaryKey("PK_File_Metadata_Authorization_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Metadata_Authorization_UserGroup_Link_AuditLog",
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
                    table.PrimaryKey("PK_File_Metadata_Authorization_UserGroup_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Metadata_Link_AuditLog",
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
                    table.PrimaryKey("PK_File_Metadata_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Notification_User",
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
                    Gotify = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_Notification_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Notification_User_AuditLog",
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
                    table.PrimaryKey("PK_File_Notification_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Notification_User_Link_AuditLog",
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
                    table.PrimaryKey("PK_File_Notification_User_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Notification_UserGroup",
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
                    Gotify = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_Notification_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Notification_UserGroup_AuditLog",
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
                    table.PrimaryKey("PK_File_Notification_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Notification_UserGroup_Link_AuditLog",
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
                    table.PrimaryKey("PK_File_Notification_UserGroup_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_QrCode_AuditLog",
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
                    table.PrimaryKey("PK_File_QrCode_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Quality_AuditLog",
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
                    table.PrimaryKey("PK_File_Quality_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    Acronym = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    DaytimePhoneNumber = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    EveningPhoneNumber = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    EMail = table.Column<string>(type: "character varying(511)", maxLength: 511, nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_UserGroup",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_UserGroup_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    Acronym = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    DaytimePhoneNumber = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    EveningPhoneNumber = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    EMail = table.Column<string>(type: "character varying(511)", maxLength: 511, nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_UserGroup_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_VirtualSubUnit_AuditLog",
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
                    table.PrimaryKey("PK_File_VirtualSubUnit_AuditLog", x => x.Id);
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
                    DirectoryState = table.Column<int>(type: "integer", nullable: false),
                    DirectoryLocked = table.Column<bool>(type: "boolean", nullable: false),
                    ArchiveIds_ExtString = table.Column<string>(type: "character varying(32766)", maxLength: 32766, nullable: false),
                    JobIdsExt_String = table.Column<string>(type: "character varying(65532)", maxLength: 65532, nullable: false),
                    WorkflowItemIds_ExtString = table.Column<string>(type: "character varying(65532)", maxLength: 65532, nullable: false),
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
                name: "RootDirectory_Authorization_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "integer", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_Authorization_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Authorization_User_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_Authorization_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Authorization_User_Link_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_Authorization_User_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Authorization_UserGroup",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "integer", nullable: false),
                    UserGroupIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_Authorization_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Authorization_UserGroup_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_Authorization_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Authorization_UserGroup_Link_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_Authorization_UserGroup_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Metadata",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    Value = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    Description = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    MetadataType = table.Column<int>(type: "integer", nullable: false),
                    MetadataPermissions = table.Column<int>(type: "integer", nullable: false),
                    ApplicableForFiles = table.Column<bool>(type: "boolean", nullable: false),
                    Stars = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_Metadata", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Metadata_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_Metadata_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Metadata_Authorization_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "integer", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_Metadata_Authorization_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Metadata_Authorization_User_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_Metadata_Authorization_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Metadata_Authorization_User_Link_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_Metadata_Authorization_User_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Metadata_Authorization_UserGroup",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "integer", nullable: false),
                    UserGroupIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_Metadata_Authorization_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Metadata_Authorization_UserGroup_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_Metadata_Authorization_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Metadata_Authorization_UserGroup_Link_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_Metadata_Authorization_UserGroup_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Metadata_Link_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_Metadata_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Notification_User",
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
                    Gotify = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_Notification_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Notification_User_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_Notification_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Notification_User_Link_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_Notification_User_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Notification_UserGroup",
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
                    Gotify = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_Notification_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Notification_UserGroup_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_Notification_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Notification_UserGroupLink_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_Notification_UserGroupLink_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_QrCode_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_QrCode_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Quality_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_Quality_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_VirtualRootUnit_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_VirtualRootUnit_AuditLog", x => x.Id);
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
                name: "SubDirectory_Authorization_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "integer", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_Authorization_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Authorization_User_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_Authorization_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Authorization_User_Link_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_Authorization_User_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Authorization_UserGroup",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "integer", nullable: false),
                    UserGroupIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_Authorization_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Authorization_UserGroup_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_Authorization_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Authorization_UserGroup_Link_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_Authorization_UserGroup_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Metadata",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    Value = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    Description = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    MetadataType = table.Column<int>(type: "integer", nullable: false),
                    MetadataPermissions = table.Column<int>(type: "integer", nullable: false),
                    ApplicableForFiles = table.Column<bool>(type: "boolean", nullable: false),
                    Stars = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_Metadata", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Metadata_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_Metadata_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Metadata_Authorization_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "integer", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_Metadata_Authorization_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Metadata_Authorization_User_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_Metadata_Authorization_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Metadata_Authorization_User_Link_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_Metadata_Authorization_User_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Metadata_Authorization_UserGroup",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "integer", nullable: false),
                    UserGroupIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_Metadata_Authorization_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Metadata_Authorization_UserGroup_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_Metadata_Authorization_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Metadata_Authorization_UserGroup_Link_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_Metadata_Authorization_UserGroup_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Metadata_Link_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_Metadata_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Notification_User",
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
                    Gotify = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_Notification_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Notification_User_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_Notification_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Notification_User_Link_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_Notification_User_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Notification_UserGroup",
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
                    Gotify = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_Notification_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Notification_UserGroup_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_Notification_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Notification_UserGroup_Link_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_Notification_UserGroup_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_QrCode_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_QrCode_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_QualityAuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_QualityAuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_VirtualSubUnit_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_VirtualSubUnit_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Metadata_Authorization_User_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MetadataId = table.Column<Guid>(type: "uuid", nullable: true),
                    AuthorizationUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_Metadata_Authorization_User_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_Metadata_Authorization_User_Link_File_Metadata_Authori~",
                        column: x => x.AuthorizationUserId,
                        principalSchema: "psgm",
                        principalTable: "File_Metadata_Authorization_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_File_Metadata_Authorization_User_Link_File_Metadata_Metadat~",
                        column: x => x.MetadataId,
                        principalSchema: "psgm",
                        principalTable: "File_Metadata",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File_Metadata_Authorization_UserGroup_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MetadataId = table.Column<Guid>(type: "uuid", nullable: true),
                    AuthorizationUserGroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_Metadata_Authorization_UserGroup_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_Metadata_Authorization_UserGroup_Link_File_Metadata_Au~",
                        column: x => x.AuthorizationUserGroupId,
                        principalSchema: "psgm",
                        principalTable: "File_Metadata_Authorization_UserGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_File_Metadata_Authorization_UserGroup_Link_File_Metadata_Me~",
                        column: x => x.MetadataId,
                        principalSchema: "psgm",
                        principalTable: "File_Metadata",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File_User_Notification",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    TriggerType = table.Column<int>(type: "integer", nullable: false),
                    TriggerState = table.Column<int>(type: "integer", nullable: false),
                    EMail = table.Column<bool>(type: "boolean", nullable: false),
                    Slack = table.Column<bool>(type: "boolean", nullable: false),
                    Teams = table.Column<bool>(type: "boolean", nullable: false),
                    SMS = table.Column<bool>(type: "boolean", nullable: false),
                    WhatsApp = table.Column<bool>(type: "boolean", nullable: false),
                    Telegram = table.Column<bool>(type: "boolean", nullable: false),
                    Gotify = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_User_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_User_Notification_File_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "psgm",
                        principalTable: "File_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File_User_Permission",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    PermissionFile = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_User_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_User_Permission_File_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "psgm",
                        principalTable: "File_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File_UserGroup_Notification",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    TriggerType = table.Column<int>(type: "integer", nullable: false),
                    TriggerState = table.Column<int>(type: "integer", nullable: false),
                    EMail = table.Column<bool>(type: "boolean", nullable: false),
                    Slack = table.Column<bool>(type: "boolean", nullable: false),
                    Teams = table.Column<bool>(type: "boolean", nullable: false),
                    SMS = table.Column<bool>(type: "boolean", nullable: false),
                    WhatsApp = table.Column<bool>(type: "boolean", nullable: false),
                    Telegram = table.Column<bool>(type: "boolean", nullable: false),
                    Gotify = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_UserGroup_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_UserGroup_Notification_File_UserGroup_UserGroupId",
                        column: x => x.UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "File_UserGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File_UserGroup_Permission",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    PermissionFile = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_UserGroup_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_UserGroup_Permission_File_UserGroup_UserGroupId",
                        column: x => x.UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "File_UserGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File_UserGroup_User_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_UserGroup_User_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_UserGroup_User_Link_File_UserGroup_UserGroupId",
                        column: x => x.UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "File_UserGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_File_UserGroup_User_Link_File_UserGroup_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "psgm",
                        principalTable: "File_UserGroup_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_QrCode",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    QrCodeType = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    RootDirectoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_QrCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectory_QrCode_RootDirectory_RootDirectoryId",
                        column: x => x.RootDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Quality",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QualityState = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    RootDirectoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_Quality", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectory_Quality_RootDirectory_RootDirectoryId",
                        column: x => x.RootDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_VirtualRootUnit",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VirtualRootUnitId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    RootDirectoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_VirtualRootUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectory_VirtualRootUnit_RootDirectory_RootDirectoryId",
                        column: x => x.RootDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory",
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
                    DirectoryState = table.Column<int>(type: "integer", nullable: false),
                    DirectoryLocked = table.Column<bool>(type: "boolean", nullable: false),
                    ArchiveIds_ExtString = table.Column<string>(type: "character varying(32766)", maxLength: 32766, nullable: false),
                    JobIdsExt_String = table.Column<string>(type: "character varying(65532)", maxLength: 65532, nullable: false),
                    WorkflowItemIds_ExtString = table.Column<string>(type: "character varying(65532)", maxLength: 65532, nullable: false),
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
                name: "RootDirectory_Authorization_User_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RootDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    AuthorizationUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_Authorization_User_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectory_Authorization_User_Link_RootDirectory_Authori~",
                        column: x => x.AuthorizationUserId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory_Authorization_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RootDirectory_Authorization_User_Link_RootDirectory_RootDir~",
                        column: x => x.RootDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Authorization_UserGroup_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RootDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    AuthorizationUserGroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_Authorization_UserGroup_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectory_Authorization_UserGroup_Link_RootDirectory_Au~",
                        column: x => x.AuthorizationUserGroupId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory_Authorization_UserGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RootDirectory_Authorization_UserGroup_Link_RootDirectory_Ro~",
                        column: x => x.RootDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Metadata_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RootDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    MetadataId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_Metadata_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectory_Metadata_Link_RootDirectory_Metadata_Metadata~",
                        column: x => x.MetadataId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory_Metadata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RootDirectory_Metadata_Link_RootDirectory_RootDirectoryId",
                        column: x => x.RootDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Metadata_Authorization_User_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MetadataId = table.Column<Guid>(type: "uuid", nullable: true),
                    AuthorizationUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_Metadata_Authorization_User_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectory_Metadata_Authorization_User_Link_RootDirector~",
                        column: x => x.AuthorizationUserId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory_Metadata_Authorization_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RootDirectory_Metadata_Authorization_User_Link_RootDirecto~1",
                        column: x => x.MetadataId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory_Metadata",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Metadata_Authorization_UserGroup_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MetadataId = table.Column<Guid>(type: "uuid", nullable: true),
                    AuthorizationUserGroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_Metadata_Authorization_UserGroup_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectory_Metadata_Authorization_UserGroup_Link_RootDir~",
                        column: x => x.AuthorizationUserGroupId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory_Metadata_Authorization_UserGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RootDirectory_Metadata_Authorization_UserGroup_Link_RootDi~1",
                        column: x => x.MetadataId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory_Metadata",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Notification_User_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RootDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    NotificationUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_Notification_User_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectory_Notification_User_Link_RootDirectory_Notifica~",
                        column: x => x.NotificationUserId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory_Notification_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RootDirectory_Notification_User_Link_RootDirectory_RootDire~",
                        column: x => x.RootDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Notification_UserGroup_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RootDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    NotificationUserGroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_Notification_UserGroup_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectory_Notification_UserGroup_Link_RootDirectory_Not~",
                        column: x => x.NotificationUserGroupId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory_Notification_UserGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RootDirectory_Notification_UserGroup_Link_RootDirectory_Roo~",
                        column: x => x.RootDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Metadata_Authorization_User_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MetadataId = table.Column<Guid>(type: "uuid", nullable: true),
                    AuthorizationUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_Metadata_Authorization_User_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_Metadata_Authorization_User_Link_SubDirectory_~",
                        column: x => x.AuthorizationUserId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory_Metadata_Authorization_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubDirectory_Metadata_Authorization_User_Link_SubDirectory~1",
                        column: x => x.MetadataId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory_Metadata",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Metadata_Authorization_UserGroup_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MetadataId = table.Column<Guid>(type: "uuid", nullable: true),
                    AuthorizationUserGroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_Metadata_Authorization_UserGroup_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_Metadata_Authorization_UserGroup_Link_SubDirec~",
                        column: x => x.AuthorizationUserGroupId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory_Metadata_Authorization_UserGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubDirectory_Metadata_Authorization_UserGroup_Link_SubDire~1",
                        column: x => x.MetadataId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory_Metadata",
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
                    ObjectExtension = table.Column<int>(type: "integer", nullable: false),
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
                    ArchiveIds_ExtString = table.Column<string>(type: "character varying(32766)", maxLength: 32766, nullable: false),
                    JobIdsExt_String = table.Column<string>(type: "character varying(65532)", maxLength: 65532, nullable: false),
                    WorkflowItemIds_ExtString = table.Column<string>(type: "character varying(65532)", maxLength: 65532, nullable: false),
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
                name: "SubDirectory_Authorization_User_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    Authorization_UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_Authorization_User_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_Authorization_User_Link_SubDirectory_Authoriza~",
                        column: x => x.Authorization_UserId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory_Authorization_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubDirectory_Authorization_User_Link_SubDirectory_SubDirect~",
                        column: x => x.SubDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Authorization_UserGroup_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    AuthorizationUserGroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_Authorization_UserGroup_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_Authorization_UserGroup_Link_SubDirectory_Auth~",
                        column: x => x.AuthorizationUserGroupId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory_Authorization_UserGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubDirectory_Authorization_UserGroup_Link_SubDirectory_SubD~",
                        column: x => x.SubDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Metadata_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    MetadataId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_Metadata_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_Metadata_Link_SubDirectory_Metadata_MetadataId",
                        column: x => x.MetadataId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory_Metadata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubDirectory_Metadata_Link_SubDirectory_SubDirectoryId",
                        column: x => x.SubDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Notification_User_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    NotificationUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_Notification_User_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_Notification_User_Link_SubDirectory_Notificati~",
                        column: x => x.NotificationUserId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory_Notification_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubDirectory_Notification_User_Link_SubDirectory_SubDirecto~",
                        column: x => x.SubDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Notification_UserGroup_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    NotificationUserGroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_Notification_UserGroup_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_Notification_UserGroup_Link_SubDirectory_Notif~",
                        column: x => x.NotificationUserGroupId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory_Notification_UserGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubDirectory_Notification_UserGroup_Link_SubDirectory_SubDi~",
                        column: x => x.SubDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_QrCode",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    QrCodeType = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    SubDirectoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_QrCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_QrCode_SubDirectory_SubDirectoryId",
                        column: x => x.SubDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Quality",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QualityState = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    SubDirectoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_Quality", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_Quality_SubDirectory_SubDirectoryId",
                        column: x => x.SubDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_VirtualSubUnit",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VirtualSubUnitId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    SubDirectoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_VirtualSubUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_VirtualSubUnit_SubDirectory_SubDirectoryId",
                        column: x => x.SubDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File_Authorization_User_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: true),
                    AuthorizationUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_Authorization_User_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_Authorization_User_Link_File_Authorization_User_Author~",
                        column: x => x.AuthorizationUserId,
                        principalSchema: "psgm",
                        principalTable: "File_Authorization_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_File_Authorization_User_Link_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "psgm",
                        principalTable: "File",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File_Authorization_UserGroup_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: true),
                    AuthorizationUserGroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_Authorization_UserGroup_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_Authorization_UserGroup_Link_File_Authorization_UserGr~",
                        column: x => x.AuthorizationUserGroupId,
                        principalSchema: "psgm",
                        principalTable: "File_Authorization_UserGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_File_Authorization_UserGroup_Link_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "psgm",
                        principalTable: "File",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File_Metadata_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: true),
                    MetadataId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_Metadata_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_Metadata_Link_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "psgm",
                        principalTable: "File",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_File_Metadata_Link_File_Metadata_MetadataId",
                        column: x => x.MetadataId,
                        principalSchema: "psgm",
                        principalTable: "File_Metadata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "File_Notification_User_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: true),
                    NotificationUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_Notification_User_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_Notification_User_Link_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "psgm",
                        principalTable: "File",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_File_Notification_User_Link_File_Notification_User_Notifica~",
                        column: x => x.NotificationUserId,
                        principalSchema: "psgm",
                        principalTable: "File_Notification_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "File_Notification_UserGroup_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: true),
                    NotificationUserGroupId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_Notification_UserGroup_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_Notification_UserGroup_Link_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "psgm",
                        principalTable: "File",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_File_Notification_UserGroup_Link_File_Notification_UserGrou~",
                        column: x => x.NotificationUserGroupId,
                        principalSchema: "psgm",
                        principalTable: "File_Notification_UserGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "File_QrCode",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    QrCodeType = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_QrCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_QrCode_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "psgm",
                        principalTable: "File",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File_Quality",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QualityState = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_Quality", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_Quality_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "psgm",
                        principalTable: "File",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File_User_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_User_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_User_Link_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "psgm",
                        principalTable: "File",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_File_User_Link_File_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "psgm",
                        principalTable: "File_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File_UserGroup_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_UserGroup_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_UserGroup_Link_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "psgm",
                        principalTable: "File",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_File_UserGroup_Link_File_UserGroup_UserGroupId",
                        column: x => x.UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "File_UserGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File_VirtualSubUnit",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VirtualSubUnitId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_VirtualSubUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_VirtualSubUnit_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "psgm",
                        principalTable: "File",
                        principalColumn: "Id");
                });

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
                name: "IX_File_Authorization_User_Link_AuthorizationUserId",
                schema: "psgm",
                table: "File_Authorization_User_Link",
                column: "AuthorizationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_File_Authorization_User_Link_FileId",
                schema: "psgm",
                table: "File_Authorization_User_Link",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_File_Authorization_UserGroup_Link_AuthorizationUserGroupId",
                schema: "psgm",
                table: "File_Authorization_UserGroup_Link",
                column: "AuthorizationUserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_File_Authorization_UserGroup_Link_FileId",
                schema: "psgm",
                table: "File_Authorization_UserGroup_Link",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_File_Metadata_Authorization_User_Link_AuthorizationUserId",
                schema: "psgm",
                table: "File_Metadata_Authorization_User_Link",
                column: "AuthorizationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_File_Metadata_Authorization_User_Link_MetadataId",
                schema: "psgm",
                table: "File_Metadata_Authorization_User_Link",
                column: "MetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_File_Metadata_Authorization_UserGroup_Link_AuthorizationUse~",
                schema: "psgm",
                table: "File_Metadata_Authorization_UserGroup_Link",
                column: "AuthorizationUserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_File_Metadata_Authorization_UserGroup_Link_MetadataId",
                schema: "psgm",
                table: "File_Metadata_Authorization_UserGroup_Link",
                column: "MetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_File_Metadata_Link_FileId",
                schema: "psgm",
                table: "File_Metadata_Link",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_File_Metadata_Link_MetadataId",
                schema: "psgm",
                table: "File_Metadata_Link",
                column: "MetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_File_Notification_User_Link_FileId",
                schema: "psgm",
                table: "File_Notification_User_Link",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_File_Notification_User_Link_NotificationUserId",
                schema: "psgm",
                table: "File_Notification_User_Link",
                column: "NotificationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_File_Notification_UserGroup_Link_FileId",
                schema: "psgm",
                table: "File_Notification_UserGroup_Link",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_File_Notification_UserGroup_Link_NotificationUserGroupId",
                schema: "psgm",
                table: "File_Notification_UserGroup_Link",
                column: "NotificationUserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_File_QrCode_FileId",
                schema: "psgm",
                table: "File_QrCode",
                column: "FileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_File_Quality_FileId",
                schema: "psgm",
                table: "File_Quality",
                column: "FileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_File_User_Link_FileId",
                schema: "psgm",
                table: "File_User_Link",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_File_User_Link_UserId",
                schema: "psgm",
                table: "File_User_Link",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_File_User_Notification_UserId",
                schema: "psgm",
                table: "File_User_Notification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_File_User_Permission_UserId",
                schema: "psgm",
                table: "File_User_Permission",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_File_UserGroup_Link_FileId",
                schema: "psgm",
                table: "File_UserGroup_Link",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_File_UserGroup_Link_UserGroupId",
                schema: "psgm",
                table: "File_UserGroup_Link",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_File_UserGroup_Notification_UserGroupId",
                schema: "psgm",
                table: "File_UserGroup_Notification",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_File_UserGroup_Permission_UserGroupId",
                schema: "psgm",
                table: "File_UserGroup_Permission",
                column: "UserGroupId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_File_UserGroup_User_Link_UserGroupId",
                schema: "psgm",
                table: "File_UserGroup_User_Link",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_File_UserGroup_User_Link_UserId",
                schema: "psgm",
                table: "File_UserGroup_User_Link",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_File_VirtualSubUnit_FileId",
                schema: "psgm",
                table: "File_VirtualSubUnit",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_Authorization_User_Link_AuthorizationUserId",
                schema: "psgm",
                table: "RootDirectory_Authorization_User_Link",
                column: "AuthorizationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_Authorization_User_Link_RootDirectoryId",
                schema: "psgm",
                table: "RootDirectory_Authorization_User_Link",
                column: "RootDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_Authorization_UserGroup_Link_AuthorizationUse~",
                schema: "psgm",
                table: "RootDirectory_Authorization_UserGroup_Link",
                column: "AuthorizationUserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_Authorization_UserGroup_Link_RootDirectoryId",
                schema: "psgm",
                table: "RootDirectory_Authorization_UserGroup_Link",
                column: "RootDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_Metadata_Authorization_User_Link_Authorizatio~",
                schema: "psgm",
                table: "RootDirectory_Metadata_Authorization_User_Link",
                column: "AuthorizationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_Metadata_Authorization_User_Link_MetadataId",
                schema: "psgm",
                table: "RootDirectory_Metadata_Authorization_User_Link",
                column: "MetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_Metadata_Authorization_UserGroup_Link_Authori~",
                schema: "psgm",
                table: "RootDirectory_Metadata_Authorization_UserGroup_Link",
                column: "AuthorizationUserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_Metadata_Authorization_UserGroup_Link_Metadat~",
                schema: "psgm",
                table: "RootDirectory_Metadata_Authorization_UserGroup_Link",
                column: "MetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_Metadata_Link_MetadataId",
                schema: "psgm",
                table: "RootDirectory_Metadata_Link",
                column: "MetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_Metadata_Link_RootDirectoryId",
                schema: "psgm",
                table: "RootDirectory_Metadata_Link",
                column: "RootDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_Notification_User_Link_NotificationUserId",
                schema: "psgm",
                table: "RootDirectory_Notification_User_Link",
                column: "NotificationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_Notification_User_Link_RootDirectoryId",
                schema: "psgm",
                table: "RootDirectory_Notification_User_Link",
                column: "RootDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_Notification_UserGroup_Link_NotificationUserG~",
                schema: "psgm",
                table: "RootDirectory_Notification_UserGroup_Link",
                column: "NotificationUserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_Notification_UserGroup_Link_RootDirectoryId",
                schema: "psgm",
                table: "RootDirectory_Notification_UserGroup_Link",
                column: "RootDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_QrCode_RootDirectoryId",
                schema: "psgm",
                table: "RootDirectory_QrCode",
                column: "RootDirectoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_Quality_RootDirectoryId",
                schema: "psgm",
                table: "RootDirectory_Quality",
                column: "RootDirectoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_VirtualRootUnit_RootDirectoryId",
                schema: "psgm",
                table: "RootDirectory_VirtualRootUnit",
                column: "RootDirectoryId");

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
                name: "IX_SubDirectory_Authorization_User_Link_Authorization_UserId",
                schema: "psgm",
                table: "SubDirectory_Authorization_User_Link",
                column: "Authorization_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_Authorization_User_Link_SubDirectoryId",
                schema: "psgm",
                table: "SubDirectory_Authorization_User_Link",
                column: "SubDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_Authorization_UserGroup_Link_AuthorizationUser~",
                schema: "psgm",
                table: "SubDirectory_Authorization_UserGroup_Link",
                column: "AuthorizationUserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_Authorization_UserGroup_Link_SubDirectoryId",
                schema: "psgm",
                table: "SubDirectory_Authorization_UserGroup_Link",
                column: "SubDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_Metadata_Authorization_User_Link_Authorization~",
                schema: "psgm",
                table: "SubDirectory_Metadata_Authorization_User_Link",
                column: "AuthorizationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_Metadata_Authorization_User_Link_MetadataId",
                schema: "psgm",
                table: "SubDirectory_Metadata_Authorization_User_Link",
                column: "MetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_Metadata_Authorization_UserGroup_Link_Authoriz~",
                schema: "psgm",
                table: "SubDirectory_Metadata_Authorization_UserGroup_Link",
                column: "AuthorizationUserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_Metadata_Authorization_UserGroup_Link_Metadata~",
                schema: "psgm",
                table: "SubDirectory_Metadata_Authorization_UserGroup_Link",
                column: "MetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_Metadata_Link_MetadataId",
                schema: "psgm",
                table: "SubDirectory_Metadata_Link",
                column: "MetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_Metadata_Link_SubDirectoryId",
                schema: "psgm",
                table: "SubDirectory_Metadata_Link",
                column: "SubDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_Notification_User_Link_NotificationUserId",
                schema: "psgm",
                table: "SubDirectory_Notification_User_Link",
                column: "NotificationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_Notification_User_Link_SubDirectoryId",
                schema: "psgm",
                table: "SubDirectory_Notification_User_Link",
                column: "SubDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_Notification_UserGroup_Link_NotificationUserGr~",
                schema: "psgm",
                table: "SubDirectory_Notification_UserGroup_Link",
                column: "NotificationUserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_Notification_UserGroup_Link_SubDirectoryId",
                schema: "psgm",
                table: "SubDirectory_Notification_UserGroup_Link",
                column: "SubDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_QrCode_SubDirectoryId",
                schema: "psgm",
                table: "SubDirectory_QrCode",
                column: "SubDirectoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_Quality_SubDirectoryId",
                schema: "psgm",
                table: "SubDirectory_Quality",
                column: "SubDirectoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_VirtualSubUnit_SubDirectoryId",
                schema: "psgm",
                table: "SubDirectory_VirtualSubUnit",
                column: "SubDirectoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Authorization_User_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Authorization_User_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Authorization_User_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Authorization_UserGroup_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Authorization_UserGroup_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Authorization_UserGroup_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Metadata_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Metadata_Authorization_User_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Metadata_Authorization_User_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Metadata_Authorization_User_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Metadata_Authorization_UserGroup_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Metadata_Authorization_UserGroup_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Metadata_Authorization_UserGroup_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Metadata_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Metadata_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Notification_User_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Notification_User_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Notification_User_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Notification_UserGroup_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Notification_UserGroup_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Notification_UserGroup_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_QrCode",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_QrCode_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Quality",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Quality_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_User_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_User_Notification",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_User_Permission",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_UserGroup_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_UserGroup_Notification",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_UserGroup_Permission",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_UserGroup_User_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_VirtualSubUnit",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_VirtualSubUnit_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Authorization_User_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Authorization_User_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Authorization_User_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Authorization_UserGroup_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Authorization_UserGroup_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Authorization_UserGroup_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Metadata_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Metadata_Authorization_User_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Metadata_Authorization_User_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Metadata_Authorization_User_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Metadata_Authorization_UserGroup_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Metadata_Authorization_UserGroup_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Metadata_Authorization_UserGroup_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Metadata_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Metadata_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Notification_User_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Notification_User_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Notification_User_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Notification_UserGroup_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Notification_UserGroup_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Notification_UserGroupLink_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_QrCode",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_QrCode_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Quality",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Quality_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_VirtualRootUnit",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_VirtualRootUnit_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Authorization_User_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Authorization_User_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Authorization_User_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Authorization_UserGroup_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Authorization_UserGroup_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Authorization_UserGroup_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Metadata_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Metadata_Authorization_User_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Metadata_Authorization_User_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Metadata_Authorization_User_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Metadata_Authorization_UserGroup_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Metadata_Authorization_UserGroup_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Metadata_Authorization_UserGroup_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Metadata_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Metadata_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Notification_User_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Notification_User_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Notification_User_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Notification_UserGroup_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Notification_UserGroup_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Notification_UserGroup_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_QrCode",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_QrCode_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Quality",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_QualityAuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_VirtualSubUnit",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_VirtualSubUnit_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Authorization_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Authorization_UserGroup",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Metadata_Authorization_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Metadata_Authorization_UserGroup",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Metadata",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Notification_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Notification_UserGroup",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_UserGroup",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_UserGroup_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Authorization_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Authorization_UserGroup",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Metadata_Authorization_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Metadata_Authorization_UserGroup",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Metadata",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Notification_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Notification_UserGroup",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Authorization_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Authorization_UserGroup",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Metadata_Authorization_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Metadata_Authorization_UserGroup",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Metadata",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Notification_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Notification_UserGroup",
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
