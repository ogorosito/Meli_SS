using Microsoft.Extensions.DependencyInjection;
using ML.SistemaSolar.Repositories;
using ML.SistemaSolar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ML.SistemaSolar
{
    public static class ServiceExtensions
    {

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IPrediccionClimaService, PrediccionClimaService>();
            services.AddScoped<IUbicacionPlanetaService, UbicacionPlanetaService>();
            services.AddScoped<IConsultaClimaService, ConsultaClimaService>();
        }

    }
}
