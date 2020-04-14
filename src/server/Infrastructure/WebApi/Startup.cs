using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Odysseus.DomainModel.MapGenerator;
using Odysseus.DomainServices.MapGenerator;
using Odysseus.Framework.Randomizer;
using System.Text.Json;

namespace WebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(policy => policy.AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    var config = new AdjacentRoomsGeneratorConfiguration(10, 3, new ConstraintRange<int>(5, 10), new ConstraintRange<int>(5, 10));
                    var generator = new ConnectedRoomsDungeonGenerator(new AdjacentRoomsGenerator(config), new CorridorsGenerator(0.4, 2));

                    await context.Response.WriteAsync(JsonSerializer.Serialize(generator.Generate(), new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    }));
                });
            });
        }
    }
}
