using System;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;

[assembly: OrchardCore.Modules.Manifest.Feature(
    Id = "WeatherForecast",
    Name = "WeatherForecast"
)]

namespace MultiTenantApp.Features.WeatherForecast
{
    [Feature("WeatherForecast")]
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<OpenWeatherMapClient>()
                .ConfigureHttpClient(client =>
                {
                    client.BaseAddress = new Uri("http://samples.openweathermap.org/data/2.5/weather");
                });
            services.AddScoped<IMessageProvider, WeatherForecastMessageProvider>();
        }
    }
}
