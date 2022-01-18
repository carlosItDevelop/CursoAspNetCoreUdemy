using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
        Task Rollback();
    }
}
