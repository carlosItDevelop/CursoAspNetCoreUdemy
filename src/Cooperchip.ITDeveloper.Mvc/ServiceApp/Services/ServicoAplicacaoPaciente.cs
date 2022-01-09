using AutoMapper;
using Cooperchip.ITDeveloper.Application.ViewModels;
using Cooperchip.ITDeveloper.Domain.Entities;
using Cooperchip.ITDeveloper.Domain.Interfaces;
using Cooperchip.ITDeveloper.Domain.Interfaces.Repository;
using Cooperchip.ITDeveloper.Mvc.ServiceApp.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Mvc.ServiceApp.Services
{
    public class ServicoAplicacaoPaciente : IServicoAplicacaoPaciente
    {
        // (query) - Get ==> Fala diretamente com o Repository
        private readonly IRepositoryPaciente _repoPaciente;

        // (Command) - Post, Put, Patch, Delete - Fala com Domain
        private readonly IPacienteDomainService _serviceDomain;

        // Cuida do Mapeamento Model/ViewModel & Reverse,
        // antes de passar para Repositório ou Seviços de Domain
        private readonly IMapper _mapper;

        public ServicoAplicacaoPaciente(IRepositoryPaciente repoPaciente,
                                        IMapper mapper, IPacienteDomainService serviceDomain)
        {
            _repoPaciente = repoPaciente;
            _mapper = mapper;
            _serviceDomain = serviceDomain;
        }

        public async Task<PacienteViewModel> ObterPacienteComEstadoPacienteApplication(Guid pacienteId)
        {
            return _mapper.Map<PacienteViewModel>(await _repoPaciente.ObterPacienteComEstadoPaciente(pacienteId));
        }

        #region: Queries methods 
        public async Task<IEnumerable<PacienteViewModel>> ObterPacientesComEstadoPacienteApplication()
        {
            return _mapper.Map<IEnumerable<PacienteViewModel>>(await _repoPaciente.ListaPacientesComEstado());
        }

        public async Task<IEnumerable<PacienteViewModel>> ObterPacientesPorEstadoPacienteApplication(Guid estadoPacienteId)
        {
            return _mapper.Map<IEnumerable<PacienteViewModel>>(await _repoPaciente.ObterPacientesPorEstadoPaciente(estadoPacienteId));
        }

        public async Task<List<EstadoPaciente>> ListaEstadoPacienteApplication()
        {
            return await _repoPaciente.ListaEstadoPaciente();
        }

        public bool TemPacienteApplication(Guid pacienteId)
        {
            return _repoPaciente.TemPaciente(pacienteId);
        }


        #region: mapper na mão
        public async Task<IEnumerable<PacienteViewModel>> ObterPacientesDePacienteViewModelApplication()
        {
            var pacientes = await _repoPaciente.ListaPacientesComEstado();
            List<PacienteViewModel> listaView = new List<PacienteViewModel>();
            foreach (var item in pacientes)
            {
                listaView.Add(new PacienteViewModel
                {
                    Ativo = item.Ativo,
                    Cpf = item.Cpf,
                    DataInternacao = item.DataInternacao,
                    DataNascimento = item.DataNascimento,
                    Email = item.Email,
                    EstadoPaciente = item.EstadoPaciente,
                    EstadoPacienteId = item.EstadoPacienteId,
                    Id = item.Id,
                    Nome = item.Nome,
                    Rg = item.Rg,
                    RgDataEmissao = item.RgDataEmissao,
                    RgOrgao = item.RgOrgao,
                    Sexo = item.Sexo,
                    TipoPaciente = item.TipoPaciente,
                    Motivo = item.Motivo
                });
            }
            return listaView;
        }

        // =======================================================================
        /* ===/ Estes três métodos abaixo delegam a responsabilidade para os Domain Srvices, 
         * pois lá haverá as validações de Regra de Negócios; 
         */
        public async Task AdicionarPacienteApplication(PacienteViewModel pacienteViewModel)
        {
            await _serviceDomain.AdicionarPaciente(_mapper.Map<Paciente>(pacienteViewModel));
        }

        public async Task AtualizarPacienteApllication(PacienteViewModel pacienteViewModel)
        {
            await _serviceDomain.AtualizarPaciente(_mapper.Map<Paciente>(pacienteViewModel));
        }

        public async Task RemoverPacienteApplication(Guid id)
        {
            var paciente = await _repoPaciente.SelecionarPorId(id);
            await _serviceDomain.ExcluirPaciente(paciente);
        }

        #endregion

        #endregion
    }
}
