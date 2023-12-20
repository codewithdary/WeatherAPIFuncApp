using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WeatherAPI.Logic
{

    public class Actual
    {
        [JsonProperty("$id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("$id")]
        public string Id { get; set; }

        [JsonProperty("actualradarurl", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("actualradarurl")]
        public string Actualradarurl { get; set; }

        [JsonProperty("sunrise", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("sunrise")]
        public DateTime Sunrise { get; set; }

        [JsonProperty("sunset", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("sunset")]
        public DateTime Sunset { get; set; }

        [JsonProperty("stationmeasurements", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("stationmeasurements")]
        public List<StationMeasurement> Stationmeasurements { get; set; }
    }




}
