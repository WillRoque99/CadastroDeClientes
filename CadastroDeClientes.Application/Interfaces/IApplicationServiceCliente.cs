using CadastroDeClientes.Application.Dtos;
using System.Collections.Generic;

namespace CadastroDeClientes.Application.Interfaces
{
    public interface IApplicationServiceCliente
    {
        void Add(ClienteViewModel clienteDto);

        void Update(ClienteViewModel clienteDto);

        void Remove(int codigo);

        IEnumerable<ClienteViewModel> GetAll();

        ClienteViewModel GetById(int id);

    }
}
