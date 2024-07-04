using BoletoBus_CleanModular.Common.Data.Repository;
using BoletosBus_CleanModular.Asiento.Application.Base;
using BoletosBus_CleanModular.Asiento.Application.Dtos;
using BoletosBus_CleanModular.Asiento.Application.Interfaces;
using BoletoBus_CleanModular.Asiento.Domain.Entities;
using BoletoBus_CleanModular.Asiento.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BoletosBus_CleanModular.Asiento.Application.Services
{
    public class AsientoService : IAsientoService
    {
        private readonly IAsientoRepository _asientoRepository;
        private readonly ILogger<AsientoService> _logger;

        public AsientoService(IAsientoRepository asientoRepository, ILogger<AsientoService> logger)
        {
            _asientoRepository = asientoRepository;
            _logger = logger;
        }

        public ServiceResult DeleteAsientos(AsientoDeleteDto asientoDelete)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var asiento = _asientoRepository.FindById(asientoDelete.IdAsiento);
                if (asiento != null)
                {
                    _asientoRepository.Remove(asiento);
                    result.Success = true;
                    result.Message = "Asientos eliminados correctamente.";
                    _logger.LogInformation("Asientos eliminados correctamente.");
                }
                else
                {
                    result.Success = false;
                    result.Message = "Asiento no encontrado.";
                    _logger.LogWarning("Asiento con id {Id} no encontrado.", asientoDelete.IdAsiento);
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al eliminar los asientos: " + ex.Message;
                _logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult GetAsiento(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var asiento = _asientoRepository.FindById(id);
                if (asiento != null)
                {
                    result.Data = asiento;
                    result.Success = true;
                    _logger.LogInformation("Asiento obtenido correctamente.");
                }
                else
                {
                    result.Success = false;
                    result.Message = "Asiento no encontrado.";
                    _logger.LogWarning("Asiento con id {Id} no encontrado.", id);
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener el asiento: " + ex.Message;
                _logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult GetAsientos()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var asientos = _asientoRepository.GetAll();
                result.Data = asientos;
                result.Success = true;
                _logger.LogInformation("Asientos obtenidos correctamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener los asientos: " + ex.Message;
                _logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult SaveAsiento(AsientoSaveDto asientoSave)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                // Validaciones
                if (asientoSave.IdBus <= 0)
                {
                    result.Success = false;
                    result.Message = "El IdBus debe ser un entero positivo.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                if (asientoSave.NumeroPiso <= 0)
                {
                    result.Success = false;
                    result.Message = "El NumeroPiso debe ser un entero positivo.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                if (asientoSave.NumeroAsiento <= 0)
                {
                    result.Success = false;
                    result.Message = "El NumeroAsiento debe ser un entero positivo.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                if (asientoSave.FechaCreacion == null || asientoSave.FechaCreacion == DateTime.MinValue)
                {
                    result.Success = false;
                    result.Message = "La FechaCreacion es inválida.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                var asiento = new Asiento
                {
                    IdBus = asientoSave.IdBus,
                    NumeroPiso = asientoSave.NumeroPiso,
                    NumeroAsiento = asientoSave.NumeroAsiento,
                    FechaCreacion = asientoSave.FechaCreacion
                };

                _asientoRepository.Save(asiento);
                result.Success = true;
                result.Message = "Asiento guardado correctamente.";
                _logger.LogInformation("Asiento guardado correctamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar el asiento: " + ex.Message;
                _logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult UpdateAsientos(AsientoUpdateDto asientoUpdate)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                // Validaciones
                if (asientoUpdate.IdBus <= 0)
                {
                    result.Success = false;
                    result.Message = "El IdBus debe ser un entero positivo.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                if (asientoUpdate.NumeroPiso <= 0)
                {
                    result.Success = false;
                    result.Message = "El NumeroPiso debe ser un entero positivo.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                if (asientoUpdate.NumeroAsiento <= 0)
                {
                    result.Success = false;
                    result.Message = "El NumeroAsiento debe ser un entero positivo.";
                    _logger.LogWarning(result.Message);
                    return result;
                }

                var asiento = _asientoRepository.FindById(asientoUpdate.IdAsiento);
                if (asiento != null)
                {
                    asiento.IdBus = asientoUpdate.IdBus;
                    asiento.NumeroPiso = asientoUpdate.NumeroPiso;
                    asiento.NumeroAsiento = asientoUpdate.NumeroAsiento;

                    _asientoRepository.Update(asiento);
                    result.Success = true;
                    result.Message = "Asientos actualizados correctamente.";
                    _logger.LogInformation("Asientos actualizados correctamente.");
                }
                else
                {
                    result.Success = false;
                    result.Message = "Asiento no encontrado.";
                    _logger.LogWarning("Asiento con id {Id} no encontrado.", asientoUpdate.IdAsiento);
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar los asientos: " + ex.Message;
                _logger.LogError(ex, result.Message);
            }
            return result;
        }
    }
}
