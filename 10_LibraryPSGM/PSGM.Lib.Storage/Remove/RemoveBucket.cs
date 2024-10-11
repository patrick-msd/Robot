using Minio.DataModel.Args;
using Serilog;

namespace PSGM.Lib.Storage
{
    public partial class StorageClient
    {
        public async Task RemoveBucket(string bucketName = "my-bucket-name")
        {
            try
            {
                await _minioClient.RemoveBucketAsync(new RemoveBucketArgs().WithBucket(bucketName)).ConfigureAwait(false);

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
