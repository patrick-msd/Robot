using Minio;
using Minio.DataModel.Args;
using Serilog;

namespace PSGM.Helper
{
    public static class ListObjectsWithoutVersion
    {
        // List objects matching optional prefix in a specified bucket.
        public static async Task<List<string>> Run(IMinioClient minio, string bucketName = "my-bucket-name", string prefix = null, bool recursive = true)
        {
            List<string> list = new List<string>();

            try
            {
                var listArgs = new ListObjectsArgs().WithBucket(bucketName)
                                                    .WithPrefix(prefix)
                                                    .WithRecursive(recursive)
                                                    .WithVersions(false);

                await foreach (var item in minio.ListObjectsEnumAsync(listArgs).ConfigureAwait(false))
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
    }

    public static class ListObjectsWithVersions
    {
        // List objects matching optional prefix in a specified bucket.
        public static async Task<List<Tuple<string, string>>> Run(IMinioClient minio, string bucketName = "my-bucket-name", string prefix = null, bool recursive = true)
        {
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();

            try
            {
                var listArgs = new ListObjectsArgs().WithBucket(bucketName)
                                                    .WithPrefix(prefix)
                                                    .WithRecursive(recursive)
                                                    .WithVersions(true);

                await foreach (var item in minio.ListObjectsEnumAsync(listArgs).ConfigureAwait(false))
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
