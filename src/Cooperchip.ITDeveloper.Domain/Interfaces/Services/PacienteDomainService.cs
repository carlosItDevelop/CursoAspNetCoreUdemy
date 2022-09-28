using Cooperchip.ITDeveloper.Domain.Entities;
using Cooperchip.ITDeveloper.Domain.Interfaces.Repository;
using Cooperchip.ITDeveloper.Domain.Interfaces.ServiceContracts;
using Cooperchip.ITDeveloper.Domain.Mensageria.Notifications;
using Cooperchip.ITDeveloper.Domain.Mensageria.Validations;
using System.Linq;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Domain.Interfaces.Services
{
    public class PacienteDomainService :  BaseService,  IPacienteDomainService
    {
        private readonly IRepositoryPaciente _repo;

        public PacienteDomainService(IRepositoryPaciente repo, INotificador notificador) : base(notificador)    
        {
            _repo = repo;
        }

        public async Task AdicionarPaciente(Paciente paciente)
        {
            if (!ExecutarValidacao(new PacienteValidation(), paciente))
            {
                return;
            }

            // Buscar Paciente pra saber se já existe um Cpf cadastrado com o mesmo;
            if(_repo.Buscar(c=>c.Cpf == paciente.Cpf).Result.Any())
            {
                Notificar("Já existe um Paciente com este Cpf informado");
                return;
            }

            await _repo.Inserir(paciente);

        }

        public async Task AtualizarPaciente(Paciente paciente)
        {
            // Não posso alterar o CPF do paciente
            

            await _repo.Atualizar(paciente);
        }


        public async Task ExcluirPaciente(Paciente paciente)
        {
            // Sair >> Desocupopar o Leito;
            // Dar baixa no prontuario;
            // Excluir os EstadosDePaciente deste Paciente;

            await _repo.Excluir(paciente);
        }

        public void Dispose()
        {
            _repo?.Dispose();
        }

    }
}
