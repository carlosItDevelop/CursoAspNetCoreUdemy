using Cooperchip.ITDeveloper.Data.ORM;
using Cooperchip.ITDeveloper.Domain.Interfaces.Repository;
using Cooperchip.ITDeveloper.Domain.Models;
using Cooperchip.ITDeveloper.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Application.Repository
{
    public class PacienteRepository : RepositoryGeneric<Paciente, Guid>, IRepositoryPaciente
    {

        private readonly ITDeveloperDbContext _ctx;

        public PacienteRepository(ITDeveloperDbContext ctx) : base(ctx)
        {
            this._ctx = ctx;
        }


        public async Task<IEnumerable<Paciente>> ListaPacientes() => await this._ctx.Paciente.AsNoTracking().ToArrayAsync();

        public async Task<IEnumerable<Paciente>> ListaPacientesComEstado()
        {
            return await _ctx.Paciente.Include(e => e.EstadoPaciente).AsNoTracking().ToListAsync();
        }

        public List<EstadoPaciente> ListaEstadoPaciente()
        {
            return this._ctx.EstadoPaciente.AsNoTracking().ToListAsync().Result;
        }

        public async Task<Paciente> ObterPacienteComEstadoPaciente(Guid pacienteId)
        {
            return await _ctx.Paciente.Include(e => e.EstadoPaciente).AsNoTracking().FirstOrDefaultAsync(x => x.Id == pacienteId);
        }

        public bool TemPaciente(Guid pacienteId)
        {
            return _ctx.Paciente.Any(x => x.Id == pacienteId);
        }

        public async Task<IEnumerable<Paciente>> ObterPacientesPorEstadoPaciente(Guid estadoPacienteId)
        {
            var lista = await _ctx.Paciente
                .Include(ep => ep.EstadoPaciente)
                .AsNoTracking()
                .Where(x => x.EstadoPaciente.Id == estadoPacienteId)
                .OrderBy(order => order.Nome).ToListAsync();

            return lista;

        }
    }
}
