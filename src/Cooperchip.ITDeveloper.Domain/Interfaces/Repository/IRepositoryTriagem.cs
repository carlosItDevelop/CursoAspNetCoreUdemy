using Cooperchip.ITDeveloper.Domain.Entities;
using Cooperchip.ITDeveloper.DomainCore.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Domain.Interfaces.Repository
{
    public interface IRepositoryTriagem : IGenericRepository<Triagem, Guid>
    {
        Task<Triagem> ObterTriagemPorId(Guid id);
        Task<IEnumerable<Triagem>> ListaTriagemPorData();
        Task<Triagem> ObterTriagemPorIdPaciente(Guid pacienteId);
        Task ExcluirTriagemPorIdPaciente(Guid pacienteId);
    }
}
