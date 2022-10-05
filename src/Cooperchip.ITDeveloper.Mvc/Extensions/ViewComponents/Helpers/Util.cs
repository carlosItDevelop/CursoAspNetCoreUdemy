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

        public static int TotNotifyEvents(ITDeveloperDbContext ctx)
        {
            return (from nf in ctx.Triagem.AsNoTracking() select nf).Count();
        }

        //public static int TotChamadaMedico(ITDeveloperDbContext ctx)
        //{
        //    return (from nf in ctx.ChamadaMedica.AsNoTracking() select nf).Count();
        //}

    }
}
