using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PSGM.Model.DbStorageStructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialeCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
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
                    UserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    SoftwareIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    Changes = table.Column<string>(type: "TEXT", maxLength: 16383, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_AuditLog", x => x.Id);
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
                name: "ProjectParameterStorage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DatabaseType = table.Column<uint>(type: "INTEGER", nullable: false),
                    DatabaseFilePath = table.Column<string>(type: "TEXT", maxLength: 1023, nullable: false),
                    DatabaseConnectionString = table.Column<string>(type: "TEXT", maxLength: 1023, nullable: false),
                    StorageType = table.Column<uint>(type: "INTEGER", nullable: false),
                    StorageClass = table.Column<uint>(type: "INTEGER", nullable: false),
                    StorageTier = table.Column<uint>(type: "INTEGER", nullable: false),
                    StorageFilePath = table.Column<string>(type: "TEXT", maxLength: 1023, nullable: false),
                    StorageS3Endpoint = table.Column<string>(type: "TEXT", maxLength: 1023, nullable: false),
                    StorageS3BucketName = table.Column<string>(type: "TEXT", maxLength: 1023, nullable: false),
                    StorageS3AccessKey = table.Column<string>(type: "TEXT", maxLength: 1023, nullable: false),
                    StorageS3SecretKey = table.Column<string>(type: "TEXT", maxLength: 1023, nullable: false),
                    StorageS3Secure = table.Column<bool>(type: "INTEGER", maxLength: 1023, nullable: false),
                    StorageS3Region = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 1023, nullable: false),
                    UrlPublic = table.Column<string>(type: "TEXT", maxLength: 1023, nullable: false),
                    ReadOnlyMode = table.Column<bool>(type: "INTEGER", nullable: false),
                    ProjectId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectParameterStorage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectParameterStorage_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectParameterStorage_ProjectId",
                table: "ProjectParameterStorage",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project_AuditLog");

            migrationBuilder.DropTable(
                name: "ProjectParameterStorage");

            migrationBuilder.DropTable(
                name: "ProjectParameterStorage_AuditLog");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
