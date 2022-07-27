using Iot.Application.Builders;
using Iot.Application.Interfaces;
using Iot.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Iot.WebApi.Extensions
{
    public static class ApplicationServiceCollectionsExtensions
    {
        public static void ConfigureIotApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IMeasurementBuilder, MeasurementBuilder>();
            services.AddSingleton<IMeasurementService, MeasurementService>();
        }
    }
}
