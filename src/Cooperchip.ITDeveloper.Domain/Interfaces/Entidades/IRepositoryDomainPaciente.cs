using Cooperchip.ITDeveloper.Domain.Models;
using Cooperchip.ITDeveloper.DomainCore.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Domain.Interfaces.Entidades
{
    public interface IRepositoryDomainPaciente : IDomainGenericRepository<Paciente, Guid>
    {
        Task<IEnumerable<Paciente>> ListaPacientesComEstado();
        Task<IEnumerable<Paciente>> ListaPacientes();

        // ListaEstadosDePaciente()
        // ListaEstadoDePacientePorPaciente( Guid PacienteId )
    }
}
