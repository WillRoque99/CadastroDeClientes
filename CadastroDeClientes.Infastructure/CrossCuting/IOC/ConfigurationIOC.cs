using Autofac;
using CadastroDeClientes.Application;
using CadastroDeClientes.Application.Interfaces;
using CadastroDeClientes.Application.Mappers;
using CadastroDeClientes.Domain.Core.Interface.Repositorys;
using CadastroDeClientes.Domain.Core.Interface.Services;
using CadastroDeClientes.Infastructure.Data.Repositoryss;
using CadastroDeClientes.Services;

namespace CadastroDeClientes.Infastructure.CrossCuting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC

            builder.RegisterType<ApplicationServiceCliente>().As<IApplicationServiceCliente>();

            builder.RegisterType<ServiceCliente>().As<IServiceCliente>();

            builder.RegisterType<RepositoryCliente>().As<IRepositoryCliente>();

            builder.RegisterType<MapperCliente>().As<IMapperCliente>();


            #endregion
        }
    }
}
