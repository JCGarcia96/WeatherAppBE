using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeatherAppBE.Models.Geolocation;

namespace WeatherAppBE.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GeolocationController : ControllerBase
    {
        public IConfiguration _configuration;
        public string GeolocationApiUrl;
        public string WeatherApiKey;
        public GeolocationController(IConfiguration configuration)
        {
            _configuration = configuration;
            GeolocationApiUrl = _configuration.GetSection("OpenWeather").GetSection("UrlGeolocationApi").Value;
            WeatherApiKey = _configuration.GetSection("OpenWeather").GetSection("ApiKey").Value;

        }
        [HttpGet]
        public async Task<IActionResult> GetCityLatLng(string cityName)
        {
            try
            {
                var resp = new HttpResponseMessage();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GeolocationApiUrl);
                    var apiCall = $"direct?q={cityName}&appId={WeatherApiKey}";
                    HttpResponseMessage Res = await client.GetAsync(apiCall);
                    var result = "";
                    if (Res.IsSuccessStatusCode)
                    {
                        result = Res.Content.ReadAsStringAsync().Result;
                        var dataItem = JsonConvert.DeserializeObject<List<City>>(result);
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

        [HttpGet]
        public async Task<IActionResult> GetZipCodeLatLng(string zipCode)
        {
            try
            {
                var resp = new HttpResponseMessage();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GeolocationApiUrl);
                    var apiCall = $"zip?zip={zipCode}&appid={WeatherApiKey}";
                    HttpResponseMessage Res = await client.GetAsync(apiCall);
                    var result = "";
                    if (Res.IsSuccessStatusCode)
                    {
                        result = Res.Content.ReadAsStringAsync().Result;
                        var dataItem = JsonConvert.DeserializeObject<ZipCode>(result);
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
