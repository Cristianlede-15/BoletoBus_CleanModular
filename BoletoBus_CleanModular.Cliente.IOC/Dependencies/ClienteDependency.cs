using BoletoBus_CleanModular.Asiento.Domain.Interfaces;
using BoletoBus_CleanModular.Asiento.Persistence.Repositories;
using BoletoBus_CleanModular.Bus.Application.Interfaces;
using BoletoBus_CleanModular.Bus.Application.Services;
using BoletoBus_CleanModular.Bus.Domain.Interfaces;
using BoletoBus_CleanModular.Cliente.Application.Interfaces;
using BoletoBus_CleanModular.Cliente.Application.Services;
using BoletoBus_CleanModular.Cliente.Domain.Interfaces;
using BoletoBus_CleanModular.Cliente.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BoletoBus_CleanModular.Cliente.IOC.Dependencies
{
    public static class ClienteDependency
    {
        public static void AddClienteDependency(this IServiceCollection services)
        {
            #region "Repositorios"
            services.AddScoped<IBusRepository, BusRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IAsientoRepository, AsientoRepository>();
            #endregion

            #region "Servicios"
            services.AddTransient<IClienteService, ClienteServices>();
            services.AddTransient<IBusService, BusService>();
            #endregion
        }
    }
}
