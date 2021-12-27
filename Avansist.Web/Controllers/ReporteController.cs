using Avansist.DAL;
using Avansist.Web.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avansist.Web.Controllers
{
    //[Authorize]
    public class ReporteController : Controller
    {
        private readonly AvansistDbContext _context;

        public ReporteController(AvansistDbContext context)
        {
            _context = context;
        }

        //**********************************|--------------|**********************************
        //*****************************|MATRICULADOS VS RETIRADOS|****************************
        //**********************************|--------------|**********************************
        //METODO GET
        public IActionResult MatriculadosVSRetirados()
        {
            return View();
        }

        //METODO POST
        [HttpPost]
        public IActionResult MatriculadosVSRetirados(ReporteViewModel model)
        {
            var estado4 = _context.Preinscripcions.Where(r => r.EstadoId == 4).
                Where(f => f.FechaMatricula >= model.FechaInicioReporte && f.FechaMatricula <= model.FechaFinReporte).Count();

            var estado5 = _context.Preinscripcions.Where(r => r.EstadoId == 5).
                Where(f => f.FechaRetiro >= model.FechaInicioReporte && f.FechaRetiro <= model.FechaFinReporte).Count();

            return Json(new { estado4, estado5 });
        }

        //**********************************|--------------|**********************************
        //*****************************|APROBADOS VS MATRICULADOS|****************************
        //**********************************|--------------|**********************************
        //METODO GET
        public IActionResult SolicitudesAprobadasVSMatriculados()
        {
            return View();
        }

        //METODO POST
        [HttpPost]
        public IActionResult SolicitudesAprobadasVSMatriculados(ReporteViewModel model)
        {
            var estado2 = _context.Preinscripcions.Where(r => r.EstadoId == 2).
                Where(f => f.FechaRegistro >= model.FechaInicioReporte && f.FechaRegistro <= model.FechaFinReporte).Count();

            var estado4 = _context.Preinscripcions.Where(r => r.EstadoId == 4).
                Where(f => f.FechaMatricula >= model.FechaInicioReporte && f.FechaMatricula <= model.FechaFinReporte).Count();

            return Json(new { estado2, estado4 });
        }

        //**********************************|--------------|**********************************
        //*****************************|APROBADOS VS NO APROBADOS|****************************
        //**********************************|--------------|**********************************
        //METODO GET
        public IActionResult AprobadosVSNoAProbados()
        {
            return View();
        }

        //METODO POST
        [HttpPost]
        public IActionResult AprobadosVSNoAProbados(ReporteViewModel model)
        {
            var estado2 = _context.Preinscripcions.Where(r => r.EstadoId == 2).
                Where(f => f.FechaRegistro >= model.FechaInicioReporte && f.FechaRegistro <= model.FechaFinReporte).Count();

            var estado4 = _context.Preinscripcions.Where(r => r.EstadoId == 2).
                Where(f => f.FechaMatricula >= model.FechaInicioReporte && f.FechaMatricula <= model.FechaFinReporte).Count();

            return Json(new { estado2, estado4 });
        }
    }
}
