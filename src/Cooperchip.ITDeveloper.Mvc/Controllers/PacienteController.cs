using Cooperchip.ITDeveloper.Domain.Interfaces.Repository;
using Cooperchip.ITDeveloper.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Mvc.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PacienteController : Controller
    {
        private readonly IRepositoryPaciente _repoPaciente;

        public PacienteController(IRepositoryPaciente repoPaciente)
        {
            this._repoPaciente = repoPaciente;
        }

        // GET: Paciente
        public async Task<IActionResult> Index()
        {
            return View(await _repoPaciente.ListaPacientesComEstado());
        }


        public async Task<IActionResult> Details(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var paciente = await this._repoPaciente.ObterPacienteComEstadoPaciente(id);

            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        public async Task<IActionResult> ReportForEstadoPaciente(Guid? id)
        {
            if (id.Value == null) return NotFound();

            var pacientePorEstado = await this._repoPaciente.ObterPacientesPorEstadoPaciente(id.Value);

            if (pacientePorEstado == null) return NotFound();

            return View(pacientePorEstado);
        }


        public IActionResult Create()
        {
            ViewBag.EstadoPaciente = new SelectList(_repoPaciente.ListaEstadoPaciente(), "Id", "Descricao");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                //paciente.Id = Guid.NewGuid(); // Não Usar
                await this._repoPaciente.Inserir(paciente);
                return RedirectToAction("Index");
            }
            ViewBag.EstadoPaciente = new SelectList(_repoPaciente.ListaEstadoPaciente(), "Id", "Descricao", paciente.EstadoPacienteId);
            return View(paciente);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id.Value == null)
            {
                return NotFound();
            }

            var paciente = await  _repoPaciente.SelecionarPorId(id.Value);
            if (paciente == null)
            {
                return NotFound();
            }
            ViewBag.EstadoPaciente = new SelectList(_repoPaciente.ListaEstadoPaciente(), "Id", "Descricao", paciente.EstadoPacienteId);
            return View(paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Paciente paciente)
        {
            if (id != paciente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await this._repoPaciente.Atualizar(paciente);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteExists(paciente.Id))
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
            ViewBag.EstadoPaciente = new SelectList(_repoPaciente.ListaEstadoPaciente(), "Id", "Descricao", paciente.EstadoPacienteId);
            return View(paciente);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var paciente = await _repoPaciente.ObterPacienteComEstadoPaciente(id);

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
            await _repoPaciente.ExcluirPorId(id);

            return RedirectToAction(nameof(Index));
        }

        private bool PacienteExists(Guid id)
        {
            return _repoPaciente.TemPaciente(id);
        }
    }
}
