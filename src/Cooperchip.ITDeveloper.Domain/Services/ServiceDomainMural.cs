using Cooperchip.ITDeveloper.Domain.Entities;
using Cooperchip.ITDeveloper.Domain.Interfaces;
using Cooperchip.ITDeveloper.Domain.Interfaces.Repository;
using Cooperchip.ITDeveloper.Domain.Mensageria.Mediators;
using Cooperchip.ITDeveloper.Domain.Mensageria.Notifications;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Domain.Services
{
    public class ServiceDomainMural : BaseService, IMuralService
    {
        private readonly IRepositoryMural _repoMural;
        private readonly IMediatorHandler _bus;
        public ServiceDomainMural(INotificador notificador, 
                                                            IRepositoryMural repoMural) : base(notificador)
        {
            _repoMural = repoMural;
        }

        public async Task AdicionarMural(Mural model)
        {
            await _repoMural.Inserir(model);
            //await _bus.PublicarEvento(new MuralCadastradoEvent(model.Data, model.Titulo, model.Autor, model.Titulo));
        }

        public async Task AtualizarMural(Mural model)
        {
            await _repoMural.Atualizar(model);
        }

        public async Task ExcluirMural(Mural model)
        {
            await _repoMural.Excluir(model);
        }

        public void Dispose()
        {
            _repoMural?.Dispose();
        }

    }
}
