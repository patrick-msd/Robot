using Minio;

namespace RC.Vision.SVSVistek.Sample
{
    public partial class Globals_Storage_S3
    {
        public string Endpoint { get; set; } = string.Empty;
        public string AccessKey { get; set; } = string.Empty;
        public string SecretKey { get; set; } = string.Empty;
        public bool Secure { get; set; } = false;
        public string Region { get; set; } = "eu-central-1";

        public string BucketName { get; set; } = string.Empty;

        public IMinioClient MinioClient { get; set; } = null;

        public void InitilizeMinIoClient()
        {
            MinioClient = new MinioClient().WithEndpoint(Endpoint).WithCredentials(AccessKey, SecretKey).WithSSL(Secure).Build();
        }
    }
}
