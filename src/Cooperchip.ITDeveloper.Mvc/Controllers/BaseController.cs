using Cooperchip.ITDeveloper.Domain.Mensageria.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace Cooperchip.ITDeveloper.Mvc.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly INotificador _notificador;

        protected BaseController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

    }
}
