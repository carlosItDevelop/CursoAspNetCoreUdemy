using Cooperchip.ITDeveloper.Data.ORM;
using Cooperchip.ITDeveloper.Data.Repository.Abstractions;
using Cooperchip.ITDeveloper.Data.Repository.Base;
using Cooperchip.ITDeveloper.Domain.Entities;
using Cooperchip.ITDeveloper.Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooperchip.ITDeveloper.Data.Repository
{
    public class MuralRepository : GenericRepository<Mural, Guid>, IRepositoryMural, IQueryMural
    {
        public MuralRepository(ITDeveloperDbContext ctx) : base(ctx){}

        public IQueryable<Mural> SelecionarTodosParaMural(string filtro = null)
        {
            var objBusca = from b in _context.Mural select b;
            if (!String.IsNullOrEmpty(filtro)) objBusca.Where(x => x.Titulo == filtro);
            return objBusca;
        }
        public SelectList MontarSelectList(IQueryable<Mural> iquery)
        {
            var ddList = new List<string>();
            var ddQuery = from d in _context.Mural.OrderBy(x => x.Titulo) select d.Titulo;
            ddList.AddRange(ddQuery.Distinct());
            return new SelectList(ddList);
        }

        public bool TemMural(Guid id)
        {
            return _context.Mural.Any(x => x.Id == id);
        }
    }
}
