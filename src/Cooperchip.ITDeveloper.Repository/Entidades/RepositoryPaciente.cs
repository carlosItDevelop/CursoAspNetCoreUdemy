using Cooperchip.ITDeveloper.Data.ORM;
using Cooperchip.ITDeveloper.Domain.Interfaces.Entidades;
using Cooperchip.ITDeveloper.Domain.Models;
using Cooperchip.ITDeveloper.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Repository.Entidades
{
    public class RepositoryPaciente : RepositoryGeneric<Paciente, Guid>, IRepositoryDomainPaciente
    {
        private readonly ITDeveloperDbContext _ctx;

        public RepositoryPaciente(ITDeveloperDbContext ctx) : base(ctx)
        {
            this._ctx = ctx;
        }

        public async Task<IEnumerable<Paciente>> ListaPacientes() => await this._ctx.Paciente.AsNoTracking().ToArrayAsync();

        public async Task<IEnumerable<Paciente>> ListaPacientesComEstado()
        {
            return await _ctx.Paciente.Include(e => e.EstadoPaciente).AsNoTracking().ToListAsync();
        }
    }
}
