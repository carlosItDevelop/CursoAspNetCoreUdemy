using Cooperchip.ITDeveloper.Domain.Entities;
using Cooperchip.ITDeveloper.DomainCore.Base;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace Cooperchip.ITDeveloper.Data.Repository.Abstractions
{
    public interface IQueryMural : IGerenicRepository<Mural, Guid>
    {
        bool TemMural(Guid id);
        IQueryable<Mural> SelecionarTodosParaMural(string filtro = null);
        SelectList MontarSelectList(IQueryable<Mural> iquery);
    }
}
