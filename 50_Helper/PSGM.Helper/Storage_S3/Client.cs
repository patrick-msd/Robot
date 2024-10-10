using Minio;

namespace PSGM.Helper
{
    public partial class S3_Client
    {
        private string _endpoint = string.Empty;
        public string Endpoint { get { return _endpoint; } set { _endpoint = value; } }

        private string _accessKey = string.Empty;
        public string AccessKey { get { return _accessKey; } set { _accessKey = value; } }

        private string _secretKey = string.Empty;
        public string SecretKey { get { return _secretKey; } set { _secretKey = value; } }

        private bool _secure = false;
        public bool Secure { get { return _secure; } set { _secure = value; } }

        private string _region = "eu-central-1";
        public string Region { get { return _region; } set { _region = value; } }

        private string _bucketName = string.Empty;
        public string BucketName { get { return _bucketName; } set { _bucketName = value; } }

        private IMinioClient? _minioClient = null;
        public IMinioClient? MinioClient { get { return _minioClient; } set { _minioClient = value; } }

        public S3_Client(string Endpoint, string AccessKey, string SecretKey, bool Secure, string Region, string BucketName)
        {
            _endpoint = Endpoint;
            _accessKey = AccessKey;
            _secretKey = SecretKey;
            _secure = Secure;
            _region = Region;
            _bucketName = BucketName;
        }

        public void InitializeMinIoClient()
        {
            MinioClient = new MinioClient().WithEndpoint(Endpoint).WithCredentials(AccessKey, SecretKey).WithSSL(Secure).Build();
        }
    }
}
