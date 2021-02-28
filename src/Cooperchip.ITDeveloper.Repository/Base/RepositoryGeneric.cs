using Cooperchip.ITDeveloper.Data.ORM;
using Cooperchip.ITDeveloper.DomainCore.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Repository.Base
{
    public abstract class RepositoryGeneric<TEntity, TKey> : IDomainGenericRepository<TEntity, TKey> where TEntity : class, new()
    {

        protected ITDeveloperDbContext _context;

        public RepositoryGeneric(ITDeveloperDbContext ctx) // Guardem essa info
        {
            this._context = ctx;
        }

        public virtual async Task Atualizar(TEntity obj)
        {
            this._context.Entry(obj).State = EntityState.Modified;
            await SaveAsync();
        }


        public virtual async Task Excluir(TEntity obj)
        {
            this._context.Entry(obj).State = EntityState.Deleted;
            await SaveAsync();
        }

        public virtual async Task ExcluirPorId(TKey id)
        {
            TEntity obj = await SelecionarPorId(id);
            await Excluir(obj);

            //_context.Set<TEntity>().Remove(new TEntity {Id = id });

        }

        public virtual async Task Inserir(TEntity obj)
        {
            this._context.Set<TEntity>().Add(obj);
            await SaveAsync();
        }

        public async Task<TEntity> SelecionarPorId(TKey id)
        {
            return await this._context.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> SelecionarTodos(Expression<Func<TEntity, bool>> quando = null)
        {
            if(quando == null)
            {
                return await this._context.Set<TEntity>().AsNoTracking().ToListAsync();
            }
            return await this._context.Set<TEntity>().AsNoTracking().Where(quando).ToListAsync();
        }



        public void Dispose()
        {
            _context?.DisposeAsync();
        }

        public virtual async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
