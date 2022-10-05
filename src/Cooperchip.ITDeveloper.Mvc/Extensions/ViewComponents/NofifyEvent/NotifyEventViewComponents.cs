using Cooperchip.ITDeveloper.Data.ORM;
using Cooperchip.ITDeveloper.Domain.Entities;
using Cooperchip.ITDeveloper.Mvc.Extensions.ViewComponents.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Mvc.Extensions.ViewComponents.NofifyEvent
{
    [ViewComponent(Name = "NotifyEvents")]
    public class NotifyEventViewComponents : ViewComponent
    {
        private readonly ITDeveloperDbContext _context;

        public NotifyEventViewComponents(ITDeveloperDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.Total = Util.TotNotifyEvents(_context);
            var notificacoes = await _context.Set<Triagem>().AsNoTracking().OrderBy(x=>x.DataNotificacao).Take(7).ToListAsync();

            return View(await Task.FromResult( notificacoes));
        }
    }
}
