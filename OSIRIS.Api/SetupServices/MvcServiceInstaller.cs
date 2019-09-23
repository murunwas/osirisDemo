using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OSIRIS.Api.Filters;

namespace OSIRIS.Api.SetupServices
{
    public class MvcServiceInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc(options => {
                options.EnableEndpointRouting = false;
                options.Filters.Add<ValidationFilter>();
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(options =>
            {
                options.RootPath = "ClientApp/public";
            });
        }
    }
}
