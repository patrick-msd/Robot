using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PSGM.Model.DbJob.Migrations
{
    /// <inheritdoc />
    public partial class InitialeCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    JobType = table.Column<uint>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 8191, nullable: false),
                    JobStarted = table.Column<DateTime>(type: "TEXT", nullable: false),
                    JobFinished = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MachineIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    DeviceIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProjectIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    FileIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    SubDirectoryIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedByUserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedByUserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    LastChanges = table.Column<string>(type: "TEXT", maxLength: 8191, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Job_AuditLog",
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
                    table.PrimaryKey("PK_Job_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    JobType = table.Column<uint>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 8191, nullable: false),
                    JobStarted = table.Column<DateTime>(type: "TEXT", nullable: false),
                    JobFinished = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MachineIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    DeviceIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProjectIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    FileIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    SubDirectoryIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedByUserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedByUserIdExt = table.Column<Guid>(type: "TEXT", nullable: false),
                    LastChanges = table.Column<string>(type: "TEXT", maxLength: 8191, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobHistory_AuditLog",
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
                    table.PrimaryKey("PK_JobHistory_AuditLog", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Job_AuditLog");

            migrationBuilder.DropTable(
                name: "JobHistory");

            migrationBuilder.DropTable(
                name: "JobHistory_AuditLog");
        }
    }
}
