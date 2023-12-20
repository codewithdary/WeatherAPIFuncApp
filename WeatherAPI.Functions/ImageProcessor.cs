using Azure.Data.Tables;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherAPI.Data;
using WeatherAPI.Logic;

namespace WeatherAPI.Functions
{
    public class ImageProcessor
{
    private TableClient _tableClient;

   

    [FunctionName("ImageProcessor")]
    public async Task Run(
        [QueueTrigger("imagequeue")] string queueMessage,
        ILogger log)
    {
        string Connection = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
        

        try
        {
            var imageQueues = JsonConvert.DeserializeObject<List<ImageQueue>>(queueMessage);

            var tableServiceClient = new TableServiceClient(Connection);
            await tableServiceClient.CreateTableIfNotExistsAsync("imagequeue");
            _tableClient = tableServiceClient.GetTableClient("imagequeue");


            // Add all records to Azure Table with status "Pending"
            await AddEntitiesToTable(imageQueues);

            // Process records one by one
            foreach (var q in imageQueues)
            {
                try
                {
                    // Retrieve the Azure Table entity
                    var tableEntity = await RetrieveEntityFromTable(q.GUID);

                    // Set the status to "Processing" before processing the image
                    tableEntity.Status = "Processing";
                    await UpdateStatusInTable(tableEntity);

                    // Process the image
                    Image image = ImageApiService.GetRandomImage().Result;
                    var imageStream = ImagingService.GenerateImage(image, q.Measurement).Result;
                    imageStream.Position = 0;
                    BlobStorageService.UploadBlob(imageStream, q.GUID + ".jpg");
                    imageStream.Dispose();

                    // Update the status in Azure Table to "Complete"
                    tableEntity.Status = "Complete";
                    await UpdateStatusInTable(tableEntity);
                }
                catch (Exception ex)
                {
                    log.LogInformation($"Error processing image {q.GUID}: {ex.Message}");

                    // Update the status in Azure Table to "Error"
                    var errorEntity = await RetrieveEntityFromTable(q.GUID);
                    errorEntity.Status = "Error";
                    await UpdateStatusInTable(errorEntity);
                }
            }
        }
        catch (Exception ex)
        {
            log.LogInformation($"Error processing queue message: {ex.Message}");
        }

        log.LogInformation($"C# Queue trigger function processed: {queueMessage}");
    }

    private async Task AddEntitiesToTable(List<ImageQueue> imageQueues)
    {
        foreach (var q in imageQueues)
        {
            var entity = new ImageProcessEntity
            {
                PartitionKey = "ImageProcessPartition",
                RowKey = q.GUID,
                Status = "Pending",
                // Add other properties as needed
            };

            await _tableClient.AddEntityAsync(entity);
        }
    }

    private async Task<ImageProcessEntity> RetrieveEntityFromTable(string rowKey)
    {
        var response = await _tableClient.GetEntityAsync<ImageProcessEntity>("ImageProcessPartition", rowKey);
        return response?.Value;
    }

    private async Task UpdateStatusInTable(ImageProcessEntity entity)
    {
        await _tableClient.UpsertEntityAsync(entity);
    }
}


}
