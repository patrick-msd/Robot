using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PSGM.Model.DbWorkflow.Migrations
{
    /// <inheritdoc />
    public partial class InitialeCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workflow",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 8191, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workflow", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workflow_AuditLog",
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
                    table.PrimaryKey("PK_Workflow_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 8191, nullable: false),
                    Configuration = table.Column<string>(type: "TEXT", maxLength: 65536, nullable: false),
                    ApplyLevel = table.Column<uint>(type: "INTEGER", nullable: false),
                    WorkflowExecutionLevel = table.Column<uint>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowItem_AuditLog",
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
                    table.PrimaryKey("PK_WorkflowItem_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowItemLink_AuditLog",
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
                    table.PrimaryKey("PK_WorkflowItemLink_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowItemLink",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Order = table.Column<uint>(type: "INTEGER", nullable: false),
                    ApplyLevel = table.Column<uint>(type: "INTEGER", nullable: false),
                    StorageType = table.Column<uint>(type: "INTEGER", nullable: false),
                    StorageClass = table.Column<uint>(type: "INTEGER", nullable: false),
                    Configuration = table.Column<string>(type: "TEXT", maxLength: 65536, nullable: false),
                    ExecutionPermissions = table.Column<int>(type: "INTEGER", nullable: false),
                    WorkflowId = table.Column<Guid>(type: "TEXT", nullable: false),
                    WorkflowItemId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowItemLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowItemLink_WorkflowItem_WorkflowItemId",
                        column: x => x.WorkflowItemId,
                        principalTable: "WorkflowItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkflowItemLink_Workflow_WorkflowId",
                        column: x => x.WorkflowId,
                        principalTable: "Workflow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "WorkflowItem",
                columns: new[] { "Id", "ApplyLevel", "Configuration", "Description", "Name", "WorkflowExecutionLevel" },
                values: new object[,]
                {
                    { new Guid("083c3d9a-0915-4506-bf60-b164d19071df"), 10000u, "", "Sharpen image ...", "Sharpen image - V2.0.0", 0u },
                    { new Guid("0f10bb0b-f782-4e5b-a53b-c75f7c0403fb"), 10000u, "", "Rotate image ...", "Rotate image - V1.0.0", 0u },
                    { new Guid("38905667-b47b-4d23-b149-c500372f0eff"), 10000u, "", "Sharpen image ...", "Sharpen image - V1.0.0", 0u },
                    { new Guid("4d7723ce-5bcd-4f82-a921-f9621fa5c383"), 10000u, "", "Calculate HDR image with OpenCV (mergeMertens) ...", "Calculate HDR image - V1.0.0", 0u },
                    { new Guid("68299067-b79b-4120-98df-13a3e2232c88"), 10000u, "", "Calculate darktable image according to the sidecar file ...", "Calculate darktable image - V1.0.0", 0u },
                    { new Guid("c2dc5eed-f926-4615-882f-c8184c981d93"), 10000u, "", "Crop image to specified size...", "Crop image - V1.0.0", 0u },
                    { new Guid("c33c011d-229a-4c3d-af44-05db3a4c7af4"), 10000u, "", "Resize image to specified size...", "Resize image - V1.0.0", 0u },
                    { new Guid("ef601faa-1bb5-4171-b907-60a2f1935eee"), 10000u, "", "Save object (depending on storage configuration in project parameters) to specified S3 storage or filesystem and add the file entity to the database...", "Save object to S3 storage or filesystem and add entity to database - V1.0.0", 0u },
                    { new Guid("f03093f8-6ea8-4bee-9875-30d1fc7975f3"), 10000u, "", "Grab image with specified camera ...", "Grab image - V1.0.0", 0u },
                    { new Guid("fd184c53-2e4a-4384-8894-3639eef8ea66"), 10000u, "", "Rotate image ...", "Rotate image - V2.0.0", 0u }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowItemLink_WorkflowId",
                table: "WorkflowItemLink",
                column: "WorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowItemLink_WorkflowItemId",
                table: "WorkflowItemLink",
                column: "WorkflowItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Workflow_AuditLog");

            migrationBuilder.DropTable(
                name: "WorkflowItem_AuditLog");

            migrationBuilder.DropTable(
                name: "WorkflowItemLink");

            migrationBuilder.DropTable(
                name: "WorkflowItemLink_AuditLog");

            migrationBuilder.DropTable(
                name: "WorkflowItem");

            migrationBuilder.DropTable(
                name: "Workflow");
        }
    }
}
