using BoletoBus_CleanModular.Cliente.Application.Base;
using BoletoBus_CleanModular.Cliente.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus_CleanModular.Cliente.Application.Interfaces
{
    public interface IClienteService
    {
        ServiceResult GetClientes();
        ServiceResult GetCliente(int id);
        ServiceResult UpdateCliente(ClienteUpdateDto clienteUpdate);
        ServiceResult DeleteCliente(ClienteDeleteDto clienteDelete);
        ServiceResult SaveCliente(ClienteSaveDto clienteSave);
    }
}
