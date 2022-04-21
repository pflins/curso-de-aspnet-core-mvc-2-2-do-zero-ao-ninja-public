using KissLog;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cooperchip.ITDeveloper.Mvc.Extentions.Filter
{
    public class AuditoriaILoggerFilter : IActionFilter
    {
        private readonly ILogger _logger;

        public AuditoriaILoggerFilter(ILogger logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Logar algo antes da execução
            _logger.Info(message: $"Url Acessada: {context.HttpContext.Request.GetDisplayUrl()} \n\n________________________________________________\n\n");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var user = context.HttpContext.User.Identity.Name;
                var tipoAuth = context.HttpContext.User.Identity.AuthenticationType;
                var urlAcessada = context.HttpContext.Request.GetDisplayUrl();
                var valueHost = context.HttpContext.Request.Host.Value;
                var tipoContent = context.HttpContext.Request.ContentType;

                var logMsg = $"O usuário {user} acessou a Url {urlAcessada} \nEm: {DateTime.Now} \n============================================================\n{valueHost}\n{tipoContent}\nTipo de Autenticação: {tipoAuth}";

                _logger.Info(logMsg);
            }
        }

    }
}
