using Avansist.Models.Entities;
using Avansist.Services.Abstract;
using Avansist.Services.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Avansist.Web.Controllers
{
    [Authorize]
    public class PreinscripcionController : Controller
    {
        private readonly IPreinscripcionServices _preinscripcionServices;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PreinscripcionController(IPreinscripcionServices preinscripcionServices, IWebHostEnvironment hostEnvironment)
        {
            _preinscripcionServices = preinscripcionServices;
            _hostEnvironment = hostEnvironment;
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
            ViewData["listaEstados"] = new SelectList(await _preinscripcionServices.ObtenerListaEstadosPreinscripcion(), "EstadoId", "NombreEstado");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PreinscripcionDto preinscripcionDto)
        {
            if (ModelState.IsValid)
            {
                var beneficiarioTem = await _preinscripcionServices.ObtenerBeneficiarioPorDocumentoYEstado(preinscripcionDto.NumeroDocumento);
                if (beneficiarioTem == null && preinscripcionDto.Imagen != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string nombreImagen = Path.GetFileNameWithoutExtension(preinscripcionDto.Imagen.FileName);
                    string extension = Path.GetExtension(preinscripcionDto.Imagen.FileName);
                    nombreImagen = nombreImagen + DateTime.Now.ToString("yymmssfff") + extension;

                    Preinscripcion preinscripcion = new()
                    {
                        PreinscripcionId = preinscripcionDto.PreinscripcionId,
                        ModalidadId = preinscripcionDto.ModalidadId,
                        FechaRegistro = preinscripcionDto.FechaRegistro,
                        PrimerNombreBeneficiario = preinscripcionDto.PrimerNombreBeneficiario,
                        SegundoNombreBeneficiario = preinscripcionDto.SegundoNombreBeneficiario,
                        PrimerApellidoBeneficiario = preinscripcionDto.PrimerApellidoBeneficiario,
                        SegundoApellidoBeneficiario = preinscripcionDto.SegundoApellidoBeneficiario,
                        GeneroId = preinscripcionDto.GeneroId,
                        Edad = preinscripcionDto.Edad,
                        TallaCamisa = preinscripcionDto.TallaCamisa,
                        TallaPantalon = preinscripcionDto.TallaPantalon,
                        TallaZapatos = preinscripcionDto.TallaZapatos,
                        GrupoSanguineoId = preinscripcionDto.GrupoSanguineoId,
                        FechaNacimiento = preinscripcionDto.FechaNacimiento,
                        LugarNacimiento = preinscripcionDto.LugarNacimiento,
                        TipoDocumentoId = preinscripcionDto.TipoDocumentoId,
                        NumeroDocumento = preinscripcionDto.NumeroDocumento,
                        LugarExpedicionDocumento = preinscripcionDto.LugarExpedicionDocumento,
                        NombreEps = preinscripcionDto.NombreEps,
                        GrupoSisben = preinscripcionDto.GrupoSisben,
                        EtniaId = preinscripcionDto.EtniaId,
                        AntecedenteMedico = preinscripcionDto.AntecedenteMedico,
                        DescripcionEnfermedad = preinscripcionDto.DescripcionEnfermedad,
                        AntecedentePsicologico = preinscripcionDto.AntecedentePsicologico,
                        DescripcionPsicologica = preinscripcionDto.DescripcionPsicologica,
                        JornadaId = preinscripcionDto.JornadaId,
                        Municipio = preinscripcionDto.Municipio,
                        CustodiaBeneficiario = preinscripcionDto.CustodiaBeneficiario,
                        DireccionResidencia = preinscripcionDto.DireccionResidencia,
                        PadrinoId = preinscripcionDto.PadrinoId,
                        AporteEconomicoPadrino = preinscripcionDto.AporteEconomicoPadrino,
                        NombreMadre = preinscripcionDto.NombreMadre,
                        ApellidoMadre = preinscripcionDto.ApellidoMadre,
                        NumeroDocumentoMadre = preinscripcionDto.NumeroDocumentoMadre,
                        LugarExpedicionDocumentoMadre = preinscripcionDto.LugarExpedicionDocumentoMadre,
                        OcupacionMadre = preinscripcionDto.OcupacionMadre,
                        NivelEscolaridadMadre = preinscripcionDto.NivelEscolaridadMadre,
                        TelefonoMadre = preinscripcionDto.TelefonoMadre,
                        DireccionMadre = preinscripcionDto.DireccionMadre,
                        BarrioMadre = preinscripcionDto.BarrioMadre,
                        MunicipioMadre = preinscripcionDto.MunicipioMadre,
                        IngresoEconomicoMadre = preinscripcionDto.IngresoEconomicoMadre,
                        NombrePadre = preinscripcionDto.NombrePadre,
                        ApellidoPadre = preinscripcionDto.ApellidoPadre,
                        NumeroDocumentoPadre = preinscripcionDto.NumeroDocumentoPadre,
                        LugarExpedicionDocumentoPadre = preinscripcionDto.LugarExpedicionDocumentoPadre,
                        OcupacionPadre = preinscripcionDto.OcupacionPadre,
                        NivelEscolaridadPadre = preinscripcionDto.NivelEscolaridadPadre,
                        TelefonoPadre = preinscripcionDto.TelefonoPadre,
                        DireccionPadre = preinscripcionDto.DireccionPadre,
                        BarrioPadre = preinscripcionDto.BarrioPadre,
                        MunicipioPadre = preinscripcionDto.MunicipioPadre,
                        IngresoEconomicoPadre = preinscripcionDto.IngresoEconomicoPadre,
                        NombreAcudiente = preinscripcionDto.NombreAcudiente,
                        ApellidoAcudiente = preinscripcionDto.ApellidoAcudiente,
                        NumeroDocumentoAcudiente = preinscripcionDto.NumeroDocumentoAcudiente,
                        LugarExpedicionDocumentoAcudiente = preinscripcionDto.LugarExpedicionDocumentoAcudiente,
                        OcupacionAcudiente = preinscripcionDto.OcupacionAcudiente,
                        NivelEscolaridadAcudiente = preinscripcionDto.NivelEscolaridadAcudiente,
                        TelefonoAcudiente = preinscripcionDto.TelefonoAcudiente,
                        DireccionAcudiente = preinscripcionDto.DireccionAcudiente,
                        BarrioAcudiente = preinscripcionDto.BarrioAcudiente,
                        MunicipioAcudiente = preinscripcionDto.MunicipioAcudiente,
                        IngresoEconomicoAcudiente = preinscripcionDto.IngresoEconomicoAcudiente,
                        EstadoId = preinscripcionDto.EstadoId,
                        AutorizacionData = preinscripcionDto.AutorizacionData,
                        AutorizacionFoto = preinscripcionDto.AutorizacionFoto,
                        NombreImagen = nombreImagen
                    };

                    string path = Path.Combine(wwwRootPath + "/image/" + nombreImagen);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await preinscripcionDto.Imagen.CopyToAsync(fileStream);
                    }

                    try
                    {
                        await _preinscripcionServices.GuardarBeneficiario(preinscripcion);
                        return Json(new { status = true });
                    }
                    catch (Exception)
                    {
                        return Json(new { status = false });
                    }
                }
                if (beneficiarioTem != null)
                {
                    return Json(new { status = 500 });
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

            if (beneficiario == null)
            {
                return NotFound();
            }

            PreinscripcionDto preinscripcionDto = new()
            {
                PreinscripcionId = beneficiario.PreinscripcionId,
                ModalidadId = beneficiario.ModalidadId,
                FechaRegistro = beneficiario.FechaRegistro,
                PrimerNombreBeneficiario = beneficiario.PrimerNombreBeneficiario,
                SegundoNombreBeneficiario = beneficiario.SegundoNombreBeneficiario,
                PrimerApellidoBeneficiario = beneficiario.PrimerApellidoBeneficiario,
                SegundoApellidoBeneficiario = beneficiario.SegundoApellidoBeneficiario,
                GeneroId = beneficiario.GeneroId,
                Edad = beneficiario.Edad,
                TallaCamisa = beneficiario.TallaCamisa,
                TallaPantalon = beneficiario.TallaPantalon,
                TallaZapatos = beneficiario.TallaZapatos,
                GrupoSanguineoId = beneficiario.GrupoSanguineoId,
                FechaNacimiento = beneficiario.FechaNacimiento,
                LugarNacimiento = beneficiario.LugarNacimiento,
                TipoDocumentoId = beneficiario.TipoDocumentoId,
                NumeroDocumento = beneficiario.NumeroDocumento,
                LugarExpedicionDocumento = beneficiario.LugarExpedicionDocumento,
                NombreEps = beneficiario.NombreEps,
                GrupoSisben = beneficiario.GrupoSisben,
                EtniaId = beneficiario.EtniaId,
                AntecedenteMedico = beneficiario.AntecedenteMedico,
                DescripcionEnfermedad = beneficiario.DescripcionEnfermedad,
                AntecedentePsicologico = beneficiario.AntecedentePsicologico,
                DescripcionPsicologica = beneficiario.DescripcionPsicologica,
                JornadaId = beneficiario.JornadaId,
                Municipio = beneficiario.Municipio,
                CustodiaBeneficiario = beneficiario.CustodiaBeneficiario,
                DireccionResidencia = beneficiario.DireccionResidencia,
                PadrinoId = beneficiario.PadrinoId,
                AporteEconomicoPadrino = beneficiario.AporteEconomicoPadrino,
                NombreMadre = beneficiario.NombreMadre,
                ApellidoMadre = beneficiario.ApellidoMadre,
                NumeroDocumentoMadre = beneficiario.NumeroDocumentoMadre,
                LugarExpedicionDocumentoMadre = beneficiario.LugarExpedicionDocumentoMadre,
                OcupacionMadre = beneficiario.OcupacionMadre,
                NivelEscolaridadMadre = beneficiario.NivelEscolaridadMadre,
                TelefonoMadre = beneficiario.TelefonoMadre,
                DireccionMadre = beneficiario.DireccionMadre,
                BarrioMadre = beneficiario.BarrioMadre,
                MunicipioMadre = beneficiario.MunicipioMadre,
                IngresoEconomicoMadre = beneficiario.IngresoEconomicoMadre,
                NombrePadre = beneficiario.NombrePadre,
                ApellidoPadre = beneficiario.ApellidoPadre,
                NumeroDocumentoPadre = beneficiario.NumeroDocumentoPadre,
                LugarExpedicionDocumentoPadre = beneficiario.LugarExpedicionDocumentoPadre,
                OcupacionPadre = beneficiario.OcupacionPadre,
                NivelEscolaridadPadre = beneficiario.NivelEscolaridadPadre,
                TelefonoPadre = beneficiario.TelefonoPadre,
                DireccionPadre = beneficiario.DireccionPadre,
                BarrioPadre = beneficiario.BarrioPadre,
                MunicipioPadre = beneficiario.MunicipioPadre,
                IngresoEconomicoPadre = beneficiario.IngresoEconomicoPadre,
                NombreAcudiente = beneficiario.NombreAcudiente,
                ApellidoAcudiente = beneficiario.ApellidoAcudiente,
                NumeroDocumentoAcudiente = beneficiario.NumeroDocumentoAcudiente,
                LugarExpedicionDocumentoAcudiente = beneficiario.LugarExpedicionDocumentoAcudiente,
                OcupacionAcudiente = beneficiario.OcupacionAcudiente,
                NivelEscolaridadAcudiente = beneficiario.NivelEscolaridadAcudiente,
                TelefonoAcudiente = beneficiario.TelefonoAcudiente,
                DireccionAcudiente = beneficiario.DireccionAcudiente,
                BarrioAcudiente = beneficiario.BarrioAcudiente,
                MunicipioAcudiente = beneficiario.MunicipioAcudiente,
                IngresoEconomicoAcudiente = beneficiario.IngresoEconomicoAcudiente,
                EstadoId = beneficiario.EstadoId,
                AutorizacionData = beneficiario.AutorizacionData,
                AutorizacionFoto = beneficiario.AutorizacionFoto,
                NombreImagen = beneficiario.NombreImagen
            };

            ViewData["listaTipoDocumentos"] = new SelectList(await _preinscripcionServices.ObtenerListaTipoDocumento(), "TipoDocumentoId", "NombreTipoDocumento");
            ViewData["listaGeneros"] = new SelectList(await _preinscripcionServices.ObtenerListaGenero(), "GeneroId", "NombreGenero");
            ViewData["listaGrupoSanguineos"] = new SelectList(await _preinscripcionServices.ObtenerListaGrupoSanguineo(), "GrupoSanguineoId", "Rh");
            ViewData["listaModalidads"] = new SelectList(await _preinscripcionServices.ObtenerListaModalidad(), "ModalidadId", "NombreModalidad");
            ViewData["listaEtnias"] = new SelectList(await _preinscripcionServices.ObtenerListaEtnia(), "EtniaId", "NombreEtnia");
            ViewData["listaJornadas"] = new SelectList(await _preinscripcionServices.ObtenerListaJornada(), "JornadaId", "NombreJornada");
            ViewData["listaPadrinos"] = new SelectList(await _preinscripcionServices.ObtenerListaPadrinos(), "PadrinoId", "NombrePadrino");
            ViewData["listaEstados"] = new SelectList(await _preinscripcionServices.ObtenerListaEstadosPreinscripcionEditar(), "EstadoId", "NombreEstado");            

            return View(preinscripcionDto);
        }

        // POST: Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(PreinscripcionDto preinscripcionDto)
        {
            if (ModelState.IsValid)
            {
                Preinscripcion preinscripcion = new();

                if (preinscripcionDto.Imagen != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;

                    //Borramos la foto anterior
                    string imagenAnterior = null;
                    if (preinscripcionDto.NombreImagen != null)
                    {
                        imagenAnterior = Path.Combine(wwwRootPath, "image", preinscripcionDto.NombreImagen);
                    }                        

                    if (System.IO.File.Exists(imagenAnterior))
                    {
                        System.IO.File.Delete(imagenAnterior);
                    }                       

                    string nombreImagen = Path.GetFileNameWithoutExtension(preinscripcionDto.Imagen.FileName);
                    string extension = Path.GetExtension(preinscripcionDto.Imagen.FileName);
                    preinscripcionDto.NombreImagen = nombreImagen + DateTime.Now.ToString("yymmssfff") + extension;

                    string path = Path.Combine(wwwRootPath + "/image/" + preinscripcionDto.NombreImagen);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await preinscripcionDto.Imagen.CopyToAsync(fileStream);
                    }
                    preinscripcion.NombreImagen = preinscripcionDto.NombreImagen;

                }
                else
                {
                    preinscripcion.NombreImagen = preinscripcionDto.NombreImagen;
                }

                preinscripcion.PreinscripcionId = preinscripcionDto.PreinscripcionId;
                preinscripcion.ModalidadId = preinscripcionDto.ModalidadId;
                preinscripcion.FechaRegistro = preinscripcionDto.FechaRegistro;
                preinscripcion.PrimerNombreBeneficiario = preinscripcionDto.PrimerNombreBeneficiario;
                preinscripcion.SegundoNombreBeneficiario = preinscripcionDto.SegundoNombreBeneficiario;
                preinscripcion.PrimerApellidoBeneficiario = preinscripcionDto.PrimerApellidoBeneficiario;
                preinscripcion.SegundoApellidoBeneficiario = preinscripcionDto.SegundoApellidoBeneficiario;
                preinscripcion.GeneroId = preinscripcionDto.GeneroId;
                preinscripcion.Edad = preinscripcionDto.Edad;
                preinscripcion.TallaCamisa = preinscripcionDto.TallaCamisa;
                preinscripcion.TallaPantalon = preinscripcionDto.TallaPantalon;
                preinscripcion.TallaZapatos = preinscripcionDto.TallaZapatos;
                preinscripcion.GrupoSanguineoId = preinscripcionDto.GrupoSanguineoId;
                preinscripcion.FechaNacimiento = preinscripcionDto.FechaNacimiento;
                preinscripcion.LugarNacimiento = preinscripcionDto.LugarNacimiento;
                preinscripcion.TipoDocumentoId = preinscripcionDto.TipoDocumentoId;
                preinscripcion.NumeroDocumento = preinscripcionDto.NumeroDocumento;
                preinscripcion.LugarExpedicionDocumento = preinscripcionDto.LugarExpedicionDocumento;
                preinscripcion.NombreEps = preinscripcionDto.NombreEps;
                preinscripcion.GrupoSisben = preinscripcionDto.GrupoSisben;
                preinscripcion.EtniaId = preinscripcionDto.EtniaId;
                preinscripcion.AntecedenteMedico = preinscripcionDto.AntecedenteMedico;
                preinscripcion.DescripcionEnfermedad = preinscripcionDto.DescripcionEnfermedad;
                preinscripcion.AntecedentePsicologico = preinscripcionDto.AntecedentePsicologico;
                preinscripcion.DescripcionPsicologica = preinscripcionDto.DescripcionPsicologica;
                preinscripcion.JornadaId = preinscripcionDto.JornadaId;
                preinscripcion.Municipio = preinscripcionDto.Municipio;
                preinscripcion.CustodiaBeneficiario = preinscripcionDto.CustodiaBeneficiario;
                preinscripcion.DireccionResidencia = preinscripcionDto.DireccionResidencia;
                preinscripcion.PadrinoId = preinscripcionDto.PadrinoId;
                preinscripcion.AporteEconomicoPadrino = preinscripcionDto.AporteEconomicoPadrino;
                preinscripcion.NombreMadre = preinscripcionDto.NombreMadre;
                preinscripcion.ApellidoMadre = preinscripcionDto.ApellidoMadre;
                preinscripcion.NumeroDocumentoMadre = preinscripcionDto.NumeroDocumentoMadre;
                preinscripcion.LugarExpedicionDocumentoMadre = preinscripcionDto.LugarExpedicionDocumentoMadre;
                preinscripcion.OcupacionMadre = preinscripcionDto.OcupacionMadre;
                preinscripcion.NivelEscolaridadMadre = preinscripcionDto.NivelEscolaridadMadre;
                preinscripcion.TelefonoMadre = preinscripcionDto.TelefonoMadre;
                preinscripcion.DireccionMadre = preinscripcionDto.DireccionMadre;
                preinscripcion.BarrioMadre = preinscripcionDto.BarrioMadre;
                preinscripcion.MunicipioMadre = preinscripcionDto.MunicipioMadre;
                preinscripcion.IngresoEconomicoMadre = preinscripcionDto.IngresoEconomicoMadre;
                preinscripcion.NombrePadre = preinscripcionDto.NombrePadre;
                preinscripcion.ApellidoPadre = preinscripcionDto.ApellidoPadre;
                preinscripcion.NumeroDocumentoPadre = preinscripcionDto.NumeroDocumentoPadre;
                preinscripcion.LugarExpedicionDocumentoPadre = preinscripcionDto.LugarExpedicionDocumentoPadre;
                preinscripcion.OcupacionPadre = preinscripcionDto.OcupacionPadre;
                preinscripcion.NivelEscolaridadPadre = preinscripcionDto.NivelEscolaridadPadre;
                preinscripcion.TelefonoPadre = preinscripcionDto.TelefonoPadre;
                preinscripcion.DireccionPadre = preinscripcionDto.DireccionPadre;
                preinscripcion.BarrioPadre = preinscripcionDto.BarrioPadre;
                preinscripcion.MunicipioPadre = preinscripcionDto.MunicipioPadre;
                preinscripcion.IngresoEconomicoPadre = preinscripcionDto.IngresoEconomicoPadre;
                preinscripcion.NombreAcudiente = preinscripcionDto.NombreAcudiente;
                preinscripcion.ApellidoAcudiente = preinscripcionDto.ApellidoAcudiente;
                preinscripcion.NumeroDocumentoAcudiente = preinscripcionDto.NumeroDocumentoAcudiente;
                preinscripcion.LugarExpedicionDocumentoAcudiente = preinscripcionDto.LugarExpedicionDocumentoAcudiente;
                preinscripcion.OcupacionAcudiente = preinscripcionDto.OcupacionAcudiente;
                preinscripcion.NivelEscolaridadAcudiente = preinscripcionDto.NivelEscolaridadAcudiente;
                preinscripcion.TelefonoAcudiente = preinscripcionDto.TelefonoAcudiente;
                preinscripcion.DireccionAcudiente = preinscripcionDto.DireccionAcudiente;
                preinscripcion.BarrioAcudiente = preinscripcionDto.BarrioAcudiente;
                preinscripcion.MunicipioAcudiente = preinscripcionDto.MunicipioAcudiente;
                preinscripcion.IngresoEconomicoAcudiente = preinscripcionDto.IngresoEconomicoAcudiente;
                preinscripcion.AutorizacionData = preinscripcionDto.AutorizacionData;
                preinscripcion.AutorizacionFoto = preinscripcionDto.AutorizacionFoto;
                preinscripcion.EstadoId = preinscripcionDto.EstadoId;
                preinscripcion.JornadaId = preinscripcionDto.JornadaId;
                preinscripcion.InstitucionEducativa = preinscripcionDto.InstitucionEducativa;
                preinscripcion.NivelEscolaridad = preinscripcionDto.NivelEscolaridad;
                preinscripcion.FechaMatricula = preinscripcionDto.FechaMatricula;

                try
                {
                    await _preinscripcionServices.EditarBeneficiario(preinscripcion);
                    return Json(new { status = true });
                }
                catch (Exception)
                {
                    return Json(new { status = false });
                }
            }
            return Json(new { status = false });
        }

        //Detalle Preinscripción Beneficiario
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiario = await _preinscripcionServices.ObtenerBeneficiarioPorId(id.Value);

            PreinscripcionDto preinscripcionDto = new()
            {
                PreinscripcionId = beneficiario.PreinscripcionId,
                ModalidadId = beneficiario.ModalidadId,
                FechaRegistro = beneficiario.FechaRegistro,
                PrimerNombreBeneficiario = beneficiario.PrimerNombreBeneficiario,
                SegundoNombreBeneficiario = beneficiario.SegundoNombreBeneficiario,
                PrimerApellidoBeneficiario = beneficiario.PrimerApellidoBeneficiario,
                SegundoApellidoBeneficiario = beneficiario.SegundoApellidoBeneficiario,
                GeneroId = beneficiario.GeneroId,
                Edad = beneficiario.Edad,
                TallaCamisa = beneficiario.TallaCamisa,
                TallaPantalon = beneficiario.TallaPantalon,
                TallaZapatos = beneficiario.TallaZapatos,
                GrupoSanguineoId = beneficiario.GrupoSanguineoId,
                FechaNacimiento = beneficiario.FechaNacimiento,
                LugarNacimiento = beneficiario.LugarNacimiento,
                TipoDocumentoId = beneficiario.TipoDocumentoId,
                NumeroDocumento = beneficiario.NumeroDocumento,
                LugarExpedicionDocumento = beneficiario.LugarExpedicionDocumento,
                NombreEps = beneficiario.NombreEps,
                GrupoSisben = beneficiario.GrupoSisben,
                EtniaId = beneficiario.EtniaId,
                AntecedenteMedico = beneficiario.AntecedenteMedico,
                DescripcionEnfermedad = beneficiario.DescripcionEnfermedad,
                AntecedentePsicologico = beneficiario.AntecedentePsicologico,
                DescripcionPsicologica = beneficiario.DescripcionPsicologica,
                JornadaId = beneficiario.JornadaId,
                Municipio = beneficiario.Municipio,
                CustodiaBeneficiario = beneficiario.CustodiaBeneficiario,
                DireccionResidencia = beneficiario.DireccionResidencia,
                PadrinoId = beneficiario.PadrinoId,
                AporteEconomicoPadrino = beneficiario.AporteEconomicoPadrino,
                NombreMadre = beneficiario.NombreMadre,
                ApellidoMadre = beneficiario.ApellidoMadre,
                NumeroDocumentoMadre = beneficiario.NumeroDocumentoMadre,
                LugarExpedicionDocumentoMadre = beneficiario.LugarExpedicionDocumentoMadre,
                OcupacionMadre = beneficiario.OcupacionMadre,
                NivelEscolaridadMadre = beneficiario.NivelEscolaridadMadre,
                TelefonoMadre = beneficiario.TelefonoMadre,
                DireccionMadre = beneficiario.DireccionMadre,
                BarrioMadre = beneficiario.BarrioMadre,
                MunicipioMadre = beneficiario.MunicipioMadre,
                IngresoEconomicoMadre = beneficiario.IngresoEconomicoMadre,
                NombrePadre = beneficiario.NombrePadre,
                ApellidoPadre = beneficiario.ApellidoPadre,
                NumeroDocumentoPadre = beneficiario.NumeroDocumentoPadre,
                LugarExpedicionDocumentoPadre = beneficiario.LugarExpedicionDocumentoPadre,
                OcupacionPadre = beneficiario.OcupacionPadre,
                NivelEscolaridadPadre = beneficiario.NivelEscolaridadPadre,
                TelefonoPadre = beneficiario.TelefonoPadre,
                DireccionPadre = beneficiario.DireccionPadre,
                BarrioPadre = beneficiario.BarrioPadre,
                MunicipioPadre = beneficiario.MunicipioPadre,
                IngresoEconomicoPadre = beneficiario.IngresoEconomicoPadre,
                NombreAcudiente = beneficiario.NombreAcudiente,
                ApellidoAcudiente = beneficiario.ApellidoAcudiente,
                NumeroDocumentoAcudiente = beneficiario.NumeroDocumentoAcudiente,
                LugarExpedicionDocumentoAcudiente = beneficiario.LugarExpedicionDocumentoAcudiente,
                OcupacionAcudiente = beneficiario.OcupacionAcudiente,
                NivelEscolaridadAcudiente = beneficiario.NivelEscolaridadAcudiente,
                TelefonoAcudiente = beneficiario.TelefonoAcudiente,
                DireccionAcudiente = beneficiario.DireccionAcudiente,
                BarrioAcudiente = beneficiario.BarrioAcudiente,
                MunicipioAcudiente = beneficiario.MunicipioAcudiente,
                IngresoEconomicoAcudiente = beneficiario.IngresoEconomicoAcudiente,
                EstadoId = beneficiario.EstadoId,
                AutorizacionData = beneficiario.AutorizacionData,
                AutorizacionFoto = beneficiario.AutorizacionFoto,
                NombreImagen = beneficiario.NombreImagen
            };

            //ViewBag.beneficiarioId = beneficiario.PreinscripcionId;
            //ViewBag.TipoDocumento = beneficiario.NombreTipoDocumento;
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

            return View(preinscripcionDto);
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

            if (beneficiario == null)
            {
                return NotFound();
            }

            PreinscripcionDto preinscripcionDto = new()
            {
                PreinscripcionId = beneficiario.PreinscripcionId,
                ModalidadId = beneficiario.ModalidadId,
                FechaRegistro = beneficiario.FechaRegistro,
                PrimerNombreBeneficiario = beneficiario.PrimerNombreBeneficiario,
                SegundoNombreBeneficiario = beneficiario.SegundoNombreBeneficiario,
                PrimerApellidoBeneficiario = beneficiario.PrimerApellidoBeneficiario,
                SegundoApellidoBeneficiario = beneficiario.SegundoApellidoBeneficiario,
                GeneroId = beneficiario.GeneroId,
                Edad = beneficiario.Edad,
                TallaCamisa = beneficiario.TallaCamisa,
                TallaPantalon = beneficiario.TallaPantalon,
                TallaZapatos = beneficiario.TallaZapatos,
                GrupoSanguineoId = beneficiario.GrupoSanguineoId,
                FechaNacimiento = beneficiario.FechaNacimiento,
                LugarNacimiento = beneficiario.LugarNacimiento,
                TipoDocumentoId = beneficiario.TipoDocumentoId,
                NumeroDocumento = beneficiario.NumeroDocumento,
                LugarExpedicionDocumento = beneficiario.LugarExpedicionDocumento,
                NombreEps = beneficiario.NombreEps,
                GrupoSisben = beneficiario.GrupoSisben,
                EtniaId = beneficiario.EtniaId,
                AntecedenteMedico = beneficiario.AntecedenteMedico,
                DescripcionEnfermedad = beneficiario.DescripcionEnfermedad,
                AntecedentePsicologico = beneficiario.AntecedentePsicologico,
                DescripcionPsicologica = beneficiario.DescripcionPsicologica,
                JornadaId = beneficiario.JornadaId,
                Municipio = beneficiario.Municipio,
                CustodiaBeneficiario = beneficiario.CustodiaBeneficiario,
                DireccionResidencia = beneficiario.DireccionResidencia,
                PadrinoId = beneficiario.PadrinoId,
                AporteEconomicoPadrino = beneficiario.AporteEconomicoPadrino,
                NombreMadre = beneficiario.NombreMadre,
                ApellidoMadre = beneficiario.ApellidoMadre,
                NumeroDocumentoMadre = beneficiario.NumeroDocumentoMadre,
                LugarExpedicionDocumentoMadre = beneficiario.LugarExpedicionDocumentoMadre,
                OcupacionMadre = beneficiario.OcupacionMadre,
                NivelEscolaridadMadre = beneficiario.NivelEscolaridadMadre,
                TelefonoMadre = beneficiario.TelefonoMadre,
                DireccionMadre = beneficiario.DireccionMadre,
                BarrioMadre = beneficiario.BarrioMadre,
                MunicipioMadre = beneficiario.MunicipioMadre,
                IngresoEconomicoMadre = beneficiario.IngresoEconomicoMadre,
                NombrePadre = beneficiario.NombrePadre,
                ApellidoPadre = beneficiario.ApellidoPadre,
                NumeroDocumentoPadre = beneficiario.NumeroDocumentoPadre,
                LugarExpedicionDocumentoPadre = beneficiario.LugarExpedicionDocumentoPadre,
                OcupacionPadre = beneficiario.OcupacionPadre,
                NivelEscolaridadPadre = beneficiario.NivelEscolaridadPadre,
                TelefonoPadre = beneficiario.TelefonoPadre,
                DireccionPadre = beneficiario.DireccionPadre,
                BarrioPadre = beneficiario.BarrioPadre,
                MunicipioPadre = beneficiario.MunicipioPadre,
                IngresoEconomicoPadre = beneficiario.IngresoEconomicoPadre,
                NombreAcudiente = beneficiario.NombreAcudiente,
                ApellidoAcudiente = beneficiario.ApellidoAcudiente,
                NumeroDocumentoAcudiente = beneficiario.NumeroDocumentoAcudiente,
                LugarExpedicionDocumentoAcudiente = beneficiario.LugarExpedicionDocumentoAcudiente,
                OcupacionAcudiente = beneficiario.OcupacionAcudiente,
                NivelEscolaridadAcudiente = beneficiario.NivelEscolaridadAcudiente,
                TelefonoAcudiente = beneficiario.TelefonoAcudiente,
                DireccionAcudiente = beneficiario.DireccionAcudiente,
                BarrioAcudiente = beneficiario.BarrioAcudiente,
                MunicipioAcudiente = beneficiario.MunicipioAcudiente,
                IngresoEconomicoAcudiente = beneficiario.IngresoEconomicoAcudiente,
                EstadoId = beneficiario.EstadoId,
                AutorizacionData = beneficiario.AutorizacionData,
                AutorizacionFoto = beneficiario.AutorizacionFoto,
                NombreImagen = beneficiario.NombreImagen
            };

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
            return View(preinscripcionDto);
        }

        //Crear Matricula Beneficiario Post
        [HttpPost]
        public async Task<IActionResult> CreateMatricula(PreinscripcionDto preinscripcionDto)
        {
            if (ModelState.IsValid)
            {

                Preinscripcion preinscripcion = new()
                {
                    PreinscripcionId = preinscripcionDto.PreinscripcionId,
                    ModalidadId = preinscripcionDto.ModalidadId,
                    FechaRegistro = preinscripcionDto.FechaRegistro,
                    PrimerNombreBeneficiario = preinscripcionDto.PrimerNombreBeneficiario,
                    SegundoNombreBeneficiario = preinscripcionDto.SegundoNombreBeneficiario,
                    PrimerApellidoBeneficiario = preinscripcionDto.PrimerApellidoBeneficiario,
                    SegundoApellidoBeneficiario = preinscripcionDto.SegundoApellidoBeneficiario,
                    GeneroId = preinscripcionDto.GeneroId,
                    Edad = preinscripcionDto.Edad,
                    TallaCamisa = preinscripcionDto.TallaCamisa,
                    TallaPantalon = preinscripcionDto.TallaPantalon,
                    TallaZapatos = preinscripcionDto.TallaZapatos,
                    GrupoSanguineoId = preinscripcionDto.GrupoSanguineoId,
                    FechaNacimiento = preinscripcionDto.FechaNacimiento,
                    LugarNacimiento = preinscripcionDto.LugarNacimiento,
                    TipoDocumentoId = preinscripcionDto.TipoDocumentoId,
                    NumeroDocumento = preinscripcionDto.NumeroDocumento,
                    LugarExpedicionDocumento = preinscripcionDto.LugarExpedicionDocumento,
                    NombreEps = preinscripcionDto.NombreEps,
                    GrupoSisben = preinscripcionDto.GrupoSisben,
                    EtniaId = preinscripcionDto.EtniaId,
                    AntecedenteMedico = preinscripcionDto.AntecedenteMedico,
                    DescripcionEnfermedad = preinscripcionDto.DescripcionEnfermedad,
                    AntecedentePsicologico = preinscripcionDto.AntecedentePsicologico,
                    DescripcionPsicologica = preinscripcionDto.DescripcionPsicologica,
                    JornadaId = preinscripcionDto.JornadaId,
                    Municipio = preinscripcionDto.Municipio,
                    CustodiaBeneficiario = preinscripcionDto.CustodiaBeneficiario,
                    DireccionResidencia = preinscripcionDto.DireccionResidencia,
                    PadrinoId = preinscripcionDto.PadrinoId,
                    AporteEconomicoPadrino = preinscripcionDto.AporteEconomicoPadrino,
                    NombreMadre = preinscripcionDto.NombreMadre,
                    ApellidoMadre = preinscripcionDto.ApellidoMadre,
                    NumeroDocumentoMadre = preinscripcionDto.NumeroDocumentoMadre,
                    LugarExpedicionDocumentoMadre = preinscripcionDto.LugarExpedicionDocumentoMadre,
                    OcupacionMadre = preinscripcionDto.OcupacionMadre,
                    NivelEscolaridadMadre = preinscripcionDto.NivelEscolaridadMadre,
                    TelefonoMadre = preinscripcionDto.TelefonoMadre,
                    DireccionMadre = preinscripcionDto.DireccionMadre,
                    BarrioMadre = preinscripcionDto.BarrioMadre,
                    MunicipioMadre = preinscripcionDto.MunicipioMadre,
                    IngresoEconomicoMadre = preinscripcionDto.IngresoEconomicoMadre,
                    NombrePadre = preinscripcionDto.NombrePadre,
                    ApellidoPadre = preinscripcionDto.ApellidoPadre,
                    NumeroDocumentoPadre = preinscripcionDto.NumeroDocumentoPadre,
                    LugarExpedicionDocumentoPadre = preinscripcionDto.LugarExpedicionDocumentoPadre,
                    OcupacionPadre = preinscripcionDto.OcupacionPadre,
                    NivelEscolaridadPadre = preinscripcionDto.NivelEscolaridadPadre,
                    TelefonoPadre = preinscripcionDto.TelefonoPadre,
                    DireccionPadre = preinscripcionDto.DireccionPadre,
                    BarrioPadre = preinscripcionDto.BarrioPadre,
                    MunicipioPadre = preinscripcionDto.MunicipioPadre,
                    IngresoEconomicoPadre = preinscripcionDto.IngresoEconomicoPadre,
                    NombreAcudiente = preinscripcionDto.NombreAcudiente,
                    ApellidoAcudiente = preinscripcionDto.ApellidoAcudiente,
                    NumeroDocumentoAcudiente = preinscripcionDto.NumeroDocumentoAcudiente,
                    LugarExpedicionDocumentoAcudiente = preinscripcionDto.LugarExpedicionDocumentoAcudiente,
                    OcupacionAcudiente = preinscripcionDto.OcupacionAcudiente,
                    NivelEscolaridadAcudiente = preinscripcionDto.NivelEscolaridadAcudiente,
                    TelefonoAcudiente = preinscripcionDto.TelefonoAcudiente,
                    DireccionAcudiente = preinscripcionDto.DireccionAcudiente,
                    BarrioAcudiente = preinscripcionDto.BarrioAcudiente,
                    MunicipioAcudiente = preinscripcionDto.MunicipioAcudiente,
                    IngresoEconomicoAcudiente = preinscripcionDto.IngresoEconomicoAcudiente,
                    EstadoId = preinscripcionDto.EstadoId,
                    FechaMatricula = preinscripcionDto.FechaMatricula,
                    InstitucionEducativa = preinscripcionDto.InstitucionEducativa,
                    NivelEscolaridad = preinscripcionDto.NivelEscolaridad,
                    AutorizacionData = preinscripcionDto.AutorizacionData,
                    AutorizacionFoto = preinscripcionDto.AutorizacionFoto,
                    NombreImagen = preinscripcionDto.NombreImagen
                };

                try
                {
                    await _preinscripcionServices.GuardarMatricula(preinscripcion);
                    return Json(new { status = true });
                }
                catch (Exception)
                {
                    return View(preinscripcionDto);
                }
            }
            return Json(new { status = false });
        }

        //Editar desde Inscripción
        public async Task<IActionResult> EditInscripcion(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiario = await _preinscripcionServices.ObtenerBeneficiarioPorId(id.Value);

            if (beneficiario == null)
            {
                return NotFound();
            }

            PreinscripcionDto preinscripcionDto = new()
            {
                PreinscripcionId = beneficiario.PreinscripcionId,
                ModalidadId = beneficiario.ModalidadId,
                FechaRegistro = beneficiario.FechaRegistro,
                PrimerNombreBeneficiario = beneficiario.PrimerNombreBeneficiario,
                SegundoNombreBeneficiario = beneficiario.SegundoNombreBeneficiario,
                PrimerApellidoBeneficiario = beneficiario.PrimerApellidoBeneficiario,
                SegundoApellidoBeneficiario = beneficiario.SegundoApellidoBeneficiario,
                GeneroId = beneficiario.GeneroId,
                Edad = beneficiario.Edad,
                TallaCamisa = beneficiario.TallaCamisa,
                TallaPantalon = beneficiario.TallaPantalon,
                TallaZapatos = beneficiario.TallaZapatos,
                GrupoSanguineoId = beneficiario.GrupoSanguineoId,
                FechaNacimiento = beneficiario.FechaNacimiento,
                LugarNacimiento = beneficiario.LugarNacimiento,
                TipoDocumentoId = beneficiario.TipoDocumentoId,
                NumeroDocumento = beneficiario.NumeroDocumento,
                LugarExpedicionDocumento = beneficiario.LugarExpedicionDocumento,
                NombreEps = beneficiario.NombreEps,
                GrupoSisben = beneficiario.GrupoSisben,
                EtniaId = beneficiario.EtniaId,
                AntecedenteMedico = beneficiario.AntecedenteMedico,
                DescripcionEnfermedad = beneficiario.DescripcionEnfermedad,
                AntecedentePsicologico = beneficiario.AntecedentePsicologico,
                DescripcionPsicologica = beneficiario.DescripcionPsicologica,
                JornadaId = beneficiario.JornadaId,
                Municipio = beneficiario.Municipio,
                CustodiaBeneficiario = beneficiario.CustodiaBeneficiario,
                DireccionResidencia = beneficiario.DireccionResidencia,
                PadrinoId = beneficiario.PadrinoId,
                AporteEconomicoPadrino = beneficiario.AporteEconomicoPadrino,
                NombreMadre = beneficiario.NombreMadre,
                ApellidoMadre = beneficiario.ApellidoMadre,
                NumeroDocumentoMadre = beneficiario.NumeroDocumentoMadre,
                LugarExpedicionDocumentoMadre = beneficiario.LugarExpedicionDocumentoMadre,
                OcupacionMadre = beneficiario.OcupacionMadre,
                NivelEscolaridadMadre = beneficiario.NivelEscolaridadMadre,
                TelefonoMadre = beneficiario.TelefonoMadre,
                DireccionMadre = beneficiario.DireccionMadre,
                BarrioMadre = beneficiario.BarrioMadre,
                MunicipioMadre = beneficiario.MunicipioMadre,
                IngresoEconomicoMadre = beneficiario.IngresoEconomicoMadre,
                NombrePadre = beneficiario.NombrePadre,
                ApellidoPadre = beneficiario.ApellidoPadre,
                NumeroDocumentoPadre = beneficiario.NumeroDocumentoPadre,
                LugarExpedicionDocumentoPadre = beneficiario.LugarExpedicionDocumentoPadre,
                OcupacionPadre = beneficiario.OcupacionPadre,
                NivelEscolaridadPadre = beneficiario.NivelEscolaridadPadre,
                TelefonoPadre = beneficiario.TelefonoPadre,
                DireccionPadre = beneficiario.DireccionPadre,
                BarrioPadre = beneficiario.BarrioPadre,
                MunicipioPadre = beneficiario.MunicipioPadre,
                IngresoEconomicoPadre = beneficiario.IngresoEconomicoPadre,
                NombreAcudiente = beneficiario.NombreAcudiente,
                ApellidoAcudiente = beneficiario.ApellidoAcudiente,
                NumeroDocumentoAcudiente = beneficiario.NumeroDocumentoAcudiente,
                LugarExpedicionDocumentoAcudiente = beneficiario.LugarExpedicionDocumentoAcudiente,
                OcupacionAcudiente = beneficiario.OcupacionAcudiente,
                NivelEscolaridadAcudiente = beneficiario.NivelEscolaridadAcudiente,
                TelefonoAcudiente = beneficiario.TelefonoAcudiente,
                DireccionAcudiente = beneficiario.DireccionAcudiente,
                BarrioAcudiente = beneficiario.BarrioAcudiente,
                MunicipioAcudiente = beneficiario.MunicipioAcudiente,
                IngresoEconomicoAcudiente = beneficiario.IngresoEconomicoAcudiente,
                EstadoId = beneficiario.EstadoId,
                AutorizacionData = beneficiario.AutorizacionData,
                AutorizacionFoto = beneficiario.AutorizacionFoto,
                NombreImagen = beneficiario.NombreImagen
            };

            ViewData["listaTipoDocumentos"] = new SelectList(await _preinscripcionServices.ObtenerListaTipoDocumento(), "TipoDocumentoId", "NombreTipoDocumento");
            ViewData["listaGeneros"] = new SelectList(await _preinscripcionServices.ObtenerListaGenero(), "GeneroId", "NombreGenero");
            ViewData["listaGrupoSanguineos"] = new SelectList(await _preinscripcionServices.ObtenerListaGrupoSanguineo(), "GrupoSanguineoId", "Rh");
            ViewData["listaModalidads"] = new SelectList(await _preinscripcionServices.ObtenerListaModalidad(), "ModalidadId", "NombreModalidad");
            ViewData["listaEtnias"] = new SelectList(await _preinscripcionServices.ObtenerListaEtnia(), "EtniaId", "NombreEtnia");
            ViewData["listaJornadas"] = new SelectList(await _preinscripcionServices.ObtenerListaJornada(), "JornadaId", "NombreJornada");
            ViewData["listaPadrinos"] = new SelectList(await _preinscripcionServices.ObtenerListaPadrinos(), "PadrinoId", "NombrePadrino");
            ViewData["listaEstados"] = new SelectList(await _preinscripcionServices.ObtenerListaEstadosInscripcion(), "EstadoId", "NombreEstado");

            return View(preinscripcionDto);
        }

        // POST: Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> EditInscripcion(PreinscripcionDto preinscripcionDto)
        {
            if (ModelState.IsValid)
            {
                Preinscripcion preinscripcion = new();

                if (preinscripcionDto.Imagen != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;

                    //Borramos la foto anterior
                    string imagenAnterior = null;
                    if (preinscripcionDto.NombreImagen != null)
                    {
                        imagenAnterior = Path.Combine(wwwRootPath, "image", preinscripcionDto.NombreImagen);
                    }

                    if (System.IO.File.Exists(imagenAnterior))
                    {
                        System.IO.File.Delete(imagenAnterior);
                    }

                    string nombreImagen = Path.GetFileNameWithoutExtension(preinscripcionDto.Imagen.FileName);
                    string extension = Path.GetExtension(preinscripcionDto.Imagen.FileName);
                    preinscripcionDto.NombreImagen = nombreImagen + DateTime.Now.ToString("yymmssfff") + extension;

                    string path = Path.Combine(wwwRootPath + "/image/" + preinscripcionDto.NombreImagen);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await preinscripcionDto.Imagen.CopyToAsync(fileStream);
                    }
                    preinscripcion.NombreImagen = preinscripcionDto.NombreImagen;

                }
                else
                {
                    preinscripcion.NombreImagen = preinscripcionDto.NombreImagen;
                }

                preinscripcion.PreinscripcionId = preinscripcionDto.PreinscripcionId;
                preinscripcion.ModalidadId = preinscripcionDto.ModalidadId;
                preinscripcion.FechaRegistro = preinscripcionDto.FechaRegistro;
                preinscripcion.PrimerNombreBeneficiario = preinscripcionDto.PrimerNombreBeneficiario;
                preinscripcion.SegundoNombreBeneficiario = preinscripcionDto.SegundoNombreBeneficiario;
                preinscripcion.PrimerApellidoBeneficiario = preinscripcionDto.PrimerApellidoBeneficiario;
                preinscripcion.SegundoApellidoBeneficiario = preinscripcionDto.SegundoApellidoBeneficiario;
                preinscripcion.GeneroId = preinscripcionDto.GeneroId;
                preinscripcion.Edad = preinscripcionDto.Edad;
                preinscripcion.TallaCamisa = preinscripcionDto.TallaCamisa;
                preinscripcion.TallaPantalon = preinscripcionDto.TallaPantalon;
                preinscripcion.TallaZapatos = preinscripcionDto.TallaZapatos;
                preinscripcion.GrupoSanguineoId = preinscripcionDto.GrupoSanguineoId;
                preinscripcion.FechaNacimiento = preinscripcionDto.FechaNacimiento;
                preinscripcion.LugarNacimiento = preinscripcionDto.LugarNacimiento;
                preinscripcion.TipoDocumentoId = preinscripcionDto.TipoDocumentoId;
                preinscripcion.NumeroDocumento = preinscripcionDto.NumeroDocumento;
                preinscripcion.LugarExpedicionDocumento = preinscripcionDto.LugarExpedicionDocumento;
                preinscripcion.NombreEps = preinscripcionDto.NombreEps;
                preinscripcion.GrupoSisben = preinscripcionDto.GrupoSisben;
                preinscripcion.EtniaId = preinscripcionDto.EtniaId;
                preinscripcion.AntecedenteMedico = preinscripcionDto.AntecedenteMedico;
                preinscripcion.DescripcionEnfermedad = preinscripcionDto.DescripcionEnfermedad;
                preinscripcion.AntecedentePsicologico = preinscripcionDto.AntecedentePsicologico;
                preinscripcion.DescripcionPsicologica = preinscripcionDto.DescripcionPsicologica;
                preinscripcion.JornadaId = preinscripcionDto.JornadaId;
                preinscripcion.Municipio = preinscripcionDto.Municipio;
                preinscripcion.CustodiaBeneficiario = preinscripcionDto.CustodiaBeneficiario;
                preinscripcion.DireccionResidencia = preinscripcionDto.DireccionResidencia;
                preinscripcion.PadrinoId = preinscripcionDto.PadrinoId;
                preinscripcion.AporteEconomicoPadrino = preinscripcionDto.AporteEconomicoPadrino;
                preinscripcion.NombreMadre = preinscripcionDto.NombreMadre;
                preinscripcion.ApellidoMadre = preinscripcionDto.ApellidoMadre;
                preinscripcion.NumeroDocumentoMadre = preinscripcionDto.NumeroDocumentoMadre;
                preinscripcion.LugarExpedicionDocumentoMadre = preinscripcionDto.LugarExpedicionDocumentoMadre;
                preinscripcion.OcupacionMadre = preinscripcionDto.OcupacionMadre;
                preinscripcion.NivelEscolaridadMadre = preinscripcionDto.NivelEscolaridadMadre;
                preinscripcion.TelefonoMadre = preinscripcionDto.TelefonoMadre;
                preinscripcion.DireccionMadre = preinscripcionDto.DireccionMadre;
                preinscripcion.BarrioMadre = preinscripcionDto.BarrioMadre;
                preinscripcion.MunicipioMadre = preinscripcionDto.MunicipioMadre;
                preinscripcion.IngresoEconomicoMadre = preinscripcionDto.IngresoEconomicoMadre;
                preinscripcion.NombrePadre = preinscripcionDto.NombrePadre;
                preinscripcion.ApellidoPadre = preinscripcionDto.ApellidoPadre;
                preinscripcion.NumeroDocumentoPadre = preinscripcionDto.NumeroDocumentoPadre;
                preinscripcion.LugarExpedicionDocumentoPadre = preinscripcionDto.LugarExpedicionDocumentoPadre;
                preinscripcion.OcupacionPadre = preinscripcionDto.OcupacionPadre;
                preinscripcion.NivelEscolaridadPadre = preinscripcionDto.NivelEscolaridadPadre;
                preinscripcion.TelefonoPadre = preinscripcionDto.TelefonoPadre;
                preinscripcion.DireccionPadre = preinscripcionDto.DireccionPadre;
                preinscripcion.BarrioPadre = preinscripcionDto.BarrioPadre;
                preinscripcion.MunicipioPadre = preinscripcionDto.MunicipioPadre;
                preinscripcion.IngresoEconomicoPadre = preinscripcionDto.IngresoEconomicoPadre;
                preinscripcion.NombreAcudiente = preinscripcionDto.NombreAcudiente;
                preinscripcion.ApellidoAcudiente = preinscripcionDto.ApellidoAcudiente;
                preinscripcion.NumeroDocumentoAcudiente = preinscripcionDto.NumeroDocumentoAcudiente;
                preinscripcion.LugarExpedicionDocumentoAcudiente = preinscripcionDto.LugarExpedicionDocumentoAcudiente;
                preinscripcion.OcupacionAcudiente = preinscripcionDto.OcupacionAcudiente;
                preinscripcion.NivelEscolaridadAcudiente = preinscripcionDto.NivelEscolaridadAcudiente;
                preinscripcion.TelefonoAcudiente = preinscripcionDto.TelefonoAcudiente;
                preinscripcion.DireccionAcudiente = preinscripcionDto.DireccionAcudiente;
                preinscripcion.BarrioAcudiente = preinscripcionDto.BarrioAcudiente;
                preinscripcion.MunicipioAcudiente = preinscripcionDto.MunicipioAcudiente;
                preinscripcion.IngresoEconomicoAcudiente = preinscripcionDto.IngresoEconomicoAcudiente;
                preinscripcion.AutorizacionData = preinscripcionDto.AutorizacionData;
                preinscripcion.AutorizacionFoto = preinscripcionDto.AutorizacionFoto;
                preinscripcion.EstadoId = preinscripcionDto.EstadoId;

                try
                {
                    await _preinscripcionServices.EditarBeneficiario(preinscripcion);
                    return Json(new { status = true });
                }
                catch (Exception)
                {
                    return Json(new { status = false });
                }
            }
            return Json(new { status = false });
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

            if (beneficiario == null)
            {
                return NotFound();
            }

            PreinscripcionDto preinscripcionDto = new()
            {
                PreinscripcionId = beneficiario.PreinscripcionId,
                ModalidadId = beneficiario.ModalidadId,
                FechaRegistro = beneficiario.FechaRegistro,
                PrimerNombreBeneficiario = beneficiario.PrimerNombreBeneficiario,
                SegundoNombreBeneficiario = beneficiario.SegundoNombreBeneficiario,
                PrimerApellidoBeneficiario = beneficiario.PrimerApellidoBeneficiario,
                SegundoApellidoBeneficiario = beneficiario.SegundoApellidoBeneficiario,
                GeneroId = beneficiario.GeneroId,
                Edad = beneficiario.Edad,
                TallaCamisa = beneficiario.TallaCamisa,
                TallaPantalon = beneficiario.TallaPantalon,
                TallaZapatos = beneficiario.TallaZapatos,
                GrupoSanguineoId = beneficiario.GrupoSanguineoId,
                FechaNacimiento = beneficiario.FechaNacimiento,
                LugarNacimiento = beneficiario.LugarNacimiento,
                TipoDocumentoId = beneficiario.TipoDocumentoId,
                NumeroDocumento = beneficiario.NumeroDocumento,
                LugarExpedicionDocumento = beneficiario.LugarExpedicionDocumento,
                NombreEps = beneficiario.NombreEps,
                GrupoSisben = beneficiario.GrupoSisben,
                EtniaId = beneficiario.EtniaId,
                AntecedenteMedico = beneficiario.AntecedenteMedico,
                DescripcionEnfermedad = beneficiario.DescripcionEnfermedad,
                AntecedentePsicologico = beneficiario.AntecedentePsicologico,
                DescripcionPsicologica = beneficiario.DescripcionPsicologica,
                JornadaId = beneficiario.JornadaId,
                Municipio = beneficiario.Municipio,
                CustodiaBeneficiario = beneficiario.CustodiaBeneficiario,
                DireccionResidencia = beneficiario.DireccionResidencia,
                PadrinoId = beneficiario.PadrinoId,
                AporteEconomicoPadrino = beneficiario.AporteEconomicoPadrino,
                NombreMadre = beneficiario.NombreMadre,
                ApellidoMadre = beneficiario.ApellidoMadre,
                NumeroDocumentoMadre = beneficiario.NumeroDocumentoMadre,
                LugarExpedicionDocumentoMadre = beneficiario.LugarExpedicionDocumentoMadre,
                OcupacionMadre = beneficiario.OcupacionMadre,
                NivelEscolaridadMadre = beneficiario.NivelEscolaridadMadre,
                TelefonoMadre = beneficiario.TelefonoMadre,
                DireccionMadre = beneficiario.DireccionMadre,
                BarrioMadre = beneficiario.BarrioMadre,
                MunicipioMadre = beneficiario.MunicipioMadre,
                IngresoEconomicoMadre = beneficiario.IngresoEconomicoMadre,
                NombrePadre = beneficiario.NombrePadre,
                ApellidoPadre = beneficiario.ApellidoPadre,
                NumeroDocumentoPadre = beneficiario.NumeroDocumentoPadre,
                LugarExpedicionDocumentoPadre = beneficiario.LugarExpedicionDocumentoPadre,
                OcupacionPadre = beneficiario.OcupacionPadre,
                NivelEscolaridadPadre = beneficiario.NivelEscolaridadPadre,
                TelefonoPadre = beneficiario.TelefonoPadre,
                DireccionPadre = beneficiario.DireccionPadre,
                BarrioPadre = beneficiario.BarrioPadre,
                MunicipioPadre = beneficiario.MunicipioPadre,
                IngresoEconomicoPadre = beneficiario.IngresoEconomicoPadre,
                NombreAcudiente = beneficiario.NombreAcudiente,
                ApellidoAcudiente = beneficiario.ApellidoAcudiente,
                NumeroDocumentoAcudiente = beneficiario.NumeroDocumentoAcudiente,
                LugarExpedicionDocumentoAcudiente = beneficiario.LugarExpedicionDocumentoAcudiente,
                OcupacionAcudiente = beneficiario.OcupacionAcudiente,
                NivelEscolaridadAcudiente = beneficiario.NivelEscolaridadAcudiente,
                TelefonoAcudiente = beneficiario.TelefonoAcudiente,
                DireccionAcudiente = beneficiario.DireccionAcudiente,
                BarrioAcudiente = beneficiario.BarrioAcudiente,
                MunicipioAcudiente = beneficiario.MunicipioAcudiente,
                IngresoEconomicoAcudiente = beneficiario.IngresoEconomicoAcudiente,
                EstadoId = beneficiario.EstadoId,
                FechaMatricula = beneficiario.FechaMatricula,
                InstitucionEducativa = beneficiario.InstitucionEducativa,
                NivelEscolaridad = beneficiario.NivelEscolaridad,
                AutorizacionData = beneficiario.AutorizacionData,
                AutorizacionFoto = beneficiario.AutorizacionFoto,
                NombreImagen = beneficiario.NombreImagen
            };

            ViewData["listaTipoDocumentos"] = new SelectList(await _preinscripcionServices.ObtenerListaTipoDocumento(), "TipoDocumentoId", "NombreTipoDocumento");
            ViewData["listaGeneros"] = new SelectList(await _preinscripcionServices.ObtenerListaGenero(), "GeneroId", "NombreGenero");
            ViewData["listaGrupoSanguineos"] = new SelectList(await _preinscripcionServices.ObtenerListaGrupoSanguineo(), "GrupoSanguineoId", "Rh");
            ViewData["listaModalidads"] = new SelectList(await _preinscripcionServices.ObtenerListaModalidad(), "ModalidadId", "NombreModalidad");
            ViewData["listaEtnias"] = new SelectList(await _preinscripcionServices.ObtenerListaEtnia(), "EtniaId", "NombreEtnia");
            ViewData["listaJornadas"] = new SelectList(await _preinscripcionServices.ObtenerListaJornada(), "JornadaId", "NombreJornada");
            ViewData["listaPadrinos"] = new SelectList(await _preinscripcionServices.ObtenerListaPadrinos(), "PadrinoId", "NombrePadrino");
            ViewData["listaEstados"] = new SelectList(await _preinscripcionServices.ObtenerEstadoMatricula(), "EstadoId", "NombreEstado");
            if (beneficiario == null)
            {
                return NotFound();
            }
            return View(preinscripcionDto);
        }

        //Editar Matricula Beneficiario Post
        [HttpPost]
        public async Task<IActionResult> EditMatricula(PreinscripcionDto preinscripcionDto)
        {
            if (ModelState.IsValid)
            {

                Preinscripcion preinscripcion = new()

                {
                    PreinscripcionId = preinscripcionDto.PreinscripcionId,
                    ModalidadId = preinscripcionDto.ModalidadId,
                    FechaRegistro = preinscripcionDto.FechaRegistro,
                    PrimerNombreBeneficiario = preinscripcionDto.PrimerNombreBeneficiario,
                    SegundoNombreBeneficiario = preinscripcionDto.SegundoNombreBeneficiario,
                    PrimerApellidoBeneficiario = preinscripcionDto.PrimerApellidoBeneficiario,
                    SegundoApellidoBeneficiario = preinscripcionDto.SegundoApellidoBeneficiario,
                    GeneroId = preinscripcionDto.GeneroId,
                    Edad = preinscripcionDto.Edad,
                    TallaCamisa = preinscripcionDto.TallaCamisa,
                    TallaPantalon = preinscripcionDto.TallaPantalon,
                    TallaZapatos = preinscripcionDto.TallaZapatos,
                    GrupoSanguineoId = preinscripcionDto.GrupoSanguineoId,
                    FechaNacimiento = preinscripcionDto.FechaNacimiento,
                    LugarNacimiento = preinscripcionDto.LugarNacimiento,
                    TipoDocumentoId = preinscripcionDto.TipoDocumentoId,
                    NumeroDocumento = preinscripcionDto.NumeroDocumento,
                    LugarExpedicionDocumento = preinscripcionDto.LugarExpedicionDocumento,
                    NombreEps = preinscripcionDto.NombreEps,
                    GrupoSisben = preinscripcionDto.GrupoSisben,
                    EtniaId = preinscripcionDto.EtniaId,
                    AntecedenteMedico = preinscripcionDto.AntecedenteMedico,
                    DescripcionEnfermedad = preinscripcionDto.DescripcionEnfermedad,
                    AntecedentePsicologico = preinscripcionDto.AntecedentePsicologico,
                    DescripcionPsicologica = preinscripcionDto.DescripcionPsicologica,
                    JornadaId = preinscripcionDto.JornadaId,
                    Municipio = preinscripcionDto.Municipio,
                    CustodiaBeneficiario = preinscripcionDto.CustodiaBeneficiario,
                    DireccionResidencia = preinscripcionDto.DireccionResidencia,
                    PadrinoId = preinscripcionDto.PadrinoId,
                    AporteEconomicoPadrino = preinscripcionDto.AporteEconomicoPadrino,
                    NombreMadre = preinscripcionDto.NombreMadre,
                    ApellidoMadre = preinscripcionDto.ApellidoMadre,
                    NumeroDocumentoMadre = preinscripcionDto.NumeroDocumentoMadre,
                    LugarExpedicionDocumentoMadre = preinscripcionDto.LugarExpedicionDocumentoMadre,
                    OcupacionMadre = preinscripcionDto.OcupacionMadre,
                    NivelEscolaridadMadre = preinscripcionDto.NivelEscolaridadMadre,
                    TelefonoMadre = preinscripcionDto.TelefonoMadre,
                    DireccionMadre = preinscripcionDto.DireccionMadre,
                    BarrioMadre = preinscripcionDto.BarrioMadre,
                    MunicipioMadre = preinscripcionDto.MunicipioMadre,
                    IngresoEconomicoMadre = preinscripcionDto.IngresoEconomicoMadre,
                    NombrePadre = preinscripcionDto.NombrePadre,
                    ApellidoPadre = preinscripcionDto.ApellidoPadre,
                    NumeroDocumentoPadre = preinscripcionDto.NumeroDocumentoPadre,
                    LugarExpedicionDocumentoPadre = preinscripcionDto.LugarExpedicionDocumentoPadre,
                    OcupacionPadre = preinscripcionDto.OcupacionPadre,
                    NivelEscolaridadPadre = preinscripcionDto.NivelEscolaridadPadre,
                    TelefonoPadre = preinscripcionDto.TelefonoPadre,
                    DireccionPadre = preinscripcionDto.DireccionPadre,
                    BarrioPadre = preinscripcionDto.BarrioPadre,
                    MunicipioPadre = preinscripcionDto.MunicipioPadre,
                    IngresoEconomicoPadre = preinscripcionDto.IngresoEconomicoPadre,
                    NombreAcudiente = preinscripcionDto.NombreAcudiente,
                    ApellidoAcudiente = preinscripcionDto.ApellidoAcudiente,
                    NumeroDocumentoAcudiente = preinscripcionDto.NumeroDocumentoAcudiente,
                    LugarExpedicionDocumentoAcudiente = preinscripcionDto.LugarExpedicionDocumentoAcudiente,
                    OcupacionAcudiente = preinscripcionDto.OcupacionAcudiente,
                    NivelEscolaridadAcudiente = preinscripcionDto.NivelEscolaridadAcudiente,
                    TelefonoAcudiente = preinscripcionDto.TelefonoAcudiente,
                    DireccionAcudiente = preinscripcionDto.DireccionAcudiente,
                    BarrioAcudiente = preinscripcionDto.BarrioAcudiente,
                    MunicipioAcudiente = preinscripcionDto.MunicipioAcudiente,
                    IngresoEconomicoAcudiente = preinscripcionDto.IngresoEconomicoAcudiente,
                    EstadoId = preinscripcionDto.EstadoId,
                    FechaMatricula = preinscripcionDto.FechaMatricula,
                    InstitucionEducativa = preinscripcionDto.InstitucionEducativa,
                    NivelEscolaridad = preinscripcionDto.NivelEscolaridad,
                    AutorizacionData = preinscripcionDto.AutorizacionData,
                    AutorizacionFoto = preinscripcionDto.AutorizacionFoto,
                    NombreImagen = preinscripcionDto.NombreImagen
                };

                try
                {
                    await _preinscripcionServices.EditarMatricula(preinscripcion);
                    return Json(new { status = true });
                }
                catch (Exception)
                {
                    return View(preinscripcionDto);
                }
            }
            return Json(new { status = false });            
        }

        public async Task<IActionResult> DetailsMatricula(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiario = await _preinscripcionServices.ObtenerBeneficiarioPorId(id.Value);

            PreinscripcionDto preinscripcionDto = new()
            {
                PreinscripcionId = beneficiario.PreinscripcionId,
                ModalidadId = beneficiario.ModalidadId,
                FechaRegistro = beneficiario.FechaRegistro,
                PrimerNombreBeneficiario = beneficiario.PrimerNombreBeneficiario,
                SegundoNombreBeneficiario = beneficiario.SegundoNombreBeneficiario,
                PrimerApellidoBeneficiario = beneficiario.PrimerApellidoBeneficiario,
                SegundoApellidoBeneficiario = beneficiario.SegundoApellidoBeneficiario,
                GeneroId = beneficiario.GeneroId,
                Edad = beneficiario.Edad,
                TallaCamisa = beneficiario.TallaCamisa,
                TallaPantalon = beneficiario.TallaPantalon,
                TallaZapatos = beneficiario.TallaZapatos,
                GrupoSanguineoId = beneficiario.GrupoSanguineoId,
                FechaNacimiento = beneficiario.FechaNacimiento,
                LugarNacimiento = beneficiario.LugarNacimiento,
                TipoDocumentoId = beneficiario.TipoDocumentoId,
                NumeroDocumento = beneficiario.NumeroDocumento,
                LugarExpedicionDocumento = beneficiario.LugarExpedicionDocumento,
                NombreEps = beneficiario.NombreEps,
                GrupoSisben = beneficiario.GrupoSisben,
                EtniaId = beneficiario.EtniaId,
                AntecedenteMedico = beneficiario.AntecedenteMedico,
                DescripcionEnfermedad = beneficiario.DescripcionEnfermedad,
                AntecedentePsicologico = beneficiario.AntecedentePsicologico,
                DescripcionPsicologica = beneficiario.DescripcionPsicologica,
                JornadaId = beneficiario.JornadaId,
                Municipio = beneficiario.Municipio,
                CustodiaBeneficiario = beneficiario.CustodiaBeneficiario,
                DireccionResidencia = beneficiario.DireccionResidencia,
                InstitucionEducativa = beneficiario.InstitucionEducativa,
                NivelEscolaridad = beneficiario.NivelEscolaridad,
                FechaMatricula = beneficiario.FechaMatricula,
                PadrinoId = beneficiario.PadrinoId,
                AporteEconomicoPadrino = beneficiario.AporteEconomicoPadrino,
                NombreMadre = beneficiario.NombreMadre,
                ApellidoMadre = beneficiario.ApellidoMadre,
                NumeroDocumentoMadre = beneficiario.NumeroDocumentoMadre,
                LugarExpedicionDocumentoMadre = beneficiario.LugarExpedicionDocumentoMadre,
                OcupacionMadre = beneficiario.OcupacionMadre,
                NivelEscolaridadMadre = beneficiario.NivelEscolaridadMadre,
                TelefonoMadre = beneficiario.TelefonoMadre,
                DireccionMadre = beneficiario.DireccionMadre,
                BarrioMadre = beneficiario.BarrioMadre,
                MunicipioMadre = beneficiario.MunicipioMadre,
                IngresoEconomicoMadre = beneficiario.IngresoEconomicoMadre,
                NombrePadre = beneficiario.NombrePadre,
                ApellidoPadre = beneficiario.ApellidoPadre,
                NumeroDocumentoPadre = beneficiario.NumeroDocumentoPadre,
                LugarExpedicionDocumentoPadre = beneficiario.LugarExpedicionDocumentoPadre,
                OcupacionPadre = beneficiario.OcupacionPadre,
                NivelEscolaridadPadre = beneficiario.NivelEscolaridadPadre,
                TelefonoPadre = beneficiario.TelefonoPadre,
                DireccionPadre = beneficiario.DireccionPadre,
                BarrioPadre = beneficiario.BarrioPadre,
                MunicipioPadre = beneficiario.MunicipioPadre,
                IngresoEconomicoPadre = beneficiario.IngresoEconomicoPadre,
                NombreAcudiente = beneficiario.NombreAcudiente,
                ApellidoAcudiente = beneficiario.ApellidoAcudiente,
                NumeroDocumentoAcudiente = beneficiario.NumeroDocumentoAcudiente,
                LugarExpedicionDocumentoAcudiente = beneficiario.LugarExpedicionDocumentoAcudiente,
                OcupacionAcudiente = beneficiario.OcupacionAcudiente,
                NivelEscolaridadAcudiente = beneficiario.NivelEscolaridadAcudiente,
                TelefonoAcudiente = beneficiario.TelefonoAcudiente,
                DireccionAcudiente = beneficiario.DireccionAcudiente,
                BarrioAcudiente = beneficiario.BarrioAcudiente,
                MunicipioAcudiente = beneficiario.MunicipioAcudiente,
                IngresoEconomicoAcudiente = beneficiario.IngresoEconomicoAcudiente,
                EstadoId = beneficiario.EstadoId,
                AutorizacionData = beneficiario.AutorizacionData,
                AutorizacionFoto = beneficiario.AutorizacionFoto,
                NombreImagen = beneficiario.NombreImagen
            };

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
            return View(preinscripcionDto);
        }

        //Crear Matricula Beneficiario Get
        public async Task<IActionResult> CreateRetiro(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiario = await _preinscripcionServices.ObtenerBeneficiarioPorId(id.Value);

            if (beneficiario == null)
            {
                return NotFound();
            }

            PreinscripcionDto preinscripcionDto = new()
            {
                PreinscripcionId = beneficiario.PreinscripcionId,
                ModalidadId = beneficiario.ModalidadId,
                FechaRegistro = beneficiario.FechaRegistro,
                PrimerNombreBeneficiario = beneficiario.PrimerNombreBeneficiario,
                SegundoNombreBeneficiario = beneficiario.SegundoNombreBeneficiario,
                PrimerApellidoBeneficiario = beneficiario.PrimerApellidoBeneficiario,
                SegundoApellidoBeneficiario = beneficiario.SegundoApellidoBeneficiario,
                GeneroId = beneficiario.GeneroId,
                Edad = beneficiario.Edad,
                TallaCamisa = beneficiario.TallaCamisa,
                TallaPantalon = beneficiario.TallaPantalon,
                TallaZapatos = beneficiario.TallaZapatos,
                GrupoSanguineoId = beneficiario.GrupoSanguineoId,
                FechaNacimiento = beneficiario.FechaNacimiento,
                LugarNacimiento = beneficiario.LugarNacimiento,
                TipoDocumentoId = beneficiario.TipoDocumentoId,
                NumeroDocumento = beneficiario.NumeroDocumento,
                LugarExpedicionDocumento = beneficiario.LugarExpedicionDocumento,
                NombreEps = beneficiario.NombreEps,
                GrupoSisben = beneficiario.GrupoSisben,
                EtniaId = beneficiario.EtniaId,
                AntecedenteMedico = beneficiario.AntecedenteMedico,
                DescripcionEnfermedad = beneficiario.DescripcionEnfermedad,
                AntecedentePsicologico = beneficiario.AntecedentePsicologico,
                DescripcionPsicologica = beneficiario.DescripcionPsicologica,
                JornadaId = beneficiario.JornadaId,
                Municipio = beneficiario.Municipio,
                CustodiaBeneficiario = beneficiario.CustodiaBeneficiario,
                DireccionResidencia = beneficiario.DireccionResidencia,
                PadrinoId = beneficiario.PadrinoId,
                AporteEconomicoPadrino = beneficiario.AporteEconomicoPadrino,
                NombreMadre = beneficiario.NombreMadre,
                ApellidoMadre = beneficiario.ApellidoMadre,
                NumeroDocumentoMadre = beneficiario.NumeroDocumentoMadre,
                LugarExpedicionDocumentoMadre = beneficiario.LugarExpedicionDocumentoMadre,
                OcupacionMadre = beneficiario.OcupacionMadre,
                NivelEscolaridadMadre = beneficiario.NivelEscolaridadMadre,
                TelefonoMadre = beneficiario.TelefonoMadre,
                DireccionMadre = beneficiario.DireccionMadre,
                BarrioMadre = beneficiario.BarrioMadre,
                MunicipioMadre = beneficiario.MunicipioMadre,
                IngresoEconomicoMadre = beneficiario.IngresoEconomicoMadre,
                NombrePadre = beneficiario.NombrePadre,
                ApellidoPadre = beneficiario.ApellidoPadre,
                NumeroDocumentoPadre = beneficiario.NumeroDocumentoPadre,
                LugarExpedicionDocumentoPadre = beneficiario.LugarExpedicionDocumentoPadre,
                OcupacionPadre = beneficiario.OcupacionPadre,
                NivelEscolaridadPadre = beneficiario.NivelEscolaridadPadre,
                TelefonoPadre = beneficiario.TelefonoPadre,
                DireccionPadre = beneficiario.DireccionPadre,
                BarrioPadre = beneficiario.BarrioPadre,
                MunicipioPadre = beneficiario.MunicipioPadre,
                IngresoEconomicoPadre = beneficiario.IngresoEconomicoPadre,
                NombreAcudiente = beneficiario.NombreAcudiente,
                ApellidoAcudiente = beneficiario.ApellidoAcudiente,
                NumeroDocumentoAcudiente = beneficiario.NumeroDocumentoAcudiente,
                LugarExpedicionDocumentoAcudiente = beneficiario.LugarExpedicionDocumentoAcudiente,
                OcupacionAcudiente = beneficiario.OcupacionAcudiente,
                NivelEscolaridadAcudiente = beneficiario.NivelEscolaridadAcudiente,
                TelefonoAcudiente = beneficiario.TelefonoAcudiente,
                DireccionAcudiente = beneficiario.DireccionAcudiente,
                BarrioAcudiente = beneficiario.BarrioAcudiente,
                MunicipioAcudiente = beneficiario.MunicipioAcudiente,
                IngresoEconomicoAcudiente = beneficiario.IngresoEconomicoAcudiente,
                FechaRetiro = beneficiario.FechaRetiro,
                ObservacionRetiro = beneficiario.ObservacionRetiro,
                EstadoId = beneficiario.EstadoId,
                AutorizacionData = beneficiario.AutorizacionData,
                AutorizacionFoto = beneficiario.AutorizacionFoto,
                NombreImagen = beneficiario.NombreImagen,
                InstitucionEducativa = beneficiario.InstitucionEducativa,
                FechaMatricula = beneficiario.FechaMatricula,
                NivelEscolaridad = beneficiario.NivelEscolaridad
            };

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
            return View(preinscripcionDto);
        }

        //Crear Retiro Beneficiario Post
        [HttpPost]
        public async Task<IActionResult> CreateRetiro(PreinscripcionDto preinscripcionDto)
        {
            if (ModelState.IsValid)
            {
                Preinscripcion preinscripcion = new()
                {
                    PreinscripcionId = preinscripcionDto.PreinscripcionId,
                    ModalidadId = preinscripcionDto.ModalidadId,
                    FechaRegistro = preinscripcionDto.FechaRegistro,
                    PrimerNombreBeneficiario = preinscripcionDto.PrimerNombreBeneficiario,
                    SegundoNombreBeneficiario = preinscripcionDto.SegundoNombreBeneficiario,
                    PrimerApellidoBeneficiario = preinscripcionDto.PrimerApellidoBeneficiario,
                    SegundoApellidoBeneficiario = preinscripcionDto.SegundoApellidoBeneficiario,
                    GeneroId = preinscripcionDto.GeneroId,
                    Edad = preinscripcionDto.Edad,
                    TallaCamisa = preinscripcionDto.TallaCamisa,
                    TallaPantalon = preinscripcionDto.TallaPantalon,
                    TallaZapatos = preinscripcionDto.TallaZapatos,
                    GrupoSanguineoId = preinscripcionDto.GrupoSanguineoId,
                    FechaNacimiento = preinscripcionDto.FechaNacimiento,
                    LugarNacimiento = preinscripcionDto.LugarNacimiento,
                    TipoDocumentoId = preinscripcionDto.TipoDocumentoId,
                    NumeroDocumento = preinscripcionDto.NumeroDocumento,
                    LugarExpedicionDocumento = preinscripcionDto.LugarExpedicionDocumento,
                    NombreEps = preinscripcionDto.NombreEps,
                    GrupoSisben = preinscripcionDto.GrupoSisben,
                    EtniaId = preinscripcionDto.EtniaId,
                    AntecedenteMedico = preinscripcionDto.AntecedenteMedico,
                    DescripcionEnfermedad = preinscripcionDto.DescripcionEnfermedad,
                    AntecedentePsicologico = preinscripcionDto.AntecedentePsicologico,
                    DescripcionPsicologica = preinscripcionDto.DescripcionPsicologica,
                    JornadaId = preinscripcionDto.JornadaId,
                    Municipio = preinscripcionDto.Municipio,
                    CustodiaBeneficiario = preinscripcionDto.CustodiaBeneficiario,
                    DireccionResidencia = preinscripcionDto.DireccionResidencia,
                    PadrinoId = preinscripcionDto.PadrinoId,
                    AporteEconomicoPadrino = preinscripcionDto.AporteEconomicoPadrino,
                    NombreMadre = preinscripcionDto.NombreMadre,
                    ApellidoMadre = preinscripcionDto.ApellidoMadre,
                    NumeroDocumentoMadre = preinscripcionDto.NumeroDocumentoMadre,
                    LugarExpedicionDocumentoMadre = preinscripcionDto.LugarExpedicionDocumentoMadre,
                    OcupacionMadre = preinscripcionDto.OcupacionMadre,
                    NivelEscolaridadMadre = preinscripcionDto.NivelEscolaridadMadre,
                    TelefonoMadre = preinscripcionDto.TelefonoMadre,
                    DireccionMadre = preinscripcionDto.DireccionMadre,
                    BarrioMadre = preinscripcionDto.BarrioMadre,
                    MunicipioMadre = preinscripcionDto.MunicipioMadre,
                    IngresoEconomicoMadre = preinscripcionDto.IngresoEconomicoMadre,
                    NombrePadre = preinscripcionDto.NombrePadre,
                    ApellidoPadre = preinscripcionDto.ApellidoPadre,
                    NumeroDocumentoPadre = preinscripcionDto.NumeroDocumentoPadre,
                    LugarExpedicionDocumentoPadre = preinscripcionDto.LugarExpedicionDocumentoPadre,
                    OcupacionPadre = preinscripcionDto.OcupacionPadre,
                    NivelEscolaridadPadre = preinscripcionDto.NivelEscolaridadPadre,
                    TelefonoPadre = preinscripcionDto.TelefonoPadre,
                    DireccionPadre = preinscripcionDto.DireccionPadre,
                    BarrioPadre = preinscripcionDto.BarrioPadre,
                    MunicipioPadre = preinscripcionDto.MunicipioPadre,
                    IngresoEconomicoPadre = preinscripcionDto.IngresoEconomicoPadre,
                    NombreAcudiente = preinscripcionDto.NombreAcudiente,
                    ApellidoAcudiente = preinscripcionDto.ApellidoAcudiente,
                    NumeroDocumentoAcudiente = preinscripcionDto.NumeroDocumentoAcudiente,
                    LugarExpedicionDocumentoAcudiente = preinscripcionDto.LugarExpedicionDocumentoAcudiente,
                    OcupacionAcudiente = preinscripcionDto.OcupacionAcudiente,
                    NivelEscolaridadAcudiente = preinscripcionDto.NivelEscolaridadAcudiente,
                    TelefonoAcudiente = preinscripcionDto.TelefonoAcudiente,
                    DireccionAcudiente = preinscripcionDto.DireccionAcudiente,
                    BarrioAcudiente = preinscripcionDto.BarrioAcudiente,
                    MunicipioAcudiente = preinscripcionDto.MunicipioAcudiente,
                    IngresoEconomicoAcudiente = preinscripcionDto.IngresoEconomicoAcudiente,
                    EstadoId = preinscripcionDto.EstadoId,
                    FechaMatricula = preinscripcionDto.FechaMatricula,
                    InstitucionEducativa = preinscripcionDto.InstitucionEducativa,
                    NivelEscolaridad = preinscripcionDto.NivelEscolaridad,
                    FechaRetiro = preinscripcionDto.FechaRetiro,
                    ObservacionRetiro = preinscripcionDto.ObservacionRetiro,
                    AutorizacionData = preinscripcionDto.AutorizacionData,
                    AutorizacionFoto = preinscripcionDto.AutorizacionFoto,
                    NombreImagen = preinscripcionDto.NombreImagen
                };

                try
                {
                    await _preinscripcionServices.GuardarRetiro(preinscripcion);
                    return Json(new { status = true });
                }
                catch (Exception)
                {
                    return View(preinscripcionDto);
                }
            }
            return Json(new { status = false });            
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

            if (beneficiario == null)
            {
                return NotFound();
            }

            PreinscripcionDto preinscripcionDto = new()
            {
                PreinscripcionId = beneficiario.PreinscripcionId,
                ModalidadId = beneficiario.ModalidadId,
                FechaRegistro = beneficiario.FechaRegistro,
                PrimerNombreBeneficiario = beneficiario.PrimerNombreBeneficiario,
                SegundoNombreBeneficiario = beneficiario.SegundoNombreBeneficiario,
                PrimerApellidoBeneficiario = beneficiario.PrimerApellidoBeneficiario,
                SegundoApellidoBeneficiario = beneficiario.SegundoApellidoBeneficiario,
                GeneroId = beneficiario.GeneroId,
                Edad = beneficiario.Edad,
                TallaCamisa = beneficiario.TallaCamisa,
                TallaPantalon = beneficiario.TallaPantalon,
                TallaZapatos = beneficiario.TallaZapatos,
                GrupoSanguineoId = beneficiario.GrupoSanguineoId,
                FechaNacimiento = beneficiario.FechaNacimiento,
                LugarNacimiento = beneficiario.LugarNacimiento,
                TipoDocumentoId = beneficiario.TipoDocumentoId,
                NumeroDocumento = beneficiario.NumeroDocumento,
                LugarExpedicionDocumento = beneficiario.LugarExpedicionDocumento,
                NombreEps = beneficiario.NombreEps,
                GrupoSisben = beneficiario.GrupoSisben,
                EtniaId = beneficiario.EtniaId,
                AntecedenteMedico = beneficiario.AntecedenteMedico,
                DescripcionEnfermedad = beneficiario.DescripcionEnfermedad,
                AntecedentePsicologico = beneficiario.AntecedentePsicologico,
                DescripcionPsicologica = beneficiario.DescripcionPsicologica,
                JornadaId = beneficiario.JornadaId,
                Municipio = beneficiario.Municipio,
                CustodiaBeneficiario = beneficiario.CustodiaBeneficiario,
                DireccionResidencia = beneficiario.DireccionResidencia,
                PadrinoId = beneficiario.PadrinoId,
                AporteEconomicoPadrino = beneficiario.AporteEconomicoPadrino,
                NombreMadre = beneficiario.NombreMadre,
                ApellidoMadre = beneficiario.ApellidoMadre,
                NumeroDocumentoMadre = beneficiario.NumeroDocumentoMadre,
                LugarExpedicionDocumentoMadre = beneficiario.LugarExpedicionDocumentoMadre,
                OcupacionMadre = beneficiario.OcupacionMadre,
                NivelEscolaridadMadre = beneficiario.NivelEscolaridadMadre,
                TelefonoMadre = beneficiario.TelefonoMadre,
                DireccionMadre = beneficiario.DireccionMadre,
                BarrioMadre = beneficiario.BarrioMadre,
                MunicipioMadre = beneficiario.MunicipioMadre,
                IngresoEconomicoMadre = beneficiario.IngresoEconomicoMadre,
                NombrePadre = beneficiario.NombrePadre,
                ApellidoPadre = beneficiario.ApellidoPadre,
                NumeroDocumentoPadre = beneficiario.NumeroDocumentoPadre,
                LugarExpedicionDocumentoPadre = beneficiario.LugarExpedicionDocumentoPadre,
                OcupacionPadre = beneficiario.OcupacionPadre,
                NivelEscolaridadPadre = beneficiario.NivelEscolaridadPadre,
                TelefonoPadre = beneficiario.TelefonoPadre,
                DireccionPadre = beneficiario.DireccionPadre,
                BarrioPadre = beneficiario.BarrioPadre,
                MunicipioPadre = beneficiario.MunicipioPadre,
                IngresoEconomicoPadre = beneficiario.IngresoEconomicoPadre,
                NombreAcudiente = beneficiario.NombreAcudiente,
                ApellidoAcudiente = beneficiario.ApellidoAcudiente,
                NumeroDocumentoAcudiente = beneficiario.NumeroDocumentoAcudiente,
                LugarExpedicionDocumentoAcudiente = beneficiario.LugarExpedicionDocumentoAcudiente,
                OcupacionAcudiente = beneficiario.OcupacionAcudiente,
                NivelEscolaridadAcudiente = beneficiario.NivelEscolaridadAcudiente,
                TelefonoAcudiente = beneficiario.TelefonoAcudiente,
                DireccionAcudiente = beneficiario.DireccionAcudiente,
                BarrioAcudiente = beneficiario.BarrioAcudiente,
                MunicipioAcudiente = beneficiario.MunicipioAcudiente,
                IngresoEconomicoAcudiente = beneficiario.IngresoEconomicoAcudiente,
                EstadoId = beneficiario.EstadoId,
                AutorizacionData = beneficiario.AutorizacionData,
                AutorizacionFoto = beneficiario.AutorizacionFoto,
                NombreImagen = beneficiario.NombreImagen,
                FechaRetiro = beneficiario.FechaRetiro,
                ObservacionRetiro = beneficiario.ObservacionRetiro,
                InstitucionEducativa = beneficiario.InstitucionEducativa,
                FechaMatricula = beneficiario.FechaMatricula,
                NivelEscolaridad = beneficiario.NivelEscolaridad
            };

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
            return View(preinscripcionDto);
        }

        //Editar Retiro Beneficiario Post
        [HttpPost]
        public async Task<IActionResult> EditRetiro(PreinscripcionDto preinscripcionDto)
        {
            if (ModelState.IsValid)
            {

                Preinscripcion preinscripcion = new()
                {
                    PreinscripcionId = preinscripcionDto.PreinscripcionId,
                    ModalidadId = preinscripcionDto.ModalidadId,
                    FechaRegistro = preinscripcionDto.FechaRegistro,
                    PrimerNombreBeneficiario = preinscripcionDto.PrimerNombreBeneficiario,
                    SegundoNombreBeneficiario = preinscripcionDto.SegundoNombreBeneficiario,
                    PrimerApellidoBeneficiario = preinscripcionDto.PrimerApellidoBeneficiario,
                    SegundoApellidoBeneficiario = preinscripcionDto.SegundoApellidoBeneficiario,
                    GeneroId = preinscripcionDto.GeneroId,
                    Edad = preinscripcionDto.Edad,
                    TallaCamisa = preinscripcionDto.TallaCamisa,
                    TallaPantalon = preinscripcionDto.TallaPantalon,
                    TallaZapatos = preinscripcionDto.TallaZapatos,
                    GrupoSanguineoId = preinscripcionDto.GrupoSanguineoId,
                    FechaNacimiento = preinscripcionDto.FechaNacimiento,
                    LugarNacimiento = preinscripcionDto.LugarNacimiento,
                    TipoDocumentoId = preinscripcionDto.TipoDocumentoId,
                    NumeroDocumento = preinscripcionDto.NumeroDocumento,
                    LugarExpedicionDocumento = preinscripcionDto.LugarExpedicionDocumento,
                    NombreEps = preinscripcionDto.NombreEps,
                    GrupoSisben = preinscripcionDto.GrupoSisben,
                    EtniaId = preinscripcionDto.EtniaId,
                    AntecedenteMedico = preinscripcionDto.AntecedenteMedico,
                    DescripcionEnfermedad = preinscripcionDto.DescripcionEnfermedad,
                    AntecedentePsicologico = preinscripcionDto.AntecedentePsicologico,
                    DescripcionPsicologica = preinscripcionDto.DescripcionPsicologica,
                    JornadaId = preinscripcionDto.JornadaId,
                    Municipio = preinscripcionDto.Municipio,
                    CustodiaBeneficiario = preinscripcionDto.CustodiaBeneficiario,
                    DireccionResidencia = preinscripcionDto.DireccionResidencia,
                    PadrinoId = preinscripcionDto.PadrinoId,
                    AporteEconomicoPadrino = preinscripcionDto.AporteEconomicoPadrino,
                    NombreMadre = preinscripcionDto.NombreMadre,
                    ApellidoMadre = preinscripcionDto.ApellidoMadre,
                    NumeroDocumentoMadre = preinscripcionDto.NumeroDocumentoMadre,
                    LugarExpedicionDocumentoMadre = preinscripcionDto.LugarExpedicionDocumentoMadre,
                    OcupacionMadre = preinscripcionDto.OcupacionMadre,
                    NivelEscolaridadMadre = preinscripcionDto.NivelEscolaridadMadre,
                    TelefonoMadre = preinscripcionDto.TelefonoMadre,
                    DireccionMadre = preinscripcionDto.DireccionMadre,
                    BarrioMadre = preinscripcionDto.BarrioMadre,
                    MunicipioMadre = preinscripcionDto.MunicipioMadre,
                    IngresoEconomicoMadre = preinscripcionDto.IngresoEconomicoMadre,
                    NombrePadre = preinscripcionDto.NombrePadre,
                    ApellidoPadre = preinscripcionDto.ApellidoPadre,
                    NumeroDocumentoPadre = preinscripcionDto.NumeroDocumentoPadre,
                    LugarExpedicionDocumentoPadre = preinscripcionDto.LugarExpedicionDocumentoPadre,
                    OcupacionPadre = preinscripcionDto.OcupacionPadre,
                    NivelEscolaridadPadre = preinscripcionDto.NivelEscolaridadPadre,
                    TelefonoPadre = preinscripcionDto.TelefonoPadre,
                    DireccionPadre = preinscripcionDto.DireccionPadre,
                    BarrioPadre = preinscripcionDto.BarrioPadre,
                    MunicipioPadre = preinscripcionDto.MunicipioPadre,
                    IngresoEconomicoPadre = preinscripcionDto.IngresoEconomicoPadre,
                    NombreAcudiente = preinscripcionDto.NombreAcudiente,
                    ApellidoAcudiente = preinscripcionDto.ApellidoAcudiente,
                    NumeroDocumentoAcudiente = preinscripcionDto.NumeroDocumentoAcudiente,
                    LugarExpedicionDocumentoAcudiente = preinscripcionDto.LugarExpedicionDocumentoAcudiente,
                    OcupacionAcudiente = preinscripcionDto.OcupacionAcudiente,
                    NivelEscolaridadAcudiente = preinscripcionDto.NivelEscolaridadAcudiente,
                    TelefonoAcudiente = preinscripcionDto.TelefonoAcudiente,
                    DireccionAcudiente = preinscripcionDto.DireccionAcudiente,
                    BarrioAcudiente = preinscripcionDto.BarrioAcudiente,
                    MunicipioAcudiente = preinscripcionDto.MunicipioAcudiente,
                    IngresoEconomicoAcudiente = preinscripcionDto.IngresoEconomicoAcudiente,
                    EstadoId = preinscripcionDto.EstadoId,
                    FechaMatricula = preinscripcionDto.FechaMatricula,
                    InstitucionEducativa = preinscripcionDto.InstitucionEducativa,
                    NivelEscolaridad = preinscripcionDto.NivelEscolaridad,
                    AutorizacionData = preinscripcionDto.AutorizacionData,
                    AutorizacionFoto = preinscripcionDto.AutorizacionFoto,
                    NombreImagen = preinscripcionDto.NombreImagen,
                    FechaRetiro = preinscripcionDto.FechaRetiro,
                    ObservacionRetiro = preinscripcionDto.ObservacionRetiro
                };

                try
                {
                    await _preinscripcionServices.EditarRetiro(preinscripcion);
                    return Json(new { status = true });
                }
                catch (Exception)
                {
                    return View(preinscripcionDto);
                }
            }
            return Json(new { status = false });            
        }

        public async Task<IActionResult> DetailsRetiro(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiario = await _preinscripcionServices.ObtenerBeneficiarioPorId(id.Value);

            PreinscripcionDto preinscripcionDto = new()
            {
                PreinscripcionId = beneficiario.PreinscripcionId,
                ModalidadId = beneficiario.ModalidadId,
                FechaRegistro = beneficiario.FechaRegistro,
                PrimerNombreBeneficiario = beneficiario.PrimerNombreBeneficiario,
                SegundoNombreBeneficiario = beneficiario.SegundoNombreBeneficiario,
                PrimerApellidoBeneficiario = beneficiario.PrimerApellidoBeneficiario,
                SegundoApellidoBeneficiario = beneficiario.SegundoApellidoBeneficiario,
                GeneroId = beneficiario.GeneroId,
                Edad = beneficiario.Edad,
                TallaCamisa = beneficiario.TallaCamisa,
                TallaPantalon = beneficiario.TallaPantalon,
                TallaZapatos = beneficiario.TallaZapatos,
                GrupoSanguineoId = beneficiario.GrupoSanguineoId,
                FechaNacimiento = beneficiario.FechaNacimiento,
                LugarNacimiento = beneficiario.LugarNacimiento,
                TipoDocumentoId = beneficiario.TipoDocumentoId,
                NumeroDocumento = beneficiario.NumeroDocumento,
                LugarExpedicionDocumento = beneficiario.LugarExpedicionDocumento,
                NombreEps = beneficiario.NombreEps,
                GrupoSisben = beneficiario.GrupoSisben,
                EtniaId = beneficiario.EtniaId,
                AntecedenteMedico = beneficiario.AntecedenteMedico,
                DescripcionEnfermedad = beneficiario.DescripcionEnfermedad,
                AntecedentePsicologico = beneficiario.AntecedentePsicologico,
                DescripcionPsicologica = beneficiario.DescripcionPsicologica,
                JornadaId = beneficiario.JornadaId,
                Municipio = beneficiario.Municipio,
                CustodiaBeneficiario = beneficiario.CustodiaBeneficiario,
                DireccionResidencia = beneficiario.DireccionResidencia,
                PadrinoId = beneficiario.PadrinoId,
                AporteEconomicoPadrino = beneficiario.AporteEconomicoPadrino,
                NombreMadre = beneficiario.NombreMadre,
                ApellidoMadre = beneficiario.ApellidoMadre,
                NumeroDocumentoMadre = beneficiario.NumeroDocumentoMadre,
                LugarExpedicionDocumentoMadre = beneficiario.LugarExpedicionDocumentoMadre,
                OcupacionMadre = beneficiario.OcupacionMadre,
                NivelEscolaridadMadre = beneficiario.NivelEscolaridadMadre,
                TelefonoMadre = beneficiario.TelefonoMadre,
                DireccionMadre = beneficiario.DireccionMadre,
                BarrioMadre = beneficiario.BarrioMadre,
                MunicipioMadre = beneficiario.MunicipioMadre,
                IngresoEconomicoMadre = beneficiario.IngresoEconomicoMadre,
                NombrePadre = beneficiario.NombrePadre,
                ApellidoPadre = beneficiario.ApellidoPadre,
                NumeroDocumentoPadre = beneficiario.NumeroDocumentoPadre,
                LugarExpedicionDocumentoPadre = beneficiario.LugarExpedicionDocumentoPadre,
                OcupacionPadre = beneficiario.OcupacionPadre,
                NivelEscolaridadPadre = beneficiario.NivelEscolaridadPadre,
                TelefonoPadre = beneficiario.TelefonoPadre,
                DireccionPadre = beneficiario.DireccionPadre,
                BarrioPadre = beneficiario.BarrioPadre,
                MunicipioPadre = beneficiario.MunicipioPadre,
                IngresoEconomicoPadre = beneficiario.IngresoEconomicoPadre,
                NombreAcudiente = beneficiario.NombreAcudiente,
                ApellidoAcudiente = beneficiario.ApellidoAcudiente,
                NumeroDocumentoAcudiente = beneficiario.NumeroDocumentoAcudiente,
                LugarExpedicionDocumentoAcudiente = beneficiario.LugarExpedicionDocumentoAcudiente,
                OcupacionAcudiente = beneficiario.OcupacionAcudiente,
                NivelEscolaridadAcudiente = beneficiario.NivelEscolaridadAcudiente,
                TelefonoAcudiente = beneficiario.TelefonoAcudiente,
                DireccionAcudiente = beneficiario.DireccionAcudiente,
                BarrioAcudiente = beneficiario.BarrioAcudiente,
                MunicipioAcudiente = beneficiario.MunicipioAcudiente,
                IngresoEconomicoAcudiente = beneficiario.IngresoEconomicoAcudiente,
                EstadoId = beneficiario.EstadoId,
                AutorizacionData = beneficiario.AutorizacionData,
                AutorizacionFoto = beneficiario.AutorizacionFoto,
                NombreImagen = beneficiario.NombreImagen,
                FechaRetiro = beneficiario.FechaRetiro,
                ObservacionRetiro = beneficiario.ObservacionRetiro,
                InstitucionEducativa = beneficiario.InstitucionEducativa,
                FechaMatricula = beneficiario.FechaMatricula,
                NivelEscolaridad = beneficiario.NivelEscolaridad
            };

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
            return View(preinscripcionDto);
        }
    }
}
