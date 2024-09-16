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
                    AuthorizationUsersString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    AuthorizationUserGroupsString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
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
                    Stars = table.Column<int>(type: "integer", nullable: false),
                    DirectoryState = table.Column<long>(type: "bigint", nullable: false),
                    SuffixProjectOwner = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    NameProjectOwner = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PrefixProjectOwner = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DescriptionProjectOwner = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    DirectoryLocked = table.Column<bool>(type: "boolean", nullable: false),
                    AuthorizationUserIdsExtString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    AuthorizationUserGroupIdsExtString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    NotificationUserIdsExtString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    NotificationUserGroupIdsExtString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    JobIdsExtString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    WorkflowItemIdsExtString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    BackupIdsExtString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
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
                    AuthorizationUsersString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    AuthorizationUserGroupsString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
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
                    AuthorizationUsersString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    AuthorizationUserGroupsString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
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
                name: "SubDirectory",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Suffix = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Prefix = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    Stars = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    DirectoryState = table.Column<long>(type: "bigint", nullable: false),
                    SuffixProjectOwner = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    NameProjectOwner = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PrefixProjectOwner = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DescriptionProjectOwner = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    DirectoryLocked = table.Column<bool>(type: "boolean", nullable: false),
                    AuthorizationUserIdsExtString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    AuthorizationUserGroupIdsExtString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    NotificationUserIdsExtString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    NotificationUserGroupIdsExtString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    JobIdsExtString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    WorkflowItemIdsExtString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    BackupIdsExtString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
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
                name: "File",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Suffix = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Prefix = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    Stars = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    FileState = table.Column<long>(type: "bigint", nullable: false),
                    SuffixProjectOwner = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    NameProjectOwner = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PrefixProjectOwner = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DescriptionProjectOwner = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    StarsProjectOwner = table.Column<int>(type: "integer", nullable: false),
                    OrderProjectOwner = table.Column<int>(type: "integer", nullable: false),
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
                    RawFileIdsString = table.Column<string>(type: "character varying(1023)", maxLength: 1023, nullable: false),
                    JobIdsExtString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    WorkflowItemIdsExtString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    BackupIdsExtString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    AuthorizationUserIdsExtString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    AuthorizationUserGroupIdsExtString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    NotificationUserIdsExtString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    NotificationUserGroupIdsExtString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
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
                name: "IX_SubDirectoryMetadataLink_SubDirectoryId",
                schema: "psgm",
                table: "SubDirectoryMetadataLink",
                column: "SubDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectoryMetadataLink_SubDirectoryMetadataId",
                schema: "psgm",
                table: "SubDirectoryMetadataLink",
                column: "SubDirectoryMetadataId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileMetadata_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileMetadataLink",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileMetadataLink_AuditLog",
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
                name: "RootDirectoryMetadata_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectoryMetadataLink",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectoryMetadataLink_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectoryMetadata_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectoryMetadataLink",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectoryMetadataLink_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "FileMetadata",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectoryMetadata",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectoryMetadata",
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
