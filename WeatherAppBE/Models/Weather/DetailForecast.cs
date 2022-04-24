using Newtonsoft.Json;

namespace WeatherAppBE.Models.Weather
{
    public class DetailForecast
    {
        public decimal Humidity { get; set; }
        public int Dt { get; set; }
        public decimal Pressure { get; set; }
        [JsonProperty("wind_speed")]
        public decimal WindSpeed { get; set; }
        public List<Weather> Weather { get; set; }
        
    }
}
