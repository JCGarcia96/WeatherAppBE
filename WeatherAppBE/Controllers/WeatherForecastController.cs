using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeatherAppBE.Models;
using WeatherAppBE.Models.Weather;

namespace WeatherAppBE.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        public IConfiguration _configuration;
        public string WeatherApiUrl;
        public string WeatherApiKey;
        public WeatherForecastController(IConfiguration configuration)
        {
            _configuration = configuration;
            WeatherApiUrl = _configuration.GetSection("OpenWeather").GetSection("UrlWeatherApi").Value;
            WeatherApiKey = _configuration.GetSection("OpenWeather").GetSection("ApiKey").Value;

        }
        [HttpPost]
        public async Task<IActionResult> GetWeatherByArea(LatLng latLng)
        {
            try
            {
                var resp = new HttpResponseMessage();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(WeatherApiUrl);
                    var apiCall = $"onecall?lat={latLng.Lat}&lon={latLng.Lng}&units=metric&appid={WeatherApiKey}";
                    HttpResponseMessage Res = await client.GetAsync(apiCall);
                    var result = "";
                    if (Res.IsSuccessStatusCode)
                    {
                        result = Res.Content.ReadAsStringAsync().Result;
                        var dataItem = JsonConvert.DeserializeObject<Forecast>(result);
                        return Ok(dataItem);
                    }
                    else
                    {
                        return StatusCode((int)Res.StatusCode);
                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }
    }
}
