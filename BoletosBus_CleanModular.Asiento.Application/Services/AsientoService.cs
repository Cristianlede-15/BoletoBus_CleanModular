using BoletoBus_CleanModular.Asiento.Domain.Interfaces;
using BoletosBus_CleanModular.Asiento.Application.Base;
using BoletosBus_CleanModular.Asiento.Application.Dtos;
using BoletosBus_CleanModular.Asiento.Application.Interfaces;
using BoletosBus_CleanModular.Infraestructure.Logger.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletosBus_CleanModular.Asiento.Application.Services
{
    public class AsientoService : IAsientoService
    {
        private readonly IAsientoService asientoDb;
        private readonly LoggerService<AsientoService> logger;

        public AsientoService(IAsientoService asientoDb, LoggerService<AsientoService> logger)
        {
            this.asientoDb = asientoDb;
            this.logger = logger;
        }
        public ServiceResult DeleteAsientos(AsientoDeleteDto asientoDelete)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                asientoDb.DeleteAsientos(asientoDelete);
                result.Success = true;
                result.Message = "Asientos eliminados correctamente.";
                logger.LogInformation("Asientos eliminados correctamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al eliminar los asientos: " + ex.Message;
                logger.LogError(result.Message);
            }
            return result;
        }

        public ServiceResult GetAsiento(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var asiento = asientoDb.GetAsientos();
                if (asiento != null)
                {
                    result.Data = asiento;
                    result.Success = true;
                    logger.LogInformation("Asiento obtenido correctamente.");
                }
                else
                {
                    result.Success = false;
                    result.Message = "Asiento no encontrado.";
                    logger.LogError("Asiento con id {Id} no encontrado.");
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener el asiento: " + ex.Message;
                logger.LogError(result.Message);
            }
            return result;
        }

        public ServiceResult GetAsientos()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = asientoDb.GetAsientos();
                result.Success = true;
                logger.LogInformation("Asientos obtenidos correctamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener los asientos: " + ex.Message;
                logger.LogError(result.Message);
            }
            return result;
        }

        public ServiceResult SaveAsiento(AsientoSaveDto asientoSave)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                if (asientoSave.IdBus <= 0)
                {
                    result.Success = false;
                    result.Message = "El IdBus debe ser un entero positivo.";
                    logger.LogError(result.Message);
                    return result;
                }

                if (asientoSave.NumeroPiso <= 0)
                {
                    result.Success = false;
                    result.Message = "El NumeroPiso debe ser un entero positivo.";
                    logger.LogError(result.Message);
                    return result;
                }

                if (asientoSave.NumeroAsiento <= 0)
                {
                    result.Success = false;
                    result.Message = "El NumeroAsiento debe ser un entero positivo.";
                    logger.LogInformation(result.Message);
                    return result;
                }

                if (asientoSave.FechaCreacion == null || asientoSave.FechaCreacion == DateTime.MinValue)
                {
                    result.Success = false;
                    result.Message = "La FechaCreacion es inválida.";
                    logger.LogError(result.Message);
                    return result;
                }

                asientoDb.SaveAsiento(asientoSave);
                result.Success = true;
                result.Message = "Asiento guardado correctamente.";
                logger.LogInformation("Asiento guardado correctamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar el asiento: " + ex.Message;
                logger.LogError(result.Message);
            }
            return result;
        }

        public ServiceResult UpdateAsientos(AsientoUpdateDto asientoUpdate)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                if (asientoUpdate.IdBus <= 0)
                {
                    result.Success = false;
                    result.Message = "El IdBus debe ser un entero positivo.";
                    logger.LogError(result.Message);
                    return result;
                }

                if (asientoUpdate.NumeroPiso <= 0)
                {
                    result.Success = false;
                    result.Message = "El NumeroPiso debe ser un entero positivo.";
                    logger.LogError(result.Message);
                    return result;
                }

                if (asientoUpdate.NumeroAsiento <= 0)
                {
                    result.Success = false;
                    result.Message = "El NumeroAsiento debe ser un entero positivo.";
                    logger.LogError(result.Message);
                    return result;
                }



                asientoDb.UpdateAsientos(asientoUpdate);
                result.Success = true;
                result.Message = "Asientos actualizados correctamente.";
                logger.LogInformation("Asientos actualizados correctamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar los asientos: " + ex.Message;
                logger.LogError(result.Message);
            }
            return result;
        }
    }
}
