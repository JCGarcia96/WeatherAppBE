using Newtonsoft.Json;

namespace WeatherAppBE.Models.Geolocation
{
    public class ZipCode : Area
    {
        [JsonProperty("zip")]
        public string _ZipCode { get; set; }
    }
}
