using BoletoBus_CleanModular.Bus.Application.Base;
using BoletoBus_CleanModular.Bus.Application.Dtos;
using BoletoBus_CleanModular.Bus.Application.Interfaces;
using BoletoBus_CleanModular.Bus.Domain.Entities;
using BoletoBus_CleanModular.Bus.Domain.Interfaces;
using BoletoBus_CleanModular.Common.Data.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoletoBus_CleanModular.Bus.Application.Services
{
    public class BusRepository : IBusRepository
    {
        private readonly IBusRepository busRepository;
        private readonly ILogger<BusService> logger;

        public BusRepository(IBusRepository busRepository, ILogger<BusService> logger)
        {
            this.busRepository = busRepository;
            this.logger = logger;
        }

        public ServiceResult FindById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var bus = busRepository.FindById(id);
                if (bus != null)
                {
                    result.Data = bus;
                    result.Success = true;
                    logger.LogInformation("Bus obtenido correctamente.");
                }
                else
                {
                    result.Success = false;
                    result.Message = "Bus no encontrado.";
                    logger.LogWarning("Bus con id {Id} no encontrado.", id);
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener el bus: " + ex.Message;
                logger.LogError(ex, result.Message);
            }
            return result;

        }

        public ServiceResult GetAll()
        {

            ServiceResult result = new ServiceResult();
            try
            {
                var buses = busRepository.GetAll();
                result.Data = buses;
                result.Success = true;
                logger.LogInformation("Buses obtenidos correctamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener los buses: " + ex.Message;
                logger.LogError(ex, result.Message);
            }
            return result;

        }

        public ServiceResult Remove(Domain.Entities.Bus busDelete)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var bus = busRepository.FindById(busDelete.Id);
                if (bus != null)
                {
                    busRepository.Remove(bus);
                    result.Success = true;
                    result.Message = "Bus eliminado correctamente.";
                    logger.LogInformation("Bus eliminado correctamente.");
                }
                else
                {
                    result.Success = false;
                    result.Message = "Bus no encontrado.";
                    logger.LogWarning("Bus con id {Id} no encontrado.", busDelete.Id);
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al eliminar el bus: " + ex.Message;
                logger.LogError(ex, result.Message);
            }
            return result;

        }

        public ServiceResult Save(Domain.Entities.Bus busSave)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                if (string.IsNullOrWhiteSpace(busSave.NumeroPlaca) || busSave.NumeroPlaca.Length > 50)
                {
                    result.Success = false;
                    result.Message = "El NumeroPlaca es inválido.";
                    logger.LogWarning(result.Message);
                    return result;
                }

                if (string.IsNullOrWhiteSpace(busSave.Nombre) || busSave.Nombre.Length > 50)
                {
                    result.Success = false;
                    result.Message = "El Nombre es inválido.";
                    logger.LogWarning(result.Message);
                    return result;
                }

                if (busSave.CapacidadPiso1 <= 0)
                {
                    result.Success = false;
                    result.Message = "La CapacidadPiso1 debe ser un entero positivo.";
                    logger.LogWarning(result.Message);
                    return result;
                }

                if (busSave.CapacidadPiso2 <= 0)
                {
                    result.Success = false;
                    result.Message = "La CapacidadPiso2 debe ser un entero positivo.";
                    logger.LogWarning(result.Message);
                    return result;
                }

                if (busSave.Disponible == null)
                {
                    result.Success = false;
                    result.Message = "El campo Disponible es inválido.";
                    logger.LogWarning(result.Message);
                    return result;
                }

                if (busSave.FechaCreacion == null || busSave.FechaCreacion == DateTime.MinValue)
                {
                    result.Success = false;
                    result.Message = "La FechaCreacion es inválida.";
                    logger.LogWarning(result.Message);
                    return result;
                }

                var bus = new Domain.Entities.Bus
                {
                    NumeroPlaca = busSave.NumeroPlaca,
                    Nombre = busSave.Nombre,
                    CapacidadPiso1 = busSave.CapacidadPiso1,
                    CapacidadPiso2 = busSave.CapacidadPiso2,
                    Disponible = (bool?)busSave.Disponible,
                    FechaCreacion = busSave.FechaCreacion
                };

                busRepository.Save(bus);
                result.Success = true;
                result.Message = "Bus guardado correctamente.";
                logger.LogInformation("Bus guardado correctamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar el bus: " + ex.Message;
                logger.LogError(ex, result.Message);
            }
            return result;

        }

        public ServiceResult Update(Domain.Entities.Bus busUpdate)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                if (string.IsNullOrWhiteSpace(busUpdate.NumeroPlaca) || busUpdate.NumeroPlaca.Length > 50)
                {
                    result.Success = false;
                    result.Message = "El NumeroPlaca es inválido.";
                    logger.LogWarning(result.Message);
                    return result;
                }

                if (string.IsNullOrWhiteSpace(busUpdate.Nombre) || busUpdate.Nombre.Length > 50)
                {
                    result.Success = false;
                    result.Message = "El Nombre es inválido.";
                    logger.LogWarning(result.Message);
                    return result;
                }

                if (busUpdate.CapacidadPiso1 <= 0)
                {
                    result.Success = false;
                    result.Message = "La CapacidadPiso1 debe ser un entero positivo.";
                    logger.LogWarning(result.Message);
                    return result;
                }

                if (busUpdate.CapacidadPiso2 <= 0)
                {
                    result.Success = false;
                    result.Message = "La CapacidadPiso2 debe ser un entero positivo.";
                    logger.LogWarning(result.Message);
                    return result;
                }

                if (busUpdate.Disponible == null)
                {
                    result.Success = false;
                    result.Message = "El campo Disponible es inválido.";
                    logger.LogWarning(result.Message);
                    return result;
                }

                var bus = busRepository.FindById(busUpdate.Id);
                if (bus != null)
                {
                    bus.NumeroPlaca = busUpdate.NumeroPlaca;
                    bus.Nombre = busUpdate.Nombre;
                    bus.CapacidadPiso1 = busUpdate.CapacidadPiso1;
                    bus.CapacidadPiso2 = busUpdate.CapacidadPiso2;
                    bus.Disponible = busUpdate.Disponible;

                    busRepository.Update(bus);
                    result.Success = true;
                    result.Message = "Bus actualizado correctamente.";
                    logger.LogInformation("Bus actualizado correctamente.");
                }
                else
                {
                    result.Success = false;
                    result.Message = "Bus no encontrado.";
                    logger.LogWarning("Bus con id {Id} no encontrado.", busUpdate.Id);
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar el bus: " + ex.Message;
                logger.LogError(ex, result.Message);
            }
            return result;

        }

        Domain.Entities.Bus IBaseRepository<Domain.Entities.Bus, int>.FindById(int id)
        {
            return busRepository.FindById(id);
        }

        List<Domain.Entities.Bus> IBaseRepository<Domain.Entities.Bus, int>.GetAll()
        {
            return busRepository.GetAll();
        }
    }
}
