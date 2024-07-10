
using BoletoBus_CleanModular.Bus.Application.Base;
using BoletoBus_CleanModular.Bus.Application.Dtos;
using BoletoBus_CleanModular.Bus.Application.Interfaces;
using BoletosBus_CleanModular.Infraestructure.Logger.Services;


namespace BoletoBus_CleanModular.Bus.Application.Services
{
    public class BusService : IBusService
    {
        private readonly IBusService _busRepository;
        private readonly LoggerService<BusService> _logger;

        public BusService(IBusService busRepository, LoggerService<BusService> logger)
        {
            _busRepository = busRepository;
            _logger = logger;
        }

        public ServiceResult DeleteBus(BusDeleteDto busDelete)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var bus = _busRepository.GetBus(busDelete.IdBus);
                if (bus != null)
                {
                    _busRepository.DeleteBus(busDelete);
                    result.Success = true;
                    result.Message = "Bus eliminado correctamente.";
                    _logger.LogInformation("Bus eliminado correctamente.");
                }
                else
                {
                    result.Success = false;
                    result.Message = "Bus no encontrado.";
                    _logger.LogInformation("Bus con id {Id} no encontrado.");
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al eliminar el bus: " + ex.Message;
                _logger.LogError(result.Message);
            }
            return result;
        }

        public ServiceResult GetBus(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var bus = _busRepository.GetBus(id);
                if (bus != null)
                {
                    result.Data = bus;
                    result.Success = true;
                    _logger.LogInformation("Bus obtenido correctamente.");
                }
                else
                {
                    result.Success = false;
                    result.Message = "Bus no encontrado.";
                    _logger.LogInformation("Bus con id {Id} no encontrado.");
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener el bus: " + ex.Message;
                _logger.LogError(result.Message);
            }
            return result;
        }

        public ServiceResult GetBuses()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var buses = _busRepository.GetBuses();
                result.Data = buses;
                result.Success = true;
                _logger.LogInformation("Buses obtenidos correctamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener los buses: " + ex.Message;
                _logger.LogError(result.Message);
            }
            return result;
        }

        public ServiceResult SaveBus(BusSaveDto busSave)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                if (string.IsNullOrWhiteSpace(busSave.NumeroPlaca) || busSave.NumeroPlaca.Length > 50)
                {
                    result.Success = false;
                    result.Message = "El NumeroPlaca es inválido.";
                    _logger.LogError(result.Message);
                    return result;
                }

                if (string.IsNullOrWhiteSpace(busSave.Nombre) || busSave.Nombre.Length > 50)
                {
                    result.Success = false;
                    result.Message = "El Nombre es inválido.";
                    _logger.LogInformation(result.Message);
                    return result;
                }

                if (busSave.CapacidadPiso1 <= 0)
                {
                    result.Success = false;
                    result.Message = "La CapacidadPiso1 debe ser un entero positivo.";
                    _logger.LogInformation(result.Message);
                    return result;
                }

                if (busSave.CapacidadPiso2 <= 0)
                {
                    result.Success = false;
                    result.Message = "La CapacidadPiso2 debe ser un entero positivo.";
                    _logger.LogInformation(result.Message);
                    return result;
                }

                if (busSave.Disponible == null)
                {
                    result.Success = false;
                    result.Message = "El campo Disponible es inválido.";
                    _logger.LogInformation(result.Message);
                    return result;
                }

                if (busSave.FechaCreacion == null || busSave.FechaCreacion == DateTime.MinValue)
                {
                    result.Success = false;
                    result.Message = "La FechaCreacion es inválida.";
                    _logger.LogInformation(result.Message);
                    return result;
                }

                _busRepository.SaveBus(busSave);
                result.Success = true;
                result.Message = "Bus guardado correctamente.";
                _logger.LogInformation("Bus guardado correctamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar el bus: " + ex.Message;
                _logger.LogError(result.Message);
            }
            return result;
        }

        public ServiceResult UpdateBuses(BusUpdateDto busUpdate)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                if (string.IsNullOrWhiteSpace(busUpdate.NumeroPlaca) || busUpdate.NumeroPlaca.Length > 50)
                {
                    result.Success = false;
                    result.Message = "El NumeroPlaca es inválido.";
                    _logger.LogInformation(result.Message);
                    return result;
                }

                if (string.IsNullOrWhiteSpace(busUpdate.Nombre) || busUpdate.Nombre.Length > 50)
                {
                    result.Success = false;
                    result.Message = "El Nombre es inválido.";
                    _logger.LogInformation(result.Message);
                    return result;
                }

                if (busUpdate.CapacidadPiso1 <= 0)
                {
                    result.Success = false;
                    result.Message = "La CapacidadPiso1 debe ser un entero positivo.";
                    _logger.LogInformation(result.Message);
                    return result;
                }

                if (busUpdate.CapacidadPiso2 <= 0)
                {
                    result.Success = false;
                    result.Message = "La CapacidadPiso2 debe ser un entero positivo.";
                    _logger.LogInformation(result.Message);
                    return result;
                }

                if (busUpdate.Disponible == null)
                {
                    result.Success = false;
                    result.Message = "El campo Disponible es inválido.";
                    _logger.LogInformation(result.Message);
                    return result;
                }

                _busRepository.UpdateBuses(busUpdate);
                result.Success = true;
                result.Message = "Bus actualizado correctamente.";
                _logger.LogInformation("Bus actualizado correctamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar el bus: " + ex.Message;
                _logger.LogError(result.Message);
            }
            return result;
        }
    }
}
