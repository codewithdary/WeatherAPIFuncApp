using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace WeatherAPI.Logic
{

    public class FivedayForecast
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("$id")]
        public string Id { get; set; }

        [JsonProperty("day", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("day")]
        public DateTime Day { get; set; }

        [JsonProperty("mintemperature", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("mintemperature")]
        public string Mintemperature { get; set; }

        [JsonProperty("maxtemperature", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("maxtemperature")]
        public string Maxtemperature { get; set; }

        [JsonProperty("mintemperatureMax", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("mintemperatureMax")]
        public int MintemperatureMax { get; set; }

        [JsonProperty("mintemperatureMin", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("mintemperatureMin")]
        public int MintemperatureMin { get; set; }

        [JsonProperty("maxtemperatureMax", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("maxtemperatureMax")]
        public int MaxtemperatureMax { get; set; }

        [JsonProperty("maxtemperatureMin", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("maxtemperatureMin")]
        public int MaxtemperatureMin { get; set; }

        [JsonProperty("rainChance", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("rainChance")]
        public int RainChance { get; set; }

        [JsonProperty("sunChance", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("sunChance")]
        public int SunChance { get; set; }

        [JsonProperty("windDirection", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("windDirection")]
        public string WindDirection { get; set; }

        [JsonProperty("wind", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("wind")]
        public int Wind { get; set; }

        [JsonProperty("mmRainMin", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("mmRainMin")]
        public double MmRainMin { get; set; }

        [JsonProperty("mmRainMax", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("mmRainMax")]
        public double MmRainMax { get; set; }

        [JsonProperty("weatherdescription", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("weatherdescription")]
        public string Weatherdescription { get; set; }

        [JsonProperty("iconurl", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("iconurl")]
        public string Iconurl { get; set; }

        [JsonProperty("fullIconUrl", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("fullIconUrl")]
        public string FullIconUrl { get; set; }
    }


}
