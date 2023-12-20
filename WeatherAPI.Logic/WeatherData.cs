using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace WeatherAPI.Logic
{

    public class WeatherData
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonProperty("buienradar", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("buienradar")]
        public Buienradar Buienradar { get; set; }

        [JsonProperty("actual", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("actual")]
        public Actual Actual { get; set; }

        [JsonProperty("forecast", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("forecast")]
        public Forecast Forecast { get; set; }
    }




}
