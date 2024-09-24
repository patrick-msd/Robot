using Minio.DataModel.Args;
using Minio.DataModel;
using Minio.Exceptions;
using Minio;
using PSGM.Helper;
using PSGM.Model.DbBackendStructure;
using System.Diagnostics;
using System.Drawing;
using System.Net;

namespace PSGM.Sample.Model.DbBackendStructure
{
    public partial class MainWindow : System.Windows.Window
    {
        public void Setup_Storage_DBStorageData(DbBackendStructure_Project projects)
        {
            #region DBStorageDataThumbnail
            config = projects[0].ProjectParameter.Storages.Where(p => p.StorageClass == StorageClass.DataThumbnail).FirstOrDefault();
            bucketName = projects[0].Id.ToString();

            endpoint = config.StorageS3Endpoint;
            accessKey = config.StorageS3AccessKey;
            secretKey = config.StorageS3SecretKey;
            secure = config.StorageS3Secure;
            region = config.StorageS3Region;

            //bucketName = string.Empty;
            //objectName = string.Empty;

            filePath = string.Empty;
            contentType = string.Empty;

            // Initialize the client with access credentials.
            minioClient = new MinioClient().WithEndpoint(endpoint)
                                            .WithCredentials(accessKey, secretKey)
            .WithSSL(secure)
                                            .WithRegion(region)
                                            .Build();

            #region List and remove all buckets
            try
            {
                var list = await minioClient.ListBucketsAsync();

                if (list.Buckets is not null)
                {
                    if (list.Buckets.Count > 0)
                    {
                        foreach (Bucket bucket in list.Buckets)
                        {
                            Log.Information("Bucket: " + bucket.Name + " " + bucket.CreationDateDateTime);

                            List<Tuple<string, string>> objects1 = await PSGM.Helper.ListObjectsWithVersions.Run(minioClient, bucket.Name, null, true);

                            PSGM.Helper.RemoveObjectsWithVersions.Run(minioClient, bucket.Name, objects1).Wait();

                            List<Tuple<string, string>> objects2 = await PSGM.Helper.ListObjectsWithVersions.Run(minioClient, bucket.Name, null, false);
                            PSGM.Helper.RemoveObjectsWithVersions.Run(minioClient, bucket.Name, objects2).Wait();

                            List<string> objects3 = await PSGM.Helper.ListObjectsWithoutVersion.Run(minioClient, bucket.Name, null, false);
                            PSGM.Helper.RemoveObjectsWithoutVersions.Run(minioClient, bucket.Name, objects3).Wait();

                            PSGM.Helper.RemoveBucket.Run(minioClient, bucket.Name).Wait();
                        }
                    }
                }
            }
            catch (MinioException ex)
            {
                Debug.WriteLine("Error occurred: " + ex);
            }
            #endregion

            #region Add project bucket
            try
            {
                bool found = await minioClient.BucketExistsAsync(new BucketExistsArgs().WithBucket(bucketName));

                if (found)
                {
                    Debug.WriteLine($"{bucketName} already exists");
                }
                else
                {
                    await PSGM.Helper.MakeBucket.Run(minioClient, bucketName, region);
                }
            }
            catch (MinioException ex)
            {
                Debug.WriteLine("Error occurred: " + ex);
            }
            #endregion
            #endregion
        }
    }
}
