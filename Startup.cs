using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Environment.Shell;

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
                // ShellSettings provide the tenant's configuration.
                var shellSettings = context.RequestServices.GetRequiredService<ShellSettings>();

                // Read the tenant-specific custom setting.
                var customSetting = shellSettings.Configuration["CustomSetting"];

                // Resolve all registered IMessageProvider services.
                var messageProviders = context.RequestServices.GetServices<IMessageProvider>();

                // Invoke all IMessageProviders.
                var messages = (await Task.WhenAll(messageProviders.Select(async x => await x.GetMessageAsync()))).ToList();

                // Add the custom setting as a message. Alternatively, could have implemented another IMessageProvider that reads the
                messages.Insert(0, customSetting);

                // Concatenate all messages.
                var output = string.Join("\r\n", messages);

                // Write the output string to the response stream.
                await context.Response.WriteAsync(output);
            }));
        }
    }
}