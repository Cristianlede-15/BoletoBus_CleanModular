using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BoletoBus_CleanModular.Asiento.Domain.Entities;
using BoletoBus_CleanModular.Asiento.Domain.Interfaces;
using BoletoBus_CleanModular.Asiento.Persistence.Context;
using BoletoBus_CleanModular.Asiento.Persistence.Interfaces;
using BoletoBus_CleanModular.Common.Data.Repository;
using BoletosBus_CleanModular.Asiento.Application.Base;
using BoletosBus_CleanModular.Asiento.Application.Interfaces;
using BoletosBus_CleanModular.Asiento.Application.Services;
using BoletosBus_CleanModular.Infraestructure.Logger.Services;
using Microsoft.Extensions.Logging;

namespace BoletoBus_CleanModular.Asiento.Persistence.Repositories
{
    public class AsientoRepository : IAsientoRepository
    {
        private readonly IAsientoRepository asientoDb;
        private readonly LoggerService<AsientoService> logger;

        public AsientoRepository(IAsientoRepository asientoDb, LoggerService<AsientoService> logger)
        {
            this.asientoDb = asientoDb;
            this.logger = logger;
        }


        public ServiceResult FindById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var asiento = asientoDb.FindById(id);
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
                    logger.LogInformation("Asiento con id {Id} no encontrado.");
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

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = asientoDb.GetAll();
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

        public ServiceResult Remove(Domain.Entities.Asiento asientoDelete)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                asientoDb.Remove(asientoDelete);
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

        public ServiceResult Save(Domain.Entities.Asiento asientoSave)
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

                asientoDb.Save(asientoSave);
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

        public ServiceResult Update(Domain.Entities.Asiento asientoUpdate)
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



                asientoDb.Update(asientoUpdate);
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

        Domain.Entities.Asiento IBaseRepository<Domain.Entities.Asiento, int>.FindById(int id)
        {
            return asientoDb.FindById(id);
        }

        List<Domain.Entities.Asiento> IBaseRepository<Domain.Entities.Asiento, int>.GetAll()
        {
            return asientoDb.GetAll();
        }

        Bus.Application.Base.ServiceResult IBaseRepository<Domain.Entities.Asiento, int>.Remove(Domain.Entities.Asiento entity)
        {
            return asientoDb.Remove(entity);
        }

        Bus.Application.Base.ServiceResult IBaseRepository<Domain.Entities.Asiento, int>.Save(Domain.Entities.Asiento entity)
        {
            return asientoDb.Save(entity);
        }

        Bus.Application.Base.ServiceResult IBaseRepository<Domain.Entities.Asiento, int>.Update(Domain.Entities.Asiento entity)
        {
            return asientoDb.Update(entity);
        }
    }
    }

