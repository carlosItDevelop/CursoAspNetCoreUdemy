using Cooperchip.ITDeveloper.Domain.Entities;
using Cooperchip.ITDeveloper.Domain.Interfaces.Repository;
using Cooperchip.ITDeveloper.Domain.Mensageria.Mediators;
using Cooperchip.ITDeveloper.Domain.Mensageria.Notifications;
using Cooperchip.ITDeveloper.Domain.Mensageria.Validations;
using Cooperchip.ITDeveloper.Domain.ServiceContracts;
using System;
using System.Linq;
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
            if (!ExecutarValidacao(new TriagemValidation(), triagem)) return;

            if (_reppoTriagem.Buscar(t => t.CodigoPaciente == triagem.CodigoPaciente && t.DataNotificacao == triagem.DataNotificacao && t.Mensagem.Trim() == triagem.Mensagem.Trim()).Result.Any()){
                Notificar("Este registro está duplicado!");
                return;
            }

            await _reppoTriagem.Inserir(triagem);
            // Publicar Evento
        }

        public async Task ExcluirTriagem(Triagem triagem)
        {
            await _reppoTriagem.Excluir(triagem);
        }

        public async Task ExcluirTriagemPorIdPaciente(Guid pacienteId)
        {
            if (!_reppoTriagem.Buscar(t=>t.CodigoPaciente == pacienteId).Result.Any())
            {
                Notificar("Não existe(m) registro(s) correspondente à busca!");
                return;
            }
            await _reppoTriagem.ExcluirTriagemPorIdPaciente(pacienteId);
        }

        public void Dispose()
        {
            _reppoTriagem?.Dispose();
        }


    }
}
