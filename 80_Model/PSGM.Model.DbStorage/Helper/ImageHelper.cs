namespace PSGM.Model.DbStorage
{
    public class ImageHelper
    {
        public Guid FileId = Guid.Empty;
        public List<Guid>? FileRawIds = null;

        public double ExposureTime = 0L;
        public DateTime DateDigitized = DateTime.MinValue;

        public Guid CameraDeviceId = Guid.Empty;
    }
}
