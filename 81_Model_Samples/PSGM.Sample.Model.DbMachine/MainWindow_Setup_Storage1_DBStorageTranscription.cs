using Microsoft.EntityFrameworkCore;
using Minio;
using Minio.DataModel;
using Minio.DataModel.Args;
using Minio.Exceptions;
using PSGM.Helper;
using PSGM.Model.DbBackend;
using System.Diagnostics;

namespace PSGM.Sample.Model.DbBackend
{
    public partial class MainWindow : System.Windows.Window
    {
        public async void Setup_Storage_DBStorageTranscription(DbBackend_Project projects)
        {
            IMinioClient minioClient;

            List<DbBackend_Storage_Cluster> clusters = _dbBackend_Context.Storage_Cluster.Where(p => p.Backend.Project.ProjectId_Ext == projects.ProjectId_Ext)
                                                                                .Include(p => p.StorageServers)
                                                                                .ToList();

            DbBackend_Storage_Cluster cluster = clusters.Where(p => p.StorageClass == StorageClass.DataTranscription).FirstOrDefault();

            minioClient = new MinioClient().WithEndpoint(cluster.GetStorageS3Endpoint(true))
                                            .WithCredentials(cluster.StorageS3AccessKey, cluster.StorageS3SecretKey)
                                            .WithSSL(cluster.StorageS3Secure)
                                            .WithRegion(cluster.StorageS3Region)
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
                            //Log.Information("Bucket: " + bucket.Name + " " + bucket.CreationDateDateTime);

                            List<Tuple<string, string>> objects1 = await ListObjectsWithVersions.Run(minioClient, bucket.Name, null, true);

                            RemoveObjectsWithVersions.Run(minioClient, bucket.Name, objects1).Wait();

                            List<Tuple<string, string>> objects2 = await ListObjectsWithVersions.Run(minioClient, bucket.Name, null, false);
                            RemoveObjectsWithVersions.Run(minioClient, bucket.Name, objects2).Wait();

                            List<string> objects3 = await ListObjectsWithoutVersion.Run(minioClient, bucket.Name, null, false);
                            RemoveObjectsWithoutVersions.Run(minioClient, bucket.Name, objects3).Wait();

                            RemoveBucket.Run(minioClient, bucket.Name).Wait();
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
                bool found = await minioClient.BucketExistsAsync(new BucketExistsArgs().WithBucket(projects.ProjectId_Ext.ToString()));

                if (found)
                {
                    Debug.WriteLine($"{projects.ProjectId_Ext.ToString()} already exists");
                }
                else
                {
                    await MakeBucket.Run(minioClient, projects.ProjectId_Ext.ToString(), cluster.StorageS3Region);
                }
            }
            catch (MinioException ex)
            {
                Debug.WriteLine("Error occurred: " + ex);
            }
            #endregion
        }
    }
}
