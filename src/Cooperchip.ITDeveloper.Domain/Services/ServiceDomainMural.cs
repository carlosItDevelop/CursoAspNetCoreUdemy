using Cooperchip.ITDeveloper.Domain.Entities;
using Cooperchip.ITDeveloper.Domain.Interfaces;
using Cooperchip.ITDeveloper.Domain.Interfaces.Repository;
using Cooperchip.ITDeveloper.Domain.Mensageria.Mediators;
using Cooperchip.ITDeveloper.Domain.Mensageria.Notifications;
using Cooperchip.ITDeveloper.Domain.Mensageria.Validations;
using System.Linq;
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
            if(!ExecutarValidacao(new MuralValidation(), model)) return;

            if (_repoMural.Buscar(m => m.Id == model.Id).Result.Any())
            {
                Notificar("Já existe um registro cadastrado com este ID.");
                return;
            }

            await _repoMural.Inserir(model);
            //await _bus.PublicarEvento(new MuralCadastradoEvent(model.Data, model.Titulo, model.Autor, model.Titulo));
        }

        public async Task AtualizarMural(Mural model)
        {

            if (!ExecutarValidacao(new MuralValidation(), model)) return;

            if (_repoMural.Buscar(m => m.Titulo.Trim().Equals(model.Titulo.Trim()) && m.Autor == model.Autor && m.Data == model.Data && m.Aviso.Trim().Equals(model.Aviso.Trim())).Result.Any())
            {
                Notificar("Não foram modificados dados algum.");
                return;
            }

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
