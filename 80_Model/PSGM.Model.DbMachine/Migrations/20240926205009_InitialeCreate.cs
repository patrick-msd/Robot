using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PSGM.Model.DbMachine.Migrations
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
                name: "Device_AuditLog",
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
                    table.PrimaryKey("PK_Device_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceGroup_AuditLog",
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
                    table.PrimaryKey("PK_DeviceGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interface_Can_AuditLog",
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
                    table.PrimaryKey("PK_Interface_Can_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interface_CanDevice_AuditLog",
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
                    table.PrimaryKey("PK_Interface_CanDevice_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interface_Ethernet_AuditLog",
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
                    table.PrimaryKey("PK_Interface_Ethernet_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interface_Serial_AuditLog",
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
                    table.PrimaryKey("PK_Interface_Serial_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    LocationType = table.Column<int>(type: "integer", nullable: false),
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
                name: "Machine_AuditLog",
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
                    table.PrimaryKey("PK_Machine_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Machine_Location_Link_AuditLog",
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
                    table.PrimaryKey("PK_Machine_Location_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Machine",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    Description = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    ApplicationName = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    InitializeAtSplashScreen = table.Column<bool>(type: "boolean", nullable: false),
                    ConnectAtSplashScreen = table.Column<bool>(type: "boolean", nullable: false),
                    AutoStartAtSplashScreen = table.Column<bool>(type: "boolean", nullable: false),
                    HomingAtSplashScreen = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Machine_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "psgm",
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "DeviceGroup",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    Description = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    Location = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    DeviceGroupeType = table.Column<int>(type: "integer", nullable: false),
                    Configuration = table.Column<string>(type: "character varying(65536)", maxLength: 65536, nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    MachineId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceGroup_Machine_MachineId",
                        column: x => x.MachineId,
                        principalSchema: "psgm",
                        principalTable: "Machine",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Machine_Location_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MachineId = table.Column<Guid>(type: "uuid", nullable: true),
                    LocationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machine_Location_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Machine_Location_Link_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "psgm",
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Machine_Location_Link_Machine_MachineId",
                        column: x => x.MachineId,
                        principalSchema: "psgm",
                        principalTable: "Machine",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Device",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DeviceName = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    DeviceDescription = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    DeviceLocation = table.Column<int>(type: "integer", maxLength: 1024, nullable: false),
                    DeviceCategory = table.Column<int>(type: "integer", nullable: false),
                    DeviceManufacturer = table.Column<int>(type: "integer", nullable: false),
                    DeviceType = table.Column<int>(type: "integer", nullable: false),
                    DeviceUrl = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: false),
                    SerialNumber = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    ConfigurationString = table.Column<string>(type: "character varying(65536)", maxLength: 65536, nullable: false),
                    AttachmentsString = table.Column<string>(type: "character varying(65536)", maxLength: 65536, nullable: false),
                    InitializeAtSplashScreen = table.Column<bool>(type: "boolean", nullable: false),
                    ConnectAtSplashScreen = table.Column<bool>(type: "boolean", nullable: false),
                    AutoStartAtSplashScreen = table.Column<bool>(type: "boolean", nullable: false),
                    HomingAtSplashScreen = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    DeviceGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Device_DeviceGroup_DeviceGroupId",
                        column: x => x.DeviceGroupId,
                        principalSchema: "psgm",
                        principalTable: "DeviceGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Interface_Can",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    Description = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    SerialNumber = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    Configuration = table.Column<string>(type: "character varying(65536)", maxLength: 65536, nullable: false),
                    Timeout = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    DeviceId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interface_Can", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interface_Can_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "psgm",
                        principalTable: "Device",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Interface_Ethernet",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IpAddress = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    Port = table.Column<int>(type: "integer", nullable: false),
                    Timeout = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    DeviceId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interface_Ethernet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interface_Ethernet_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "psgm",
                        principalTable: "Device",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Interface_Serial",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PortName = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    BaudRate = table.Column<int>(type: "integer", nullable: false),
                    Parity = table.Column<byte>(type: "smallint", nullable: false),
                    StopBits = table.Column<byte>(type: "smallint", nullable: false),
                    Handshake = table.Column<byte>(type: "smallint", nullable: false),
                    ReadTimeout = table.Column<int>(type: "integer", nullable: false),
                    WriteTimeout = table.Column<int>(type: "integer", nullable: false),
                    SerialPortRetrySending = table.Column<int>(type: "integer", nullable: false),
                    MonitoringInterval = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    DeviceId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interface_Serial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interface_Serial_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "psgm",
                        principalTable: "Device",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Interface_CanDevice",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CanDeviceId = table.Column<long>(type: "bigint", nullable: false),
                    DeviceName = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    DeviceDescription = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    DeviceLocation = table.Column<int>(type: "integer", maxLength: 1024, nullable: false),
                    DeviceCategory = table.Column<int>(type: "integer", nullable: false),
                    DeviceManufacturer = table.Column<int>(type: "integer", nullable: false),
                    DeviceType = table.Column<int>(type: "integer", nullable: false),
                    DeviceUrl = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: false),
                    SerialNumber = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    Configuration = table.Column<string>(type: "character varying(65536)", maxLength: 65536, nullable: false),
                    Timeout = table.Column<int>(type: "integer", nullable: false),
                    InitializeAtSplashScreen = table.Column<bool>(type: "boolean", nullable: false),
                    ConnectAtSplashScreen = table.Column<bool>(type: "boolean", nullable: false),
                    AutoStartAtSplashScreen = table.Column<bool>(type: "boolean", nullable: false),
                    HomingAtSplashScreen = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    Interface_CanId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interface_CanDevice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interface_CanDevice_Interface_Can_Interface_CanId",
                        column: x => x.Interface_CanId,
                        principalSchema: "psgm",
                        principalTable: "Interface_Can",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_LocationId",
                schema: "psgm",
                table: "Address",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Device_DeviceGroupId",
                schema: "psgm",
                table: "Device",
                column: "DeviceGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceGroup_MachineId",
                schema: "psgm",
                table: "DeviceGroup",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Interface_Can_DeviceId",
                schema: "psgm",
                table: "Interface_Can",
                column: "DeviceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interface_CanDevice_Interface_CanId",
                schema: "psgm",
                table: "Interface_CanDevice",
                column: "Interface_CanId");

            migrationBuilder.CreateIndex(
                name: "IX_Interface_Ethernet_DeviceId",
                schema: "psgm",
                table: "Interface_Ethernet",
                column: "DeviceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interface_Serial_DeviceId",
                schema: "psgm",
                table: "Interface_Serial",
                column: "DeviceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Location_Address_Link_AddressId",
                schema: "psgm",
                table: "Location_Address_Link",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_Address_Link_LocationId",
                schema: "psgm",
                table: "Location_Address_Link",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Machine_ProjectId",
                schema: "psgm",
                table: "Machine",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Machine_Location_Link_LocationId",
                schema: "psgm",
                table: "Machine_Location_Link",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Machine_Location_Link_MachineId",
                schema: "psgm",
                table: "Machine_Location_Link",
                column: "MachineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Device_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "DeviceGroup_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Interface_Can_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Interface_CanDevice",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Interface_CanDevice_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Interface_Ethernet",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Interface_Ethernet_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Interface_Serial",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Interface_Serial_AuditLog",
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
                name: "Machine_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Machine_Location_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Machine_Location_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Project_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Interface_Can",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Device",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "DeviceGroup",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Machine",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Project",
                schema: "psgm");
        }
    }
}
