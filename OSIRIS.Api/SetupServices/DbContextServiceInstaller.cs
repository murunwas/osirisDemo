using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OSIRIS.Database;

namespace OSIRIS.Api.SetupServices
{
    public class DbContextServiceInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OSIRISDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),a=> a.MigrationsAssembly("OSIRIS.Api"));
                
            }
            );
        }
    }
}
