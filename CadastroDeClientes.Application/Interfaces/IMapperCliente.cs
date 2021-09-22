using CadastroDeClientes.Application.Dtos;
using CadastroDeClientes.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroDeClientes.Application.Interfaces
{
   public interface IMapperCliente
    {
        Cliente MapperDtoToEntity(ClienteViewModel clienteDto);

        IEnumerable<ClienteViewModel> MapperListClientesDto(IEnumerable<Cliente> clientes);

        ClienteViewModel MapperEntityToDto(Cliente cliente);

    }
}
