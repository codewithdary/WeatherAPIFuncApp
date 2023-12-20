using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherAPI.Logic;


namespace WeatherAPI.Data
{
    public class WeatherApiService
    {
        private static readonly HttpClient httpClient = new HttpClient();
        public static async Task<WeatherData> GetWeatherData(ILogger log)
        {

            string APIUrl = Environment.GetEnvironmentVariable("WeatherAPIURL");
            using var result = await httpClient.GetAsync(APIUrl);
            if (result.IsSuccessStatusCode)
            {
                var data = await result.Content.ReadAsStringAsync();
                data = data.Replace("$id", "id");

                WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(data);

                return weatherData;


            }

            return null;

        }


    }
}