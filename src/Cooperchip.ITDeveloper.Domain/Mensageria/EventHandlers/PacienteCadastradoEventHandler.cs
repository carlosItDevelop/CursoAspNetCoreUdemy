using Cooperchip.ITDeveloper.Domain.Entities;
using Cooperchip.ITDeveloper.Domain.Interfaces;
using Cooperchip.ITDeveloper.Domain.Mensageria.EventPublish;
using Cooperchip.ITDeveloper.Domain.Mensageria.Mediators;
using Cooperchip.ITDeveloper.Domain.ServiceContracts;
using MediatR;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Domain.Mensageria.EventHandlers
{
    public class PacienteCadastradoEventHandler : INotificationHandler<PacienteCadastradoEvent>
    {
        private readonly IMediatorHandler _mediator;
        private readonly ITriagemDomainService _triagemService;
        private readonly IUnitOfWork _uow;

        public PacienteCadastradoEventHandler(IMediatorHandler mediator,
                                                                                 ITriagemDomainService triagemService,
                                                                                 IUnitOfWork uow)
        {
            _mediator = mediator;
            _triagemService = triagemService;
            _uow = uow;
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
                mensagem = $"{notification.Paciente.Nome}: {notification.Motivo}";
                await _triagemService.AdicionarTriagem(new Triagem(notification.AggregateId, notification.Paciente.Nome, notification.Timestamp, mensagem));

                await _uow.Commit();
            }
            await Task.CompletedTask;
        }
    }
}
