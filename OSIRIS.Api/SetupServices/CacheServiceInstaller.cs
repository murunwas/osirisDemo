using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OSIRIS.Api.Cache;
using OSIRIS.Common.Services.Cache;
using StackExchange.Redis;

namespace OSIRIS.Api.SetupServices
{
    public class CacheServiceInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var redisCacheSettings = new RedisCacheSettings();
            configuration.GetSection(nameof(RedisCacheSettings)).Bind(redisCacheSettings);
            services.AddSingleton(redisCacheSettings);

            if (!redisCacheSettings.Enabled)
            {
                return;
            }

            services.AddSingleton<IConnectionMultiplexer>(_ =>
               ConnectionMultiplexer.Connect(redisCacheSettings.ConnectionString));
            services.AddStackExchangeRedisCache(options => options.Configuration = redisCacheSettings.ConnectionString);
            services.AddSingleton<ICacheService, CacheService>();
        }
    }
}
