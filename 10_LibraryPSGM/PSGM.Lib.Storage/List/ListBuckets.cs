using Minio.DataModel.Result;
using Serilog;

namespace PSGM.Lib.Storage
{
    public partial class StorageClient
    {
        public async Task<ListAllMyBucketsResult> ListBucketsAsync()
        {
            //try
            //{
                if (_minioClient is not null)
                {
                    return await _minioClient.ListBucketsAsync();
                }
                else
                {
                    throw new Exception("MinIO Client is not initialized");
                }
            //}
            //catch (Exception ex)
            //{
            //    Log.Error($"S3 List Buckets -  Exception: {ex}");
            //}
        }
    }
}
