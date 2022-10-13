using Cooperchip.ITDeveloper.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace Cooperchip.ITDeveloper.Data.Repository.Abstractions
{
    public interface IQueryMural
    {
        bool TemMural(Guid id);
        IQueryable<Mural> SelecionarTodosParaMural(string filtro = null);
        SelectList MontarSelectList(IQueryable<Mural> iquery);
    }
}
