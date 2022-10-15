using AutoMapper;
using Cooperchip.ITDeveloper.Data.Repository.Abstractions;
using Cooperchip.ITDeveloper.Domain.Interfaces.Repository;
using Cooperchip.ITDeveloper.Domain.Interfaces;
using Cooperchip.ITDeveloper.Mvc.ServiceApp.Settings;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Cooperchip.ITDeveloper.Mvc.ServiceApp.ViewModels;
using System.Threading.Tasks;
using System;
using Cooperchip.ITDeveloper.Domain.Entities;
using Cooperchip.ITDeveloper.Mvc.ServiceApp.Services;
using Microsoft.Extensions.Options;
using Cooperchip.ITDeveloper.Domain.Mensageria.Notifications;

namespace Cooperchip.ITDeveloper.Mvc.Controllers
{
    public class MuralController : BaseController
    {
        private readonly EmailCredentialsSettings _emailCredentialSettings;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;

        private readonly IRepositoryMural _repoMural;
        private readonly IQueryMural _queryMural;
        private readonly IMuralService _serviceMural;

        public MuralController(IOptions<EmailCredentialsSettings> emailCredentialSettings,
                               IRepositoryMural repoMural,
                               IQueryMural queryMural,
                               IMuralService serviceMural,
                               IMapper mapper,
                               IUnitOfWork uow, INotificador notificador) : base(notificador)
        {
            _emailCredentialSettings = emailCredentialSettings.Value;
            _repoMural = repoMural;
            _queryMural = queryMural;
            _serviceMural = serviceMural;
            _mapper = mapper;
            _uow = uow;
        }

        public IActionResult Index(string filtro = null)
        {
            var objBusca = _queryMural.SelecionarTodosParaMural(filtro);
            ViewBag.filtro = _queryMural.MontarSelectList(objBusca);
            return View(objBusca.Select(x => new MuralViewModel()
            {
                Id = x.Id,
                Data = x.Data,
                Autor = x.Autor,
                Aviso = x.Aviso,
                Email = x.Email,
                Titulo = x.Titulo
            }).ToList());
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var model = _mapper.Map<MuralViewModel>(await _repoMural.SelecionarPorId(id));
            if (model == null) return NotFound();

            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.DataMural = DateTime.Now;
            return View();
        }

        public ActionResult Credencial()
        {
            ViewBag.DataMural = DateTime.Now;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Credencial(MuralViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Aviso += model.Email;
                try
                {
                    await _serviceMural.AdicionarMural(_mapper.Map<Mural>(model));
                    if (!OperacaoValida()) return View(model);
                    await _uow.Commit();
                    ViewBag.Success = "Credecial requisitada com sucesso!";
                }
                catch (Exception)
                {
                    ViewBag.Erro = "Confira a digitação";
                    ModelState.AddModelError("error_sendmail", "Confira a digitação");
                    return View("Credencial");
                }

                // Todo: Decidir sobre fromEmail e toEmail
                try
                {
                    EmailService.EnviarEmail(_emailCredentialSettings.EmailSender, _emailCredentialSettings.EmailSender, "Solicitação de Credencial - Evolumed-Sys", model.Aviso, _emailCredentialSettings);
                }
                catch (Exception ex)
                {
                    ViewBag.Erro = ex.Message;
                    ModelState.AddModelError("error_sendmail", ex.Message);
                    return View("Credencial");
                }
                return RedirectToAction("Login", "Account");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MuralViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _serviceMural.AdicionarMural(_mapper.Map<Mural>(model));
                if (!OperacaoValida()) return View(model);
                await _uow.Commit();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var mural = _mapper.Map<MuralViewModel>(await _queryMural.SelecionarPorId(id));
            if (mural == null) return NotFound();

            return View(mural);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MuralViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _serviceMural.AtualizarMural(_mapper.Map<Mural>(model));
                if (!OperacaoValida()) return View(model);
                await _uow.Commit();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet("Detele")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = _mapper.Map<MuralViewModel>(await _queryMural.SelecionarPorId(id));
            if (model == null) return NotFound();

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var model = await _queryMural.SelecionarPorId(id);
            await _serviceMural.ExcluirMural(model);
            await _uow.Commit();

            return RedirectToAction("Index");
        }

    }
}
