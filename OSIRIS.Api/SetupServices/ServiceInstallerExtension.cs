using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace OSIRIS.Api.SetupServices
{
    public static class ServiceInstallerExtension
    {
        public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var installers = typeof(Startup).Assembly.ExportedTypes.Where(x =>typeof(IServiceInstaller)
                                    .IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                                    .Select(Activator.CreateInstance).Cast<IServiceInstaller>()
                                    .ToList();

            installers.ForEach(installer => installer.InstallServices(services, configuration));
        }
    }
}
