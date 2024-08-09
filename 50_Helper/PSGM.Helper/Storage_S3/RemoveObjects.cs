using Minio;
using Minio.DataModel.Args;
using Serilog;

namespace PSGM.Helper
{
    public static class RemoveObjectsWithoutVersions
    {
        // Remove a list of objects from a bucket
        public static async Task Run(IMinioClient minio, string bucketName = "my-bucket-name", List<string> objectsList = null)
        {
            try
            {
                try
                {
                    var objArgs = new RemoveObjectsArgs().WithBucket(bucketName)
                                                            .WithObjects(objectsList);

                    foreach (var objDeleteError in await minio.RemoveObjectsAsync(objArgs).ConfigureAwait(false))
                    {
#if DEBUG
                        Log.Debug($"Object: {objDeleteError.Key}");
#endif
                    }
                }
                catch (Exception ex)
                {
                    Log.Error($"OnError: {ex}");
                }

#if DEBUG
                Log.Debug($"Removed objects in list from \"{bucketName}\"");
#endif
            }
            catch (Exception ex)
            {
                Log.Error($"S3 Remove Objects -  Exception: {ex}");
            }
        }
    }

    public static class RemoveObjectsWithVersions
    {
        // Remove a list of objects from a bucket
        public static async Task Run(IMinioClient minio, string bucketName = "my-bucket-name", List<Tuple<string, string>> objectsVersionsList = null)
        {
            try
            {
                try
                {
                    var objVersionsArgs = new RemoveObjectsArgs().WithBucket(bucketName)
                                                                    .WithObjectsVersions(objectsVersionsList);

                    foreach (var objVerDeleteError in await minio.RemoveObjectsAsync(objVersionsArgs).ConfigureAwait(false))
                    {
#if DEBUG
                        Log.Error($"Object: {objVerDeleteError.Key} Object Version: {objVerDeleteError.VersionId}");
#endif
                    }
                }
                catch (Exception ex)
                {
                    Log.Error($"OnError: {ex}");
                }

#if DEBUG
                Log.Debug($"Removed objects versions in list from \"{bucketName}\"");
#endif
            }
            catch (Exception ex)
            {
                Log.Error($"S3 Remove Objects with Version -  Exception: {ex}");
            }
        }
    }
}
