using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avansist.Web.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger _logger;

        public ErrorController(ILogger logger)
        {
            _logger = logger;
        }

        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "El recurso solicitado no existe";
                    break;
            }

            return View("Error2");
        }

        [AllowAnonymous]
        public IActionResult Error2()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            _logger.LogError($"Ruta del ERROR: {exceptionHandlerPathFeature.Path} " +
                $"Excepcion: {exceptionHandlerPathFeature.Error}" +
                $"Traza del ERROR: {exceptionHandlerPathFeature.Error.StackTrace}");

            return View("ErrorGenerico");
        }
    }
}
