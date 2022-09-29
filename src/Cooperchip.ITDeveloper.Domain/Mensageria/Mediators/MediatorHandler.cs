using MediatR;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Domain.Mensageria.Mediators
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
        }
    }

}
