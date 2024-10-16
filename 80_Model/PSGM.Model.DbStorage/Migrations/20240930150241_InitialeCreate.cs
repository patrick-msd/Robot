﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PSGM.Model.DbStorage.Migrations
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
                name: "File_Archive",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ArchiveId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_Archive", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Archive_AuditLog",
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
                    table.PrimaryKey("PK_File_Archive_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Archive_Link_AuditLog",
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
                    table.PrimaryKey("PK_File_Archive_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_AuditLog",
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
                    table.PrimaryKey("PK_File_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Job",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    JobId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_Job", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Job_AuditLog",
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
                    table.PrimaryKey("PK_File_Job_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Job_Link_AuditLog",
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
                    table.PrimaryKey("PK_File_Job_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Metadata_AuditLog",
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
                    table.PrimaryKey("PK_File_Metadata_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Metadata_Link_AuditLog",
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
                    table.PrimaryKey("PK_File_Metadata_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_QrCode_AuditLog",
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
                    table.PrimaryKey("PK_File_QrCode_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Quality_AuditLog",
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
                    table.PrimaryKey("PK_File_Quality_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_User_AuditLog",
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
                    table.PrimaryKey("PK_File_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_User_Link_AuditLog",
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
                    table.PrimaryKey("PK_File_User_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_User_Notification_AuditLog",
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
                    table.PrimaryKey("PK_File_User_Notification_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_User_Permission_AuditLog",
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
                    table.PrimaryKey("PK_File_User_Permission_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_UserGroup",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_UserGroup_AuditLog",
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
                    table.PrimaryKey("PK_File_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_UserGroup_Link_AuditLog",
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
                    table.PrimaryKey("PK_File_UserGroup_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_UserGroup_Notification_AuditLog",
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
                    table.PrimaryKey("PK_File_UserGroup_Notification_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_UserGroup_Permission_AuditLog",
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
                    table.PrimaryKey("PK_File_UserGroup_Permission_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_UserGroup_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_UserGroup_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_UserGroup_User_AuditLog",
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
                    table.PrimaryKey("PK_File_UserGroup_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_UserGroup_User_Link_AuditLog",
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
                    table.PrimaryKey("PK_File_UserGroup_User_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_VirtualUnit_AuditLog",
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
                    table.PrimaryKey("PK_File_VirtualUnit_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_VirtualUnit_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_VirtualUnit_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_VirtualUnit_User_AuditLog",
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
                    table.PrimaryKey("PK_File_VirtualUnit_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_VirtualUnit_User_Link_AuditLog",
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
                    table.PrimaryKey("PK_File_VirtualUnit_User_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_VirtualUnit_User_Notification_AuditLog",
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
                    table.PrimaryKey("PK_File_VirtualUnit_User_Notification_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_VirtualUnit_User_Permission_AuditLog",
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
                    table.PrimaryKey("PK_File_VirtualUnit_User_Permission_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_VirtualUnit_UserGroup",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_VirtualUnit_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_VirtualUnit_UserGroup_AuditLog",
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
                    table.PrimaryKey("PK_File_VirtualUnit_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_VirtualUnit_UserGroup_Link_AuditLog",
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
                    table.PrimaryKey("PK_File_VirtualUnit_UserGroup_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_VirtualUnit_UserGroup_Notification_AuditLog",
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
                    table.PrimaryKey("PK_File_VirtualUnit_UserGroup_Notification_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_VirtualUnit_UserGroup_Permission_AuditLog",
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
                    table.PrimaryKey("PK_File_VirtualUnit_UserGroup_Permission_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_VirtualUnit_UserGroup_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_VirtualUnit_UserGroup_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_VirtualUnit_UserGroup_User_AuditLog",
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
                    table.PrimaryKey("PK_File_VirtualUnit_UserGroup_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_VirtualUnit_UserGroup_User_Link_AuditLog",
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
                    table.PrimaryKey("PK_File_VirtualUnit_UserGroup_User_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Workflow",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ArchiveId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_Workflow", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Workflow_AuditLog",
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
                    table.PrimaryKey("PK_File_Workflow_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_Workflow_Link_AuditLog",
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
                    table.PrimaryKey("PK_File_Workflow_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetadataKey",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    Description = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetadataKey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetadataKey_AuditLog",
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
                    table.PrimaryKey("PK_MetadataKey_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetadataKey_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetadataKey_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetadataKey_User_AuditLog",
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
                    table.PrimaryKey("PK_MetadataKey_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetadataKey_User_Link_AuditLog",
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
                    table.PrimaryKey("PK_MetadataKey_User_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetadataKey_User_Notification_AuditLog",
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
                    table.PrimaryKey("PK_MetadataKey_User_Notification_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetadataKey_User_Permission_AuditLog",
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
                    table.PrimaryKey("PK_MetadataKey_User_Permission_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetadataKey_UserGroup",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetadataKey_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetadataKey_UserGroup_AuditLog",
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
                    table.PrimaryKey("PK_MetadataKey_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetadataKey_UserGroup_Link_AuditLog",
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
                    table.PrimaryKey("PK_MetadataKey_UserGroup_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetadataKey_UserGroup_Notification_AuditLog",
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
                    table.PrimaryKey("PK_MetadataKey_UserGroup_Notification_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetadataKey_UserGroup_Permission_AuditLog",
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
                    table.PrimaryKey("PK_MetadataKey_UserGroup_Permission_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetadataKey_UserGroup_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetadataKey_UserGroup_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetadataKey_UserGroup_User_AuditLog",
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
                    table.PrimaryKey("PK_MetadataKey_UserGroup_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MetadataKey_UserGroup_User_Link_AuditLog",
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
                    table.PrimaryKey("PK_MetadataKey_UserGroup_User_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Suffix = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Prefix = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    SuffixProjectOwner = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    NameProjectOwner = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PrefixProjectOwner = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DescriptionProjectOwner = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    Stars = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    DirectoryState = table.Column<int>(type: "integer", nullable: false),
                    Locked = table.Column<bool>(type: "boolean", nullable: false),
                    LockedDescription = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    ObjectsAutofill = table.Column<int>(type: "integer", nullable: false),
                    DirectorySizeAutofill = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Archive",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ArchiveId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_Archive", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Archive_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_Archive_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Archive_Link_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_Archive_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Job",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    JobId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_Job", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Job_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_Job_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Job_Link_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_Job_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Metadata_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_Metadata_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Metadata_Link_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_Metadata_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_QrCode_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_QrCode_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Quality_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_Quality_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_User_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_User_Link_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_User_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_User_Notification_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_User_Notification_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_User_Permission_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_User_Permission_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_UserGroup",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_UserGroup_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_UserGroup_Link_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_UserGroup_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_UserGroup_Notification_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_UserGroup_Notification_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_UserGroup_Permission_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_UserGroup_Permission_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_UserGroup_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_UserGroup_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_UserGroup_User_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_UserGroup_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_UserGroup_User_Link_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_UserGroup_User_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_VirtualUnit_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_VirtualUnit_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_VirtualUnit_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_VirtualUnit_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_VirtualUnit_User_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_VirtualUnit_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_VirtualUnit_User_Link_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_VirtualUnit_User_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_VirtualUnit_User_Notification_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_VirtualUnit_User_Notification_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_VirtualUnit_User_Permission_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_VirtualUnit_User_Permission_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_VirtualUnit_UserGroup",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_VirtualUnit_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_VirtualUnit_UserGroup_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_VirtualUnit_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_VirtualUnit_UserGroup_Link_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_VirtualUnit_UserGroup_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_VirtualUnit_UserGroup_Notification_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_VirtualUnit_UserGroup_Notification_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_VirtualUnit_UserGroup_Permission_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_VirtualUnit_UserGroup_Permission_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_VirtualUnit_UserGroup_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_VirtualUnit_UserGroup_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_VirtualUnit_UserGroup_User_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_VirtualUnit_UserGroup_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_VirtualUnit_UserGroup_User_Link_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_VirtualUnit_UserGroup_User_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Workflow",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ArchiveId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_Workflow", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Workflow_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_Workflow_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Workflow_Link_AuditLog",
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
                    table.PrimaryKey("PK_RootDirectory_Workflow_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Archive",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ArchiveId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_Archive", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Archive_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_Archive_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Archive_Link_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_Archive_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Job",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    JobId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_Job", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Job_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_Job_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Job_Link_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_Job_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Metadata_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_Metadata_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Metadata_Link_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_Metadata_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_QrCode_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_QrCode_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_QualityAuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_QualityAuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_User_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_User_Link_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_User_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_User_Notification_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_User_Notification_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_User_Permission_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_User_Permission_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_UserGroup",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_UserGroup_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_UserGroup_Link_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_UserGroup_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_UserGroup_Notification_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_UserGroup_Notification_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_UserGroup_Permission_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_UserGroup_Permission_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_UserGroup_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_UserGroup_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_UserGroup_User_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_UserGroup_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_UserGroup_User_Link_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_UserGroup_User_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_VirtualUnit_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_VirtualUnit_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_VirtualUnit_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_VirtualUnit_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_VirtualUnit_User_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_VirtualUnit_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_VirtualUnit_User_Link_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_VirtualUnit_User_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_VirtualUnit_User_Notification_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_VirtualUnit_User_Notification_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_VirtualUnit_User_Permission_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_VirtualUnit_User_Permission_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_VirtualUnit_UserGroup",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_VirtualUnit_UserGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_VirtualUnit_UserGroup_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_VirtualUnit_UserGroup_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_VirtualUnit_UserGroup_Link_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_VirtualUnit_UserGroup_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_VirtualUnit_UserGroup_Notification_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_VirtualUnit_UserGroup_Notification_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_VirtualUnit_UserGroup_Permission_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_VirtualUnit_UserGroup_Permission_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_VirtualUnit_UserGroup_User",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_VirtualUnit_UserGroup_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_VirtualUnit_UserGroup_User_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_VirtualUnit_UserGroup_User_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_VirtualUnit_UserGroup_User_Link_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_VirtualUnit_UserGroup_User_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Workflow",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ArchiveId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_Workflow", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Workflow_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_Workflow_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Workflow_Link_AuditLog",
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
                    table.PrimaryKey("PK_SubDirectory_Workflow_Link_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "File_User_Notification",
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
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_User_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_User_Notification_File_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "psgm",
                        principalTable: "File_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File_User_Permission",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    PermissionFile = table.Column<int>(type: "integer", nullable: false),
                    PermissionMetadata = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_User_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_User_Permission_File_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "psgm",
                        principalTable: "File_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File_UserGroup_Notification",
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
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_UserGroup_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_UserGroup_Notification_File_UserGroup_UserGroupId",
                        column: x => x.UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "File_UserGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File_UserGroup_Permission",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    PermissionFile = table.Column<int>(type: "integer", nullable: false),
                    PermissionMetadata = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_UserGroup_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_UserGroup_Permission_File_UserGroup_UserGroupId",
                        column: x => x.UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "File_UserGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File_UserGroup_User_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_UserGroup_User_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_UserGroup_User_Link_File_UserGroup_UserGroupId",
                        column: x => x.UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "File_UserGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_File_UserGroup_User_Link_File_UserGroup_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "psgm",
                        principalTable: "File_UserGroup_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "File_VirtualUnit_User_Notification",
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
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_VirtualUnit_User_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_VirtualUnit_User_Notification_File_VirtualUnit_User_Us~",
                        column: x => x.UserId,
                        principalSchema: "psgm",
                        principalTable: "File_VirtualUnit_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File_VirtualUnit_User_Permission",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    PermissionFile = table.Column<int>(type: "integer", nullable: false),
                    PermissionMetadata = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_VirtualUnit_User_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_VirtualUnit_User_Permission_File_VirtualUnit_User_User~",
                        column: x => x.UserId,
                        principalSchema: "psgm",
                        principalTable: "File_VirtualUnit_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File_VirtualUnit_UserGroup_Notification",
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
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_VirtualUnit_UserGroup_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_VirtualUnit_UserGroup_Notification_File_VirtualUnit_Us~",
                        column: x => x.UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "File_VirtualUnit_UserGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File_VirtualUnit_UserGroup_Permission",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    PermissionFile = table.Column<int>(type: "integer", nullable: false),
                    PermissionMetadata = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_VirtualUnit_UserGroup_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_VirtualUnit_UserGroup_Permission_File_VirtualUnit_User~",
                        column: x => x.UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "File_VirtualUnit_UserGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File_VirtualUnit_UserGroup_User_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_VirtualUnit_UserGroup_User_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_VirtualUnit_UserGroup_User_Link_File_VirtualUnit_UserG~",
                        column: x => x.UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "File_VirtualUnit_UserGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_File_VirtualUnit_UserGroup_User_Link_File_VirtualUnit_User~1",
                        column: x => x.UserId,
                        principalSchema: "psgm",
                        principalTable: "File_VirtualUnit_UserGroup_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "File_Metadata",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    Description = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    MetadataSource = table.Column<int>(type: "integer", nullable: false),
                    MetadataPermissions = table.Column<int>(type: "integer", nullable: false),
                    ApplicableForFiles = table.Column<bool>(type: "boolean", nullable: false),
                    Stars = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    KeyId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_Metadata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_Metadata_MetadataKey_KeyId",
                        column: x => x.KeyId,
                        principalSchema: "psgm",
                        principalTable: "MetadataKey",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Metadata",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    Description = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    MetadataSource = table.Column<int>(type: "integer", nullable: false),
                    MetadataPermissions = table.Column<int>(type: "integer", nullable: false),
                    ApplicableForFiles = table.Column<bool>(type: "boolean", nullable: false),
                    Stars = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    KeyId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_Metadata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectory_Metadata_MetadataKey_KeyId",
                        column: x => x.KeyId,
                        principalSchema: "psgm",
                        principalTable: "MetadataKey",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Metadata",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    Description = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    MetadataSource = table.Column<int>(type: "integer", nullable: false),
                    MetadataPermissions = table.Column<int>(type: "integer", nullable: false),
                    ApplicableForFiles = table.Column<bool>(type: "boolean", nullable: false),
                    Stars = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    KeyId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_Metadata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_Metadata_MetadataKey_KeyId",
                        column: x => x.KeyId,
                        principalSchema: "psgm",
                        principalTable: "MetadataKey",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MetadataKey_User_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MetadataKeyId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetadataKey_User_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetadataKey_User_Link_MetadataKey_MetadataKeyId",
                        column: x => x.MetadataKeyId,
                        principalSchema: "psgm",
                        principalTable: "MetadataKey",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MetadataKey_User_Link_MetadataKey_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "psgm",
                        principalTable: "MetadataKey_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MetadataKey_User_Notification",
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
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetadataKey_User_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetadataKey_User_Notification_MetadataKey_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "psgm",
                        principalTable: "MetadataKey_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MetadataKey_User_Permission",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    PermissionFile = table.Column<int>(type: "integer", nullable: false),
                    PermissionMetadata = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetadataKey_User_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetadataKey_User_Permission_MetadataKey_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "psgm",
                        principalTable: "MetadataKey_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MetadataKey_UserGroup_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MetadataKeyId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetadataKey_UserGroup_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetadataKey_UserGroup_Link_MetadataKey_MetadataKeyId",
                        column: x => x.MetadataKeyId,
                        principalSchema: "psgm",
                        principalTable: "MetadataKey",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MetadataKey_UserGroup_Link_MetadataKey_UserGroup_UserGroupId",
                        column: x => x.UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "MetadataKey_UserGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MetadataKey_UserGroup_Notification",
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
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetadataKey_UserGroup_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetadataKey_UserGroup_Notification_MetadataKey_UserGroup_Us~",
                        column: x => x.UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "MetadataKey_UserGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MetadataKey_UserGroup_Permission",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    PermissionFile = table.Column<int>(type: "integer", nullable: false),
                    PermissionMetadata = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetadataKey_UserGroup_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetadataKey_UserGroup_Permission_MetadataKey_UserGroup_User~",
                        column: x => x.UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "MetadataKey_UserGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MetadataKey_UserGroup_User_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetadataKey_UserGroup_User_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MetadataKey_UserGroup_User_Link_MetadataKey_UserGroup_UserG~",
                        column: x => x.UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "MetadataKey_UserGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MetadataKey_UserGroup_User_Link_MetadataKey_UserGroup_User_~",
                        column: x => x.UserId,
                        principalSchema: "psgm",
                        principalTable: "MetadataKey_UserGroup_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_QrCode",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QrCode_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    RootDirectoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_QrCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectory_QrCode_RootDirectory_RootDirectoryId",
                        column: x => x.RootDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Quality",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QualityState = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    RootDirectoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_Quality", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectory_Quality_RootDirectory_RootDirectoryId",
                        column: x => x.RootDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_VirtualUnit",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VirtualUnitId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    RootDirectoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_VirtualUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectory_VirtualUnit_RootDirectory_RootDirectoryId",
                        column: x => x.RootDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Suffix = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Prefix = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    SuffixProjectOwner = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    NameProjectOwner = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PrefixProjectOwner = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DescriptionProjectOwner = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    Stars = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    DirectoryState = table.Column<int>(type: "integer", nullable: false),
                    Locked = table.Column<bool>(type: "boolean", nullable: false),
                    LockedDescription = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    ObjectsAutofill = table.Column<int>(type: "integer", nullable: false),
                    DirectorySizeAutofill = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    RootDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    ParentSubDirectoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_RootDirectory_RootDirectoryId",
                        column: x => x.RootDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubDirectory_SubDirectory_ParentSubDirectoryId",
                        column: x => x.ParentSubDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Archive_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RootDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    ArchiveId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_Archive_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectory_Archive_Link_RootDirectory_Archive_ArchiveId",
                        column: x => x.ArchiveId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory_Archive",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RootDirectory_Archive_Link_RootDirectory_RootDirectoryId",
                        column: x => x.RootDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Job_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RootDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    JobId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_Job_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectory_Job_Link_RootDirectory_Job_JobId",
                        column: x => x.JobId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory_Job",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RootDirectory_Job_Link_RootDirectory_RootDirectoryId",
                        column: x => x.RootDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_User_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RootDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_User_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectory_User_Link_RootDirectory_RootDirectoryId",
                        column: x => x.RootDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RootDirectory_User_Link_RootDirectory_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_User_Notification",
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
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_User_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectory_User_Notification_RootDirectory_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_User_Permission",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    PermissionFile = table.Column<int>(type: "integer", nullable: false),
                    PermissionMetadata = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_User_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectory_User_Permission_RootDirectory_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_UserGroup_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RootDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_UserGroup_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectory_UserGroup_Link_RootDirectory_RootDirectoryId",
                        column: x => x.RootDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RootDirectory_UserGroup_Link_RootDirectory_UserGroup_UserGr~",
                        column: x => x.UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory_UserGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_UserGroup_Notification",
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
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_UserGroup_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectory_UserGroup_Notification_RootDirectory_UserGrou~",
                        column: x => x.UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory_UserGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_UserGroup_Permission",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    PermissionFile = table.Column<int>(type: "integer", nullable: false),
                    PermissionMetadata = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_UserGroup_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectory_UserGroup_Permission_RootDirectory_UserGroup_~",
                        column: x => x.UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory_UserGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_UserGroup_User_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_UserGroup_User_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectory_UserGroup_User_Link_RootDirectory_UserGroup_U~",
                        column: x => x.UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory_UserGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RootDirectory_UserGroup_User_Link_RootDirectory_UserGroup_~1",
                        column: x => x.UserId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory_UserGroup_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_VirtualUnit_User_Notification",
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
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_VirtualUnit_User_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectory_VirtualUnit_User_Notification_RootDirectory_V~",
                        column: x => x.UserId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory_VirtualUnit_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_VirtualUnit_User_Permission",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    PermissionFile = table.Column<int>(type: "integer", nullable: false),
                    PermissionMetadata = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_VirtualUnit_User_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectory_VirtualUnit_User_Permission_RootDirectory_Vir~",
                        column: x => x.UserId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory_VirtualUnit_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_VirtualUnit_UserGroup_Notification",
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
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_VirtualUnit_UserGroup_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectory_VirtualUnit_UserGroup_Notification_RootDirect~",
                        column: x => x.UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory_VirtualUnit_UserGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_VirtualUnit_UserGroup_Permission",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    PermissionFile = table.Column<int>(type: "integer", nullable: false),
                    PermissionMetadata = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_VirtualUnit_UserGroup_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectory_VirtualUnit_UserGroup_Permission_RootDirector~",
                        column: x => x.UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory_VirtualUnit_UserGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_VirtualUnit_UserGroup_User_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_VirtualUnit_UserGroup_User_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectory_VirtualUnit_UserGroup_User_Link_RootDirectory~",
                        column: x => x.UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory_VirtualUnit_UserGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RootDirectory_VirtualUnit_UserGroup_User_Link_RootDirector~1",
                        column: x => x.UserId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory_VirtualUnit_UserGroup_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Workflow_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RootDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    WorkflowId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_Workflow_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectory_Workflow_Link_RootDirectory_RootDirectoryId",
                        column: x => x.RootDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RootDirectory_Workflow_Link_RootDirectory_Workflow_Workflow~",
                        column: x => x.WorkflowId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory_Workflow",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_User_Notification",
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
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_User_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_User_Notification_SubDirectory_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_User_Permission",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    PermissionFile = table.Column<int>(type: "integer", nullable: false),
                    PermissionMetadata = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_User_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_User_Permission_SubDirectory_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_UserGroup_Notification",
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
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_UserGroup_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_UserGroup_Notification_SubDirectory_UserGroup_~",
                        column: x => x.UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory_UserGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_UserGroup_Permission",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    PermissionFile = table.Column<int>(type: "integer", nullable: false),
                    PermissionMetadata = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_UserGroup_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_UserGroup_Permission_SubDirectory_UserGroup_Us~",
                        column: x => x.UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory_UserGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_UserGroup_User_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_UserGroup_User_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_UserGroup_User_Link_SubDirectory_UserGroup_Use~",
                        column: x => x.UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory_UserGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubDirectory_UserGroup_User_Link_SubDirectory_UserGroup_Us~1",
                        column: x => x.UserId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory_UserGroup_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_VirtualUnit_User_Notification",
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
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_VirtualUnit_User_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_VirtualUnit_User_Notification_SubDirectory_Vir~",
                        column: x => x.UserId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory_VirtualUnit_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_VirtualUnit_User_Permission",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    PermissionFile = table.Column<int>(type: "integer", nullable: false),
                    PermissionMetadata = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_VirtualUnit_User_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_VirtualUnit_User_Permission_SubDirectory_Virtu~",
                        column: x => x.UserId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory_VirtualUnit_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_VirtualUnit_UserGroup_Notification",
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
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_VirtualUnit_UserGroup_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_VirtualUnit_UserGroup_Notification_SubDirector~",
                        column: x => x.UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory_VirtualUnit_UserGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_VirtualUnit_UserGroup_Permission",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(16384)", maxLength: 16384, nullable: false),
                    PermissionFile = table.Column<int>(type: "integer", nullable: false),
                    PermissionMetadata = table.Column<int>(type: "integer", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_VirtualUnit_UserGroup_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_VirtualUnit_UserGroup_Permission_SubDirectory_~",
                        column: x => x.UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory_VirtualUnit_UserGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_VirtualUnit_UserGroup_User_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_VirtualUnit_UserGroup_User_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_VirtualUnit_UserGroup_User_Link_SubDirectory_V~",
                        column: x => x.UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory_VirtualUnit_UserGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubDirectory_VirtualUnit_UserGroup_User_Link_SubDirectory_~1",
                        column: x => x.UserId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory_VirtualUnit_UserGroup_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_Metadata_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RootDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    MetadataId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_Metadata_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectory_Metadata_Link_RootDirectory_Metadata_Metadata~",
                        column: x => x.MetadataId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory_Metadata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RootDirectory_Metadata_Link_RootDirectory_RootDirectoryId",
                        column: x => x.RootDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_VirtualUnit_User_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_VirtualUnit_User_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectory_VirtualUnit_User_Link_RootDirectory_VirtualUn~",
                        column: x => x.FileId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory_VirtualUnit",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RootDirectory_VirtualUnit_User_Link_RootDirectory_VirtualU~1",
                        column: x => x.UserId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory_VirtualUnit_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RootDirectory_VirtualUnit_UserGroup_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VirtualUnitId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RootDirectory_VirtualUnit_UserGroup_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RootDirectory_VirtualUnit_UserGroup_Link_RootDirectory_Virt~",
                        column: x => x.UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory_VirtualUnit_UserGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RootDirectory_VirtualUnit_UserGroup_Link_RootDirectory_Vir~1",
                        column: x => x.VirtualUnitId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory_VirtualUnit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Suffix = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Prefix = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    SuffixProjectOwner = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    NameProjectOwner = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PrefixProjectOwner = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DescriptionProjectOwner = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    Stars = table.Column<int>(type: "integer", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    ObjectExtension = table.Column<int>(type: "integer", nullable: false),
                    ObjectSize = table.Column<long>(type: "bigint", nullable: false),
                    StorageObjectName = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    StorageObjectVersion = table.Column<int>(type: "integer", nullable: false),
                    StorageObjectUrl = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    StorageObjectUrlPublic = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    ExtId1 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ExtId2 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ExtId3 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ExtId4 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ExtId5 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ExtId6 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ExtId7 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ExtId8 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ExtId9 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ExtId10 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    MachineId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    DeviceId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    SoftwareId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    Locked = table.Column<bool>(type: "boolean", nullable: false),
                    LockedDescription = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    RawFileIdsString = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    RootDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    SubDirectoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_RootDirectory_RootDirectoryId",
                        column: x => x.RootDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "RootDirectory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_File_SubDirectory_SubDirectoryId",
                        column: x => x.SubDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Archive_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    ArchiveId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_Archive_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_Archive_Link_SubDirectory_Archive_ArchiveId",
                        column: x => x.ArchiveId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory_Archive",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubDirectory_Archive_Link_SubDirectory_SubDirectoryId",
                        column: x => x.SubDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Job_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    JobId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_Job_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_Job_Link_SubDirectory_Job_JobId",
                        column: x => x.JobId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory_Job",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubDirectory_Job_Link_SubDirectory_SubDirectoryId",
                        column: x => x.SubDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Metadata_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    MetadataId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_Metadata_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_Metadata_Link_SubDirectory_Metadata_MetadataId",
                        column: x => x.MetadataId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory_Metadata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubDirectory_Metadata_Link_SubDirectory_SubDirectoryId",
                        column: x => x.SubDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_QrCode",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QrCode_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    SubDirectoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_QrCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_QrCode_SubDirectory_SubDirectoryId",
                        column: x => x.SubDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Quality",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QualityState = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    SubDirectoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_Quality", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_Quality_SubDirectory_SubDirectoryId",
                        column: x => x.SubDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_User_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_User_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_User_Link_SubDirectory_SubDirectoryId",
                        column: x => x.SubDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubDirectory_User_Link_SubDirectory_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_UserGroup_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_UserGroup_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_UserGroup_Link_SubDirectory_SubDirectoryId",
                        column: x => x.SubDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubDirectory_UserGroup_Link_SubDirectory_UserGroup_UserGrou~",
                        column: x => x.UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory_UserGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_VirtualUnit",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VirtualUnitId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    SubDirectoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_VirtualUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_VirtualUnit_SubDirectory_SubDirectoryId",
                        column: x => x.SubDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_Workflow_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubDirectoryId = table.Column<Guid>(type: "uuid", nullable: true),
                    WorkflowId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_Workflow_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_Workflow_Link_SubDirectory_SubDirectoryId",
                        column: x => x.SubDirectoryId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubDirectory_Workflow_Link_SubDirectory_Workflow_WorkflowId",
                        column: x => x.WorkflowId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory_Workflow",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File_Archive_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: true),
                    ArchiveId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_Archive_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_Archive_Link_File_Archive_ArchiveId",
                        column: x => x.ArchiveId,
                        principalSchema: "psgm",
                        principalTable: "File_Archive",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_File_Archive_Link_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "psgm",
                        principalTable: "File",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File_Job_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: true),
                    JobId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_Job_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_Job_Link_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "psgm",
                        principalTable: "File",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_File_Job_Link_File_Job_JobId",
                        column: x => x.JobId,
                        principalSchema: "psgm",
                        principalTable: "File_Job",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File_Metadata_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: true),
                    MetadataId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_Metadata_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_Metadata_Link_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "psgm",
                        principalTable: "File",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_File_Metadata_Link_File_Metadata_MetadataId",
                        column: x => x.MetadataId,
                        principalSchema: "psgm",
                        principalTable: "File_Metadata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "File_QrCode",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QrCode_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_QrCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_QrCode_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "psgm",
                        principalTable: "File",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File_Quality",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    QualityState = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(8192)", maxLength: 8192, nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_Quality", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_Quality_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "psgm",
                        principalTable: "File",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File_User_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_User_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_User_Link_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "psgm",
                        principalTable: "File",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_File_User_Link_File_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "psgm",
                        principalTable: "File_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File_UserGroup_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_UserGroup_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_UserGroup_Link_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "psgm",
                        principalTable: "File",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_File_UserGroup_Link_File_UserGroup_UserGroupId",
                        column: x => x.UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "File_UserGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File_VirtualUnit",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VirtualUnitId_Ext = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDateTimeAutoFill = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedByUserId_ExtAutoFill = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_VirtualUnit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_VirtualUnit_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "psgm",
                        principalTable: "File",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File_Workflow_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: true),
                    WorkflowId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_Workflow_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_Workflow_Link_File_FileId",
                        column: x => x.FileId,
                        principalSchema: "psgm",
                        principalTable: "File",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_File_Workflow_Link_File_Workflow_WorkflowId",
                        column: x => x.WorkflowId,
                        principalSchema: "psgm",
                        principalTable: "File_Workflow",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_VirtualUnit_User_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_VirtualUnit_User_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_VirtualUnit_User_Link_SubDirectory_VirtualUnit~",
                        column: x => x.FileId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory_VirtualUnit",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubDirectory_VirtualUnit_User_Link_SubDirectory_VirtualUni~1",
                        column: x => x.UserId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory_VirtualUnit_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubDirectory_VirtualUnit_UserGroup_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VirtualUnitId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDirectory_VirtualUnit_UserGroup_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubDirectory_VirtualUnit_UserGroup_Link_SubDirectory_Virtua~",
                        column: x => x.UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory_VirtualUnit_UserGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubDirectory_VirtualUnit_UserGroup_Link_SubDirectory_Virtu~1",
                        column: x => x.VirtualUnitId,
                        principalSchema: "psgm",
                        principalTable: "SubDirectory_VirtualUnit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File_VirtualUnit_User_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_VirtualUnit_User_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_VirtualUnit_User_Link_File_VirtualUnit_FileId",
                        column: x => x.FileId,
                        principalSchema: "psgm",
                        principalTable: "File_VirtualUnit",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_File_VirtualUnit_User_Link_File_VirtualUnit_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "psgm",
                        principalTable: "File_VirtualUnit_User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "File_VirtualUnit_UserGroup_Link",
                schema: "psgm",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    VirtualUnitId = table.Column<Guid>(type: "uuid", nullable: true),
                    UserGroupId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File_VirtualUnit_UserGroup_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_File_VirtualUnit_UserGroup_Link_File_VirtualUnit_UserGroup_~",
                        column: x => x.UserGroupId,
                        principalSchema: "psgm",
                        principalTable: "File_VirtualUnit_UserGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_File_VirtualUnit_UserGroup_Link_File_VirtualUnit_VirtualUni~",
                        column: x => x.VirtualUnitId,
                        principalSchema: "psgm",
                        principalTable: "File_VirtualUnit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_File_RootDirectoryId",
                schema: "psgm",
                table: "File",
                column: "RootDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_File_SubDirectoryId",
                schema: "psgm",
                table: "File",
                column: "SubDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_File_Archive_Link_ArchiveId",
                schema: "psgm",
                table: "File_Archive_Link",
                column: "ArchiveId");

            migrationBuilder.CreateIndex(
                name: "IX_File_Archive_Link_FileId",
                schema: "psgm",
                table: "File_Archive_Link",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_File_Job_Link_FileId",
                schema: "psgm",
                table: "File_Job_Link",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_File_Job_Link_JobId",
                schema: "psgm",
                table: "File_Job_Link",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_File_Metadata_KeyId",
                schema: "psgm",
                table: "File_Metadata",
                column: "KeyId");

            migrationBuilder.CreateIndex(
                name: "IX_File_Metadata_Link_FileId",
                schema: "psgm",
                table: "File_Metadata_Link",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_File_Metadata_Link_MetadataId",
                schema: "psgm",
                table: "File_Metadata_Link",
                column: "MetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_File_QrCode_FileId",
                schema: "psgm",
                table: "File_QrCode",
                column: "FileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_File_Quality_FileId",
                schema: "psgm",
                table: "File_Quality",
                column: "FileId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_File_User_Link_FileId",
                schema: "psgm",
                table: "File_User_Link",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_File_User_Link_UserId",
                schema: "psgm",
                table: "File_User_Link",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_File_User_Notification_UserId",
                schema: "psgm",
                table: "File_User_Notification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_File_User_Permission_UserId",
                schema: "psgm",
                table: "File_User_Permission",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_File_UserGroup_Link_FileId",
                schema: "psgm",
                table: "File_UserGroup_Link",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_File_UserGroup_Link_UserGroupId",
                schema: "psgm",
                table: "File_UserGroup_Link",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_File_UserGroup_Notification_UserGroupId",
                schema: "psgm",
                table: "File_UserGroup_Notification",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_File_UserGroup_Permission_UserGroupId",
                schema: "psgm",
                table: "File_UserGroup_Permission",
                column: "UserGroupId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_File_UserGroup_User_Link_UserGroupId",
                schema: "psgm",
                table: "File_UserGroup_User_Link",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_File_UserGroup_User_Link_UserId",
                schema: "psgm",
                table: "File_UserGroup_User_Link",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_File_VirtualUnit_FileId",
                schema: "psgm",
                table: "File_VirtualUnit",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_File_VirtualUnit_User_Link_FileId",
                schema: "psgm",
                table: "File_VirtualUnit_User_Link",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_File_VirtualUnit_User_Link_UserId",
                schema: "psgm",
                table: "File_VirtualUnit_User_Link",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_File_VirtualUnit_User_Notification_UserId",
                schema: "psgm",
                table: "File_VirtualUnit_User_Notification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_File_VirtualUnit_User_Permission_UserId",
                schema: "psgm",
                table: "File_VirtualUnit_User_Permission",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_File_VirtualUnit_UserGroup_Link_UserGroupId",
                schema: "psgm",
                table: "File_VirtualUnit_UserGroup_Link",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_File_VirtualUnit_UserGroup_Link_VirtualUnitId",
                schema: "psgm",
                table: "File_VirtualUnit_UserGroup_Link",
                column: "VirtualUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_File_VirtualUnit_UserGroup_Notification_UserGroupId",
                schema: "psgm",
                table: "File_VirtualUnit_UserGroup_Notification",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_File_VirtualUnit_UserGroup_Permission_UserGroupId",
                schema: "psgm",
                table: "File_VirtualUnit_UserGroup_Permission",
                column: "UserGroupId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_File_VirtualUnit_UserGroup_User_Link_UserGroupId",
                schema: "psgm",
                table: "File_VirtualUnit_UserGroup_User_Link",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_File_VirtualUnit_UserGroup_User_Link_UserId",
                schema: "psgm",
                table: "File_VirtualUnit_UserGroup_User_Link",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_File_Workflow_Link_FileId",
                schema: "psgm",
                table: "File_Workflow_Link",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_File_Workflow_Link_WorkflowId",
                schema: "psgm",
                table: "File_Workflow_Link",
                column: "WorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_MetadataKey_User_Link_MetadataKeyId",
                schema: "psgm",
                table: "MetadataKey_User_Link",
                column: "MetadataKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_MetadataKey_User_Link_UserId",
                schema: "psgm",
                table: "MetadataKey_User_Link",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MetadataKey_User_Notification_UserId",
                schema: "psgm",
                table: "MetadataKey_User_Notification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MetadataKey_User_Permission_UserId",
                schema: "psgm",
                table: "MetadataKey_User_Permission",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MetadataKey_UserGroup_Link_MetadataKeyId",
                schema: "psgm",
                table: "MetadataKey_UserGroup_Link",
                column: "MetadataKeyId");

            migrationBuilder.CreateIndex(
                name: "IX_MetadataKey_UserGroup_Link_UserGroupId",
                schema: "psgm",
                table: "MetadataKey_UserGroup_Link",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_MetadataKey_UserGroup_Notification_UserGroupId",
                schema: "psgm",
                table: "MetadataKey_UserGroup_Notification",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_MetadataKey_UserGroup_Permission_UserGroupId",
                schema: "psgm",
                table: "MetadataKey_UserGroup_Permission",
                column: "UserGroupId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MetadataKey_UserGroup_User_Link_UserGroupId",
                schema: "psgm",
                table: "MetadataKey_UserGroup_User_Link",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_MetadataKey_UserGroup_User_Link_UserId",
                schema: "psgm",
                table: "MetadataKey_UserGroup_User_Link",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_Archive_Link_ArchiveId",
                schema: "psgm",
                table: "RootDirectory_Archive_Link",
                column: "ArchiveId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_Archive_Link_RootDirectoryId",
                schema: "psgm",
                table: "RootDirectory_Archive_Link",
                column: "RootDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_Job_Link_JobId",
                schema: "psgm",
                table: "RootDirectory_Job_Link",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_Job_Link_RootDirectoryId",
                schema: "psgm",
                table: "RootDirectory_Job_Link",
                column: "RootDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_Metadata_KeyId",
                schema: "psgm",
                table: "RootDirectory_Metadata",
                column: "KeyId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_Metadata_Link_MetadataId",
                schema: "psgm",
                table: "RootDirectory_Metadata_Link",
                column: "MetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_Metadata_Link_RootDirectoryId",
                schema: "psgm",
                table: "RootDirectory_Metadata_Link",
                column: "RootDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_QrCode_RootDirectoryId",
                schema: "psgm",
                table: "RootDirectory_QrCode",
                column: "RootDirectoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_Quality_RootDirectoryId",
                schema: "psgm",
                table: "RootDirectory_Quality",
                column: "RootDirectoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_User_Link_RootDirectoryId",
                schema: "psgm",
                table: "RootDirectory_User_Link",
                column: "RootDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_User_Link_UserId",
                schema: "psgm",
                table: "RootDirectory_User_Link",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_User_Notification_UserId",
                schema: "psgm",
                table: "RootDirectory_User_Notification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_User_Permission_UserId",
                schema: "psgm",
                table: "RootDirectory_User_Permission",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_UserGroup_Link_RootDirectoryId",
                schema: "psgm",
                table: "RootDirectory_UserGroup_Link",
                column: "RootDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_UserGroup_Link_UserGroupId",
                schema: "psgm",
                table: "RootDirectory_UserGroup_Link",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_UserGroup_Notification_UserGroupId",
                schema: "psgm",
                table: "RootDirectory_UserGroup_Notification",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_UserGroup_Permission_UserGroupId",
                schema: "psgm",
                table: "RootDirectory_UserGroup_Permission",
                column: "UserGroupId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_UserGroup_User_Link_UserGroupId",
                schema: "psgm",
                table: "RootDirectory_UserGroup_User_Link",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_UserGroup_User_Link_UserId",
                schema: "psgm",
                table: "RootDirectory_UserGroup_User_Link",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_VirtualUnit_RootDirectoryId",
                schema: "psgm",
                table: "RootDirectory_VirtualUnit",
                column: "RootDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_VirtualUnit_User_Link_FileId",
                schema: "psgm",
                table: "RootDirectory_VirtualUnit_User_Link",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_VirtualUnit_User_Link_UserId",
                schema: "psgm",
                table: "RootDirectory_VirtualUnit_User_Link",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_VirtualUnit_User_Notification_UserId",
                schema: "psgm",
                table: "RootDirectory_VirtualUnit_User_Notification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_VirtualUnit_User_Permission_UserId",
                schema: "psgm",
                table: "RootDirectory_VirtualUnit_User_Permission",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_VirtualUnit_UserGroup_Link_UserGroupId",
                schema: "psgm",
                table: "RootDirectory_VirtualUnit_UserGroup_Link",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_VirtualUnit_UserGroup_Link_VirtualUnitId",
                schema: "psgm",
                table: "RootDirectory_VirtualUnit_UserGroup_Link",
                column: "VirtualUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_VirtualUnit_UserGroup_Notification_UserGroupId",
                schema: "psgm",
                table: "RootDirectory_VirtualUnit_UserGroup_Notification",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_VirtualUnit_UserGroup_Permission_UserGroupId",
                schema: "psgm",
                table: "RootDirectory_VirtualUnit_UserGroup_Permission",
                column: "UserGroupId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_VirtualUnit_UserGroup_User_Link_UserGroupId",
                schema: "psgm",
                table: "RootDirectory_VirtualUnit_UserGroup_User_Link",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_VirtualUnit_UserGroup_User_Link_UserId",
                schema: "psgm",
                table: "RootDirectory_VirtualUnit_UserGroup_User_Link",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_Workflow_Link_RootDirectoryId",
                schema: "psgm",
                table: "RootDirectory_Workflow_Link",
                column: "RootDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RootDirectory_Workflow_Link_WorkflowId",
                schema: "psgm",
                table: "RootDirectory_Workflow_Link",
                column: "WorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_ParentSubDirectoryId",
                schema: "psgm",
                table: "SubDirectory",
                column: "ParentSubDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_RootDirectoryId",
                schema: "psgm",
                table: "SubDirectory",
                column: "RootDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_Archive_Link_ArchiveId",
                schema: "psgm",
                table: "SubDirectory_Archive_Link",
                column: "ArchiveId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_Archive_Link_SubDirectoryId",
                schema: "psgm",
                table: "SubDirectory_Archive_Link",
                column: "SubDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_Job_Link_JobId",
                schema: "psgm",
                table: "SubDirectory_Job_Link",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_Job_Link_SubDirectoryId",
                schema: "psgm",
                table: "SubDirectory_Job_Link",
                column: "SubDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_Metadata_KeyId",
                schema: "psgm",
                table: "SubDirectory_Metadata",
                column: "KeyId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_Metadata_Link_MetadataId",
                schema: "psgm",
                table: "SubDirectory_Metadata_Link",
                column: "MetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_Metadata_Link_SubDirectoryId",
                schema: "psgm",
                table: "SubDirectory_Metadata_Link",
                column: "SubDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_QrCode_SubDirectoryId",
                schema: "psgm",
                table: "SubDirectory_QrCode",
                column: "SubDirectoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_Quality_SubDirectoryId",
                schema: "psgm",
                table: "SubDirectory_Quality",
                column: "SubDirectoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_User_Link_SubDirectoryId",
                schema: "psgm",
                table: "SubDirectory_User_Link",
                column: "SubDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_User_Link_UserId",
                schema: "psgm",
                table: "SubDirectory_User_Link",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_User_Notification_UserId",
                schema: "psgm",
                table: "SubDirectory_User_Notification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_User_Permission_UserId",
                schema: "psgm",
                table: "SubDirectory_User_Permission",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_UserGroup_Link_SubDirectoryId",
                schema: "psgm",
                table: "SubDirectory_UserGroup_Link",
                column: "SubDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_UserGroup_Link_UserGroupId",
                schema: "psgm",
                table: "SubDirectory_UserGroup_Link",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_UserGroup_Notification_UserGroupId",
                schema: "psgm",
                table: "SubDirectory_UserGroup_Notification",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_UserGroup_Permission_UserGroupId",
                schema: "psgm",
                table: "SubDirectory_UserGroup_Permission",
                column: "UserGroupId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_UserGroup_User_Link_UserGroupId",
                schema: "psgm",
                table: "SubDirectory_UserGroup_User_Link",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_UserGroup_User_Link_UserId",
                schema: "psgm",
                table: "SubDirectory_UserGroup_User_Link",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_VirtualUnit_SubDirectoryId",
                schema: "psgm",
                table: "SubDirectory_VirtualUnit",
                column: "SubDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_VirtualUnit_User_Link_FileId",
                schema: "psgm",
                table: "SubDirectory_VirtualUnit_User_Link",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_VirtualUnit_User_Link_UserId",
                schema: "psgm",
                table: "SubDirectory_VirtualUnit_User_Link",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_VirtualUnit_User_Notification_UserId",
                schema: "psgm",
                table: "SubDirectory_VirtualUnit_User_Notification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_VirtualUnit_User_Permission_UserId",
                schema: "psgm",
                table: "SubDirectory_VirtualUnit_User_Permission",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_VirtualUnit_UserGroup_Link_UserGroupId",
                schema: "psgm",
                table: "SubDirectory_VirtualUnit_UserGroup_Link",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_VirtualUnit_UserGroup_Link_VirtualUnitId",
                schema: "psgm",
                table: "SubDirectory_VirtualUnit_UserGroup_Link",
                column: "VirtualUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_VirtualUnit_UserGroup_Notification_UserGroupId",
                schema: "psgm",
                table: "SubDirectory_VirtualUnit_UserGroup_Notification",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_VirtualUnit_UserGroup_Permission_UserGroupId",
                schema: "psgm",
                table: "SubDirectory_VirtualUnit_UserGroup_Permission",
                column: "UserGroupId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_VirtualUnit_UserGroup_User_Link_UserGroupId",
                schema: "psgm",
                table: "SubDirectory_VirtualUnit_UserGroup_User_Link",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_VirtualUnit_UserGroup_User_Link_UserId",
                schema: "psgm",
                table: "SubDirectory_VirtualUnit_UserGroup_User_Link",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_Workflow_Link_SubDirectoryId",
                schema: "psgm",
                table: "SubDirectory_Workflow_Link",
                column: "SubDirectoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubDirectory_Workflow_Link_WorkflowId",
                schema: "psgm",
                table: "SubDirectory_Workflow_Link",
                column: "WorkflowId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "File_Archive_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Archive_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Archive_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Job_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Job_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Job_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Metadata_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Metadata_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Metadata_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_QrCode",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_QrCode_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Quality",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Quality_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_User_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_User_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_User_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_User_Notification",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_User_Notification_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_User_Permission",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_User_Permission_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_UserGroup_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_UserGroup_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_UserGroup_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_UserGroup_Notification",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_UserGroup_Notification_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_UserGroup_Permission",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_UserGroup_Permission_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_UserGroup_User_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_UserGroup_User_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_UserGroup_User_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_VirtualUnit_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_VirtualUnit_User_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_VirtualUnit_User_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_VirtualUnit_User_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_VirtualUnit_User_Notification",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_VirtualUnit_User_Notification_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_VirtualUnit_User_Permission",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_VirtualUnit_User_Permission_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_VirtualUnit_UserGroup_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_VirtualUnit_UserGroup_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_VirtualUnit_UserGroup_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_VirtualUnit_UserGroup_Notification",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_VirtualUnit_UserGroup_Notification_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_VirtualUnit_UserGroup_Permission",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_VirtualUnit_UserGroup_Permission_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_VirtualUnit_UserGroup_User_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_VirtualUnit_UserGroup_User_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_VirtualUnit_UserGroup_User_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Workflow_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Workflow_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Workflow_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "MetadataKey_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "MetadataKey_User_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "MetadataKey_User_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "MetadataKey_User_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "MetadataKey_User_Notification",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "MetadataKey_User_Notification_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "MetadataKey_User_Permission",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "MetadataKey_User_Permission_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "MetadataKey_UserGroup_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "MetadataKey_UserGroup_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "MetadataKey_UserGroup_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "MetadataKey_UserGroup_Notification",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "MetadataKey_UserGroup_Notification_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "MetadataKey_UserGroup_Permission",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "MetadataKey_UserGroup_Permission_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "MetadataKey_UserGroup_User_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "MetadataKey_UserGroup_User_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "MetadataKey_UserGroup_User_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Archive_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Archive_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Archive_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Job_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Job_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Job_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Metadata_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Metadata_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Metadata_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_QrCode",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_QrCode_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Quality",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Quality_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_User_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_User_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_User_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_User_Notification",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_User_Notification_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_User_Permission",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_User_Permission_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_UserGroup_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_UserGroup_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_UserGroup_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_UserGroup_Notification",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_UserGroup_Notification_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_UserGroup_Permission",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_UserGroup_Permission_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_UserGroup_User_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_UserGroup_User_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_UserGroup_User_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_VirtualUnit_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_VirtualUnit_User_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_VirtualUnit_User_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_VirtualUnit_User_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_VirtualUnit_User_Notification",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_VirtualUnit_User_Notification_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_VirtualUnit_User_Permission",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_VirtualUnit_User_Permission_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_VirtualUnit_UserGroup_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_VirtualUnit_UserGroup_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_VirtualUnit_UserGroup_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_VirtualUnit_UserGroup_Notification",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_VirtualUnit_UserGroup_Notification_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_VirtualUnit_UserGroup_Permission",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_VirtualUnit_UserGroup_Permission_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_VirtualUnit_UserGroup_User_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_VirtualUnit_UserGroup_User_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_VirtualUnit_UserGroup_User_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Workflow_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Workflow_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Workflow_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Archive_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Archive_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Archive_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Job_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Job_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Job_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Metadata_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Metadata_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Metadata_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_QrCode",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_QrCode_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Quality",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_QualityAuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_User_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_User_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_User_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_User_Notification",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_User_Notification_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_User_Permission",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_User_Permission_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_UserGroup_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_UserGroup_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_UserGroup_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_UserGroup_Notification",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_UserGroup_Notification_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_UserGroup_Permission",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_UserGroup_Permission_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_UserGroup_User_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_UserGroup_User_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_UserGroup_User_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_VirtualUnit_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_VirtualUnit_User_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_VirtualUnit_User_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_VirtualUnit_User_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_VirtualUnit_User_Notification",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_VirtualUnit_User_Notification_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_VirtualUnit_User_Permission",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_VirtualUnit_User_Permission_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_VirtualUnit_UserGroup_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_VirtualUnit_UserGroup_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_VirtualUnit_UserGroup_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_VirtualUnit_UserGroup_Notification",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_VirtualUnit_UserGroup_Notification_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_VirtualUnit_UserGroup_Permission",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_VirtualUnit_UserGroup_Permission_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_VirtualUnit_UserGroup_User_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_VirtualUnit_UserGroup_User_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_VirtualUnit_UserGroup_User_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Workflow_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Workflow_Link",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Workflow_Link_AuditLog",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Archive",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Job",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Metadata",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_UserGroup",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_UserGroup_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_VirtualUnit_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_VirtualUnit",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_VirtualUnit_UserGroup",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_VirtualUnit_UserGroup_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File_Workflow",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "MetadataKey_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "MetadataKey_UserGroup",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "MetadataKey_UserGroup_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Archive",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Job",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Metadata",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_UserGroup",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_UserGroup_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_VirtualUnit_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_VirtualUnit",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_VirtualUnit_UserGroup",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_VirtualUnit_UserGroup_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory_Workflow",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Archive",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Job",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Metadata",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_UserGroup",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_UserGroup_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_VirtualUnit_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_VirtualUnit",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_VirtualUnit_UserGroup",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_VirtualUnit_UserGroup_User",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory_Workflow",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "File",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "MetadataKey",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "SubDirectory",
                schema: "psgm");

            migrationBuilder.DropTable(
                name: "RootDirectory",
                schema: "psgm");
        }
    }
}
