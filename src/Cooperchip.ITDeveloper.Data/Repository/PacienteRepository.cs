using Cooperchip.ITDeveloper.Data.ORM;
using Cooperchip.ITDeveloper.Data.Repository.Abstractions;
using Cooperchip.ITDeveloper.Data.Repository.Base;
using Cooperchip.ITDeveloper.Domain.Entities;
using Cooperchip.ITDeveloper.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Data.Repository
{
    public class PacienteRepository : GenericRepository<Paciente, Guid>, IRepositoryPaciente, IQueryPaciente
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

        public async Task<List<EstadoPaciente>> ListaEstadoPaciente()
        {
            return await _context.EstadoPaciente.AsNoTracking().ToListAsync();
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

        public async Task InserirPacienteComEstadoPaciente(Paciente paciente)
        {
            paciente.EstadoPaciente = await _context.EstadoPaciente.FindAsync(paciente.EstadoPacienteId);
            _context.Set<Paciente>().Add(paciente);
            //await _context.SaveChangesAsync();
        }

    }
}
