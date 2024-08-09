using Minio;
using Minio.DataModel.Args;
using Serilog;

namespace PSGM.Helper
{
    public static class RemoveObject
    {
        // Remove an object from a bucket
        public static async Task Run(IMinioClient minio, string bucketName = "my-bucket-name", string objectName = "my-object-name", string versionId = null)
        {
            if (minio is null) throw new ArgumentNullException(nameof(minio));

            try
            {
                var args = new RemoveObjectArgs().WithBucket(bucketName)
                                                    .WithObject(objectName);
                var versions = "";

                if (!string.IsNullOrEmpty(versionId))
                {
                    args = args.WithVersionId(versionId);
                    versions = ", with version ID " + versionId + " ";
                }

                Console.WriteLine("Running example for API: RemoveObjectAsync");

                await minio.RemoveObjectAsync(args).ConfigureAwait(false);

                Console.WriteLine($"Removed object {objectName} from bucket {bucketName}{versions} successfully");
            }
            catch (Exception ex)
            {
                Log.Error($"S3 Remove Object -  Exception: {ex}");
            }
        }
    }
}
