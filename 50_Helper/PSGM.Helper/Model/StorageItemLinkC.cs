using OpenCvSharp;

namespace PSGM.Helper
{
    public class ConfigurationSaveImageV1_0_0
    {
        public int Quality { get; set; } = 100;

        public int ThumbnailWidth { get; set; } = 0;

        public int ThumbnailHeight { get; set; } = 0;

        public int ThumbnailQuality { get; set; } = 90;
    }

    public class ConfigurationResizeV1_0_0
    {
        public int Width { get; set; } = 0;

        public int Height { get; set; } = 0;
    }

    public class ConfigurationDarktableV1_0_0
    {
        public Guid CameraId { get; set; } = Guid.NewGuid();

        public string DarktableExecutePath { get; set; } = string.Empty;

        public string DarktableExecuteArgumetns { get; set; } = string.Empty;

        public string DarktableSidecarFile { get; set; } = string.Empty;
    }

    public class ConfigurationCropV1_0_0
    {
        public Guid CameraId { get; set; } = Guid.NewGuid();

        // Width
        public int RowStart { get; set; } = 0;

        public int RowEnd { get; set; } = 0;

        // Height
        public int ColumnStart { get; set; } = 0;

        public int ColumnEnd { get; set; } = 0;
    }

    public class ConfigurationRotateV1_0_0
    {
        public Guid CameraId { get; set; } = Guid.NewGuid();

        public RotateFlags Rotate { get; set; } = 0;
    }

    public class ConfigurationRotateV2_0_0
    {
        public Guid CameraId { get; set; } = Guid.NewGuid();

        public double angle { get; set; } = 0;
    }

    public class ConfigurationSharpenV1_0_0
    {
        public Guid CameraId { get; set; } = Guid.NewGuid();

        public float[,] Filter { get; set; }

        MatType MatType { get; set; } = MatType.CV_8UC3;
    }

    public class ConfigurationSharpenV2_0_0
    {
        public Guid CameraId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// SigmaS: Controls how much the image is smoothed - the larger its value,
        /// the more smoothed the image gets, but it's also slower to compute.
        /// </summary>
        public float SigmaS { get; set; } = 0;

        /// <summary>
        /// SigmaR: Ss important if you want to preserve edges while smoothing the image.
        /// Small sigma_r results in only very similar colors to be averaged(i.e.smoothed), while colors that differ much will stay intact.
        /// </summary>
        public float SigmaR { get; set; } = 0;
    }
}
