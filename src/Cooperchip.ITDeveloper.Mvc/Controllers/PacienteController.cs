using Cooperchip.ITDeveloper.Application.Interfaces;
using Cooperchip.ITDeveloper.Application.ViewModels;
using Cooperchip.ITDeveloper.Domain.Entities;
using Cooperchip.ITDeveloper.Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Mvc.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PacienteController : Controller
    {
        private readonly IServicoAplicacaoPaciente _serviceApp;

        public PacienteController(IServicoAplicacaoPaciente serviceApp)
        {
            _serviceApp = serviceApp;
        }

        // GET: Paciente
        public async Task<IActionResult> Index()
        {
            // TODO: Aqui, usando AutoMapper
            return View(await _serviceApp.ObterPacientesComEstadoPacienteApplication());
            
            // TODO: Aqui, escrevedo o mapper na mão!
            //return View(await _serviceApp.ObterPacientesDePacienteViewModelApplication());
        }


        public async Task<IActionResult> Details(Guid id)
        {
            var paciente = await _serviceApp.ObterPacienteComEstadoPacienteApplication(id);

            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        public async Task<IActionResult> ReportForEstadoPaciente(Guid id)
        {
            var pacientePorEstado = await _serviceApp.ObterPacientesPorEstadoPacienteApplication(id);

            if (pacientePorEstado == null) return NotFound();

            return View(pacientePorEstado);
        }


        public async Task<IActionResult> Create()
        {
            ViewBag.EstadoPaciente = new SelectList(await _serviceApp.ListaEstadoPacienteApplication(), "Id", "Descricao");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PacienteViewModel pacienteVM)
        {
            if (ModelState.IsValid)
            {
                await this._serviceApp.AdicionarPacienteApplication(pacienteVM);
                return RedirectToAction("Index");
            }
            ViewBag.EstadoPaciente = new SelectList(await _serviceApp.ListaEstadoPacienteApplication(), "Id", "Descricao", pacienteVM.EstadoPacienteId);
            return View(pacienteVM);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var paciente = await _serviceApp.ObterPacienteComEstadoPacienteApplication(id);
            if (paciente == null)
            {
                return NotFound();
            }
            ViewBag.EstadoPaciente = new SelectList(await _serviceApp.ListaEstadoPacienteApplication(), "Id", "Descricao", paciente.EstadoPacienteId);
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
                    await this._serviceApp.AtualizarPacienteApllication(pacienteVM);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteExists(pacienteVM.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.EstadoPaciente = new SelectList(await _serviceApp.ListaEstadoPacienteApplication(), "Id", "Descricao", pacienteVM.EstadoPacienteId);
            return View(pacienteVM);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var paciente = await _serviceApp.ObterPacienteComEstadoPacienteApplication(id);

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
            await _serviceApp.RemoverPacienteApplication(id);

            return RedirectToAction(nameof(Index));
        }

        private bool PacienteExists(Guid id)
        {
            return _serviceApp.TemPacienteApplication(id);
        }
    }
}
