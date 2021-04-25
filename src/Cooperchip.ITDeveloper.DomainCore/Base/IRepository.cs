using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace Cooperchip.ITDeveloper.DomainCore.Base
{
    public interface IRepository<TEntity, TKey> : IDisposable where TEntity : class
    {
        Task<IEnumerable<TEntity>> SelecionarTodos(Expression<Func<TEntity, bool>> quando = null);
        Task<TEntity> SelecionarPorId(TKey id);
        Task Inserir (TEntity obj);
        Task Atualizar(TEntity obj);
        Task Excluir(TEntity obj);
        Task ExcluirPorId(TKey id);
        Task<int> SaveAsync();
    }
}
