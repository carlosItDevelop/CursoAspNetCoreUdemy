using Cooperchip.ITDeveloper.Data.ORM;
using Cooperchip.ITDeveloper.Domain.Interfaces;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ITDeveloperDbContext _context;

        public UnitOfWork(ITDeveloperDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            var success = (await _context.SaveChangesAsync()) > 0;
            return success;
        }

        public Task Rollback()
        {
            // Fazer algumas coisas,
            // tipo, Logger, avisar alguém ou algum processo...
            return Task.CompletedTask;
        }
    }
}
