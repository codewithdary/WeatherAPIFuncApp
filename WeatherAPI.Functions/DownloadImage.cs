using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace WeatherAPI.Functions
{
    public static class DownloadImage
    {
        [FunctionName("DownloadImage")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["file"];
            string responseMessage = "";

            string Connection = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
            string containerName = Environment.GetEnvironmentVariable("ContainerName");

            try
            {
                var containerClient = new BlobContainerClient(Connection, containerName);

                var blobClient = containerClient.GetBlobClient(name);

                var content = blobClient.DownloadContentAsync().Result;


                return new FileContentResult(content.Value.Content.ToArray(), "image/jpeg")
                {
                    FileDownloadName = name
                };
            }

            catch (Exception ex)
            {
                responseMessage = ex.Message;
                log.LogError($"Failed downloading  file from Blob Storage");
                log.LogError(ex, responseMessage);
                var model = new { error = responseMessage };
                return new ObjectResult(model)
                {
                    StatusCode = 500
                };
            }


        }
    }
}
