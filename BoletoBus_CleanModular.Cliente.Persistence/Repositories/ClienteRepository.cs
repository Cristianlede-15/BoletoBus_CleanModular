using BoletoBus_CleanModular.Bus.Application.Base;
using BoletoBus_CleanModular.Bus.Application.Services;
using BoletoBus_CleanModular.Cliente.Domain.Interfaces;
using BoletoBus_CleanModular.Common.Data.Repository;
using BoletosBus_CleanModular.Infraestructure.Logger.Services;
using Microsoft.Extensions.Logging;

namespace BoletoBus_CleanModular.Cliente.Persistence.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly LoggerService<BusService> _logger;

        public ClienteRepository(IClienteRepository clienteRepository, LoggerService<BusService> _logger)
        {
            this._clienteRepository = clienteRepository;
            this._logger = _logger;
        }
        public ServiceResult FindById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var cliente = _clienteRepository.FindById(id);
                if (cliente != null)
                {
                    result.Data = cliente;
                    result.Success = true;
                    _logger.LogInformation("Cliente obtenido correctamente.");
                }
                else
                {
                    result.Success = false;
                    result.Message = "Cliente no encontrado.";
                    _logger.LogInformation($"Cliente con id {id} no encontrado.");
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener el cliente: " + ex.Message;
                _logger.LogError(result.Message);
            }
            return result;
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var clientes = _clienteRepository.GetAll();
                result.Data = clientes;
                result.Success = true;
                _logger.LogInformation("Clientes obtenidos correctamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener los clientes: " + ex.Message;
                _logger.LogError(result.Message);
            }
            return result;
        }

        public ServiceResult Remove(Domain.Entities.Cliente clienteDelete)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var cliente = _clienteRepository.FindById(clienteDelete.Id);
                if (cliente != null)
                {
                    _clienteRepository.Remove(clienteDelete);
                    result.Success = true;
                    result.Message = "Cliente eliminado correctamente.";
                    _logger.LogInformation("Cliente eliminado correctamente.");
                }
                else
                {
                    result.Success = false;
                    result.Message = "Cliente no encontrado.";
                    _logger.LogInformation($"Cliente con id {clienteDelete.Id} no encontrado.");
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al eliminar el cliente: " + ex.Message;
                _logger.LogError(result.Message);
            }
            return result;
        }

        public ServiceResult Save(Domain.Entities.Cliente clienteSave)
        {
            ServiceResult result = new ServiceResult();
            try
            {

                if (string.IsNullOrWhiteSpace(clienteSave.Nombre) || clienteSave.Nombre.Length > 50)
                {
                    result.Success = false;
                    result.Message = "El Nombre es inválido.";
                    _logger.LogInformation(result.Message);
                    return result;
                }

                _clienteRepository.Save(clienteSave);
                result.Success = true;
                result.Message = "Cliente guardado correctamente.";
                _logger.LogInformation("Cliente guardado correctamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar el cliente: " + ex.Message;
                _logger.LogError(result.Message);
            }
            return result;
        }

        public ServiceResult Update(Domain.Entities.Cliente clienteUpdate)
        {
            ServiceResult result = new ServiceResult();
            try
            {

                if (string.IsNullOrWhiteSpace(clienteUpdate.Nombre) || clienteUpdate.Nombre.Length > 50)
                {
                    result.Success = false;
                    result.Message = "El Nombre es inválido.";
                    _logger.LogInformation(result.Message);
                    return result;
                }

                _clienteRepository.Update(clienteUpdate);
                result.Success = true;
                result.Message = "Cliente actualizado correctamente.";
                _logger.LogInformation("Cliente actualizado correctamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar el cliente: " + ex.Message;
                _logger.LogError(result.Message);
            }
            return result;
        }

        Domain.Entities.Cliente IBaseRepository<Domain.Entities.Cliente, int>.FindById(int id)
        {
            return _clienteRepository.FindById(id);
        }

        List<Domain.Entities.Cliente> IBaseRepository<Domain.Entities.Cliente, int>.GetAll()
        {
            return _clienteRepository.GetAll();
        }
    }
}
