using Iot.Infrastructure.Configs;
using Iot.Infrastructure.Factories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Iot.WebApi.Extensions
{
    public static class InfrastructureServiceCollectionsExtensions
    {
        public static void ConfigureIotInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration.GetSection(StorageAccountConfig.SectionName).Get<StorageAccountConfig>();
            services.AddSingleton(config);
            services.AddSingleton<StorageAccountFactory>();
        }
    }
}
