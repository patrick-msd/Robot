using Minio;
using Minio.DataModel.Args;
using Serilog;

namespace PSGM.Helper
{
    public static class MakeBucket
    {
        // Make a bucket
        public static async Task Run(IMinioClient minio, string bucketName = "my-bucket-name", string loc = "us-east-1")
        {
            try
            {
                await minio.MakeBucketAsync(new MakeBucketArgs().WithBucket(bucketName).WithLocation(loc)).ConfigureAwait(false);

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
