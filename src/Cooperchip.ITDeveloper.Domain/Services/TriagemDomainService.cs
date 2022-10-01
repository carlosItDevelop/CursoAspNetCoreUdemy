using Cooperchip.ITDeveloper.Domain.Entities;
using Cooperchip.ITDeveloper.Domain.Interfaces.Repository;
using Cooperchip.ITDeveloper.Domain.Mensageria.Mediators;
using Cooperchip.ITDeveloper.Domain.Mensageria.Notifications;
using Cooperchip.ITDeveloper.Domain.ServiceContracts;
using System;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Domain.Services
{
    public class TriagemDomainService : BaseService, ITriagemDomainService
    {

        private readonly IRepositoryTriagem _reppoTriagem;
        private readonly IMediatorHandler _mediatorHandler;


        public TriagemDomainService(IRepositoryTriagem reppoTriagem,
                                                                INotificador notificador,
                                                                IMediatorHandler mediatorHandler)
            : base(notificador)
        {
            _reppoTriagem = reppoTriagem;
            _mediatorHandler = mediatorHandler;
        }

        public async Task AdicionarTriagem(Triagem triagem)
        {
            //Notificar("sdhfdsfdfaf");
            await _reppoTriagem.Inserir(triagem);
        }

        public async Task ExcluirTriagem(Triagem triagem)
        {
            await _reppoTriagem.Excluir(triagem);
        }

        public async Task ExcluirTriagemPorIdPaciente(Guid pacienteId)
        {
            await _reppoTriagem.ExcluirTriagemPorIdPaciente(pacienteId);
        }

        public void Dispose()
        {
            _reppoTriagem?.Dispose();
        }


    }
}
