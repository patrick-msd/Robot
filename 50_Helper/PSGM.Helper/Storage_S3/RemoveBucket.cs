using Minio;
using Minio.DataModel.Args;
using Serilog;

namespace PSGM.Helper
{
    public static class RemoveBucket
    {
        // Remove a bucket
        public static async Task Run(IMinioClient minio, string bucketName = "my-bucket-name")
        {
            try
            {
                await minio.RemoveBucketAsync(new RemoveBucketArgs().WithBucket(bucketName)).ConfigureAwait(false);

#if DEBUG
                Log.Debug($"Removed the bucket \"{bucketName}\" successfully");
#endif
            }
            catch (Exception ex)
            {
                Log.Error($"S3 Remove Bucket -  Exception: {ex}");
            }
        }
    }
}
