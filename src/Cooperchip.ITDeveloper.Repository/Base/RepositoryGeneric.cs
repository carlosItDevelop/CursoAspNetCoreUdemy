using Cooperchip.ITDeveloper.Data.ORM;
using Cooperchip.ITDeveloper.DomainCore.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Repository.Base
{
    public abstract class RepositoryGeneric<TEntity, TKey> : IDomainGenericRepository<TEntity, TKey> where TEntity : class, new()
    {

        private ITDeveloperDbContext _context;

        public RepositoryGeneric(ITDeveloperDbContext ctx) // Guardem essa info
        {
            this._context = ctx;
        }

        public Task Atualizar(TEntity obj)
        {
            throw new NotImplementedException();
        }


        public Task Excluir(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public Task ExcluirPorId(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task Inserir(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> SelecionarPorId(TKey id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> SelecionarTodos(Expression<Func<TEntity, bool>> quando = null)
        {
            throw new NotImplementedException();
        }

        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.DisposeAsync();
        }

    }
}
