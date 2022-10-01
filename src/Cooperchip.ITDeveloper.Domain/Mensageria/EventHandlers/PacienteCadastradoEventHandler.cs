using Cooperchip.ITDeveloper.Domain.Mensageria.EventPublish;
using Cooperchip.ITDeveloper.Domain.Mensageria.Mediators;
using MediatR;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Domain.Mensageria.EventHandlers
{
    public class PacienteCadastradoEventHandler : INotificationHandler<PacienteCadastradoEvent>
    {
        private readonly IMediatorHandler _mediator;

        public PacienteCadastradoEventHandler(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        public async Task Handle(PacienteCadastradoEvent notification, CancellationToken cancellationToken)
        {
            var mensagem = $"{notification.Motivo}";

            if (notification.Paciente.EstadoPaciente.Descricao.Equals("Grave"))
            {
                Debug.WriteLine($"ANTES DA TRIAGEM, O Sr(a). {notification.Paciente.Nome} DEVE VERIFICAR SE TEM PRIORIDADE!");

            } else if(notification.Paciente.EstadoPaciente.Descricao.Equals("S/Avaliação"))
            {
                await _mediator.PublicarEvento(new PacienteSemAvaliacaoEvent(notification.AggregateId, notification.Paciente, mensagem));
            }
            else
            {
                // Todo: new Triagem(..,..,..);
                Debug.WriteLine($"==================\t================");
                Debug.WriteLine($"Código do Paciente.:\t{notification.AggregateId}");
                Debug.WriteLine($"Nome do Paciente ..:\t{notification.Paciente.Nome}");
                Debug.WriteLine($"Data da Notificação:\t{notification.Timestamp}");
                Debug.WriteLine($"Menssagem .............:\t{notification.Motivo}");
                Debug.WriteLine($"==================\t================");
                Debug.WriteLine($"Estado do Paciente..:\t{notification.Paciente.EstadoPaciente.Descricao}");
                Debug.WriteLine($"==================\t================");
            }


            await Task.CompletedTask;
        }
    }
}
