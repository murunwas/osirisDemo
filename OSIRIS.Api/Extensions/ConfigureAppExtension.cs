using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using OSIRIS.Api.MiddleWares;

namespace OSIRIS.Api.Extensions
{
    public static class ConfigureAppExtension
    {
        public static void ConfigurAppeException(this IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            };
            app.ConfigureCustomExceptionMiddleware();
        }

        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "OSIRIS Movie API V1");
            });
        }

        public static void ConfigureMVC(this IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    //spa.UseReactDevelopmentServer(npmScript: "start");
                    //spa.UseProxyToSpaDevelopmentServer("http://localhost:5000");
                }
            });
        }


    }
}
