using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Odysseus.Infrastructure.WebApi.Configurations;
using Odysseus.Infrastructure.WebApi.Hubs;

namespace Odysseus.Infrastructure.WebApi
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration) =>
            this.configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<MapHubOptions>(
                configuration.GetSection(MapHubOptions.MapHub));

            services.AddCors();
            services.AddSignalR();
        }

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IOptions<MapHubOptions> mapHubOptions)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
                builder.WithOrigins(mapHubOptions.Value.Url)
                    .AllowAnyHeader()
                    .WithMethods("GET", "POST")
                    .AllowCredentials()
            );

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<MapHub>("/hub");

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Odysseus");
                });
            });
        }
    }
}
