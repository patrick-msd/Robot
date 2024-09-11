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
            migrationBuilder.CreateTable(
                name: "Adderss_AuditLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Changes = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adderss_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Device_AuditLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Changes = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceGroup_AuditLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Changes = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interface_Can_AuditLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Changes = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interface_Can_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interface_CanDevice_AuditLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Changes = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interface_CanDevice_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interface_Ethernet_AuditLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Changes = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interface_Ethernet_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interface_Serial_AuditLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Changes = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interface_Serial_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location_AuditLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Changes = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Machine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 8191, nullable: false),
                    ApplicationName = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    InitialzeAtSplashscreen = table.Column<bool>(type: "INTEGER", nullable: false),
                    ConnectAtSplashscreen = table.Column<bool>(type: "INTEGER", nullable: false),
                    AutoStartAtSplashscreen = table.Column<bool>(type: "INTEGER", nullable: false),
                    HomingAtSplashscreen = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Machine_AuditLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SourceId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Changes = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machine_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 8191, nullable: false),
                    Location = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    DeviceGroupeType = table.Column<uint>(type: "INTEGER", nullable: false),
                    Configuration = table.Column<string>(type: "TEXT", maxLength: 65536, nullable: false),
                    MachineId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeviceGroup_Machine_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machine",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    MachineId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Machine_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machine",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DeviceName = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    DeviceDescription = table.Column<string>(type: "TEXT", maxLength: 8191, nullable: false),
                    DeviceLocation = table.Column<uint>(type: "INTEGER", maxLength: 1024, nullable: false),
                    DeviceCategory = table.Column<uint>(type: "INTEGER", nullable: false),
                    DeviceManufacturer = table.Column<uint>(type: "INTEGER", nullable: false),
                    DeviceType = table.Column<uint>(type: "INTEGER", nullable: false),
                    DeviceUrl = table.Column<string>(type: "TEXT", maxLength: 2048, nullable: false),
                    Serialnumber = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    ConfigurationString = table.Column<string>(type: "TEXT", maxLength: 65536, nullable: false),
                    AttachmentsString = table.Column<string>(type: "TEXT", maxLength: 65536, nullable: false),
                    InitializeAtSplashscreen = table.Column<bool>(type: "INTEGER", nullable: false),
                    ConnectAtSplashscreen = table.Column<bool>(type: "INTEGER", nullable: false),
                    AutoStartAtSplashscreen = table.Column<bool>(type: "INTEGER", nullable: false),
                    HomingAtSplashscreen = table.Column<bool>(type: "INTEGER", nullable: false),
                    DeviceGroupId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Device_DeviceGroup_DeviceGroupId",
                        column: x => x.DeviceGroupId,
                        principalTable: "DeviceGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Line1 = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Line2 = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    City = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    State = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    CountryCode = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    CountryName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    RegionCode = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    RegionName = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    GpsAltitude = table.Column<int>(type: "INTEGER", nullable: false),
                    GpsLatitudeDegree = table.Column<decimal>(type: "TEXT", nullable: false),
                    GpsLatitudeMinute = table.Column<decimal>(type: "TEXT", nullable: false),
                    GpsLatitudeSecond = table.Column<decimal>(type: "TEXT", nullable: false),
                    GpsLatitudeCardinalPoint = table.Column<char>(type: "TEXT", nullable: false),
                    GpsLongitudeDegree = table.Column<decimal>(type: "TEXT", nullable: false),
                    GpsLongitudeMinute = table.Column<decimal>(type: "TEXT", nullable: false),
                    GpsLongitudeSecond = table.Column<decimal>(type: "TEXT", nullable: false),
                    GpsLongitudeCardinalPoint = table.Column<char>(type: "TEXT", nullable: false),
                    LocationId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Interface_Can",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 8191, nullable: false),
                    Serialnumber = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    Configuration = table.Column<string>(type: "TEXT", maxLength: 65536, nullable: false),
                    Timeout = table.Column<int>(type: "INTEGER", nullable: false),
                    DeviceId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interface_Can", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interface_Can_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Device",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Interface_Ethernet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    IpAddress = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    Port = table.Column<int>(type: "INTEGER", nullable: false),
                    Timeout = table.Column<int>(type: "INTEGER", nullable: false),
                    DeviceId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interface_Ethernet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interface_Ethernet_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Device",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Interface_Serial",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PortName = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    BaudRate = table.Column<int>(type: "INTEGER", nullable: false),
                    Parity = table.Column<byte>(type: "INTEGER", nullable: false),
                    StopBits = table.Column<byte>(type: "INTEGER", nullable: false),
                    Handshake = table.Column<byte>(type: "INTEGER", nullable: false),
                    ReadTimeout = table.Column<int>(type: "INTEGER", nullable: false),
                    WriteTimeout = table.Column<int>(type: "INTEGER", nullable: false),
                    SerialPortRetrySending = table.Column<int>(type: "INTEGER", nullable: false),
                    MonitoringInterval = table.Column<int>(type: "INTEGER", nullable: false),
                    DeviceId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interface_Serial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interface_Serial_Device_DeviceId",
                        column: x => x.DeviceId,
                        principalTable: "Device",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Interface_CanDevice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CanDeviceId = table.Column<uint>(type: "INTEGER", nullable: false),
                    DeviceName = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    DeviceDescription = table.Column<string>(type: "TEXT", maxLength: 8191, nullable: false),
                    DeviceLocation = table.Column<uint>(type: "INTEGER", maxLength: 1024, nullable: false),
                    DeviceCategory = table.Column<uint>(type: "INTEGER", nullable: false),
                    DeviceManufacturer = table.Column<uint>(type: "INTEGER", nullable: false),
                    DeviceType = table.Column<uint>(type: "INTEGER", nullable: false),
                    DeviceUrl = table.Column<string>(type: "TEXT", maxLength: 2048, nullable: false),
                    Serialnumber = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    Configuration = table.Column<string>(type: "TEXT", maxLength: 65536, nullable: false),
                    Timeout = table.Column<int>(type: "INTEGER", nullable: false),
                    InitialzeAtSplashscreen = table.Column<bool>(type: "INTEGER", nullable: false),
                    ConnectAtSplashscreen = table.Column<bool>(type: "INTEGER", nullable: false),
                    AutoStartAtSplashscreen = table.Column<bool>(type: "INTEGER", nullable: false),
                    HomingAtSplashscreen = table.Column<bool>(type: "INTEGER", nullable: false),
                    Interface_CanId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interface_CanDevice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interface_CanDevice_Interface_Can_Interface_CanId",
                        column: x => x.Interface_CanId,
                        principalTable: "Interface_Can",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_LocationId",
                table: "Address",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Device_DeviceGroupId",
                table: "Device",
                column: "DeviceGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_DeviceGroup_MachineId",
                table: "DeviceGroup",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Interface_Can_DeviceId",
                table: "Interface_Can",
                column: "DeviceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interface_CanDevice_Interface_CanId",
                table: "Interface_CanDevice",
                column: "Interface_CanId");

            migrationBuilder.CreateIndex(
                name: "IX_Interface_Ethernet_DeviceId",
                table: "Interface_Ethernet",
                column: "DeviceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interface_Serial_DeviceId",
                table: "Interface_Serial",
                column: "DeviceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Location_MachineId",
                table: "Location",
                column: "MachineId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adderss_AuditLog");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Device_AuditLog");

            migrationBuilder.DropTable(
                name: "DeviceGroup_AuditLog");

            migrationBuilder.DropTable(
                name: "Interface_Can_AuditLog");

            migrationBuilder.DropTable(
                name: "Interface_CanDevice");

            migrationBuilder.DropTable(
                name: "Interface_CanDevice_AuditLog");

            migrationBuilder.DropTable(
                name: "Interface_Ethernet");

            migrationBuilder.DropTable(
                name: "Interface_Ethernet_AuditLog");

            migrationBuilder.DropTable(
                name: "Interface_Serial");

            migrationBuilder.DropTable(
                name: "Interface_Serial_AuditLog");

            migrationBuilder.DropTable(
                name: "Location_AuditLog");

            migrationBuilder.DropTable(
                name: "Machine_AuditLog");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Interface_Can");

            migrationBuilder.DropTable(
                name: "Device");

            migrationBuilder.DropTable(
                name: "DeviceGroup");

            migrationBuilder.DropTable(
                name: "Machine");
        }
    }
}
