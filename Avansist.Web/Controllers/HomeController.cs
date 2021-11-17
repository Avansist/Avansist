using Avansist.Services.Abstract;
using Avansist.Services.DTOs;
using Avansist.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Avansist.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICalendarioServices _calendarioServices;

        public HomeController(ILogger<HomeController> logger, ICalendarioServices calendarioServices)
        {
            _logger = logger;
            _calendarioServices = calendarioServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AgendaDto agendaDto)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { status = false });
            }

            await _calendarioServices.GuardarEvento(agendaDto);

            return Json(new { status = true });
        }

        public IActionResult Listar()
        {
            try
            {
                var listarAgenda = _calendarioServices.ListarEvento();
                return Json(new { status = true, data = listarAgenda });
            }
            catch (Exception)
            {

                return Json(new { status = false });
            }
        }


        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _calendarioServices.ObtenerAgendaPorId(id.Value);
            if (!ModelState.IsValid)
            {
                return Json(new { status = false });
            }

            return Json(new { status = true, data = agenda });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AgendaDto agendaDto)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { status = false });
            }
            await _calendarioServices.EditarEvento(agendaDto);
            return Json(new { status = true });
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _calendarioServices.ObtenerIdParaEliminar(id.Value);
            if (!ModelState.IsValid)
            {
                return Json(new { status = false });
            }

            await _calendarioServices.EliminarEvento(agenda);

            return Json(new { status = true });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
