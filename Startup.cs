using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MultiTenantApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddOrchardCore()
                .WithTenants();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOrchardCore(a => a.Run(async context =>
            {
                var messageProviders = context.RequestServices.GetServices<IMessageProvider>();
                var messages = await Task.WhenAll(messageProviders.Select(async x => await x.GetMessageAsync()));
                var output = string.Join("\r\n", messages);
                await context.Response.WriteAsync(output);
            }));
        }
    }
}