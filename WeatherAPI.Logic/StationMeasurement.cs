using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace WeatherAPI.Logic
{




    public class StationMeasurement
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonProperty("stationid", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("stationid")]
        public int Stationid { get; set; }

        [JsonProperty("stationname", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("stationname")]
        public string Stationname { get; set; }

        [JsonProperty("lat", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("lon")]
        public double Lon { get; set; }

        [JsonProperty("regio", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("regio")]
        public string Regio { get; set; }

        [JsonProperty("timestamp", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("weatherdescription", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("weatherdescription")]
        public string Weatherdescription { get; set; }

        [JsonProperty("iconurl", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("iconurl")]
        public string Iconurl { get; set; }

        [JsonProperty("fullIconUrl", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("fullIconUrl")]
        public string FullIconUrl { get; set; }

        [JsonProperty("graphUrl", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("graphUrl")]
        public string GraphUrl { get; set; }

        [JsonProperty("winddirection", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("winddirection")]
        public string Winddirection { get; set; }

        [JsonProperty("temperature", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("temperature")]
        public double Temperature { get; set; }

        [JsonProperty("groundtemperature", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("groundtemperature")]
        public double Groundtemperature { get; set; }

        [JsonProperty("feeltemperature", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("feeltemperature")]
        public double Feeltemperature { get; set; }

        [JsonProperty("windgusts", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("windgusts")]
        public double Windgusts { get; set; }

        [JsonProperty("windspeed", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("windspeed")]
        public double Windspeed { get; set; }

        [JsonProperty("windspeedBft", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("windspeedBft")]
        public int WindspeedBft { get; set; }

        [JsonProperty("humidity", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("humidity")]
        public double Humidity { get; set; }

        [JsonProperty("precipitation", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("precipitation")]
        public double Precipitation { get; set; }

        [JsonProperty("sunpower", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("sunpower")]
        public double Sunpower { get; set; }

        [JsonProperty("rainFallLast24Hour", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("rainFallLast24Hour")]
        public double RainFallLast24Hour { get; set; }

        [JsonProperty("rainFallLastHour", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("rainFallLastHour")]
        public double RainFallLastHour { get; set; }

        [JsonProperty("winddirectiondegrees", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("winddirectiondegrees")]
        public int Winddirectiondegrees { get; set; }

        [JsonProperty("airpressure", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("airpressure")]
        public double? Airpressure { get; set; }

        [JsonProperty("visibility", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("visibility")]
        public double? Visibility { get; set; }
    }


}
