using CadastroDeClientes.Domain.Core.Interface.Repositorys;
using CadastroDeClientes.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CadastroDeClientes.Infastructure.Data.Repositoryss
{
    public class RepositoryCliente : RepositoryBase<Cliente>, IRepositoryCliente
    {
        private readonly ClienteContext clienteContext;

        public RepositoryCliente(ClienteContext clienteContext)
            : base(clienteContext)
        {
            this.clienteContext = clienteContext;
        }
    }
}
