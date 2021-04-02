using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BizStream.Assignment.Server {
    public class Startup {
        public void ConfigureServices(
            IServiceCollection services) =>

            services
                .AddCors()
                .AddLogging()
                .AddControllers();

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env) {

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseCors(app =>
                    app
                        .WithOrigins("http://localhost:54321")
                        .AllowAnyHeader()
                        .AllowAnyMethod())
                .UseRouting()
                .UseEndpoints(endpoints =>
                    endpoints.MapControllers());
        }
    }
}
