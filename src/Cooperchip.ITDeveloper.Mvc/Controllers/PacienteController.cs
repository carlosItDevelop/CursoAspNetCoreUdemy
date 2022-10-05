using AutoMapper;
using Cooperchip.ITDeveloper.Application.ViewModels;
using Cooperchip.ITDeveloper.Data.Repository.Abstractions;
using Cooperchip.ITDeveloper.Domain.Entities;
using Cooperchip.ITDeveloper.Domain.Interfaces;
using Cooperchip.ITDeveloper.Domain.Interfaces.ServiceContracts;
using Cooperchip.ITDeveloper.Domain.Mensageria.EventPublish;
using Cooperchip.ITDeveloper.Domain.Mensageria.Notifications;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Mvc.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PacienteController : BaseController
    {

        // Unit Of Work Pattern Applicated
        private readonly IUnitOfWork _uow;

        // (query) - Get ==> Fala diretamente com a Data Layer
        private readonly IQueryPaciente _queryRepo;

        // (Command) - Post, Put, Patch, Delete - Fala com Domain
        private readonly IPacienteDomainService _serviceDomain;

        // Cuida do Mapeamento Model/ViewModel & Reverse,
        // antes de passar para Repositório ou Seviços de Domain
        private readonly IMapper _mapper;

        public PacienteController(IQueryPaciente queryRepo,
                                  IPacienteDomainService serviceDomain,
                                  IMapper mapper,
                                  IUnitOfWork uow,
                                  INotificador notificador) : base(notificador)
        {
            _queryRepo = queryRepo;
            _serviceDomain = serviceDomain;
            _mapper = mapper;
            _uow = uow;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var pacientes = await _queryRepo.ListaPacientesComEstado();
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
            return View(listaView);

        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var paciente = _mapper.Map<PacienteViewModel>(await _queryRepo.ObterPacienteComEstadoPaciente(id));

            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        [HttpGet]
        public async Task<IActionResult> ReportForEstadoPaciente(Guid id)
        {
            var pacientePorEstado = _mapper.Map<IEnumerable<PacienteViewModel>>(await _queryRepo.ObterPacientesPorEstadoPaciente(id));

            if (pacientePorEstado == null) return NotFound();

            return View(pacientePorEstado);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.EstadoPaciente = new SelectList(await _queryRepo.ListaEstadoPaciente(), "Id", "Descricao");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PacienteViewModel pacienteVM)
        {
            if (ModelState.IsValid)
            {
                await _serviceDomain.AdicionarPaciente(_mapper.Map<Paciente>(pacienteVM));
                if (!OperacaoValida()) return View(pacienteVM);
                // Outros processos dentro do mesmo repositório / AggregateRoot
                await _uow.Commit();

                TempData["Sucesso"] = "Registro cadastrado com sucesso!";
                return RedirectToAction("Index");
            }

            ViewBag.EstadoPaciente = new SelectList(await _queryRepo.ListaEstadoPaciente(), "Id", "Descricao", pacienteVM.EstadoPacienteId);
            return View(pacienteVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var paciente = _mapper.Map<PacienteViewModel>(await _queryRepo.ObterPacienteComEstadoPaciente(id));
            if (paciente == null)
            {
                return NotFound();
            }
            ViewBag.EstadoPaciente = new SelectList(await _queryRepo.ListaEstadoPaciente(), "Id", "Descricao", paciente.EstadoPacienteId);
            return View(paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, PacienteViewModel pacienteVM)
        {
            if (id != pacienteVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _serviceDomain.AtualizarPaciente(_mapper.Map<Paciente>(pacienteVM));
                    if (!OperacaoValida()) return View(pacienteVM);
                    // Outros processos dentro do mesmo repositório / Agregate Root
                    // ...
                    // ...

                    await _uow.Commit();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteExists(pacienteVM.Id))
                    {
                        await _uow.Rollback();
                        return NotFound();
                    }
                    else
                    {
                        await _uow.Rollback();
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.EstadoPaciente = new SelectList(await _queryRepo.ListaEstadoPaciente(), "Id", "Descricao", pacienteVM.EstadoPacienteId);
            return View(pacienteVM);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var paciente = _mapper.Map<PacienteViewModel>(await _queryRepo.ObterPacienteComEstadoPaciente(id));

            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var paciente = await _queryRepo.SelecionarPorId(id);
            await _serviceDomain.ExcluirPaciente(paciente);

            // Outros processos dentro do mesmo repositório / Agregate Root
            // ...
            // ...

            await _uow.Commit();

            return RedirectToAction(nameof(Index));
        }

        private bool PacienteExists(Guid id)
        {
            return _queryRepo.TemPaciente(id);
        }
    }
}
