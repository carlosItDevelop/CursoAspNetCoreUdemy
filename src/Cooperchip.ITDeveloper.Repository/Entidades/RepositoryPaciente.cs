using Cooperchip.ITDeveloper.Data.ORM;
using Cooperchip.ITDeveloper.Domain.Interfaces.Entidades;
using Cooperchip.ITDeveloper.Domain.Models;
using Cooperchip.ITDeveloper.Repository.Base;
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

        public Task<IEnumerable<Paciente>> ListaPacientes()
        {
            return null;
        }

        public Task<IEnumerable<Paciente>> ListaPacientesComEstado()
        {
            return null;
        }
    }
}
