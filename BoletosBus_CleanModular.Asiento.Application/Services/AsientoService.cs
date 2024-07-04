using BoletoBus_CleanModular.Asiento.Domain.Interfaces;
using BoletosBus_CleanModular.Asiento.Application.Base;
using BoletosBus_CleanModular.Asiento.Application.Dtos;
using BoletosBus_CleanModular.Asiento.Application.Interfaces;

namespace BoletosBus_CleanModular.Asiento.Application.Services
{
    public class AsientoService : IAsientoService
    {
        private readonly IAsientoRepository asientoRepository;
        private readonly ILogger<AsientoService> logger;

        public AsientoService(IAsientoRepository asientoRepository, ILogger<AsientoService> logger)
        {
            this.asientoRepository = asientoRepository;
            this.logger = logger;
        }

        public ServiceResult DeleteAsientos(AsientoDeleteDto asientoDelete)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var asiento = asientoRepository.FindById(asientoDelete.Id);
                if (asiento == null)
                {
                    result.Success = false;
                    result.Message = "Asiento no encontrado.";
                    logger.LogWarning("Asiento con id {Id} no encontrado.", asientoDelete.Id);
                    return result;
                }
                asientoRepository.Remove(asiento);
                result.Success = true;
                result.Message = "Asientos eliminados correctamente.";
                logger.LogInformation("Asientos eliminados correctamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al eliminar los asientos: " + ex.Message;
                logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult GetAsiento(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var asiento = asientoRepository.FindById(id);
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
                    logger.LogWarning("Asiento con id {Id} no encontrado.", id);
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener el asiento: " + ex.Message;
                logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult GetAsientos()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = asientoRepository.GetAll();
                result.Success = true;
                logger.LogInformation("Asientos obtenidos correctamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener los asientos: " + ex.Message;
                logger.LogError(ex, result.Message);
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
                    logger.LogWarning(result.Message);
                    return result;
                }

                if (asientoSave.NumeroPiso <= 0)
                {
                    result.Success = false;
                    result.Message = "El NumeroPiso debe ser un entero positivo.";
                    logger.LogWarning(result.Message);
                    return result;
                }

                if (asientoSave.NumeroAsiento <= 0)
                {
                    result.Success = false;
                    result.Message = "El NumeroAsiento debe ser un entero positivo.";
                    logger.LogWarning(result.Message);
                    return result;
                }

                if (asientoSave.FechaCreacion == null || asientoSave.FechaCreacion == DateTime.MinValue)
                {
                    result.Success = false;
                    result.Message = "La FechaCreacion es inválida.";
                    logger.LogWarning(result.Message);
                    return result;
                }

                var asiento = new Asiento
                {
                    IdBus = asientoSave.IdBus,
                    NumeroPiso = asientoSave.NumeroPiso,
                    NumeroAsiento = asientoSave.NumeroAsiento,
                    FechaCreacion = asientoSave.FechaCreacion
                };

                asientoRepository.Save(asiento);
                result.Success = true;
                result.Message = "Asiento guardado correctamente.";
                logger.LogInformation("Asiento guardado correctamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar el asiento: " + ex.Message;
                logger.LogError(ex, result.Message);
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
                    logger.LogWarning(result.Message);
                    return result;
                }

                if (asientoUpdate.NumeroPiso <= 0)
                {
                    result.Success = false;
                    result.Message = "El NumeroPiso debe ser un entero positivo.";
                    logger.LogWarning(result.Message);
                    return result;
                }

                if (asientoUpdate.NumeroAsiento <= 0)
                {
                    result.Success = false;
                    result.Message = "El NumeroAsiento debe ser un entero positivo.";
                    logger.LogWarning(result.Message);
                    return result;
                }

                var asiento = asientoRepository.FindById(asientoUpdate.IdAsiento);
                if (asiento == null)
                {
                    result.Success = false;
                    result.Message = "Asiento no encontrado.";
                    logger.LogWarning("Asiento con id {Id} no encontrado.", asientoUpdate.IdAsiento);
                    return result;
                }

                asiento.IdBus = asientoUpdate.IdBus;
                asiento.NumeroPiso = asientoUpdate.NumeroPiso;
                asiento.NumeroAsiento = asientoUpdate.NumeroAsiento;

                asientoRepository.Update(asiento);
                result.Success = true;
                result.Message = "Asientos actualizados correctamente.";
                logger.LogInformation("Asientos actualizados correctamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar los asientos: " + ex.Message;
                logger.LogError(ex, result.Message);
            }
            return result;
        }
    }
}
