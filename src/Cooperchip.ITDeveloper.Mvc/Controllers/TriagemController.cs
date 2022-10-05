using AutoMapper;
using Cooperchip.ITDeveloper.Domain.Entities;
using Cooperchip.ITDeveloper.Domain.Interfaces;
using Cooperchip.ITDeveloper.Domain.Interfaces.Repository;
using Cooperchip.ITDeveloper.Domain.Mensageria.Notifications;
using Cooperchip.ITDeveloper.Mvc.ServiceApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Mvc.Controllers
{
    public class TriagemController : BaseController
    {
        private readonly IRepositoryTriagem _repoTriagem;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public TriagemController(IRepositoryTriagem repoTriagem,
                                                      IUnitOfWork uow,
                                                      IMapper mapper,
                                                      INotificador notificador): base(notificador)
        {
            _repoTriagem = repoTriagem;
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet("listagem-notificacoes")]
        public async Task<IActionResult> Index()
        {
            var lista = _mapper.Map<IEnumerable<TriagemViewModel>>(await _repoTriagem.SelecionarTodos());
            return View(lista);
        }

        [HttpGet("triagem-para-prontuario/{id:guid}")]
        public async Task<IActionResult> Triagem(Guid id)
        {
            var triagem = _mapper.Map<TriagemViewModel>(await _repoTriagem.ObterTriagemPorId(id));

            if (triagem == null) return BadRequest();

            return View(triagem);
        }

        [HttpGet("nova-triagem")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("nova-triagem")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TriagemViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await this._repoTriagem.Inserir(_mapper.Map<Triagem>(viewModel));
                if (!OperacaoValida()) return View(viewModel);

                await _uow.Commit();

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        [HttpGet("excluir-triagem/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var triagem = _mapper.Map<TriagemViewModel>(await _repoTriagem.ObterTriagemPorId(id));

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
