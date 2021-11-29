using Avansist.DAL;
using Avansist.Models.Entities;
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
        private readonly AvansistDbContext _avansistDbContext;

        public ControlAsistenciaController(IControlAsistenciaServices controlAsistenciaServices , AvansistDbContext avansistDbContext )
        {
            _controlAsistenciaServices = controlAsistenciaServices;
            _avansistDbContext = avansistDbContext;
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
        public async Task<IActionResult> Create(ControlAsistenciaDto controlAsistenciaDto)
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
        public async Task<IActionResult> Edit(ControlAsistenciaDto controlAsistenciaDto)
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















        //**********************************|--------------|**********************************
        //**********************************|SALIDA EXTRACURRICULAR|************
        //**********************************|--------------|**********************************


        // INDEX SALIDA EXTRACURRICULAR
        public IActionResult IndexSalidadExtracurricular()
        {

            var listarSalidadExtracurricularDto = _controlAsistenciaServices.ListarSalidadExtracurricularDto();
            return View(listarSalidadExtracurricularDto);
        }

        //Crear salida extracurricular

        public async Task<IActionResult> CreateSalidadextracurricular()
        {
            ViewData["listaBeneficiarios"] = new SelectList(await _controlAsistenciaServices.ObtenerListaBeneficiario(), "PreinscripcionId", "PrimerNombreBeneficiario");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSalidadextracurricular(SalidadExtracurricularDto salidadExtracurricularDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _controlAsistenciaServices.GuardarSalidadExtracurricular(salidadExtracurricularDto);
                    return RedirectToAction("IndexSalidadExtracurricular", "ControlAsistencia");
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return View(salidadExtracurricularDto);
        }




        // editarrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr



        public async Task<IActionResult> EditarSalidadExtracurricular(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var controlsalidadE = await _controlAsistenciaServices.ObtenerSalidadExtracurricularID(id.Value);


            if (controlsalidadE == null)
            {
                return NotFound();
            }
            return View(controlsalidadE);
        }

        // POST: Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> EditarSalidadExtracurricular(SalidadExtracurricularDto salidadExtracurricularDto)
        {
            if (salidadExtracurricularDto.SalidaExtracurricularId == salidadExtracurricularDto.SalidaExtracurricularId)
            {
                if (ModelState.IsValid)
                {
                    await _controlAsistenciaServices.EditarSalidadExtracurricular(salidadExtracurricularDto);
                    return RedirectToAction("IndexSalidadExtracurricular", "ControlAsistencia");
                }
                return View(salidadExtracurricularDto);
            }
            return NotFound();
        }



        public  IActionResult IndexDetalleSalida()
        {
            var listarDetalleSalida =  _controlAsistenciaServices.ListarBeneficiarioDetalleSalidaDto();
            return View(listarDetalleSalida);
        }



        //--------------------------------------
        public IActionResult GuardarDetalle(DetalleDto detalle)
        {
            using (var transaction = _avansistDbContext.Database.BeginTransaction())
            {
                try
                {
                    SalidaExtracurricular salidaExtracurricular = new()
                    {
                        PreinscripcionId = detalle.PreinscripcionId,
                        NombreSalidadEvento = detalle.NombreSalidadEvento,
                        Direccion = detalle.Direccion,
                        ResponsableEvento = detalle.ResponsableEvento,
                        DocumentoResponsable = detalle.DocumentoResponsable,
                        EstadoEvento = detalle.EstadoEvento,
                        FechaSalidadEvento = detalle.FechaSalidadEvento,
                        FechaRegresoEvento = detalle.FechaRegresoEvento

                    };
                    _avansistDbContext.Add(salidaExtracurricular);
                    _avansistDbContext.SaveChanges();
                     

                    foreach (Preinscripcion item in _avansistDbContext.Preinscripcions)
                    {
                        DetalleSalida detalleSalida = new DetalleSalida()
                        {
                            PreinscripcionId = item.PreinscripcionId,
                            SalidaExtracurricularId = salidaExtracurricular.SalidaExtracurricularId
                        };
                        _avansistDbContext.Add(detalleSalida);
                       
                    }
                    _avansistDbContext.SaveChanges();

                    

                    transaction.Commit();
                }
                catch (Exception)
                {

                    transaction.Rollback();
                }
                return RedirectToAction("IndexSalidadExtracurricular");
            }
            
        }


        public async Task<IActionResult> EliminarRegistro(int? id)
        {
            var detalleSalida = await _controlAsistenciaServices.ObtenerDetalleID(id.Value);
            if (detalleSalida == null)
            {
                return NotFound();
            }
            DetalleSalida detallesalida1 = new()
            {
                DetalleSalidaId = detalleSalida.DetalleId
            };
            try
            {
                await _controlAsistenciaServices.EliminarDetalleSalida(detallesalida1);
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction("CreateSalidadextracurricular");

        }








    }
}
