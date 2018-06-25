using System.Threading.Tasks;

namespace MultiTenantApp.Features.WeatherForecast
{
    public class WeatherForecastMessageProvider : IMessageProvider
    {
        private readonly OpenWeatherMapClient _client;

        public WeatherForecastMessageProvider(OpenWeatherMapClient client)
        {
            _client = client;
        }

        public async Task<string> GetMessageAsync()
        {
            var weather = await _client.GetWeatherDescriptionAsync("Hilversum,NL");
            return $"Today's weather will contain: {weather}";
        }
    }
}
