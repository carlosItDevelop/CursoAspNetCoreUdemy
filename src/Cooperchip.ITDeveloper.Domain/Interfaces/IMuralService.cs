using Cooperchip.ITDeveloper.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Domain.Interfaces
{
    public interface IMuralService : IDisposable
    {
        Task AdicionarMural(Mural model);
        Task AtualizarMural(Mural model);
        Task ExcluirMural(Mural model);
    }
}
