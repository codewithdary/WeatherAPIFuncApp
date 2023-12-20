using Azure.Storage.Blobs;
using System;
using System.IO;
using System.Threading.Tasks;



namespace WeatherAPI.Data
{

    public class BlobStorageService
    {


        public static void UploadBlob(Stream myBlob, string fileName)

        {

            string Connection = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
            string containerName = Environment.GetEnvironmentVariable("ContainerName");

            var blobClient = new BlobContainerClient(Connection, containerName);
            var blob = blobClient.GetBlobClient(fileName);
            blob.UploadAsync(myBlob, overwrite: true).Wait();
            var url = blob.Uri;


        }


    }
}