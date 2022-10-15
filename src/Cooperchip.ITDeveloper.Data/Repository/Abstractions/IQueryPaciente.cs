﻿using Cooperchip.ITDeveloper.Domain.Entities;
using Cooperchip.ITDeveloper.DomainCore.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Data.Repository.Abstractions
{
    public interface IQueryPaciente : IGenericRepository<Paciente, Guid>
    {
        Task<IEnumerable<Paciente>> ListaPacientesComEstado();
        Task<IEnumerable<Paciente>> ListaPacientes();
        Task<List<EstadoPaciente>> ListaEstadoPaciente();
        Task<Paciente> ObterPacienteComEstadoPaciente(Guid pacienteId);
        bool TemPaciente(Guid pacienteId);
        Task<IEnumerable<Paciente>> ObterPacientesPorEstadoPaciente(Guid estadoPacienteId);
    }
}
