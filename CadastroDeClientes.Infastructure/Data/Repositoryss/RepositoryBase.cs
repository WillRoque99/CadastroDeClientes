using CadastroDeClientes.Domain.Core.Interface.Repositorys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CadastroDeClientes.Infastructure.Data.Repositoryss
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly ClienteContext clienteContext;

        public RepositoryBase(ClienteContext clienteContext)
        {
            this.clienteContext = clienteContext;
        }

        public void Add(TEntity obj)
        {
            try
            {
                clienteContext.Set<TEntity>().Add(obj);
                clienteContext.SaveChanges();

            }


            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<TEntity> GetAll()
        {
            return clienteContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return clienteContext.Set<TEntity>().Find(id);
        }

        public TEntity GetByCodigo(int Codigo)
        {
            return clienteContext.Set<TEntity>().Find(Codigo);
        }

        public void Remove(TEntity obj)
        {
            try
            {
                clienteContext.Set<TEntity>().Remove(obj);
                clienteContext.SaveChanges();

            }


            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(TEntity obj)
        {
            try
            {
                clienteContext.Entry(obj).State = EntityState.Modified;
                clienteContext.SaveChanges();

            }


            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
