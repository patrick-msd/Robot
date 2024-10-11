using Minio.DataModel.Args;

namespace PSGM.Lib.Storage
{
    public partial class StorageClient
    {
        public async Task<bool> ExistsBucketAsync(BucketExistsArgs bucketExistsArgs)
        {
            return await _minioClient.BucketExistsAsync(bucketExistsArgs);
        }
    }
}
