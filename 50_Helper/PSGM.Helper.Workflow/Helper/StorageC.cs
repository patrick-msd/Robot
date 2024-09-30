using Minio;

namespace PSGM.Helper.Workflow
{
    public class StorageConnector
    {
        public StorageClass StorageClass = StorageClass.Undefined;

        public string FilePath = string.Empty;

        public string ObjectBucket = string.Empty;

        public IMinioClient? MinioClient;
    }
}
