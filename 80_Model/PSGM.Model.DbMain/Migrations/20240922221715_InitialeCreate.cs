using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    AddressLinkId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Archive_Job",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    JobType = table.Column<int>(type: "integer", nullable: false),
                    JobStarted = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    JobFinished = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MachineId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archive_Job", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Archive_Job_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archive_Job_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Archive_Job_Link_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archive_Job_Link_AuditLog", x => x.Id);
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
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contributors_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliverySlip_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliverySlip_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliverySlip_Template_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliverySlip_Template_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location_Address_Link_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location_Address_Link_AuditLog", x => x.Id);
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
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
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
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organization_Employee_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization_Employee_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organization_Employee_Notification_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareId_Ext = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization_Employee_Notification_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organization_Employee_Permission_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareId_Ext = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization_Employee_Permission_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organization_EmployeeGroup_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization_EmployeeGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organization_Location_Link_Audit",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization_Location_Link_Audit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    Description = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
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
                    Machines_ExtString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
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
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project_Location_Link_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Location_Link_AuditLog", x => x.Id);
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
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowGroup_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowItem",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    WorkflowApplyLevel = table.Column<int>(type: "integer", nullable: false),
                    WorkflowExecutionLevel = table.Column<int>(type: "integer", nullable: false),
                    Configuration = table.Column<string>(type: "character varying(65536)", maxLength: 65536, nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowItem_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowItem_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowItemLink_AuditLog",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Action = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    Changes = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowItemLink_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location_Address_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: true),
                    LocationId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location_Address_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Address_Link_Address_AddressId",
                        column: x => x.AddressId,
                        principalSchema: "psgm",
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Location_Address_Link_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "psgm",
                        principalTable: "Location",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DeliverySlip",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    InternalContactUserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    ExternalContactUserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    DeliverySlipIsDirectory = table.Column<bool>(type: "boolean", nullable: false),
                    NumberOfUnits = table.Column<int>(type: "integer", nullable: false),
                    DeliverySlipState = table.Column<int>(type: "integer", maxLength: 1023, nullable: false),
                    DocumentObjectName = table.Column<string>(type: "character varying(1023)", maxLength: 1023, nullable: false),
                    ProcessingStartedDateTime = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 1023, nullable: false),
                    Machines_ExtString = table.Column<string>(type: "character varying(16383)", maxLength: 16383, nullable: false),
                    ProcessingStartedUserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    ProcessingFinishedDateTime = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 1023, nullable: false),
                    ProcessingFinishedUserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliverySlip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliverySlip_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "psgm",
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Project_Location_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: true),
                    LocationId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Location_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Location_Link_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "psgm",
                        principalTable: "Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Project_Location_Link_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "psgm",
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DeliverySlip_Template",
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
                    DeliverySlipState = table.Column<int>(type: "integer", maxLength: 1023, nullable: false),
                    DeliverySlipDocumentObjectName = table.Column<string>(type: "character varying(1023)", maxLength: 1023, nullable: false),
                    OderProcessingStartedDateTime = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 1023, nullable: false),
                    OderProcessingStartedUserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    OderProcessingFinishedDateTime = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 1023, nullable: false),
                    OderProcessingFinishedUserIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    DeliverySlipId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliverySlip_Template", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliverySlip_Template_DeliverySlip_DeliverySlipId",
                        column: x => x.DeliverySlipId,
                        principalSchema: "psgm",
                        principalTable: "DeliverySlip",
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
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeliverySlipInternetId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeliverySlipExternalId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organization_DeliverySlip_DeliverySlipExternalId",
                        column: x => x.DeliverySlipExternalId,
                        principalSchema: "psgm",
                        principalTable: "DeliverySlip",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Organization_DeliverySlip_DeliverySlipInternetId",
                        column: x => x.DeliverySlipInternetId,
                        principalSchema: "psgm",
                        principalTable: "DeliverySlip",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Organization_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "psgm",
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Unit",
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
                    NaturalUnit = table.Column<bool>(type: "boolean", nullable: false),
                    PreparationDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PreparationUserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    DetectedDefectsDuringPreparation = table.Column<int>(type: "integer", nullable: false),
                    AqlStateImage = table.Column<int>(type: "integer", nullable: false),
                    AqlStateLastChangeImage = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AqlStateTranscription = table.Column<int>(type: "integer", nullable: false),
                    AqlStateLastChangeTranscription = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ArchiveJobStarted = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ArchiveJobFinished = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ObjectsOnStorageInUnit = table.Column<int>(type: "integer", nullable: false),
                    DirectorySizeOnStorage = table.Column<long>(type: "bigint", nullable: false),
                    Locked = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    DeliverySlipId = table.Column<Guid>(type: "uuid", nullable: true),
                    ParentUnitId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unit_DeliverySlip_DeliverySlipId",
                        column: x => x.DeliverySlipId,
                        principalSchema: "psgm",
                        principalTable: "DeliverySlip",
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
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
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
                name: "Organization_EmployeeGroup",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    Permissions = table.Column<int>(type: "integer", nullable: false),
                    UserGroupIdExt = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization_EmployeeGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organization_EmployeeGroup_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalSchema: "psgm",
                        principalTable: "Organization",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Organization_Location_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: true),
                    LocationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization_Location_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organization_Location_Link_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "psgm",
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Organization_Location_Link_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalSchema: "psgm",
                        principalTable: "Organization",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Archive_Job_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: true),
                    ArchiveJobId = table.Column<Guid>(type: "uuid", nullable: true),
                    UnitId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archive_Job_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Archive_Job_Link_Archive_Job_ArchiveJobId",
                        column: x => x.ArchiveJobId,
                        principalSchema: "psgm",
                        principalTable: "Archive_Job",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Archive_Job_Link_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "psgm",
                        principalTable: "Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Archive_Job_Link_Unit_UnitId",
                        column: x => x.UnitId,
                        principalSchema: "psgm",
                        principalTable: "Unit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkflowGroup",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(8191)", maxLength: 8191, nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    DeliverySlipId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: true),
                    UnitId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowGroup_DeliverySlip_DeliverySlipId",
                        column: x => x.DeliverySlipId,
                        principalSchema: "psgm",
                        principalTable: "DeliverySlip",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkflowGroup_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "psgm",
                        principalTable: "Project",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkflowGroup_Unit_UnitId",
                        column: x => x.UnitId,
                        principalSchema: "psgm",
                        principalTable: "Unit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Organization_Employee",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Acronym = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    DaytimePhoneNumber = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    EveningPhoneNumber = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    EMail = table.Column<string>(type: "character varying(511)", maxLength: 511, nullable: false),
                    FieldOfEmployment = table.Column<int>(type: "integer", nullable: false),
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: true),
                    EmployeeGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organization_Employee_Organization_EmployeeGroup_EmployeeGr~",
                        column: x => x.EmployeeGroupId,
                        principalSchema: "psgm",
                        principalTable: "Organization_EmployeeGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Organization_Employee_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalSchema: "psgm",
                        principalTable: "Organization",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkflowItemLink",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    ApplyLevel = table.Column<int>(type: "integer", nullable: false),
                    StorageType = table.Column<int>(type: "integer", nullable: false),
                    StorageClass = table.Column<int>(type: "integer", nullable: false),
                    Permissions = table.Column<int>(type: "integer", nullable: false),
                    WorkflowExecutionLevel = table.Column<int>(type: "integer", nullable: false),
                    Configuration = table.Column<string>(type: "character varying(65536)", maxLength: 65536, nullable: false),
                    WorkflowGroupId = table.Column<Guid>(type: "uuid", nullable: true),
                    WorkflowItemId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowItemLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowItemLink_WorkflowGroup_WorkflowGroupId",
                        column: x => x.WorkflowGroupId,
                        principalSchema: "psgm",
                        principalTable: "WorkflowGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkflowItemLink_WorkflowItem_WorkflowItemId",
                        column: x => x.WorkflowItemId,
                        principalSchema: "psgm",
                        principalTable: "WorkflowItem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Organization_Employee_Notification",
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
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization_Employee_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organization_Employee_Notification_Organization_Employee_Em~",
                        column: x => x.EmployeeId,
                        principalSchema: "psgm",
                        principalTable: "Organization_Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Organization_Employee_Permission",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    Addresses = table.Column<int>(type: "integer", nullable: false),
                    Contributors = table.Column<int>(type: "integer", nullable: false),
                    DeliverySlip = table.Column<int>(type: "integer", nullable: false),
                    Locations = table.Column<int>(type: "integer", nullable: false),
                    Organizations = table.Column<int>(type: "integer", nullable: false),
                    Units = table.Column<int>(type: "integer", nullable: false),
                    Archive = table.Column<int>(type: "integer", nullable: false),
                    Job = table.Column<int>(type: "integer", nullable: false),
                    Machine = table.Column<int>(type: "integer", nullable: false),
                    Software = table.Column<int>(type: "integer", nullable: false),
                    Storage = table.Column<int>(type: "integer", nullable: false),
                    StorageDirectories = table.Column<int>(type: "integer", nullable: false),
                    StorageFiles = table.Column<int>(type: "integer", nullable: false),
                    Workflow = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization_Employee_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organization_Employee_Permission_Organization_Employee_Empl~",
                        column: x => x.EmployeeId,
                        principalSchema: "psgm",
                        principalTable: "Organization_Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "psgm",
                table: "WorkflowItem",
                columns: new[] { "Id", "Configuration", "CreatedByUserId_ExtAutoFill", "CreatedDateTimeAutoFill", "Description", "ModifiedByUserId_ExtAutoFill", "ModifiedDateTimeAutoFill", "Name", "WorkflowApplyLevel", "WorkflowExecutionLevel" },
                values: new object[,]
                {
                    { new Guid("083c3d9a-0915-4506-bf60-b164d19071df"), "", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sharpen image ...", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sharpen image - V2.0.0", 10000, 90000 },
                    { new Guid("0f10bb0b-f782-4e5b-a53b-c75f7c0403fb"), "", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rotate image ...", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rotate image - V1.0.0", 10000, 90000 },
                    { new Guid("38905667-b47b-4d23-b149-c500372f0eff"), "", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sharpen image ...", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sharpen image - V1.0.0", 10000, 90000 },
                    { new Guid("4d7723ce-5bcd-4f82-a921-f9621fa5c383"), "", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Calculate HDR image with OpenCV (mergeMertens) ...", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Calculate HDR image - V1.0.0", 10000, 90000 },
                    { new Guid("68299067-b79b-4120-98df-13a3e2232c88"), "", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Calculate darktable image according to the sidecar file ...", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Calculate darktable image - V1.0.0", 10000, 90000 },
                    { new Guid("c2dc5eed-f926-4615-882f-c8184c981d93"), "", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Crop image to specified size...", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Crop image - V1.0.0", 10000, 90000 },
                    { new Guid("c33c011d-229a-4c3d-af44-05db3a4c7af4"), "", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Resize image to specified size...", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Resize image - V1.0.0", 10000, 90000 },
                    { new Guid("ef601faa-1bb5-4171-b907-60a2f1935eee"), "", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Save object (depending on storage configuration in project parameters) to specified S3 storage or filesystem and add the file entity to the database...", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Save object to S3 storage or filesystem and add entity to database - V1.0.0", 10000, 90000 },
                    { new Guid("f03093f8-6ea8-4bee-9875-30d1fc7975f3"), "", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grab image with specified camera ...", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grab image - V1.0.0", 10000, 10000 },
                    { new Guid("fd184c53-2e4a-4384-8894-3639eef8ea66"), "", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rotate image ...", new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rotate image - V2.0.0", 10000, 90000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Archive_Job_Link_ArchiveJobId",
                schema: "psgm",
                table: "Archive_Job_Link",
                column: "ArchiveJobId");

            migrationBuilder.CreateIndex(
                name: "IX_Archive_Job_Link_ProjectId",
                schema: "psgm",
                table: "Archive_Job_Link",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Archive_Job_Link_UnitId",
                schema: "psgm",
                table: "Archive_Job_Link",
                column: "UnitId");

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
                name: "IX_DeliverySlip_ProjectId",
                schema: "psgm",
                table: "DeliverySlip",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliverySlip_Template_DeliverySlipId",
                schema: "psgm",
                table: "DeliverySlip_Template",
                column: "DeliverySlipId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Location_Address_Link_AddressId",
                schema: "psgm",
                table: "Location_Address_Link",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Location_Address_Link_LocationId",
                schema: "psgm",
                table: "Location_Address_Link",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organization_DeliverySlipExternalId",
                schema: "psgm",
                table: "Organization",
                column: "DeliverySlipExternalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organization_DeliverySlipInternetId",
                schema: "psgm",
                table: "Organization",
                column: "DeliverySlipInternetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organization_ProjectId",
                schema: "psgm",
                table: "Organization",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organization_Employee_EmployeeGroupId",
                schema: "psgm",
                table: "Organization_Employee",
                column: "EmployeeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_Employee_OrganizationId",
                schema: "psgm",
                table: "Organization_Employee",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_Employee_Notification_EmployeeId",
                schema: "psgm",
                table: "Organization_Employee_Notification",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_Employee_Permission_EmployeeId",
                schema: "psgm",
                table: "Organization_Employee_Permission",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organization_EmployeeGroup_OrganizationId",
                schema: "psgm",
                table: "Organization_EmployeeGroup",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_Location_Link_LocationId",
                schema: "psgm",
                table: "Organization_Location_Link",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_Location_Link_OrganizationId",
                schema: "psgm",
                table: "Organization_Location_Link",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Location_Link_LocationId",
                schema: "psgm",
                table: "Project_Location_Link",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Location_Link_ProjectId",
                schema: "psgm",
                table: "Project_Location_Link",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_DeliverySlipId",
                schema: "psgm",
                table: "Unit",
                column: "DeliverySlipId");

            migrationBuilder.CreateIndex(
                name: "IX_Unit_ParentUnitId",
                schema: "psgm",
                table: "Unit",
                column: "ParentUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowGroup_DeliverySlipId",
                schema: "psgm",
                table: "WorkflowGroup",
                column: "DeliverySlipId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowGroup_ProjectId",
                schema: "psgm",
                table: "WorkflowGroup",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowGroup_UnitId",
                schema: "psgm",
                table: "WorkflowGroup",
                column: "UnitId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowItemLink_WorkflowGroupId",
                schema: "psgm",
                table: "WorkflowItemLink",
                column: "WorkflowGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowItemLink_WorkflowItemId",
                schema: "psgm",
                table: "WorkflowItemLink",
                column: "WorkflowItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Archive_Job_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Archive_Job_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Archive_Job_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Contributors",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Contributors_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "DeliverySlip_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "DeliverySlip_Template",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "DeliverySlip_Template_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Location_Address_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Location_Address_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Location_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Organization_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Organization_Employee_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Organization_Employee_Notification",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Organization_Employee_Notification_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Organization_Employee_Permission",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Organization_Employee_Permission_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Organization_EmployeeGroup_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Organization_Location_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Organization_Location_Link_Audit",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Project_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Project_Location_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Project_Location_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Unit_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "WorkflowGroup_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "WorkflowItem_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "WorkflowItemLink",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "WorkflowItemLink_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Archive_Job",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Organization_Employee",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "WorkflowGroup",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "WorkflowItem",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Organization_EmployeeGroup",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Unit",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Organization",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "DeliverySlip",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Project",
                schema: "psgm");
        }
    }
}
