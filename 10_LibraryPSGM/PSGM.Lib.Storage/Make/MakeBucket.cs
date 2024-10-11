using Minio.DataModel.Args;
using Serilog;

namespace PSGM.Lib.Storage
{
    public partial class StorageClient
    {
        public async Task MakeBucket(string bucketName = "my-bucket-name", string loc = "us-east-1")
        {
            try
            {
                await _minioClient.MakeBucketAsync(new MakeBucketArgs().WithBucket(bucketName).WithLocation(loc));

#if DEBUG
                Log.Debug($"Created the bucket \"{bucketName}\" successfully");
#endif
            }
            catch (Exception ex)
            {
                Log.Error($"S3 Make Bucket -  Exception: {ex}");
            }
        }
    }
}
