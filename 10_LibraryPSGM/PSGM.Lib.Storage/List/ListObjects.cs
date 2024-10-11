using Minio.DataModel.Args;
using Serilog;

namespace PSGM.Lib.Storage
{
    public partial class StorageClient
    {

        public async Task<List<string>> ListObjectsWithoutVersion(string bucketName = "my-bucket-name", string prefix = null, bool recursive = true)
        {
            List<string> list = new List<string>();

            try
            {
                var listArgs = new ListObjectsArgs().WithBucket(bucketName)
                                                    .WithPrefix(prefix)
                                                    .WithRecursive(recursive)
                                                    .WithVersions(false);

                await foreach (var item in _minioClient.ListObjectsEnumAsync(listArgs).ConfigureAwait(false))
                {
                    list.Add(item.Key);
#if DEBUG
                    Log.Debug($"Object: {item.Key}");
#endif
                }

#if DEBUG
                Log.Debug($"Listed all objects in bucket \"{bucketName}\"");
#endif
            }
            catch (Exception e)
            {
                Log.Error($"S3 List Objects without Versions -  Exception: {e}");
            }

            return list;
        }

        public async Task<List<Tuple<string, string>>> ListObjectsWithVersions(string bucketName = "my-bucket-name", string prefix = null, bool recursive = true)
        {
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();

            try
            {
                var listArgs = new ListObjectsArgs().WithBucket(bucketName)
                                                    .WithPrefix(prefix)
                                                    .WithRecursive(recursive)
                                                    .WithVersions(true);

                await foreach (var item in _minioClient.ListObjectsEnumAsync(listArgs).ConfigureAwait(false))
                {
                    list.Add(Tuple.Create(item.Key, item.VersionId));
#if DEBUG
                    Log.Debug($"Object: {item.Key}");
#endif
                }

#if DEBUG
                Log.Debug($"Listed all objects in bucket \"{bucketName}\"");
#endif
            }
            catch (Exception ex)
            {
                Log.Error($"S3 List Objects with Versions -  Exception: {ex}");
            }

            return list;
        }
    }
}
