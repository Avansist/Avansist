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
    public class PreinscripcionController : Controller
    {
        private readonly IPreinscripcionServices _preinscripcionServices;

        public PreinscripcionController(IPreinscripcionServices preinscripcionServices)
        {
            _preinscripcionServices = preinscripcionServices;
        }

        //**********************************|--------------|**********************************
        //**********************************|PREINSCRIPCION|**********************************
        //**********************************|--------------|**********************************
        //Listar Inf Beneficiario Resumen
        public IActionResult Index()
        {
            var listarBeneficiariosDtos = _preinscripcionServices.ListarBeneficiarioResumenDto();
            return View(listarBeneficiariosDtos);
        }

        //Crear Preinscripción Beneficiario
        public async Task<IActionResult> Create()
        {
            ViewData["listaTipoDocumentos"] = new SelectList(await _preinscripcionServices.ObtenerListaTipoDocumento(), "TipoDocumentoId", "NombreTipoDocumento");
            ViewData["listaGeneros"] = new SelectList(await _preinscripcionServices.ObtenerListaGenero(), "GeneroId", "NombreGenero");
            ViewData["listaGrupoSanguineos"] = new SelectList(await _preinscripcionServices.ObtenerListaGrupoSanguineo(), "GrupoSanguineoId", "Rh");
            ViewData["listaModalidads"] = new SelectList(await _preinscripcionServices.ObtenerListaModalidad(), "ModalidadId", "NombreModalidad");
            ViewData["listaEtnias"] = new SelectList(await _preinscripcionServices.ObtenerListaEtnia(), "EtniaId", "NombreEtnia");
            ViewData["listaJornadas"] = new SelectList(await _preinscripcionServices.ObtenerListaJornada(), "JornadaId", "NombreJornada");
            ViewData["listaPadrinos"] = new SelectList(await _preinscripcionServices.ObtenerListaPadrinos(), "PadrinoId", "NombrePadrino");
            ViewData["listaEstados"] = new SelectList(await _preinscripcionServices.ObtenerListaEstados(), "EstadoId", "NombreEstado");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PreinscripcionDto preinscripcionDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _preinscripcionServices.GuardarBeneficiario(preinscripcionDto);
                    return Json(new { status = true });
                }
                catch (Exception)
                {
                    return View(preinscripcionDto);
                }
            }
            return Json(new { status = false });
        }

        //Editar Preinscripción Beneficiario
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiario = await _preinscripcionServices.ObtenerBeneficiarioPorId(id.Value);
            ViewData["listaTipoDocumentos"] = new SelectList(await _preinscripcionServices.ObtenerListaTipoDocumento(), "TipoDocumentoId", "NombreTipoDocumento");
            ViewData["listaGeneros"] = new SelectList(await _preinscripcionServices.ObtenerListaGenero(), "GeneroId", "NombreGenero");
            ViewData["listaGrupoSanguineos"] = new SelectList(await _preinscripcionServices.ObtenerListaGrupoSanguineo(), "GrupoSanguineoId", "Rh");
            ViewData["listaModalidads"] = new SelectList(await _preinscripcionServices.ObtenerListaModalidad(), "ModalidadId", "NombreModalidad");
            ViewData["listaEtnias"] = new SelectList(await _preinscripcionServices.ObtenerListaEtnia(), "EtniaId", "NombreEtnia");
            ViewData["listaJornadas"] = new SelectList(await _preinscripcionServices.ObtenerListaJornada(), "JornadaId", "NombreJornada");
            ViewData["listaPadrinos"] = new SelectList(await _preinscripcionServices.ObtenerListaPadrinos(), "PadrinoId", "NombrePadrino");
            ViewData["listaEstados"] = new SelectList(await _preinscripcionServices.ObtenerListaEstados(), "EstadoId", "NombreEstado");
            if (beneficiario == null)
            {
                return NotFound();
            }

            return View(beneficiario);
        }

        // POST: Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(PreinscripcionDto preinscripcionDto)
        {
            if (preinscripcionDto.PreinscripcionId == preinscripcionDto.PreinscripcionId)
            {
                if (ModelState.IsValid)
                {
                    await _preinscripcionServices.EditarBeneficiario(preinscripcionDto);
                    return RedirectToAction(nameof(Index));
                }
                return View(preinscripcionDto);
            }
            return NotFound();
        }

        //Detalle Preinscripción Beneficiario
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiario = await _preinscripcionServices.ObtenerBeneficiarioPorId(id.Value);
            ViewBag.beneficiarioId = beneficiario.PreinscripcionId;
            ViewBag.TipoDocumento = beneficiario.NombreTipoDocumento;
            ViewData["listaTipoDocumentos"] = new SelectList(await _preinscripcionServices.ObtenerListaTipoDocumento(), "TipoDocumentoId", "NombreTipoDocumento");
            ViewData["listaGeneros"] = new SelectList(await _preinscripcionServices.ObtenerListaGenero(), "GeneroId", "NombreGenero");
            ViewData["listaGrupoSanguineos"] = new SelectList(await _preinscripcionServices.ObtenerListaGrupoSanguineo(), "GrupoSanguineoId", "Rh");
            ViewData["listaModalidads"] = new SelectList(await _preinscripcionServices.ObtenerListaModalidad(), "ModalidadId", "NombreModalidad");
            ViewData["listaEtnias"] = new SelectList(await _preinscripcionServices.ObtenerListaEtnia(), "EtniaId", "NombreEtnia");
            ViewData["listaJornadas"] = new SelectList(await _preinscripcionServices.ObtenerListaJornada(), "JornadaId", "NombreJornada");
            ViewData["listaPadrinos"] = new SelectList(await _preinscripcionServices.ObtenerListaPadrinos(), "PadrinoId", "NombrePadrino");
            ViewData["listaEstados"] = new SelectList(await _preinscripcionServices.ObtenerListaEstados(), "EstadoId", "NombreEstado");
            if (beneficiario == null)
            {
                return NotFound();
            }

            return View(beneficiario);
        }

        //**********************************|--------------|**********************************
        //**********************************|AG-BENFICIARIO|**********************************
        //**********************************|--------------|**********************************
        //Crear Agenda Del Beneficiario
        public async Task<IActionResult> CreateAB(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiario = await _preinscripcionServices.BuscarBeneficiarioPorId(id.Value);
            ViewBag.Nombre = beneficiario.PreinscripcionId;
            if (beneficiario == null)
            {
                return NotFound();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAB(AgendaBeneficiarioDto agendaBeneficiarioDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _preinscripcionServices.GuardarAgendaBeneficiario(agendaBeneficiarioDto);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return View(agendaBeneficiarioDto);
        }

        //**********************************|--------------|**********************************
        //**********************************| INSCRIPCION  |**********************************
        //**********************************|--------------|**********************************
        //Listar Inscripción 
        public IActionResult IndexInscritos()
        {
            var listarBeneficiariosDtos = _preinscripcionServices.ListarBeneficiarioResumenDtoInscritos();
            return View(listarBeneficiariosDtos);
        }

        //Crear Matricula Beneficiario Get
        public async Task<IActionResult> CreateMatricula(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiario = await _preinscripcionServices.ObtenerBeneficiarioPorId(id.Value);
            ViewData["listaTipoDocumentos"] = new SelectList(await _preinscripcionServices.ObtenerListaTipoDocumento(), "TipoDocumentoId", "NombreTipoDocumento");
            ViewData["listaGeneros"] = new SelectList(await _preinscripcionServices.ObtenerListaGenero(), "GeneroId", "NombreGenero");
            ViewData["listaGrupoSanguineos"] = new SelectList(await _preinscripcionServices.ObtenerListaGrupoSanguineo(), "GrupoSanguineoId", "Rh");
            ViewData["listaModalidads"] = new SelectList(await _preinscripcionServices.ObtenerListaModalidad(), "ModalidadId", "NombreModalidad");
            ViewData["listaEtnias"] = new SelectList(await _preinscripcionServices.ObtenerListaEtnia(), "EtniaId", "NombreEtnia");
            ViewData["listaJornadas"] = new SelectList(await _preinscripcionServices.ObtenerListaJornada(), "JornadaId", "NombreJornada");
            ViewData["listaPadrinos"] = new SelectList(await _preinscripcionServices.ObtenerListaPadrinos(), "PadrinoId", "NombrePadrino");
            ViewData["listaEstados"] = new SelectList(await _preinscripcionServices.ObtenerListaEstados(), "EstadoId", "NombreEstado");
            if (beneficiario == null)
            {
                return NotFound();
            }
            return View(beneficiario);
        }

        //Crear Matricula Beneficiario Post
        [HttpPost]
        public async Task<IActionResult> CreateMatricula(PreinscripcionDto preinscripcionDto)
        {
            if (preinscripcionDto.PreinscripcionId == preinscripcionDto.PreinscripcionId)
            {
                if (ModelState.IsValid)
                {
                    await _preinscripcionServices.GuardarMatricula(preinscripcionDto);
                    return RedirectToAction(nameof(Index));
                }
                return View(preinscripcionDto);
            }
            return NotFound();
        }

        //**********************************|--------------|**********************************
        //**********************************|  MATRICULA   |**********************************
        //**********************************|--------------|**********************************
        //Listar Matricula
        public IActionResult IndexMatricula()
        {
            var listarMatriculaDtos = _preinscripcionServices.ListarMatriculaDto();
            return View(listarMatriculaDtos);
        }

        //Editar Matricula Beneficiario Get
        public async Task<IActionResult> EditMatricula(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiario = await _preinscripcionServices.ObtenerBeneficiarioPorId(id.Value);
            ViewData["listaTipoDocumentos"] = new SelectList(await _preinscripcionServices.ObtenerListaTipoDocumento(), "TipoDocumentoId", "NombreTipoDocumento");
            ViewData["listaGeneros"] = new SelectList(await _preinscripcionServices.ObtenerListaGenero(), "GeneroId", "NombreGenero");
            ViewData["listaGrupoSanguineos"] = new SelectList(await _preinscripcionServices.ObtenerListaGrupoSanguineo(), "GrupoSanguineoId", "Rh");
            ViewData["listaModalidads"] = new SelectList(await _preinscripcionServices.ObtenerListaModalidad(), "ModalidadId", "NombreModalidad");
            ViewData["listaEtnias"] = new SelectList(await _preinscripcionServices.ObtenerListaEtnia(), "EtniaId", "NombreEtnia");
            ViewData["listaJornadas"] = new SelectList(await _preinscripcionServices.ObtenerListaJornada(), "JornadaId", "NombreJornada");
            ViewData["listaPadrinos"] = new SelectList(await _preinscripcionServices.ObtenerListaPadrinos(), "PadrinoId", "NombrePadrino");
            ViewData["listaEstados"] = new SelectList(await _preinscripcionServices.ObtenerListaEstados(), "EstadoId", "NombreEstado");
            if (beneficiario == null)
            {
                return NotFound();
            }
            return View(beneficiario);
        }

        //Editar Matricula Beneficiario Post
        [HttpPost]
        public async Task<IActionResult> EditMatricula(PreinscripcionDto preinscripcionDto)
        {
            if (preinscripcionDto.PreinscripcionId == preinscripcionDto.PreinscripcionId)
            {
                if (ModelState.IsValid)
                {
                    await _preinscripcionServices.EditarMatricula(preinscripcionDto);
                    return RedirectToAction(nameof(Index));
                }
                return View(preinscripcionDto);
            }
            return NotFound();
        }

        public async Task<IActionResult> DetailsMatricula(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiario = await _preinscripcionServices.ObtenerBeneficiarioPorId(id.Value);
            ViewData["listaTipoDocumentos"] = new SelectList(await _preinscripcionServices.ObtenerListaTipoDocumento(), "TipoDocumentoId", "NombreTipoDocumento");
            ViewData["listaGeneros"] = new SelectList(await _preinscripcionServices.ObtenerListaGenero(), "GeneroId", "NombreGenero");
            ViewData["listaGrupoSanguineos"] = new SelectList(await _preinscripcionServices.ObtenerListaGrupoSanguineo(), "GrupoSanguineoId", "Rh");
            ViewData["listaModalidads"] = new SelectList(await _preinscripcionServices.ObtenerListaModalidad(), "ModalidadId", "NombreModalidad");
            ViewData["listaEtnias"] = new SelectList(await _preinscripcionServices.ObtenerListaEtnia(), "EtniaId", "NombreEtnia");
            ViewData["listaJornadas"] = new SelectList(await _preinscripcionServices.ObtenerListaJornada(), "JornadaId", "NombreJornada");
            ViewData["listaPadrinos"] = new SelectList(await _preinscripcionServices.ObtenerListaPadrinos(), "PadrinoId", "NombrePadrino");
            ViewData["listaEstados"] = new SelectList(await _preinscripcionServices.ObtenerListaEstados(), "EstadoId", "NombreEstado");
            if (beneficiario == null)
            {
                return NotFound();
            }
            return View(beneficiario);
        }

        //Crear Matricula Beneficiario Get
        public async Task<IActionResult> CreateRetiro(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiario = await _preinscripcionServices.ObtenerBeneficiarioPorId(id.Value);
            ViewData["listaTipoDocumentos"] = new SelectList(await _preinscripcionServices.ObtenerListaTipoDocumento(), "TipoDocumentoId", "NombreTipoDocumento");
            ViewData["listaGeneros"] = new SelectList(await _preinscripcionServices.ObtenerListaGenero(), "GeneroId", "NombreGenero");
            ViewData["listaGrupoSanguineos"] = new SelectList(await _preinscripcionServices.ObtenerListaGrupoSanguineo(), "GrupoSanguineoId", "Rh");
            ViewData["listaModalidads"] = new SelectList(await _preinscripcionServices.ObtenerListaModalidad(), "ModalidadId", "NombreModalidad");
            ViewData["listaEtnias"] = new SelectList(await _preinscripcionServices.ObtenerListaEtnia(), "EtniaId", "NombreEtnia");
            ViewData["listaJornadas"] = new SelectList(await _preinscripcionServices.ObtenerListaJornada(), "JornadaId", "NombreJornada");
            ViewData["listaPadrinos"] = new SelectList(await _preinscripcionServices.ObtenerListaPadrinos(), "PadrinoId", "NombrePadrino");
            ViewData["listaEstados"] = new SelectList(await _preinscripcionServices.ObtenerListaEstados(), "EstadoId", "NombreEstado");
            if (beneficiario == null)
            {
                return NotFound();
            }
            return View(beneficiario);
        }

        //Crear Retiro Beneficiario Post
        [HttpPost]
        public async Task<IActionResult> CreateRetiro(PreinscripcionDto preinscripcionDto)
        {
            if (preinscripcionDto.PreinscripcionId == preinscripcionDto.PreinscripcionId)
            {
                if (ModelState.IsValid)
                {
                    await _preinscripcionServices.GuardarRetiro(preinscripcionDto);
                    return RedirectToAction(nameof(Index));
                }
                return View(preinscripcionDto);
            }
            return NotFound();
        }

        //**********************************|--------------|**********************************
        //**********************************|    RETIRO    |**********************************
        //**********************************|--------------|**********************************
        //Listar Retiro

        public IActionResult IndexRetiro()
        {
            var listarMatriculaDtos = _preinscripcionServices.ListarRetiroDto();
            return View(listarMatriculaDtos);
        }

        //Editar Retiro Beneficiario Get
        public async Task<IActionResult> EditRetiro(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiario = await _preinscripcionServices.ObtenerBeneficiarioPorId(id.Value);
            ViewData["listaTipoDocumentos"] = new SelectList(await _preinscripcionServices.ObtenerListaTipoDocumento(), "TipoDocumentoId", "NombreTipoDocumento");
            ViewData["listaGeneros"] = new SelectList(await _preinscripcionServices.ObtenerListaGenero(), "GeneroId", "NombreGenero");
            ViewData["listaGrupoSanguineos"] = new SelectList(await _preinscripcionServices.ObtenerListaGrupoSanguineo(), "GrupoSanguineoId", "Rh");
            ViewData["listaModalidads"] = new SelectList(await _preinscripcionServices.ObtenerListaModalidad(), "ModalidadId", "NombreModalidad");
            ViewData["listaEtnias"] = new SelectList(await _preinscripcionServices.ObtenerListaEtnia(), "EtniaId", "NombreEtnia");
            ViewData["listaJornadas"] = new SelectList(await _preinscripcionServices.ObtenerListaJornada(), "JornadaId", "NombreJornada");
            ViewData["listaPadrinos"] = new SelectList(await _preinscripcionServices.ObtenerListaPadrinos(), "PadrinoId", "NombrePadrino");
            ViewData["listaEstados"] = new SelectList(await _preinscripcionServices.ObtenerListaEstados(), "EstadoId", "NombreEstado");
            if (beneficiario == null)
            {
                return NotFound();
            }
            return View(beneficiario);
        }

        //Editar Retiro Beneficiario Post
        [HttpPost]
        public async Task<IActionResult> EditRetiro(PreinscripcionDto preinscripcionDto)
        {
            if (preinscripcionDto.PreinscripcionId == preinscripcionDto.PreinscripcionId)
            {
                if (ModelState.IsValid)
                {
                    await _preinscripcionServices.EditarRetiro(preinscripcionDto);
                    return RedirectToAction(nameof(Index));
                }
                return View(preinscripcionDto);
            }
            return NotFound();
        }

        public async Task<IActionResult> DetailsRetiro(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiario = await _preinscripcionServices.ObtenerBeneficiarioPorId(id.Value);
            ViewData["listaTipoDocumentos"] = new SelectList(await _preinscripcionServices.ObtenerListaTipoDocumento(), "TipoDocumentoId", "NombreTipoDocumento");
            ViewData["listaGeneros"] = new SelectList(await _preinscripcionServices.ObtenerListaGenero(), "GeneroId", "NombreGenero");
            ViewData["listaGrupoSanguineos"] = new SelectList(await _preinscripcionServices.ObtenerListaGrupoSanguineo(), "GrupoSanguineoId", "Rh");
            ViewData["listaModalidads"] = new SelectList(await _preinscripcionServices.ObtenerListaModalidad(), "ModalidadId", "NombreModalidad");
            ViewData["listaEtnias"] = new SelectList(await _preinscripcionServices.ObtenerListaEtnia(), "EtniaId", "NombreEtnia");
            ViewData["listaJornadas"] = new SelectList(await _preinscripcionServices.ObtenerListaJornada(), "JornadaId", "NombreJornada");
            ViewData["listaPadrinos"] = new SelectList(await _preinscripcionServices.ObtenerListaPadrinos(), "PadrinoId", "NombrePadrino");
            ViewData["listaEstados"] = new SelectList(await _preinscripcionServices.ObtenerListaEstados(), "EstadoId", "NombreEstado");
            if (beneficiario == null)
            {
                return NotFound();
            }
            return View(beneficiario);
        }
    }
}
