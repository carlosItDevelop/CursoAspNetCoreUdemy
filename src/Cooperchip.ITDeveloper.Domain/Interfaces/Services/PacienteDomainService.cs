using Cooperchip.ITDeveloper.Domain.Entities;
using Cooperchip.ITDeveloper.Domain.Interfaces.Repository;
using System;
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
            await _repo.Inserir(paciente);
        }

        public async Task AtualizarPaciente(Paciente paciente)
        {
            await _repo.Atualizar(paciente);
        }


        public async Task ExcluirPaciente(Paciente paciente)
        {
            await _repo.Excluir(paciente);
        }

        public void Dispose()
        {
            _repo?.Dispose();
        }

    }
}
