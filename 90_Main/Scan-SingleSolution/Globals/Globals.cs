using System;

namespace RC.Scan_SingleSolution
{
    public static partial class Globals
    {
        public static string? ApplicationPath { get; set; }
        public static string? ApplicationPathConfigFile { get; set; }

        public static string? ApplicationTitle { get; set; }
        public static Version? ApplicationVersion { get; set; }


        public static Globals_ConfigFile? ConfigFile { get; set; }
    }
}
