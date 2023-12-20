using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Storage.Table;
using WeatherAPI.Logic;
using Azure.Data.Tables;

namespace WeatherAPI.Functions
{
    

public static class GetStatus
{
    private static readonly string TableName = "imagequeue";

    [FunctionName("GetStatus")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
        ILogger log)
        
    {
       

         string Connection = Environment.GetEnvironmentVariable("AzureWebJobsStorage");

        log.LogInformation("C# HTTP trigger function processed a request.");

        string rowKey = req.Query["rowKey"];
        if (string.IsNullOrEmpty(rowKey))
        {
            return new BadRequestObjectResult("RowKey is required in the query string.");
        }

        try
        {
            
            var tableServiceClient = new TableServiceClient(Connection);
            var tableClient = tableServiceClient.GetTableClient(TableName);

            // Retrieve the Azure Table entity using the provided RowKey
            var tableEntity = await RetrieveEntityFromTable(tableClient, rowKey);

            if (tableEntity != null)
            {
                return new OkObjectResult($"Status for RowKey {rowKey}: {tableEntity.Status}");
            }
            else
            {
                return new NotFoundObjectResult($"No entity found in the table for RowKey {rowKey}");
            }
        }
        catch (Exception ex)
        {
            log.LogError($"Error retrieving status for RowKey {rowKey}: {ex.Message}");
            return new StatusCodeResult(500); // Internal Server Error
        }
    }

    

    private static async Task<ImageProcessEntity> RetrieveEntityFromTable(TableClient _tableClient,string rowKey)
    {
        var response = await _tableClient.GetEntityAsync<ImageProcessEntity>("ImageProcessPartition", rowKey);
        return response?.Value;
    }
}


}
