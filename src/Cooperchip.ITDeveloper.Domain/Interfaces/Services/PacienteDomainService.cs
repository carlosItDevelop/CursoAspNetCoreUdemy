using Cooperchip.ITDeveloper.Domain.Entities;
using Cooperchip.ITDeveloper.Domain.Interfaces.Repository;
using Cooperchip.ITDeveloper.Domain.Interfaces.ServiceContracts;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Domain.Interfaces.Services
{
    public class PacienteDomainService : IPacienteDomainService
    {
        private readonly IRepositoryPaciente _repo;

        public PacienteDomainService(IRepositoryPaciente repo)
        {
            _repo = repo;
        }

        public async Task AdicionarPaciente(Paciente paciente)
        {

            // Não podemos cadastrar um paciente no futuro
            // Não podemos cadastrar um paciente, cuja data de nascimento esteja no futro
            // Não posso atribuir CPF inválido e nem CPF de outra pessoa

            await _repo.Inserir(paciente);

        }

        public async Task AtualizarPaciente(Paciente paciente)
        {
            // Não posso alterar o CPF do paciente
            

            await _repo.Atualizar(paciente);
        }


        public async Task ExcluirPaciente(Paciente paciente)
        {
            // Sair >> Desicupopar o Leito
            // Dar baixa no prontuario

            await _repo.Excluir(paciente);
        }

        public void Dispose()
        {
            _repo?.Dispose();
        }

    }
}
