using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace MultiTenantApp.Features.WeatherForecast
{
    public class OpenWeatherMapClient
    {
        private readonly HttpClient _httpClient;

        public OpenWeatherMapClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetWeatherDescriptionAsync(string location)
        {
            var json = await _httpClient.GetStringAsync($"?q={location}&appid=b6907d289e10d714a6e88b30761fae22");
            var model = JObject.Parse(json);
            return model["weather"][0]["description"].Value<string>();
        }
    }
}
