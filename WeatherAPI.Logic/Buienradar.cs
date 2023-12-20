using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace WeatherAPI.Logic
{

    public class Buienradar
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("$id")]
        public string Id { get; set; }

        [JsonProperty("copyright", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("copyright")]
        public string Copyright { get; set; }

        [JsonProperty("terms", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("terms")]
        public string Terms { get; set; }
    }


}
