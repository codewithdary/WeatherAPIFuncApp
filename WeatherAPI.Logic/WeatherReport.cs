using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;

namespace WeatherAPI.Logic
{


    public class WeatherReport
    {
        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonProperty("published", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("published")]
        public DateTime Published { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonProperty("summary", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("summary")]
        public string Summary { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonProperty("author", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonProperty("authorbio", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("authorbio")]
        public string Authorbio { get; set; }
    }




}
