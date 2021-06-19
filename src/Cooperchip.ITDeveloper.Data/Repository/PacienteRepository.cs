using Cooperchip.ITDeveloper.Data.ORM;
using Cooperchip.ITDeveloper.Data.Repository.Base;
using Cooperchip.ITDeveloper.Domain.Interfaces.Repository;
using Cooperchip.ITDeveloper.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Data.Repository
{
    public class PacienteRepository : RepositoryGeneric<Paciente, Guid>, IRepositoryPaciente
    {

        public PacienteRepository(ITDeveloperDbContext ctx) : base(ctx)
        {
            _context = ctx;
        }


        public async Task<IEnumerable<Paciente>> ListaPacientes() => await _context.Paciente.AsNoTracking().ToArrayAsync();

        public async Task<IEnumerable<Paciente>> ListaPacientesComEstado()
        {
            return await _context.Paciente.Include(e => e.EstadoPaciente).AsNoTracking().ToListAsync();
        }

        public List<EstadoPaciente> ListaEstadoPaciente()
        {
            return _context.EstadoPaciente.AsNoTracking().ToListAsync().Result;
        }

        public async Task<Paciente> ObterPacienteComEstadoPaciente(Guid pacienteId)
        {
            return await _context.Paciente.Include(e => e.EstadoPaciente).AsNoTracking().FirstOrDefaultAsync(x => x.Id == pacienteId);
        }

        public bool TemPaciente(Guid pacienteId)
        {
            return _context.Paciente.Any(x => x.Id == pacienteId);
        }

        public async Task<IEnumerable<Paciente>> ObterPacientesPorEstadoPaciente(Guid estadoPacienteId)
        {
            var lista = await _context.Paciente
                .Include(ep => ep.EstadoPaciente)
                .AsNoTracking()
                .Where(x => x.EstadoPaciente.Id == estadoPacienteId)
                .OrderBy(order => order.Nome).ToListAsync();

            return lista;

        }
    }
}
