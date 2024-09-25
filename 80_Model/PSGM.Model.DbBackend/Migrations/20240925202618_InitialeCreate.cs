using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PSGM.Model.DbBackend.Migrations
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
                name: "Backend_AuditLog",
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
                    table.PrimaryKey("PK_Backend_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Database_Cluster_AuditLog",
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
                    table.PrimaryKey("PK_Database_Cluster_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Database_Server_AuditLog",
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
                    table.PrimaryKey("PK_Database_Server_AuditLog", x => x.Id);
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
                name: "Storage_Cluster_AuditLog",
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
                    table.PrimaryKey("PK_Storage_Cluster_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Storage_Server_AuditLog",
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
                    table.PrimaryKey("PK_Storage_Server_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Backend",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    BackendType = table.Column<int>(type: "integer", nullable: false),
                    ReadOnlyMode = table.Column<bool>(type: "boolean", nullable: false),
                    Locked = table.Column<bool>(type: "boolean", nullable: false),
                    LockedDescription = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    Url = table.Column<string>(type: "character varying(1023)", maxLength: 1023, nullable: false),
                    UrlPublic = table.Column<string>(type: "character varying(1023)", maxLength: 1023, nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Backend", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Backend_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalSchema: "psgm",
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Database_Cluster",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    BranchNumber = table.Column<int>(type: "integer", nullable: false),
                    Domain = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Stars = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    DatabaseType = table.Column<int>(type: "integer", nullable: false),
                    DatabaseFilePath = table.Column<string>(type: "character varying(1023)", maxLength: 1023, nullable: false),
                    DatabasePort = table.Column<int>(type: "integer", nullable: false),
                    DatabaseUsername = table.Column<string>(type: "character varying(1023)", maxLength: 1023, nullable: false),
                    DatabasePassword = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    ReadOnlyMode = table.Column<bool>(type: "boolean", nullable: false),
                    Locked = table.Column<bool>(type: "boolean", nullable: false),
                    LockedDescription = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    Url = table.Column<string>(type: "character varying(1023)", maxLength: 1023, nullable: false),
                    UrlPublic = table.Column<string>(type: "character varying(1023)", maxLength: 1023, nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    BackendId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Database_Cluster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Database_Cluster_Backend_BackendId",
                        column: x => x.BackendId,
                        principalSchema: "psgm",
                        principalTable: "Backend",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Storage_Cluster",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    BranchNumber = table.Column<int>(type: "integer", nullable: false),
                    Domain = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Stars = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    DatabaseType = table.Column<int>(type: "integer", nullable: false),
                    DatabaseFilePath = table.Column<string>(type: "character varying(1023)", maxLength: 1023, nullable: false),
                    DatabasePort = table.Column<int>(type: "integer", nullable: false),
                    DatabaseUsername = table.Column<string>(type: "character varying(1023)", maxLength: 1023, nullable: false),
                    DatabasePassword = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    ReadOnlyMode = table.Column<bool>(type: "boolean", nullable: false),
                    Locked = table.Column<bool>(type: "boolean", nullable: false),
                    LockedDescription = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    Url = table.Column<string>(type: "character varying(1023)", maxLength: 1023, nullable: false),
                    UrlPublic = table.Column<string>(type: "character varying(1023)", maxLength: 1023, nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    BackendId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage_Cluster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Storage_Cluster_Backend_BackendId",
                        column: x => x.BackendId,
                        principalSchema: "psgm",
                        principalTable: "Backend",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Database_Server",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    FirstIpSegment = table.Column<int>(type: "integer", nullable: false),
                    LastIpSegment = table.Column<int>(type: "integer", nullable: false),
                    VLAN = table.Column<int>(type: "integer", nullable: false),
                    ReadOnlyMode = table.Column<bool>(type: "boolean", nullable: false),
                    Locked = table.Column<bool>(type: "boolean", nullable: false),
                    LockedDescription = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ClusterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Database_Server", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Database_Server_Database_Cluster_ClusterId",
                        column: x => x.ClusterId,
                        principalSchema: "psgm",
                        principalTable: "Database_Cluster",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Storage_Server",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    FirstIpSegment = table.Column<int>(type: "integer", nullable: false),
                    LastIpSegment = table.Column<int>(type: "integer", nullable: false),
                    VLAN = table.Column<int>(type: "integer", nullable: false),
                    ReadOnlyMode = table.Column<bool>(type: "boolean", nullable: false),
                    Locked = table.Column<bool>(type: "boolean", nullable: false),
                    LockedDescription = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ClusterId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage_Server", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Storage_Server_Storage_Cluster_ClusterId",
                        column: x => x.ClusterId,
                        principalSchema: "psgm",
                        principalTable: "Storage_Cluster",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Backend_ProjectId",
                schema: "psgm",
                table: "Backend",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Database_Cluster_BackendId",
                schema: "psgm",
                table: "Database_Cluster",
                column: "BackendId");

            migrationBuilder.CreateIndex(
                name: "IX_Database_Server_ClusterId",
                schema: "psgm",
                table: "Database_Server",
                column: "ClusterId");

            migrationBuilder.CreateIndex(
                name: "IX_Storage_Cluster_BackendId",
                schema: "psgm",
                table: "Storage_Cluster",
                column: "BackendId");

            migrationBuilder.CreateIndex(
                name: "IX_Storage_Server_ClusterId",
                schema: "psgm",
                table: "Storage_Server",
                column: "ClusterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Backend_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Database_Cluster_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Database_Server",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Database_Server_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Project_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Storage_Cluster_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Storage_Server",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Storage_Server_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Database_Cluster",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Storage_Cluster",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Backend",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "Project",
                schema: "psgm");
        }
    }
}
