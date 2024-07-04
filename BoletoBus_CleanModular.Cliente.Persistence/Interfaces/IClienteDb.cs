using BoletoBus_CleanModular.Cliente.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus_CleanModular.Cliente.Persistence.Interfaces
{
    public interface IClienteDb
    {
        void SaveCliente(ClienteSaveDto clienteSave);
        void UpdateCliente(ClienteUpdateDto clienteUpdate);
        void DeleteCliente(ClienteDeleteDto clienteDelete);

        List<ClienteAccessDto> GetClientes();
        ClienteAccessDto GetCliente(int IdCliente);
    }
}
