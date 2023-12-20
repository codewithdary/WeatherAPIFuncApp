using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace WeatherAPI.Logic
{


    public class LongTerm
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("$id")]
        public string Id { get; set; }

        [JsonProperty("startdate", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("startdate")]
        public DateTime Startdate { get; set; }

        [JsonProperty("enddate", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("enddate")]
        public DateTime Enddate { get; set; }

        [JsonProperty("forecast", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("forecast")]
        public string Forecast { get; set; }
    }


}
