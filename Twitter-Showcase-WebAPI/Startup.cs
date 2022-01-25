using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Twitter_Showcase_WebAPI.Services;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using System.IO;

namespace Twitter_Showcase_WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ITwitterAuthorizationService, TwitterAuthorizationService>();
            services.AddScoped<IUserDetailsService, UserDetailsService>();
            services.AddScoped<IUserTimelineService, UserTimelineService>();
            services.AddScoped<IContentSearchService, ContentSearchService>();

            services.AddControllers();

            // serving react project from the generated build folder for production
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "frontend/build";
            });
        }

        // configure middleware
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //app.UseCors(options =>
            //    options.WithOrigins() // accept requests from frontend
            //    .AllowAnyMethod()
            //    .AllowAnyHeader()
            //    //.AllowCredentials()
            //);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            //app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // enabling React to be served
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "frontend";
                // Change env to "Production" once ready and then we can run react project from ConfigureServices method!
                // currently set to "Development" so this will run
                // Check status in launchSettings.json
                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });


        }
    }
}
