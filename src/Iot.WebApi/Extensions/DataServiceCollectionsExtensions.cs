using Iot.Data.Configs;
using Iot.Data.Handlers;
using Iot.Data.Interfaces;
using Iot.Data.Repositories;
using Iot.Data.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Iot.WebApi.Extensions
{
    public static class DataServiceCollectionsExtensions
    {
        public static void ConfigureIotDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration.GetSection(MeasurementCsvConfig.SectionPath).Get<MeasurementCsvConfig>();
            services.AddSingleton(config);
            services.AddSingleton<IMeasurementContentHandler, MeasurementContentHandler>();
            services.AddSingleton<IMeasurementDataService, MeasurementDataService>();
            services.AddSingleton<IMeasurementRepository, MeasurementRepository>();
        }
    }
}
