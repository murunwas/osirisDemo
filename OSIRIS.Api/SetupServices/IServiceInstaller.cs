using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OSIRIS.Api.SetupServices
{
    public interface IServiceInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
