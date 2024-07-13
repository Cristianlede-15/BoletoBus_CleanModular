using BoletoBus_CleanModular.Cliente.Application.Base;
using BoletoBus_CleanModular.Cliente.Application.Dtos;
using BoletoBus_CleanModular.Cliente.Application.Interfaces;
using BoletoBus_CleanModular.Infraestructure.Logger.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus_CleanModular.Cliente.Application.Services
{
    public class ClienteServices : IClienteService
    {
        private readonly IClienteService _clienteService;
        private readonly LoggerService<ClienteServices> _logger;

        public ClienteServices(IClienteService clienteService, LoggerService<ClienteServices> logger)
        {
            _clienteService = clienteService;
            _logger = logger;
        }
        public ServiceResult DeleteCliente(ClienteDeleteDto clienteDelete)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var cliente = _clienteService.GetCliente(clienteDelete.IdCliente);
                if (cliente != null)
                {
                    _clienteService.DeleteCliente(clienteDelete);
                    result.Success = true;
                    result.Message = "Cliente eliminado correctamente.";
                    _logger.LogInformation("Cliente eliminado correctamente.");
                }
                else
                {
                    result.Success = false;
                    result.Message = "Cliente no encontrado.";
                    _logger.LogInformation($"Cliente con id {clienteDelete.IdCliente} no encontrado.");
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

        public ServiceResult GetCliente(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var cliente = _clienteService.GetCliente(id);
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

        public ServiceResult GetClientes()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var clientes = _clienteService.GetClientes();
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

        public ServiceResult SaveCliente(ClienteSaveDto clienteSave)
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

                _clienteService.SaveCliente(clienteSave);
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

        public ServiceResult UpdateCliente(ClienteUpdateDto clienteUpdate)
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

                _clienteService.UpdateCliente(clienteUpdate);
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
    }
}
