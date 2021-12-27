using Avansist.Models.Entities;
using Avansist.Services.Abstract;
using Avansist.Services.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avansist.Web.Controllers
{
    //[Authorize]
    public class PadrinoController : Controller
    {
        private readonly IPadrinoServices _padrinoServices;

        public PadrinoController(IPadrinoServices padrinoServices)
        {
            _padrinoServices = padrinoServices;
        }

        //Listar Info padrino
        public IActionResult Index()
        {
            var listarPadrinos = _padrinoServices.ListarPadrinoResumenDto();
            return View(listarPadrinos);
        }

        //Crear Padrino Get
        public async Task<IActionResult> Create()
        {
            ViewData["listaTipoDocumentos"] = new SelectList(await _padrinoServices.ObtenerListaTipoDocumento(), "TipoDocumentoId", "NombreTipoDocumento");
            return View();
        }

        //Crear padrino Post
        [HttpPost]
        public async Task<IActionResult> Create(PadrinoDto padrinoDto)
        {
            if (ModelState.IsValid)
            {
                var PadrinoTem = await _padrinoServices.ObtenerPadrinoPorDocumento(padrinoDto.NumeroDocumento);
                if (PadrinoTem == null)
                {
                    Padrino padrino = new()
                    {
                        PadrinoId = padrinoDto.PadrinoId,
                        NombrePadrino = padrinoDto.NombrePadrino,
                        ApellidoPadrino = padrinoDto.ApellidoPadrino,
                        TipoDocumentoId = padrinoDto.TipoDocumentoId,
                        NumeroDocumento = padrinoDto.NumeroDocumento,
                        Ocupacion = padrinoDto.Ocupacion,
                        Telefono = padrinoDto.Telefono,
                        CorreoElectronico = padrinoDto.CorreoElectronico
                    };

                    try
                    {
                        var result = _padrinoServices.GuardarPadrino(padrinoDto);
                        return Json(new 
                        {
                            status = true
                        });
                        //return RedirectToAction(nameof(Index));
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                if (PadrinoTem != null)
                {
                    return Json(new
                    {
                        status = 500
                    });
                }
            }
            return View(padrinoDto);
        }

        //Editar padrino Get
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var padrino = await _padrinoServices.ObtenerPadrinoPorId(id.Value);
            ViewData["listaTipoDocumentos"] = new SelectList(await _padrinoServices.ObtenerListaTipoDocumento(), "TipoDocumentoId", "NombreTipoDocumento");
            if (padrino == null)
            {
                return NotFound();
            }

            return View(padrino);
        }

        //Editar padrino post
        [HttpPost]
        public async Task<IActionResult> Edit(PadrinoDto padrinoDto)
        {
            if (padrinoDto.PadrinoId == padrinoDto.PadrinoId)
            {
                if (ModelState.IsValid)
                {

                    await _padrinoServices.EditarPadrino(padrinoDto);
                    return RedirectToAction(nameof(Index));

                }
                return View(padrinoDto);
            }

            return NotFound();

        }

        //Detalle padrino
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var padrino = await _padrinoServices.ObtenerPadrinoPorId(id.Value);
            ViewData["listaTipoDocumentos"] = new SelectList(await _padrinoServices.ObtenerListaTipoDocumento(), "TipoDocumentoId", "NombreTipoDocumento");
            if (padrino == null)
            {
                return NotFound();
            }

            return View(padrino);
        }

    }
}
