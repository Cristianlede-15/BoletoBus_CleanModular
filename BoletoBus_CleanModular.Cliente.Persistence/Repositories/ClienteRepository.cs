using BoletoBus_CleanModular.Cliente.Application.Base;
using BoletoBus_CleanModular.Cliente.Application.Dtos;
using BoletoBus_CleanModular.Cliente.Application.Interfaces;
using BoletoBus_CleanModular.Cliente.Domain.Entities;
using BoletoBus_CleanModular.Cliente.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace BoletoBus_CleanModular.Cliente.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository clienteRepository;
        private readonly ILogger<ClienteService> logger;

        public ClienteService(IClienteRepository clienteRepository, ILogger<ClienteService> logger)
        {
            this.clienteRepository = clienteRepository;
            this.logger = logger;
        }

        public ServiceResult DeleteCliente(ClienteDeleteDto clienteDelete)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var cliente = clienteRepository.FindById(clienteDelete.IdCliente);
                if (cliente != null)
                {
                    clienteRepository.Remove(cliente);
                    result.Success = true;
                    result.Message = "Cliente eliminado correctamente.";
                    logger.LogInformation("Cliente eliminado correctamente.");
                }
                else
                {
                    result.Success = false;
                    result.Message = "Cliente no encontrado.";
                    logger.LogWarning("Cliente con id {Id} no encontrado.", clienteDelete.IdCliente);
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al eliminar el cliente: " + ex.Message;
                logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult GetCliente(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var cliente = clienteRepository.FindById(id);
                if (cliente != null)
                {
                    result.Data = cliente;
                    result.Success = true;
                    logger.LogInformation("Cliente obtenido correctamente.");
                }
                else
                {
                    result.Success = false;
                    result.Message = "Cliente no encontrado.";
                    logger.LogWarning("Cliente con id {Id} no encontrado.", id);
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener el cliente: " + ex.Message;
                logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult GetClientes()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                var clientes = clienteRepository.GetAll();
                result.Data = clientes;
                result.Success = true;
                logger.LogInformation("Clientes obtenidos correctamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al obtener los clientes: " + ex.Message;
                logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult SaveCliente(ClienteSaveDto clienteSave)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                if (string.IsNullOrEmpty(clienteSave.Nombre) || clienteSave.Nombre.Length > 50)
                {
                    result.Success = false;
                    result.Message = "El nombre del cliente es inválido.";
                    logger.LogWarning(result.Message);
                    return result;
                }

                if (!string.IsNullOrEmpty(clienteSave.Telefono) && clienteSave.Telefono.Length > 20)
                {
                    result.Success = false;
                    result.Message = "El teléfono del cliente es inválido.";
                    logger.LogWarning(result.Message);
                    return result;
                }

                if (!string.IsNullOrEmpty(clienteSave.Email) && clienteSave.Email.Length > 50)
                {
                    result.Success = false;
                    result.Message = "El email del cliente es inválido.";
                    logger.LogWarning(result.Message);
                    return result;
                }

                var cliente = new Cliente
                {
                    Nombre = clienteSave.Nombre,
                    Telefono = clienteSave.Telefono,
                    Email = clienteSave.Email
                };

                clienteRepository.Save(cliente);
                result.Success = true;
                result.Message = "Cliente guardado correctamente.";
                logger.LogInformation("Cliente guardado correctamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al guardar el cliente: " + ex.Message;
                logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult UpdateCliente(ClienteUpdateDto clienteUpdate)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                if (string.IsNullOrEmpty(clienteUpdate.Nombre) || clienteUpdate.Nombre.Length > 50)
                {
                    result.Success = false;
                    result.Message = "El nombre del cliente es inválido.";
                    logger.LogWarning(result.Message);
                    return result;
                }

                if (!string.IsNullOrEmpty(clienteUpdate.Telefono) && clienteUpdate.Telefono.Length > 20)
                {
                    result.Success = false;
                    result.Message = "El teléfono del cliente es inválido.";
                    logger.LogWarning(result.Message);
                    return result;
                }

                if (!string.IsNullOrEmpty(clienteUpdate.Email) && clienteUpdate.Email.Length > 50)
                {
                    result.Success = false;
                    result.Message = "El email del cliente es inválido.";
                    logger.LogWarning(result.Message);
                    return result;
                }

                var cliente = clienteRepository.FindById(clienteUpdate.IdCliente);
                if (cliente != null)
                {
                    cliente.Nombre = clienteUpdate.Nombre;
                    cliente.Telefono = clienteUpdate.Telefono;
                    cliente.Email = clienteUpdate.Email;

                    clienteRepository.Update(cliente);
                    result.Success = true;
                    result.Message = "Cliente actualizado correctamente.";
                    logger.LogInformation("Cliente actualizado correctamente.");
                }
                else
                {
                    result.Success = false;
                    result.Message = "Cliente no encontrado.";
                    logger.LogWarning("Cliente con id {Id} no encontrado.", clienteUpdate.IdCliente);
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error al actualizar el cliente: " + ex.Message;
                logger.LogError(ex, result.Message);
            }
            return result;
        }
    }
}
