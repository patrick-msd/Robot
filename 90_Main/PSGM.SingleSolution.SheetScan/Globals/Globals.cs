﻿using PSGM.Helper;
using PSGM.Lib.Storage;
using PSGM.Model.DbBackend;
using PSGM.Model.DbJob;
using PSGM.Model.DbMachine;
using PSGM.Model.DbMain;
using PSGM.Model.DbSoftware;
using PSGM.Model.DbStorage;
using PSGM.Model.DbUser;
using Serilog.Sinks.Grafana.Loki;

namespace PSGM.SingleSolution.SheetScan
{
    public static class Globals
    {
        public static Guid ApplicationId { get; set; } = Guid.Empty;
        public static string? ApplicationPath { get; set; } = string.Empty;
        public static string? ApplicationTitle { get; set; } = string.Empty;
        public static Version? ApplicationVersion { get; set; } = null;

        public static List<LokiLabel>? LokiLabels { get; set; } = null;
        public static string? LokiUri { get; set; } = string.Empty;
        public static string? LokiOutputTemplate { get; set; } = string.Empty;

        public static Guid ComputerId { get; set; } = Guid.Empty;

        public static Guid MachineId { get; set; } = Guid.Empty;

        public static Guid OrganizationId { get; set; } = Guid.Empty;
        public static Guid UserId { get; set; } = Guid.Empty;

        public static Guid ProjectId { get; set; } = Guid.Empty;
        public static Guid DirectoryId { get; set; } = Guid.Empty;
        public static Guid UnitId { get; set; } = Guid.Empty;

        public static ConfigFile? ConfigFile { get; set; } = null;

        public static DbBackend_Context? DbBackend_Context { get; set; } = null;
        public static DbJob_Context? DbJob_Context { get; set; } = null;
        public static DbMachine_Context? DbMachine_Context { get; set; } = null;
        public static DbMain_Context? DbMain_Context { get; set; } = null;
        public static DbSoftware_Context? DbSoftware_Context { get; set; } = null;
        public static DbStorage_Context? DbStorageData_Context { get; set; } = null;
        public static DbStorage_Context? DbStorageDataRaw_Context { get; set; } = null;
        public static DbUser_Context? DbUser_Context { get; set; } = null;

        public static StorageClient? StorageMain { get; set; } = null;
        public static StorageClient? StorageDataRaw { get; set; } = null;
        public static StorageClient? StorageDataRawThumbnail { get; set; } = null;
        public static StorageClient? StorageData { get; set; } = null;
        public static StorageClient? StorageDataThumbnail { get; set; } = null;
        public static StorageClient? StorageTranscription { get; set; } = null;

        public static Globals_Machine? Machine { get; set; } = null;
    }
}
