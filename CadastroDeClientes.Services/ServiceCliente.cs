using CadastroDeClientes.Domain.Core.Interface.Repositorys;
using CadastroDeClientes.Domain.Core.Interface.Services;
using CadastroDeClientes.Domain.Entitys;

namespace CadastroDeClientes.Services
{
    public class ServiceCliente : ServiceBase<Cliente>, IServiceCliente
    {
        private readonly IRepositoryCliente repositoryCliente;

        public ServiceCliente(IRepositoryCliente repositoryCliente)
        : base(repositoryCliente)
        {
            this.repositoryCliente = repositoryCliente;
        }
    }
    }
