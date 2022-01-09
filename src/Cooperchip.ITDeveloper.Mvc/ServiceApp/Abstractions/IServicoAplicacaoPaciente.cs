using Cooperchip.ITDeveloper.Application.ViewModels;
using Cooperchip.ITDeveloper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Mvc.ServiceApp.Abstractions
{
    public interface IServicoAplicacaoPaciente
    {
        /* Queries */
        Task<IEnumerable<PacienteViewModel>> ObterPacientesComEstadoPacienteApplication();
        Task<IEnumerable<PacienteViewModel>> ObterPacientesDePacienteViewModelApplication();
        Task<PacienteViewModel> ObterPacienteComEstadoPacienteApplication(Guid pacienteId);
        Task<IEnumerable<PacienteViewModel>> ObterPacientesPorEstadoPacienteApplication(Guid estadoPacienteId);
        Task<List<EstadoPaciente>> ListaEstadoPacienteApplication();
        bool TemPacienteApplication(Guid pacienteId);


        /* Commands */

        Task AdicionarPacienteApplication(PacienteViewModel pacienteViewModel);
        Task AtualizarPacienteApllication(PacienteViewModel pacienteViewModel);
        Task RemoverPacienteApplication(Guid id);


    }
}
