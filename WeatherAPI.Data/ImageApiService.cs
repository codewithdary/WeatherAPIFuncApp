using Newtonsoft.Json;
using SixLabors.ImageSharp;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;


namespace WeatherAPI.Data
{
    public class ImageApiService
    {
        private static readonly HttpClient httpClient = new HttpClient();
        public static async Task<Image?> GetRandomImage()
        {


            string APIUrl = Environment.GetEnvironmentVariable("ImageAPIURL");

            using (var result = await httpClient.GetAsync(APIUrl))
            {
                if (result.IsSuccessStatusCode)
                {
                    var data = await result.Content.ReadAsStringAsync();
                    dynamic ImageData = JsonConvert.DeserializeObject(data);
                    var imgurl = ImageData.urls.small.ToString();

                    using (Stream stream = await httpClient.GetStreamAsync(imgurl))
                    {
                        var image = Image.Load(stream);
                        return image;

                    }

                }
            }

            return null;
        }


    }
}