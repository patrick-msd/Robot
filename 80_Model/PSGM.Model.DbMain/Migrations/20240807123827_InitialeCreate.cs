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
                name: "Contributors_AuditLog",
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
                    table.PrimaryKey("PK_Contributors_AuditLog", x => x.Id);
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
                name: "Organization_AuditLog",
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
                    table.PrimaryKey("PK_Organization_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationAuthorization_User_AuditLog",
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
                    table.PrimaryKey("PK_OrganizationAuthorization_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationAuthorization_UserGroup_AuditLog",
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
                    table.PrimaryKey("PK_OrganizationAuthorization_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationNotification_UserGroup_AuditLog",
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
                    table.PrimaryKey("PK_OrganizationNotification_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizationotification_User_AuditLog",
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
                    table.PrimaryKey("PK_Organizationotification_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 8191, nullable: false),
                    Status = table.Column<uint>(type: "INTEGER", nullable: false),
                    Started = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Finished = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WorkflowIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    WorkflowApplyLevel = table.Column<uint>(type: "INTEGER", nullable: false),
                    MachinesExtString = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false),
                    MachinesExt = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project_AuditLog",
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
                    table.PrimaryKey("PK_Project_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectAuthorization_User_AuditLog",
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
                    table.PrimaryKey("PK_ProjectAuthorization_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectAuthorization_UserGroup_AuditLog",
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
                    table.PrimaryKey("PK_ProjectAuthorization_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectNotification_User_AuditLog",
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
                    table.PrimaryKey("PK_ProjectNotification_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectNotification_UserGroup_AuditLog",
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
                    table.PrimaryKey("PK_ProjectNotification_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectParameter_AuditLog",
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
                    table.PrimaryKey("PK_ProjectParameter_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectParameterStorage_AuditLog",
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
                    table.PrimaryKey("PK_ProjectParameterStorage_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 16384, nullable: false),
                    Acronym = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    DaytimePhoneNumber = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    EveningPhoneNumber = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    EMail = table.Column<string>(type: "TEXT", maxLength: 511, nullable: false),
                    Homepage = table.Column<string>(type: "TEXT", maxLength: 511, nullable: false),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organization_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectAuthorization_User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Permissions = table.Column<int>(type: "INTEGER", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectAuthorization_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectAuthorization_User_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectAuthorization_UserGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Permissions = table.Column<int>(type: "INTEGER", nullable: false),
                    UserGroupIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectAuthorization_UserGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectAuthorization_UserGroup_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectNotification_User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NotificationString = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false),
                    UserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectNotification_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectNotification_User_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectNotification_UserGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NotificationString = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false),
                    UserGroupIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectNotification_UserGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectNotification_UserGroup_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectParameter",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectParameter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectParameter_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contributors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 8191, nullable: false),
                    ContributorType = table.Column<int>(type: "INTEGER", nullable: false),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: true),
                    OrganizationId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contributors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contributors_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contributors_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: true),
                    OrganizationId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Location_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrganizationAuthorization_User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Permissions = table.Column<int>(type: "INTEGER", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationAuthorization_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationAuthorization_User_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrganizationAuthorization_UserGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Permissions = table.Column<int>(type: "INTEGER", nullable: false),
                    UserGroupIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationAuthorization_UserGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationAuthorization_UserGroup_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrganizationNotification_User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NotificationString = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false),
                    UserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationNotification_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationNotification_User_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrganizationNotification_UserGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NotificationString = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false),
                    UserGroupIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationNotification_UserGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationNotification_UserGroup_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProjectParameterStorage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DatabaseType = table.Column<uint>(type: "INTEGER", nullable: false),
                    DatabaseFilePath = table.Column<string>(type: "TEXT", maxLength: 1023, nullable: false),
                    DatabaseConnectionString = table.Column<string>(type: "TEXT", maxLength: 1023, nullable: false),
                    StorageType = table.Column<uint>(type: "INTEGER", nullable: false),
                    StorageClass = table.Column<uint>(type: "INTEGER", nullable: false),
                    StorageFilePath = table.Column<string>(type: "TEXT", maxLength: 1023, nullable: false),
                    StorageS3Endpoint = table.Column<string>(type: "TEXT", maxLength: 1023, nullable: false),
                    StorageS3BucketName = table.Column<string>(type: "TEXT", maxLength: 1023, nullable: false),
                    StorageS3AccessKey = table.Column<string>(type: "TEXT", maxLength: 1023, nullable: false),
                    StorageS3SecretKey = table.Column<string>(type: "TEXT", maxLength: 1023, nullable: false),
                    StorageS3Secure = table.Column<bool>(type: "INTEGER", maxLength: 1023, nullable: false),
                    StorageS3Region = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 1023, nullable: false),
                    UrlPublic = table.Column<string>(type: "TEXT", maxLength: 1023, nullable: false),
                    ProjectParameterId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectParameterStorage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectParameterStorage_ProjectParameter_ProjectParameterId",
                        column: x => x.ProjectParameterId,
                        principalTable: "ProjectParameter",
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

            migrationBuilder.CreateIndex(
                name: "IX_Address_LocationId",
                table: "Address",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contributors_OrganizationId",
                table: "Contributors",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Contributors_ProjectId",
                table: "Contributors",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_OrganizationId",
                table: "Location",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_ProjectId",
                table: "Location",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Organization_ProjectId",
                table: "Organization",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationAuthorization_User_OrganizationId",
                table: "OrganizationAuthorization_User",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationAuthorization_UserGroup_OrganizationId",
                table: "OrganizationAuthorization_UserGroup",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationNotification_User_OrganizationId",
                table: "OrganizationNotification_User",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationNotification_UserGroup_OrganizationId",
                table: "OrganizationNotification_UserGroup",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAuthorization_User_ProjectId",
                table: "ProjectAuthorization_User",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAuthorization_UserGroup_ProjectId",
                table: "ProjectAuthorization_UserGroup",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectNotification_User_ProjectId",
                table: "ProjectNotification_User",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectNotification_UserGroup_ProjectId",
                table: "ProjectNotification_UserGroup",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectParameter_ProjectId",
                table: "ProjectParameter",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectParameterStorage_ProjectParameterId",
                table: "ProjectParameterStorage",
                column: "ProjectParameterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adderss_AuditLog");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Contributors");

            migrationBuilder.DropTable(
                name: "Contributors_AuditLog");

            migrationBuilder.DropTable(
                name: "Location_AuditLog");

            migrationBuilder.DropTable(
                name: "Organization_AuditLog");

            migrationBuilder.DropTable(
                name: "OrganizationAuthorization_User");

            migrationBuilder.DropTable(
                name: "OrganizationAuthorization_User_AuditLog");

            migrationBuilder.DropTable(
                name: "OrganizationAuthorization_UserGroup");

            migrationBuilder.DropTable(
                name: "OrganizationAuthorization_UserGroup_AuditLog");

            migrationBuilder.DropTable(
                name: "OrganizationNotification_User");

            migrationBuilder.DropTable(
                name: "OrganizationNotification_UserGroup");

            migrationBuilder.DropTable(
                name: "OrganizationNotification_UserGroup_AuditLog");

            migrationBuilder.DropTable(
                name: "Organizationotification_User_AuditLog");

            migrationBuilder.DropTable(
                name: "Project_AuditLog");

            migrationBuilder.DropTable(
                name: "ProjectAuthorization_User");

            migrationBuilder.DropTable(
                name: "ProjectAuthorization_User_AuditLog");

            migrationBuilder.DropTable(
                name: "ProjectAuthorization_UserGroup");

            migrationBuilder.DropTable(
                name: "ProjectAuthorization_UserGroup_AuditLog");

            migrationBuilder.DropTable(
                name: "ProjectNotification_User");

            migrationBuilder.DropTable(
                name: "ProjectNotification_User_AuditLog");

            migrationBuilder.DropTable(
                name: "ProjectNotification_UserGroup");

            migrationBuilder.DropTable(
                name: "ProjectNotification_UserGroup_AuditLog");

            migrationBuilder.DropTable(
                name: "ProjectParameter_AuditLog");

            migrationBuilder.DropTable(
                name: "ProjectParameterStorage");

            migrationBuilder.DropTable(
                name: "ProjectParameterStorage_AuditLog");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "ProjectParameter");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
