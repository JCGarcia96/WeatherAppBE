using WeatherAppBE.Models.Geolocation;

namespace WeatherAppBE.Models.Weather
{
    public class Forecast
    {
        public CurrentWeather Current { get; set; }
        public List<DailyForecast> Daily { get; set; }
        public List<HourlyForecast> Hourly { get; set; }
        public Area Area { get; set; }
    }
}
