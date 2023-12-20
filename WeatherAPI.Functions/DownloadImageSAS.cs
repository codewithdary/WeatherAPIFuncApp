using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherAPI.Functions
{
    public static class DownloadImageSAS
    {
        private static readonly HttpClient httpClient = new HttpClient();
        
        [FunctionName("DownloadImageSAS")]
        public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
        ILogger log)
    {
        log.LogInformation("C# HTTP trigger function processed a request.");

        string name = req.Query["file"];
        string sasToken = req.Query["token"]; // Parameter for SAS token
        string responseMessage = "";

        try
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(sasToken))
            {
                // Handle missing parameters
                responseMessage = "Missing required parameters.";
                log.LogError(responseMessage);
                return new BadRequestObjectResult(new { error = responseMessage });
            }

            // Create the Blob URI with SAS token
            var blobUri = new Uri($"{Environment.GetEnvironmentVariable("BlobBaseUrl")}/{Environment.GetEnvironmentVariable("ContainerName")}/{name}?{sasToken}");

            // Download the blob content
            using (var httpClient = new HttpClient())
            {
                var content = await httpClient.GetByteArrayAsync(blobUri);
                
                // Return the file content as a response
                return new FileContentResult(content, "image/jpeg")
                {
                    FileDownloadName = name
                };
            }
        }
        catch (Exception ex)
        {
            responseMessage = ex.Message;
            log.LogError($"Failed downloading file from Blob Storage");
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
