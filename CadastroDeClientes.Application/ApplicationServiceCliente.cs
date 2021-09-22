using CadastroDeClientes.Application.Dtos;
using CadastroDeClientes.Application.Interfaces;
using CadastroDeClientes.Domain.Core.Interface.Services;
using System.Collections.Generic;

namespace CadastroDeClientes.Application
{
    public class ApplicationServiceCliente : IApplicationServiceCliente
    {
        private readonly IServiceCliente serviceCliente;
        private readonly IMapperCliente mapperCliente;
        public ApplicationServiceCliente(IServiceCliente serviceCliente, IMapperCliente mapperCliente)
        {
            this.serviceCliente = serviceCliente;
            this.mapperCliente = mapperCliente;
        }

        public void Add(ClienteViewModel salvarClienteViewModel)
        {
            var cliente = mapperCliente.MapperDtoToEntity(salvarClienteViewModel);
            serviceCliente.Add(cliente);
        }

        public IEnumerable<ClienteViewModel> GetAll()
        {
            var cliente = serviceCliente.GetAll();
            return mapperCliente.MapperListClientesDto(cliente);
        }

        public ClienteViewModel GetById(int id)
        {
            var cliente = serviceCliente.GetByCodigo(id);

            return cliente != null 
                ? mapperCliente.MapperEntityToDto(cliente) 
                : new ClienteViewModel();
        }

        public void Remove(int codigo)
        {
            var cliente = serviceCliente.GetByCodigo(codigo);
            serviceCliente.Remove(cliente);
        }

        public void Update(ClienteViewModel clienteDto)
        {
            var cliente = serviceCliente.GetByCodigo(clienteDto.Codigo);
            cliente.Nome = clienteDto.Nome;
            cliente.CNPJ = clienteDto.CNPJ;
            cliente.DataDeCadastro = clienteDto.DataDeCadastro;
            cliente.Endereço = clienteDto.Endereço;
            cliente.Telefone = clienteDto.Telefone;

            serviceCliente.Update(cliente);
        }

    }
}
