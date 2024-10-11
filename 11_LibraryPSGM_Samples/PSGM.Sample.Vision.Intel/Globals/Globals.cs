using PSGM.Helper;
using PSGM.Model.DbBackend;
using PSGM.Model.DbMachine;
using PSGM.Model.DbMain;
using System;
using System.Collections.Generic;

namespace PSGM.Vision.Intel.Sample
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
        public static DbMachine_Context? DbMachine_Context { get; set; } = null;
        public static DbMain_Context? DbMain_Context { get; set; } = null;

        public static Globals_Machine? Machine { get; set; } = null;
    }
}
