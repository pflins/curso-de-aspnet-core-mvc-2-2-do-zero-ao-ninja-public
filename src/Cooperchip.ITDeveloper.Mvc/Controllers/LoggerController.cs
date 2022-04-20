using System;
using KissLog;
using Microsoft.AspNetCore.Authorization;
//using Microsoft.Extensions.Logging; // Opção log nativo
using Microsoft.AspNetCore.Mvc;

namespace Cooperchip.ITDeveloper.Mvc.Controllers
{
    public class LoggerController : Controller
    {
        private readonly ILogger _logger;

        public LoggerController(ILogger logger) 
        {
            _logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            var usuario = HttpContext.User.Identity.Name;

            _logger.Trace(message: $"o usuário: { usuario } foi quem fez isso!");

            try
            {
                throw new Exception(message: "ATENÇÃO: \n UM ERRO (PROPOSITAL) OCORREU. \nCONTATE O ADMINISTRADOR DO SISTEMA!");
            }
            catch (Exception e)
            {
                _logger.Error(message: $"{e} - Usuário Logado: { usuario }");
            }

            /* Força o ERRO */
            //throw new Exception(message: "ATENÇÃO: \n UM ERRO (PROPOSITAL) OCORREU. \nCONTATE O ADMINISTRADOR DO SISTEMA!");
            /**/

            return View();
        }
    }

    /* Using KissLog before [Authorize] */
    //public class LoggerController : Controller
    //{
    //    private readonly ILogger _logger;

    //    public LoggerController(ILogger logger)
    //    {
    //        _logger = logger;
    //    }

    //    public IActionResult Index()
    //    {
    //        var msgLogger = "ATENÇÃO: \n UM ERRO (PROPOSITAL) OCORREU!";

    //        if (HttpContext.User.Identity.IsAuthenticated)
    //        {
    //            _logger.Trace(message: $"o usuário: {HttpContext.User.Identity.Name} foi quem fez isso!");
    //        }

    //        try
    //        {
    //            throw new Exception(message: msgLogger);
    //        }
    //        catch (Exception e)
    //        {
    //            _logger.Error(message: $"{e} - {HttpContext.User.Identity.Name}");
    //        }

    //        return View();
    //    }
    //}

    /* Using Native Logger */
    //public class LoggerController : Controller
    //{
    //    private readonly ILogger<LoggerController> _logger;

    //    public LoggerController(ILogger<LoggerController> logger)
    //    {
    //        _logger = logger;
    //    }

    //    public IActionResult Index()
    //    {
    //        var msgLogger = "TESTANDO EXIBIÇÃO DE LOGGER!";

    //        Opção log nativo
    //        _logger.Log(LogLevel.Critical, msgLogger);
    //        _logger.Log(LogLevel.Warning, msgLogger);
    //        _logger.Log(LogLevel.Trace, msgLogger);
    //        _logger.LogError(msgLogger);

    //        try
    //        {
    //            throw new Exception(message: "UMA EXCEÇÃO FOI GERADA PARA TESTE DE AUDITORIA!");
    //        }
    //        catch (Exception e)
    //        {
    //            _logger.LogError(e.Message);
    //        }

    //        ViewData["msgLogger"] = msgLogger;

    //        return View();
    //    }
    //}
}
