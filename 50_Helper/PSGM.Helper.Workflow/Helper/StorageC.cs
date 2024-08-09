using Minio;

namespace PSGM.Helper.Workflow
{
    public class StorageConnector
    {
        public StorageClass StorageClass = StorageClass.Unknown;

        public string FilePath = string.Empty;

        public string ObjectBucket = string.Empty;

        public IMinioClient? MinioClient;
    }
}
