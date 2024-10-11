using Minio.DataModel.Args;
using Serilog;

namespace PSGM.Lib.Storage
{
    public partial class StorageClient
    {
        public async Task RemoveObjectsWithoutVersions(string bucketName = "my-bucket-name", List<string> objectsList = null)
        {
            try
            {
                try
                {
                    var objArgs = new RemoveObjectsArgs().WithBucket(bucketName)
                                                            .WithObjects(objectsList);

                    foreach (var objDeleteError in await _minioClient.RemoveObjectsAsync(objArgs).ConfigureAwait(false))
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

        public async Task RemoveObjectsWithVersions(string bucketName = "my-bucket-name", List<Tuple<string, string>> objectsVersionsList = null)
        {
            try
            {
                try
                {
                    var objVersionsArgs = new RemoveObjectsArgs().WithBucket(bucketName)
                                                                    .WithObjectsVersions(objectsVersionsList);

                    foreach (var objVerDeleteError in await _minioClient.RemoveObjectsAsync(objVersionsArgs).ConfigureAwait(false))
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
