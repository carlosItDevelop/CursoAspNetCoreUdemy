using System.Collections.Generic;

namespace Cooperchip.ITDeveloper.Domain.Mensageria.Notifications
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
