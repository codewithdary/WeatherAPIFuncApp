using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WeatherAPI.Logic
{

    public class Forecast
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("$id")]
        public string Id { get; set; }

        [JsonProperty("weatherreport", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("weatherreport")]
        public WeatherReport Weatherreport { get; set; }

        [JsonProperty("shortterm", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("shortterm")]
        public ShortTerm Shortterm { get; set; }

        [JsonProperty("longterm", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("longterm")]
        public LongTerm Longterm { get; set; }

        [JsonProperty("fivedayforecast", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("fivedayforecast")]
        public List<FivedayForecast> Fivedayforecast { get; set; }
    }


}
