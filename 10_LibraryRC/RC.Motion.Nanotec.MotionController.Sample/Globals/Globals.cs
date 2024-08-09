using RC.Model;
using Serilog.Sinks.Grafana.Loki;
using System;
using System.Collections.Generic;

namespace RC.Motion.Nanotec.Sample
{
    public static class Globals
    {
        public static string? ApplicationPath { get; set; }

        public static string? ApplicationTitle { get; set; }
        public static Version? ApplicationVersion { get; set; }

        public static List<LokiLabel>? LokiLabels { get; set; } = null;
        public static string? LokiUri { get; set; } = string.Empty;
        public static string? LokiOutputTemplate { get; set; } = string.Empty;

        public static RcContext? Context { get; set; } = null;
        public static Globals_Device? Device { get; set; } = null;
    }
}
