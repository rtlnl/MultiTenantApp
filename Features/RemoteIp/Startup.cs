using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;

[assembly: OrchardCore.Modules.Manifest.Feature(
    Id = "RemoteIpMessage",
    Name = "RemoteIpMessage"
)]

namespace MultiTenantApp.Features.RemoteIpMessage
{
    [Feature("RemoteIpMessage")]
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IMessageProvider, RemoteIpMessageProvider>();
        }
    }
}
