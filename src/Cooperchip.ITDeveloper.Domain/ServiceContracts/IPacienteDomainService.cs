using Cooperchip.ITDeveloper.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Domain.Interfaces.ServiceContracts
{
    public interface IPacienteDomainService : IDisposable
    {
        Task AdicionarPaciente(Paciente paciente);
        Task AtualizarPaciente(Paciente paciente);
        Task ExcluirPaciente(Paciente paciente);
    }
}
