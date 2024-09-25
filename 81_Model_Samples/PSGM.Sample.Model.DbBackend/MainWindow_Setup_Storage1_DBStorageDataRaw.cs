using Minio;
using Minio.DataModel.Args;
using Minio.Exceptions;
using PSGM.Helper;
using PSGM.Model.DbBackend;
using System.Diagnostics;

namespace PSGM.Sample.Model.DbBackend
{
    public partial class MainWindow : System.Windows.Window
    {
        public async void Setup_Storage_DBStorageDataRaw(DbBackend_Project projects)
        {
            IMinioClient minioClient;

            //DbBackend_Backend? structure = projects.Cluster.Where(p => p.StorageClass == StorageClass.DataRaw).FirstOrDefault();

            //minioClient = new MinioClient().WithEndpoint(structure.GetStorageS3Endpoint(true))
            //                                .WithCredentials(structure.StorageS3AccessKey, structure.StorageS3SecretKey)
            //                                .WithSSL(structure.StorageS3Secure)
            //                                .WithRegion(structure.StorageS3Region)
            //                                .Build();

            //#region List and remove all buckets
            //try
            //{
            //    var list = await minioClient.ListBucketsAsync();

            //    if (list.Buckets is not null)
            //    {
            //        if (list.Buckets.Count > 0)
            //        {
            //            foreach (Bucket bucket in list.Buckets)
            //            {
            //                //Log.Information("Bucket: " + bucket.Name + " " + bucket.CreationDateDateTime);

            //                List<Tuple<string, string>> objects1 = await ListObjectsWithVersions.Run(minioClient, bucket.Name, null, true);

            //                RemoveObjectsWithVersions.Run(minioClient, bucket.Name, objects1).Wait();

            //                List<Tuple<string, string>> objects2 = await ListObjectsWithVersions.Run(minioClient, bucket.Name, null, false);
            //                RemoveObjectsWithVersions.Run(minioClient, bucket.Name, objects2).Wait();

            //                List<string> objects3 = await ListObjectsWithoutVersion.Run(minioClient, bucket.Name, null, false);
            //                RemoveObjectsWithoutVersions.Run(minioClient, bucket.Name, objects3).Wait();

            //                RemoveBucket.Run(minioClient, bucket.Name).Wait();
            //            }
            //        }
            //    }
            //}
            //catch (MinioException ex)
            //{
            //    Debug.WriteLine("Error occurred: " + ex);
            //}
            //#endregion

            //#region Add project bucket
            //try
            //{
            //    bool found = await minioClient.BucketExistsAsync(new BucketExistsArgs().WithBucket(structure.ProjectId.ToString()));

            //    if (found)
            //    {
            //        Debug.WriteLine($"{structure.ProjectId.ToString()} already exists");
            //    }
            //    else
            //    {
            //        await MakeBucket.Run(minioClient, structure.ProjectId.ToString(), structure.StorageS3Region);
            //    }
            //}
            //catch (MinioException ex)
            //{
            //    Debug.WriteLine("Error occurred: " + ex);
            //}
            //#endregion
        }
    }
}
