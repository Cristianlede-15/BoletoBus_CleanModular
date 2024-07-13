using BoletoBus_CleanModular.Asiento.Domain.Interfaces;
using BoletoBus_CleanModular.Asiento.Persistence.Repositories;
using BoletoBus_CleanModular.Asiento.Application.Interfaces;
using BoletoBus_CleanModular.Asiento.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus_CleanModular.Asiento.IOC.Dependencies
{
    public static class AsientoDependency
    {
        public static void AddAsientoDependency(this IServiceCollection services)
        {
            #region "Repositorios"

            services.AddScoped<IAsientoService, AsientoService>();
            services.AddScoped<IAsientoRepository, AsientoRepository>();
            #endregion


            #region "Servicios"
            services.AddTransient<IAsientoService, AsientoService>();
            services.AddTransient<IAsientoRepository, AsientoRepository>();
            #endregion
        }
    }
}
