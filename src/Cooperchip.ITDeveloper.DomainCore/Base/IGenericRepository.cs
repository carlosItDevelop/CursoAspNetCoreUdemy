﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace Cooperchip.ITDeveloper.DomainCore.Base
{
    public interface IGenericRepository<T, TKey> : IDisposable where T : class
    {
        Task<IEnumerable<T>> SelecionarTodos(Expression<Func<T, bool>> quando = null);
        Task<T> SelecionarPorId(TKey id);
        Task Inserir (T obj);
        Task Atualizar(T obj);
        Task Excluir(T obj);
        Task ExcluirPorId(TKey id);
        Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate);
        //Task<int> SaveAsync();
    }
}
