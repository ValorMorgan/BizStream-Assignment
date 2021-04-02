using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.DependencyInjection;

namespace BizStream.Assignment.Client {
    public class Startup {
        public void ConfigureServices(
            IServiceCollection services) =>

            services
                .AddSpaStaticFiles(options =>
                    options.RootPath = "build");

        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env) {

            // TODO: Setup for Production (currently only uses Development Server)
            app
                .UseStaticFiles()
                .UseSpaStaticFiles();
            app.UseSpa(spa => {
                spa.Options.SourcePath = "build";
                spa.UseReactDevelopmentServer(npmScript: "start");
            });
        }
    }
}
