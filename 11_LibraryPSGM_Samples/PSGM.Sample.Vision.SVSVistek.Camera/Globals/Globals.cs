using Serilog.Sinks.Grafana.Loki;
using System;
using System.Collections.Generic;

namespace RC.Vision.SVSVistek.Sample
{
    public static class Globals
    {
        public static string? ApplicationPath { get; set; } = string.Empty;

        public static string? ApplicationTitle { get; set; } = string.Empty;
        public static Version? ApplicationVersion { get; set; } = null;

        public static List<LokiLabel>? LokiLabels { get; set; } = null;
        public static string? LokiUri { get; set; } = string.Empty;
        public static string? LokiOutputTemplate { get; set; } = string.Empty;

        public static PSGM.Model.DbMachine.DbMachine_Context? DbMachine_Context { get; set; } = null;
        public static PSGM.Model.DbMain.DbMain_Context? DbMain_Context { get; set; } = null;
        public static PSGM.Model.DbSoftware.DbSoftware_Context? DbSoftware_Context { get; set; } = null;
        public static PSGM.Model.DbStorage.DbStorage_Context? DbStorage_Context { get; set; } = null;
        public static PSGM.Model.DbStorage.DbStorage_Context? DbStorageRaw_Context { get; set; } = null;
        public static PSGM.Model.DbUser.DbUser_Context? DbUser_Context { get; set; } = null;
        public static PSGM.Model.DbWorkflow.DbWorkflow_Context? DbWorkflow_Context { get; set; } = null;

        public static Globals_Storage? Storage { get; set; } = null;

        public static Globals_Machine? Machine { get; set; } = null;
    }
}
