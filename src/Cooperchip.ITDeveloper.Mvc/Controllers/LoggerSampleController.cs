using KissLog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cooperchip.ITDeveloper.Mvc.Controllers
{
    public class LoggerSampleController : Controller
    {
        private readonly ILogger _logger;

        public LoggerSampleController(ILogger logger)
        {
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {

            var usuario = HttpContext.User.Identity.Name;

            _logger.Trace($"O usuário: {usuario} foi quem fez isso!");

            try
            {
                throw new Exception("ATENÇÃO: \n UM ERRO(PROPOSITAL) OCORREU. \nCONTATE O ADMINISTRADOR DO SISTEMA!");
            }
            catch (Exception e)
            {
                _logger.Error($"{e} - Usuário Logado: {usuario}");
            }

            //throw new Exception("ATENÇÃO: \n UM ERRO(PROPOSITAL) OCORREU. \nCONTATE O ADMINISTRADOR DO SISTEMA!");

            return View();
        }
    }
}