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
            migrationBuilder.CreateTable(
                name: "File_AuditLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    Changes = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileAuthorization_User_AuditLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    Changes = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileAuthorization_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileAuthorization_UserGroup_AuditLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    Changes = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileAuthorization_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileNotification_User_AuditLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    Changes = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileNotification_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileNotification_UserGroup_AuditLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    Changes = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileNotification_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order_AuditLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    Changes = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderTemplate_AuditLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    Changes = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTemplate_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QrCode_AuditLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    Changes = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QrCode_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Suffix = table.Column<string>(type: "TEXT", maxLength: 127, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 8191, nullable: false),
                    Objects = table.Column<long>(type: "INTEGER", nullable: false),
                    DirectorySize = table.Column<long>(type: "INTEGER", nullable: false),
                    JobIdsExtString = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false),
                    WorkflowItemIdsExtString = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false),
                    BackupIdsExtString = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "TEXT", nullable: false),
                    LastModificationChanges = table.Column<string>(type: "TEXT", maxLength: 8191, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_AuditLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    Changes = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectoryAuthorization_User_AuditLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    Changes = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectoryAuthorization_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectoryAuthorization_UserGroup_AuditLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    Changes = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectoryAuthorization_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectoryNotification_User_AuditLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    Changes = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectoryNotification_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectoryNotification_UserGroup_AuditLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    Changes = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectoryNotification_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_AuditLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    Changes = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectoryAuthorization_User_AuditLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    Changes = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectoryAuthorization_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectoryAuthorization_UserGroup_AuditLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    Changes = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectoryAuthorization_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectoryNotification_User_AuditLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    Changes = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectoryNotification_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectoryNotification_UserGroup_AuditLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    Changes = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectoryNotification_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectoryAuthorization_User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "INTEGER", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    RootDirectoryId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectoryAuthorization_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectoryAuthorization_User_RootDirectory_RootDirectoryId",
                        column: x => x.RootDirectoryId,
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectoryAuthorization_UserGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "INTEGER", nullable: false),
                    UserGroupIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    RootDirectoryId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectoryAuthorization_UserGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectoryAuthorization_UserGroup_RootDirectory_RootDirectoryId",
                        column: x => x.RootDirectoryId,
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectoryNotification_User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 16384, nullable: false),
                    NotificationString = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false),
                    UserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    RootDirectoryId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectoryNotification_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectoryNotification_User_RootDirectory_RootDirectoryId",
                        column: x => x.RootDirectoryId,
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectoryNotification_UserGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 16384, nullable: false),
                    NotificationString = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false),
                    UserGroupIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    RootDirectoryId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectoryNotification_UserGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectoryNotification_UserGroup_RootDirectory_RootDirectoryId",
                        column: x => x.RootDirectoryId,
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Suffix = table.Column<string>(type: "TEXT", maxLength: 127, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 8191, nullable: false),
                    Objects = table.Column<long>(type: "INTEGER", nullable: false),
                    DirectorySize = table.Column<long>(type: "INTEGER", nullable: false),
                    JobsIdExtString = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false),
                    WorkflowItemExtString = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false),
                    BackupsExtString = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "TEXT", nullable: false),
                    LastModificationChanges = table.Column<string>(type: "TEXT", maxLength: 8191, nullable: false),
                    RootDirectoryId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ParentSubDirectoryId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_RootDirectory_RootDirectoryId",
                        column: x => x.RootDirectoryId,
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubDirectory_SubDirectory_ParentSubDirectoryId",
                        column: x => x.ParentSubDirectoryId,
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Suffix = table.Column<string>(type: "TEXT", maxLength: 127, nullable: false),
                    RawFileIdsString = table.Column<string>(type: "TEXT", maxLength: 1023, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 8191, nullable: false),
                    StorageObjectName = table.Column<string>(type: "TEXT", maxLength: 8191, nullable: false),
                    StorageObjectUrlPublic = table.Column<string>(type: "TEXT", maxLength: 4096, nullable: false),
                    ObjectExtension = table.Column<uint>(type: "INTEGER", nullable: false),
                    ObjectSize = table.Column<long>(type: "INTEGER", nullable: false),
                    ObjectMetadataString = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false),
                    MachineIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    DeviceIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    JobsIdExtString = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false),
                    WorkflowItemExtString = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false),
                    BackupsExtString = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "TEXT", nullable: false),
                    LastModificationChanges = table.Column<string>(type: "TEXT", maxLength: 8191, nullable: false),
                    RootDirectoryId = table.Column<Guid>(type: "TEXT", nullable: true),
                    SubDirectoryId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_RootDirectory_RootDirectoryId",
                        column: x => x.RootDirectoryId,
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_File_SubDirectory_SubDirectoryId",
                        column: x => x.SubDirectoryId,
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    InternalContactUserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    InternalContributorsUserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    ExternalContactUserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    ExternalContributorsUserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 8191, nullable: false),
                    OderStatus = table.Column<uint>(type: "INTEGER", maxLength: 1023, nullable: false),
                    OrderDocumentObjectName = table.Column<string>(type: "TEXT", maxLength: 1023, nullable: false),
                    OderProcessingStartedDateTime = table.Column<DateTime>(type: "TEXT", maxLength: 1023, nullable: false),
                    OderProcessingStartedUserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    OderProcessingFinishedDateTime = table.Column<DateTime>(type: "TEXT", maxLength: 1023, nullable: false),
                    OderProcessingFinishedUserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedByUserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedByUserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    LastChanges = table.Column<string>(type: "TEXT", maxLength: 8191, nullable: false),
                    SubDirectoryId = table.Column<Guid>(type: "TEXT", nullable: true),
                    RootDirectoryId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_RootDirectory_RootDirectoryId",
                        column: x => x.RootDirectoryId,
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_SubDirectory_SubDirectoryId",
                        column: x => x.SubDirectoryId,
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectoryAuthorization_User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "INTEGER", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    SubDirectoryId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectoryAuthorization_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectoryAuthorization_User_SubDirectory_SubDirectoryId",
                        column: x => x.SubDirectoryId,
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectoryAuthorization_UserGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "INTEGER", nullable: false),
                    UserGroupIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    SubDirectoryId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectoryAuthorization_UserGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectoryAuthorization_UserGroup_SubDirectory_SubDirectoryId",
                        column: x => x.SubDirectoryId,
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectoryNotification_User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 16384, nullable: false),
                    NotificationString = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false),
                    UserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    SubDirectoryId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectoryNotification_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectoryNotification_User_SubDirectory_SubDirectoryId",
                        column: x => x.SubDirectoryId,
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectoryNotification_UserGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 16384, nullable: false),
                    NotificationString = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false),
                    UserGroupIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    SubDirectoryId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectoryNotification_UserGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectoryNotification_UserGroup_SubDirectory_SubDirectoryId",
                        column: x => x.SubDirectoryId,
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FileAuthorization_User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "INTEGER", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    FileId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileAuthorization_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileAuthorization_User_File_FileId",
                        column: x => x.FileId,
                        principalTable: "File",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FileAuthorization_UserGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "INTEGER", nullable: false),
                    UserGroupIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    FileId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileAuthorization_UserGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileAuthorization_UserGroup_File_FileId",
                        column: x => x.FileId,
                        principalTable: "File",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FileNotification_User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 16384, nullable: false),
                    NotificationString = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false),
                    UserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    FileId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileNotification_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileNotification_User_File_FileId",
                        column: x => x.FileId,
                        principalTable: "File",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FileNotification_UserGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 16384, nullable: false),
                    NotificationString = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false),
                    UserGroupIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    FileId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileNotification_UserGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileNotification_UserGroup_File_FileId",
                        column: x => x.FileId,
                        principalTable: "File",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QrCode",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 8191, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedByUserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedByUserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    LastChanges = table.Column<string>(type: "TEXT", maxLength: 8191, nullable: false),
                    FileId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QrCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QrCode_File_FileId",
                        column: x => x.FileId,
                        principalTable: "File",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderTemplate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    InternalContactUserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    InternalContributorsUserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    ExternalContactUserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    ExternalContributorsUserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 8191, nullable: false),
                    OderStatus = table.Column<uint>(type: "INTEGER", maxLength: 1023, nullable: false),
                    OrderDocumentObjectName = table.Column<string>(type: "TEXT", maxLength: 1023, nullable: false),
                    OderProcessingStartedDateTime = table.Column<DateTime>(type: "TEXT", maxLength: 1023, nullable: false),
                    OderProcessingStartedUserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    OderProcessingFinishedDateTime = table.Column<DateTime>(type: "TEXT", maxLength: 1023, nullable: false),
                    OderProcessingFinishedUserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedByUserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedByUserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    LastChanges = table.Column<string>(type: "TEXT", maxLength: 8191, nullable: false),
                    OrderId = table.Column<Guid>(type: "TEXT", nullable: true),
                    SubDirectoryId = table.Column<Guid>(type: "TEXT", nullable: true),
                    RootDirectoryId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderTemplate_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderTemplate_RootDirectory_RootDirectoryId",
                        column: x => x.RootDirectoryId,
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderTemplate_SubDirectory_SubDirectoryId",
                        column: x => x.SubDirectoryId,
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_File_RootDirectoryId",
                table: "File",
                column: "RootDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_File_SubDirectoryId",
                table: "File",
                column: "SubDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FileAuthorization_User_FileId",
                table: "FileAuthorization_User",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_FileAuthorization_UserGroup_FileId",
                table: "FileAuthorization_UserGroup",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_FileNotification_User_FileId",
                table: "FileNotification_User",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_FileNotification_UserGroup_FileId",
                table: "FileNotification_UserGroup",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_RootDirectoryId",
                table: "Order",
                column: "RootDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_SubDirectoryId",
                table: "Order",
                column: "SubDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTemplate_OrderId",
                table: "OrderTemplate",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderTemplate_RootDirectoryId",
                table: "OrderTemplate",
                column: "RootDirectoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderTemplate_SubDirectoryId",
                table: "OrderTemplate",
                column: "SubDirectoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QrCode_FileId",
                table: "QrCode",
                column: "FileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectoryAuthorization_User_RootDirectoryId",
                table: "RootDirectoryAuthorization_User",
                column: "RootDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectoryAuthorization_UserGroup_RootDirectoryId",
                table: "RootDirectoryAuthorization_UserGroup",
                column: "RootDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectoryNotification_User_RootDirectoryId",
                table: "RootDirectoryNotification_User",
                column: "RootDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectoryNotification_UserGroup_RootDirectoryId",
                table: "RootDirectoryNotification_UserGroup",
                column: "RootDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_ParentSubDirectoryId",
                table: "SubDirectory",
                column: "ParentSubDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_RootDirectoryId",
                table: "SubDirectory",
                column: "RootDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectoryAuthorization_User_SubDirectoryId",
                table: "SubDirectoryAuthorization_User",
                column: "SubDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectoryAuthorization_UserGroup_SubDirectoryId",
                table: "SubDirectoryAuthorization_UserGroup",
                column: "SubDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectoryNotification_User_SubDirectoryId",
                table: "SubDirectoryNotification_User",
                column: "SubDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectoryNotification_UserGroup_SubDirectoryId",
                table: "SubDirectoryNotification_UserGroup",
                column: "SubDirectoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File_AuditLog");

            migrationBuilder.DropTable(
                name: "FileAuthorization_User");

            migrationBuilder.DropTable(
                name: "FileAuthorization_User_AuditLog");

            migrationBuilder.DropTable(
                name: "FileAuthorization_UserGroup");

            migrationBuilder.DropTable(
                name: "FileAuthorization_UserGroup_AuditLog");

            migrationBuilder.DropTable(
                name: "FileNotification_User");

            migrationBuilder.DropTable(
                name: "FileNotification_User_AuditLog");

            migrationBuilder.DropTable(
                name: "FileNotification_UserGroup");

            migrationBuilder.DropTable(
                name: "FileNotification_UserGroup_AuditLog");

            migrationBuilder.DropTable(
                name: "Order_AuditLog");

            migrationBuilder.DropTable(
                name: "OrderTemplate");

            migrationBuilder.DropTable(
                name: "OrderTemplate_AuditLog");

            migrationBuilder.DropTable(
                name: "QrCode");

            migrationBuilder.DropTable(
                name: "QrCode_AuditLog");

            migrationBuilder.DropTable(
                name: "RootDirectory_AuditLog");

            migrationBuilder.DropTable(
                name: "RootDirectoryAuthorization_User");

            migrationBuilder.DropTable(
                name: "RootDirectoryAuthorization_User_AuditLog");

            migrationBuilder.DropTable(
                name: "RootDirectoryAuthorization_UserGroup");

            migrationBuilder.DropTable(
                name: "RootDirectoryAuthorization_UserGroup_AuditLog");

            migrationBuilder.DropTable(
                name: "RootDirectoryNotification_User");

            migrationBuilder.DropTable(
                name: "RootDirectoryNotification_User_AuditLog");

            migrationBuilder.DropTable(
                name: "RootDirectoryNotification_UserGroup");

            migrationBuilder.DropTable(
                name: "RootDirectoryNotification_UserGroup_AuditLog");

            migrationBuilder.DropTable(
                name: "SubDirectory_AuditLog");

            migrationBuilder.DropTable(
                name: "SubDirectoryAuthorization_User");

            migrationBuilder.DropTable(
                name: "SubDirectoryAuthorization_User_AuditLog");

            migrationBuilder.DropTable(
                name: "SubDirectoryAuthorization_UserGroup");

            migrationBuilder.DropTable(
                name: "SubDirectoryAuthorization_UserGroup_AuditLog");

            migrationBuilder.DropTable(
                name: "SubDirectoryNotification_User");

            migrationBuilder.DropTable(
                name: "SubDirectoryNotification_User_AuditLog");

            migrationBuilder.DropTable(
                name: "SubDirectoryNotification_UserGroup");

            migrationBuilder.DropTable(
                name: "SubDirectoryNotification_UserGroup_AuditLog");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "SubDirectory");

            migrationBuilder.DropTable(
                name: "RootDirectory");
        }
    }
}
