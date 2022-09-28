using System.Collections.Generic;
using System.Linq;

namespace Cooperchip.ITDeveloper.Domain.Mensageria.Notifications
{
    public class Notificador : INotificador
    {
        private List<Notificacao> _notificacoes;
        public Notificador(List<Notificacao> notificacao) => _notificacoes = notificacao;

        public bool TemNotificacao()
        {
            return _notificacoes.Any();
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public void Handle(Notificacao notificacao) => _notificacoes.Add(notificacao);
    }
}

