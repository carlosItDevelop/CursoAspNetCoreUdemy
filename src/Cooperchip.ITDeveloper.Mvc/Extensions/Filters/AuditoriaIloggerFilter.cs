using System;
using KissLog;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Cooperchip.ITDeveloper.Mvc.Extensions.Filters
{
    public class AuditoriaIloggerFilter : IActionFilter
    {
        private readonly ILogger _logger;
        public AuditoriaIloggerFilter(ILogger logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Todo: Logar algo antes / durante a execução;
            _logger.Info($"Url Acessada: {context.HttpContext.Request.GetDisplayUrl()} \n\n_________________________________________\n\n");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Todo: Poderia gravar em JSON, gravar numa base de dados, Gravar exceções
            // Todo: Após a Ação vamos auditar.
            // Todo: Só vou logar quem estiver autenticado.
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var user = context.HttpContext.User.Identity.Name;
                var tipoAuth = context.HttpContext.User.Identity.AuthenticationType;
                var urlAcessada = context.HttpContext.Request.GetDisplayUrl();
                var valueHost = context.HttpContext.Request.Host.Value;
                var tipoContent = context.HttpContext.Request.ContentType;

                var logMsg = $"O usuário {user} acessou a Url: {urlAcessada} \nEm {DateTime.Now}\n";
                logMsg += "=================================================================";
                logMsg += $"{valueHost}\n{tipoContent}\nTipo de Autenticação: {tipoAuth}";


                _logger.Info(logMsg);


            }
        }

    }
}