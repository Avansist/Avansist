using Avansist.Services.Abstract;
using Avansist.Services.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avansist.Web.Controllers
{
    public class ControlAsistenciaController : Controller
    {
        private readonly IControlAsistenciaServices _controlAsistenciaServices;

        public ControlAsistenciaController(IControlAsistenciaServices controlAsistenciaServices)
        {
            _controlAsistenciaServices = controlAsistenciaServices;
        }

        //********************************|------------------|**********************************
        //********************************|ASISTENCIA CONTROL|**********************************
        //********************************|------------------|**********************************
        //Listar Inf Ingreso Resumen
        public IActionResult Index()
        {
            var listarControlAsistenciaDto = _controlAsistenciaServices.ListarControlAsistenciaResumenDto();
            return View(listarControlAsistenciaDto);
        }

        //Crear Ingreso Beneficiario
        public async Task<IActionResult> Create()
        {
            ViewData["listaBeneficiarios"] = new SelectList(await _controlAsistenciaServices.ObtenerListaBeneficiario(), "PreinscripcionId", "PrimerNombreBeneficiario");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create (ControlAsistenciaDto controlAsistenciaDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _controlAsistenciaServices.GuardarIngreso(controlAsistenciaDto);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return View(controlAsistenciaDto);
        }

        //Crear Salida Beneficiario
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controlIngrso = await _controlAsistenciaServices.ObtenerIngresoPorId(id.Value);
            ViewData["listaBeneficiarios"] = new SelectList(await _controlAsistenciaServices.ObtenerListaBeneficiario(), "PreinscripcionId", "PrimerNombreBeneficiario");

            if (controlIngrso == null)
            {
                return NotFound();
            }
            return View(controlIngrso);
        }

        // POST: Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit (ControlAsistenciaDto controlAsistenciaDto)
        {
            if (controlAsistenciaDto.ControlAsistenciaId == controlAsistenciaDto.ControlAsistenciaId)
            {
                if (ModelState.IsValid)
                {
                    await _controlAsistenciaServices.EditarIngreso(controlAsistenciaDto);
                    return RedirectToAction(nameof(Index));
                }
                return View(controlAsistenciaDto);
            }
            return NotFound();
        }

        //Detalle Ingreso Beneficiario
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controlIngrso = await _controlAsistenciaServices.ObtenerIngresoPorId(id.Value);
            ViewData["listaBeneficiarios"] = new SelectList(await _controlAsistenciaServices.ObtenerListaBeneficiario(), "PreinscripcionId", "PrimerNombreBeneficiario");

            if (controlIngrso == null)
            {
                return NotFound();
            }
            return View(controlIngrso);
        }
    }
}
