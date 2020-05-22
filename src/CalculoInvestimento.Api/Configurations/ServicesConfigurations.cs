using CalculoInvestimento.Application.Services;
using CalculoInvestimento.Domain.Interfaces.Repositories;
using CalculoInvestimento.Domain.Interfaces.Services;
using CalculoInvestimento.Infra.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace CalculoInvestimento.Api.Configurations
{
    public static class ServicesConfigurations
    {
        public static IServiceCollection ConfigureApi(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITesouroDiretoRepository, TesouroDiretoRepository>();
            services.AddScoped<IFundosRepository, FundosRepository>();
            services.AddScoped<ILciRepository, LciRepository>();
            services.AddScoped<IInvestimentosServices, InvestimentosServices>();
            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("ConexaoRedis");
                options.InstanceName = "calculoinvestimento";
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Calculo Investimento Api",
                    Version = "v1",
                    Contact = new OpenApiContact()
                    {
                        Name = "Fernando Mikio Hatori",
                        Email = "nandomk@gmail.com"
                    }
                });
            });

            services.AddHealthChecks();
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddApiVersion();
            return services;
        }

        private static IServiceCollection AddApiVersion(this IServiceCollection services)
        {
            services.AddScoped<IApiVersionDescriptionProvider, DefaultApiVersionDescriptionProvider>();

            services.AddVersionedApiExplorer(o =>
            {
                o.GroupNameFormat = "'v'VVV";
                o.SubstituteApiVersionInUrl = true;
            });

            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });

            return services;
        }


    }
}
