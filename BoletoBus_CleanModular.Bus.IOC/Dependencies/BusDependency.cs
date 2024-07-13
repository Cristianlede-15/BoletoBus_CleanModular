using BoletoBus_CleanModular.Bus.Application.Interfaces;
using BoletoBus_CleanModular.Bus.Application.Services;
using BoletoBus_CleanModular.Bus.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus_CleanModular.Bus.IOC.Dependencies
{
    public static class BusDependency
    {
        public static void AddBusDependency(this IServiceCollection services)
        {
            #region "Repositorios"
            services.AddScoped<IBusService, BusService>();
            services.AddScoped<IBusRepository, BusRepository>();
            #endregion

            #region "Servicios"
            services.AddTransient<IBusService, BusService>();
            services.AddTransient<IBusRepository, BusRepository>();
            #endregion
        }
    }
}
