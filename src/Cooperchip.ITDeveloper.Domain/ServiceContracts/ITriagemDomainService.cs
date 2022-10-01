using Cooperchip.ITDeveloper.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Domain.ServiceContracts
{
    public interface ITriagemDomainService : IDisposable
    {
        Task AdicionarTriagem(Triagem triagem);
        Task ExcluirTriagem(Triagem triagem);
        Task ExcluirTriagemPorIdPaciente(Guid pacienteId);
    }
}
