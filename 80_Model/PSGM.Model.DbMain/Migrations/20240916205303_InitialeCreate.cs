using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PSGM.Model.DbMain.Migrations
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
                name: "Adderss_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adderss_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contributors_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contributors_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryBill_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryBill_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryBillTemplate_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryBillTemplate_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentType_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organization_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationAuthorization_User_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationAuthorization_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationAuthorization_UserGroup_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationAuthorization_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationNotification_UserGroup_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationNotification_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizationotification_User_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizationotification_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    Description = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    Status = table.Column<long>(type: "bigint", nullable: false),
                    Started = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Finished = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AqlQuantityImage = table.Column<int>(type: "integer", nullable: false),
                    AqlInspectionLevelImage = table.Column<int>(type: "integer", nullable: false),
                    AqlAcceptableQualityLevelImage = table.Column<int>(type: "integer", nullable: false),
                    AqlStateImage = table.Column<int>(type: "integer", nullable: false),
                    AqlStateLastChangeImage = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AqlQuantityTranscription = table.Column<int>(type: "integer", nullable: false),
                    AqlInspectionLevelTranscription = table.Column<int>(type: "integer", nullable: false),
                    AqlAcceptableQualityLevelTranscription = table.Column<int>(type: "integer", nullable: false),
                    AqlStateTranscription = table.Column<int>(type: "integer", nullable: false),
                    AqlStateLastChangeTranscription = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MaxDirectorySize = table.Column<long>(type: "bigint", nullable: false),
                    WorkflowIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkflowApplyLevel = table.Column<long>(type: "bigint", nullable: false),
                    MachinesExtString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectAuthorization_User_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectAuthorization_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectAuthorization_UserGroup_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectAuthorization_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectNotification_User_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectNotification_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectNotification_UserGroup_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectNotification_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unit_AuditLog",
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
                    table.PrimaryKey("PK_Unit_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryBill",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    InternalContactUserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    InternalContributorsUserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    ExternalContactUserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    ExternalContributorsUserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    DeliveryBillIsDirectory = table.Column<bool>(type: "boolean", nullable: false),
                    DeliveryBillState = table.Column<long>(type: "bigint", maxLength: 1023, nullable: false),
                    DocumentObjectName = table.Column<string>(type: "character varying(1023)", maxLength: 1023, nullable: false),
                    ProcessingStartedDateTime = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 1023, nullable: false),
                    ProcessingStartedUserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    ProcessingFinishedDateTime = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 1023, nullable: false),
                    ProcessingFinishedUserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    LastChanges = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryBill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryBill_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "psgm",
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    Acronym = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    DaytimePhoneNumber = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    EveningPhoneNumber = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    EMail = table.Column<string>(type: "character varying(511)", maxLength: 511, nullable: false),
                    Homepage = table.Column<string>(type: "character varying(511)", maxLength: 511, nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organization_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "psgm",
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectAuthorization_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "integer", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectAuthorization_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectAuthorization_User_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "psgm",
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectAuthorization_UserGroup",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "integer", nullable: false),
                    UserGroupIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectAuthorization_UserGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectAuthorization_UserGroup_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "psgm",
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectNotification_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    NotificationString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectNotification_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectNotification_User_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "psgm",
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectNotification_UserGroup",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    NotificationString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    UserGroupIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectNotification_UserGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectNotification_UserGroup_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "psgm",
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DeliveryBillTemplate",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    InternalContactUserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    InternalContributorsUserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    ExternalContactUserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    ExternalContributorsUserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    DeliveryBillState = table.Column<long>(type: "bigint", maxLength: 1023, nullable: false),
                    DeliveryBillDocumentObjectName = table.Column<string>(type: "character varying(1023)", maxLength: 1023, nullable: false),
                    OderProcessingStartedDateTime = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 1023, nullable: false),
                    OderProcessingStartedUserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    OderProcessingFinishedDateTime = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 1023, nullable: false),
                    OderProcessingFinishedUserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    LastChanges = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    DeliveryBillId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryBillTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryBillTemplate_DeliveryBill_DeliveryBillId",
                        column: x => x.DeliveryBillId,
                        principalSchema: "psgm",
                        principalTable: "DeliveryBill",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DocumentType",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    Description = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    Status = table.Column<long>(type: "bigint", nullable: false),
                    Started = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Finished = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WorkflowIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    WorkflowApplyLevel = table.Column<long>(type: "bigint", nullable: false),
                    MachinesExtString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    DeliveryBillId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentType_DeliveryBill_DeliveryBillId",
                        column: x => x.DeliveryBillId,
                        principalSchema: "psgm",
                        principalTable: "DeliveryBill",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Suffix = table.Column<string>(type: "character varying(127)", maxLength: 127, nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    Objects = table.Column<long>(type: "bigint", nullable: false),
                    DirectorySize = table.Column<long>(type: "bigint", nullable: false),
                    DocumentType = table.Column<bool>(type: "boolean", nullable: false),
                    Locked = table.Column<bool>(type: "boolean", nullable: false),
                    JobsIdExtString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    WorkflowItemExtString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    BackupsExtString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserIdExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModificationChanges = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    DeliveryBillId = table.Column<Guid>(type: "uuid", nullable: true),
                    ParentUnitId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unit_DeliveryBill_DeliveryBillId",
                        column: x => x.DeliveryBillId,
                        principalSchema: "psgm",
                        principalTable: "DeliveryBill",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Unit_Unit_ParentUnitId",
                        column: x => x.ParentUnitId,
                        principalSchema: "psgm",
                        principalTable: "Unit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contributors",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    ContributorType = table.Column<int>(type: "integer", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: true),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contributors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contributors_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalSchema: "psgm",
                        principalTable: "Organization",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contributors_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "psgm",
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: true),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalSchema: "psgm",
                        principalTable: "Organization",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Location_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "psgm",
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrganizationAuthorization_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "integer", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationAuthorization_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationAuthorization_User_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalSchema: "psgm",
                        principalTable: "Organization",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrganizationAuthorization_UserGroup",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "integer", nullable: false),
                    UserGroupIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationAuthorization_UserGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationAuthorization_UserGroup_Organization_Organizati~",
                        column: x => x.OrganizationId,
                        principalSchema: "psgm",
                        principalTable: "Organization",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrganizationNotification_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    NotificationString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    UserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationNotification_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationNotification_User_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalSchema: "psgm",
                        principalTable: "Organization",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrganizationNotification_UserGroup",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    NotificationString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    UserGroupIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationNotification_UserGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationNotification_UserGroup_Organization_Organizatio~",
                        column: x => x.OrganizationId,
                        principalSchema: "psgm",
                        principalTable: "Organization",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Line1 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Line2 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    City = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    State = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CountryCode = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    CountryName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PostalCode = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    RegionCode = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    RegionName = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    GpsAltitude = table.Column<int>(type: "integer", nullable: false),
                    GpsLatitudeDegree = table.Column<decimal>(type: "numeric", nullable: false),
                    GpsLatitudeMinute = table.Column<decimal>(type: "numeric", nullable: false),
                    GpsLatitudeSecond = table.Column<decimal>(type: "numeric", nullable: false),
                    GpsLatitudeCardinalPoint = table.Column<char>(type: "character(1)", nullable: false),
                    GpsLongitudeDegree = table.Column<decimal>(type: "numeric", nullable: false),
                    GpsLongitudeMinute = table.Column<decimal>(type: "numeric", nullable: false),
                    GpsLongitudeSecond = table.Column<decimal>(type: "numeric", nullable: false),
                    GpsLongitudeCardinalPoint = table.Column<char>(type: "character(1)", nullable: false),
                    LocationId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "psgm",
                        principalTable: "Location",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_LocationId",
                schema: "psgm",
                table: "Address",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contributors_OrganizationId",
                schema: "psgm",
                table: "Contributors",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Contributors_ProjectId",
                schema: "psgm",
                table: "Contributors",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryBill_ProjectId",
                schema: "psgm",
                table: "DeliveryBill",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryBillTemplate_DeliveryBillId",
                schema: "psgm",
                table: "DeliveryBillTemplate",
                column: "DeliveryBillId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentType_DeliveryBillId",
                schema: "psgm",
                table: "DocumentType",
                column: "DeliveryBillId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_OrganizationId",
                schema: "psgm",
                table: "Location",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_ProjectId",
                schema: "psgm",
                table: "Location",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_ProjectId",
                schema: "psgm",
                table: "Organization",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationAuthorization_User_OrganizationId",
                schema: "psgm",
                table: "OrganizationAuthorization_User",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationAuthorization_UserGroup_OrganizationId",
                schema: "psgm",
                table: "OrganizationAuthorization_UserGroup",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationNotification_User_OrganizationId",
                schema: "psgm",
                table: "OrganizationNotification_User",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationNotification_UserGroup_OrganizationId",
                schema: "psgm",
                table: "OrganizationNotification_UserGroup",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAuthorization_User_ProjectId",
                schema: "psgm",
                table: "ProjectAuthorization_User",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAuthorization_UserGroup_ProjectId",
                schema: "psgm",
                table: "ProjectAuthorization_UserGroup",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectNotification_User_ProjectId",
                schema: "psgm",
                table: "ProjectNotification_User",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectNotification_UserGroup_ProjectId",
                schema: "psgm",
                table: "ProjectNotification_UserGroup",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_DeliveryBillId",
                schema: "psgm",
                table: "Unit",
                column: "DeliveryBillId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_ParentUnitId",
                schema: "psgm",
                table: "Unit",
                column: "ParentUnitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adderss_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Contributors",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Contributors_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "DeliveryBill_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "DeliveryBillTemplate",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "DeliveryBillTemplate_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "DocumentType",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "DocumentType_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Location_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Organization_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "OrganizationAuthorization_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "OrganizationAuthorization_User_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "OrganizationAuthorization_UserGroup",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "OrganizationAuthorization_UserGroup_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "OrganizationNotification_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "OrganizationNotification_UserGroup",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "OrganizationNotification_UserGroup_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Organizationotification_User_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Project_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "ProjectAuthorization_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "ProjectAuthorization_User_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "ProjectAuthorization_UserGroup",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "ProjectAuthorization_UserGroup_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "ProjectNotification_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "ProjectNotification_User_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "ProjectNotification_UserGroup",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "ProjectNotification_UserGroup_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Unit",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Unit_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "DeliveryBill",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Organization",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Project",
                schema: "psgm");
        }
    }
}
