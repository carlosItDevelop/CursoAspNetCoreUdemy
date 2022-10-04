using AutoMapper;
using Cooperchip.ITDeveloper.Domain.Entities;
using Cooperchip.ITDeveloper.Domain.Interfaces;
using Cooperchip.ITDeveloper.Domain.Interfaces.Repository;
using Cooperchip.ITDeveloper.Mvc.ServiceApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Mvc.Controllers
{
    public class TriagemController : Controller
    {
        private readonly IRepositoryTriagem _repoTriagem;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public TriagemController(IRepositoryTriagem appTriagem,
                                 IUnitOfWork uow,
                                 IMapper mapper)
        {
            _repoTriagem = appTriagem;
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet("listagem-notificacoes")]
        public async Task<IActionResult> Index()
        {
            var lista = await _repoTriagem.SelecionarTodos();
            return View(lista);
        }

        [HttpGet("triagem-para-prontuario/{id:guid}")]
        public async Task<IActionResult> Triagem(Guid id)
        {
            var triagem = await _repoTriagem.ObterTriagemPorId(id);

            if (triagem == null) return BadRequest();

            return View(triagem);
        }

        [HttpGet("nova-triagem")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("adicionando-triagem")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TriagemViewModel model)
        {
            if (ModelState.IsValid)
            {
                await this._repoTriagem.Inserir(_mapper.Map<Triagem>(model));
                await _uow.Commit();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet("excluir-triagem/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var triagem = await _repoTriagem.ObterTriagemPorId(id);

            if (triagem == null)
            {
                return NotFound();
            }

            return View(triagem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _repoTriagem.ExcluirPorId(id);
            await _uow.Commit();

            return RedirectToAction(nameof(Index));
        }

    }
}
