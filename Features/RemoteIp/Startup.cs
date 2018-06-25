using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;

[assembly: OrchardCore.Modules.Manifest.Feature(
    Id = "RemoteIp",
    Name = "RemoteIp"
)]

namespace MultiTenantApp.Features.RemoteIp
{
    [Feature("RemoteIp")]
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IMessageProvider, RemoteIpMessageProvider>();
        }
    }
}
