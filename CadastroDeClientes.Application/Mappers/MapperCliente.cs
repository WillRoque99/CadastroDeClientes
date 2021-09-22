using CadastroDeClientes.Application.Dtos;
using CadastroDeClientes.Application.Interfaces;
using CadastroDeClientes.Domain.Entitys;
using System.Collections.Generic;
using System.Linq;

namespace CadastroDeClientes.Application.Mappers
{
    public class MapperCliente : IMapperCliente
    {
        public Cliente MapperDtoToEntity(ClienteViewModel clienteDto)
        {
            var cliente = new Cliente()
            {
                Nome = clienteDto.Nome,
                CNPJ = clienteDto.CNPJ,
                DataDeCadastro = clienteDto.DataDeCadastro,
                Endereço = clienteDto.Endereço,
                Telefone = clienteDto.Telefone
            };
            return cliente;
        }

        public ClienteViewModel MapperEntityToDto(Cliente cliente)
        {
            var clienteDto = new ClienteViewModel()
            {
                Codigo = cliente.Codigo,
                Nome = cliente.Nome,
                CNPJ = cliente.CNPJ,
                DataDeCadastro = cliente.DataDeCadastro,
                Endereço = cliente.Endereço,
                Telefone = cliente.Telefone
            };
            return clienteDto;
        }

        public IEnumerable<ClienteViewModel> MapperListClientesDto(IEnumerable<Cliente> clientes)
        {
            var dto = clientes.Select(c => new ClienteViewModel { Codigo = c.Codigo, Nome = c.Nome, CNPJ = c.CNPJ, DataDeCadastro = c.DataDeCadastro, Endereço = c.Endereço, Telefone = c.Telefone });

            return dto;
        }
    }
}
