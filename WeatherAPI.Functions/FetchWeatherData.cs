using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAPI.Data;
using WeatherAPI.Logic;

namespace WeatherAPI.Functions
{
    public static class FetchWeatherData
{
    private static readonly string UserName = Environment.GetEnvironmentVariable("APIUsername");
    private static readonly string Password = Environment.GetEnvironmentVariable("APIPassword");

    [FunctionName("FetchWeatherData")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
        [Queue("imagequeue", Connection = "AzureWebJobsStorage")] ICollector<string> msg,
        ILogger log)
    {
        log.LogInformation("C# HTTP trigger function processed a request.");

        // Check for basic authentication
        if (!IsAuthorized(req))
        {
            return new UnauthorizedResult();
        }

        try
        {
            var weatherData = await WeatherApiService.GetWeatherData(log);

            var queues = new List<ImageQueue>();

            await Task.WhenAll(weatherData.Actual.Stationmeasurements.Select(async measure =>
            {
                queues.Add(new ImageQueue
                {
                    GUID = Guid.NewGuid().ToString(),
                    Measurement = measure,
                });
            }));

            msg.Add(JsonConvert.SerializeObject(queues));

            return (ActionResult)new OkObjectResult($"{JsonConvert.SerializeObject(queues.Select(q => q.GUID).ToList())}");
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult(ex.Message);
        }
    }

    private static bool IsAuthorized(HttpRequest req)
    {
        string authHeader = req.Headers["Authorization"];

        if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Basic "))
        {
            string encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
            Encoding encoding = Encoding.GetEncoding("iso-8859-1");
            string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));

            int separatorIndex = usernamePassword.IndexOf(':');

            string username = usernamePassword.Substring(0, separatorIndex);
            string password = usernamePassword.Substring(separatorIndex + 1);

            return username == UserName && password == Password;
        }

        return false;
    }
}


}
