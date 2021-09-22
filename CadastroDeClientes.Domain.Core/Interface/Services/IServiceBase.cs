using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroDeClientes.Domain.Core.Interface.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        void Update(TEntity obj);

        void Remove(TEntity obj);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        TEntity GetByCodigo(int Código);

    }
}
