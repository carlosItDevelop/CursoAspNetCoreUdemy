using Cooperchip.ITDeveloper.Domain.Mensageria.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Mvc.Extensions.ViewComponents.Summary
{
    [ViewComponent(Name = "summary")]
    public class SummaryViewComponents : ViewComponent
    {
        private readonly INotificador _notificador;
        public SummaryViewComponents(INotificador notificador) => _notificador = notificador;
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult(_notificador.ObterNotificacoes());
            notificacoes.ForEach(c => ViewData.ModelState.AddModelError(string.Empty, c.Mensagem));
            return View(await Task.FromResult(notificacoes));
        }
    }
}
