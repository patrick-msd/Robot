using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PSGM.Model.DbSoftware.Migrations
{
    /// <inheritdoc />
    public partial class InitialeCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Software",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 127, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 8191, nullable: false),
                    Version = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    ReleaseChannel = table.Column<uint>(type: "INTEGER", nullable: false),
                    SoftwareType = table.Column<uint>(type: "INTEGER", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndOfLife = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdateServer = table.Column<string>(type: "TEXT", maxLength: 2048, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Software", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Software_AuditLog",
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
                    table.PrimaryKey("PK_Software_AuditLog", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Software");

            migrationBuilder.DropTable(
                name: "Software_AuditLog");
        }
    }
}
