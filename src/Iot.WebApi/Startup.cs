using Iot.Application.Builders;
using Iot.Application.Interfaces;
using Iot.Application.Services;
using Iot.Data.Handlers;
using Iot.Data.Interfaces;
using Iot.Data.Repositories;
using Iot.Data.Services;
using Iot.Infrastructure.Configs;
using Iot.Infrastructure.Factories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using System;
using System.IO;
using System.Linq;

namespace Iot.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.Converters.Add(new StringEnumConverter()));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Internet of Things API",
                    Description = "An ASP.NET Core Web API for evaluate technical skills"
                });
                var xmlFilename = $"Iot.WebApi.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
            services.ConfigureSwaggerGen(options => options.CustomSchemaIds(x => x.FullName));
            services.AddSwaggerGenNewtonsoftSupport();

            services.AddApiVersioning(setup =>
            {
                setup.DefaultApiVersion = new ApiVersion(1, 0);
                setup.AssumeDefaultVersionWhenUnspecified = true;
                setup.ReportApiVersions = true;
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {
                    var errors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .Select(e => e.Value.Errors.First().ErrorMessage).ToArray();

                    return new BadRequestObjectResult(errors);
                };
            });

            #region [ Application ]
            services.AddSingleton<IMeasurementBuilder, MeasurementBuilder>();
            services.AddSingleton<IMeasurementService, MeasurementService>();
            #endregion

            #region [ Data ]
            services.AddSingleton<IMeasurementContentHandler, MeasurementContentHandler>();
            services.AddSingleton<IMeasurementDataService, MeasurementDataService>();
            services.AddSingleton<IMeasurementRepository, MeasurementRepository>();
            #endregion

            #region [ Infrastructure ]
            services.Configure<StorageAccountConfig>(Configuration.GetSection(StorageAccountConfig.SectionName));
            services.AddSingleton<StorageAccountConfig>();
            services.AddSingleton<StorageAccountFactory>();
            #endregion

            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

            services.AddAutoMapper(typeof(Startup));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
