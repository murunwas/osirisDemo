using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OSIRIS.Repository.GetMovies;
using System.Reflection;

namespace OSIRIS.Api.SetupServices
{
    public class MediatrServiceInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(GetMovieQuery).Assembly);
        }
    }
}
