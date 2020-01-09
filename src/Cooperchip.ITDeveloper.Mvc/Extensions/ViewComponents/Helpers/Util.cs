using Cooperchip.ITDeveloper.Data.ORM;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Cooperchip.ITDeveloper.Mvc.Extensions.ViewComponents.Helpers
{
    public static class Util
    {
        public static int TotReg(ITDeveloperDbContext ctx)
        {
            return (from pac in ctx.Paciente.AsNoTracking() select pac).Count();
        }

        public static decimal GetNumRegEstado(ITDeveloperDbContext ctx, string estado)
        {
            return ctx.Paciente.AsNoTracking()
                .Count(x => x.EstadoPaciente.Descricao.Contains(estado));
        }

    }
}
