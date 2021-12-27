using Avansist.DAL;
using Avansist.Models.Entities;
using Avansist.Services.Abstract;
using Avansist.Services.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansist.Services.Servicies
{
    public class ControlAsistenciaServices : IControlAsistenciaServices
    {
        private readonly AvansistDbContext _context;

        public ControlAsistenciaServices(AvansistDbContext context)
        {
            _context = context;
        }

        //********************************|------------------|**********************************
        //********************************|ASISTENCIA INGRESO|**********************************
        //********************************|------------------|**********************************
        //Editar Inf Beneficiario de Ingreso
        public async Task EditarIngreso(ControlAsistenciaDto controlAsistenciaDto)
        {
            ControlAsistencia controlAsistencia = new()
            {
                ControlAsistenciaId = controlAsistenciaDto.ControlAsistenciaId,
                PreinscripcionId = controlAsistenciaDto.PreinscripcionId,
                FechaIngreso = controlAsistenciaDto.FechaIngreso,
                ObservacionIngreso = controlAsistenciaDto.ObservacionIngreso,
                FechaSalida = controlAsistenciaDto.FechaSalida,
                AutorizacionSalida = controlAsistenciaDto.AutorizacionSalida,
                ObservacionSalida = controlAsistenciaDto.ObservacionSalida
            };
            _context.Update(controlAsistencia);
            await _context.SaveChangesAsync();
        }

        //Guardar Inf Beneficiario de Ingreso
        public async Task GuardarIngreso(ControlAsistenciaDto controlAsistenciaDto)
        {
            ControlAsistencia controlAsistencia = new()
            {
                ControlAsistenciaId = controlAsistenciaDto.ControlAsistenciaId,
                PreinscripcionId = controlAsistenciaDto.PreinscripcionId,
                FechaIngreso = controlAsistenciaDto.FechaIngreso,
                ObservacionIngreso = controlAsistenciaDto.ObservacionIngreso,
                FechaSalida = controlAsistenciaDto.FechaSalida,
                AutorizacionSalida = controlAsistenciaDto.AutorizacionSalida,
                ObservacionSalida = controlAsistenciaDto.ObservacionSalida
            };
            _context.Add(controlAsistencia);
            await _context.SaveChangesAsync();
        }

        //Listar Inf Beneficiario de Ingreso
        public IEnumerable<ControlAsistenciaResumenDto> ListarControlAsistenciaResumenDto()
        {
            List<ControlAsistenciaResumenDto> listaControlAsistenciaDto = new();
            _context.ControlAsistencias.Include(p => p.Preinscripcion)
                .OrderByDescending(c => c.FechaSalida).ToList().ForEach(ci =>
                {
                    ControlAsistenciaResumenDto controlAsistenciaDto = new()
                    {
                        ControlAsistenciaId = ci.ControlAsistenciaId,
                        NombreBeneficiario = ci.Preinscripcion.PrimerNombreBeneficiario,
                        ApellidoBeneficiario = ci.Preinscripcion.PrimerApellidoBeneficiario,
                        FechaIngreso = ci.FechaIngreso,
                        AutorizacionSalida = ci.AutorizacionSalida,
                        FechaSalida = ci.FechaSalida
                    };
                    listaControlAsistenciaDto.Add(controlAsistenciaDto);
                });
            return listaControlAsistenciaDto;
        }

        //Obtener Inf Beneficiario de Ingreso
        public async Task<ControlAsistenciaDto> ObtenerIngresoPorId(int id)
        {
            var i = await _context.ControlAsistencias.Where(ci => ci.ControlAsistenciaId == id).FirstAsync();
            ControlAsistenciaDto controlAsistenciaDto = new()
            {
                ControlAsistenciaId = i.ControlAsistenciaId,
                PreinscripcionId = i.PreinscripcionId,
                FechaIngreso = i.FechaIngreso,
                ObservacionIngreso = i.ObservacionIngreso,
                FechaSalida = i.FechaSalida,
                AutorizacionSalida = i.AutorizacionSalida,
                ObservacionSalida = i.ObservacionSalida
            };
            return controlAsistenciaDto;
        }
        
        //Obtener Lista De Foraneas Para Control de ingreso
        public async Task<IEnumerable<Preinscripcion>> ObtenerListaBeneficiario()
        {
            return await _context.Preinscripcions.ToListAsync();
        }

        // obtener beneficiario por id y salida por defecto
        public async Task<ControlAsistencia> ObtenerBeneficiarioPorIdYSalidaPorDefecto(int idBeneficiario)
        {
            return await _context.ControlAsistencias.FirstOrDefaultAsync(n => n.PreinscripcionId == idBeneficiario && n.FechaSalida == DateTime.MinValue);
        }


        //-----------------------------------
        // ESTE ES EL SERVICIP PARA MOSTRAR LA VISTA DEL INDEX

        //Listar evento salidad extracurricular
        public IEnumerable<SalidadExtracurricularDto> ListarSalidadExtracurricularDto()
        {
            List<SalidadExtracurricularDto> listarSalidadExtracurricularDto = new();
            _context.SalidaExtracurriculars
                .OrderByDescending(c => c.FechaSalidadEvento).ToList().ForEach(ci =>
                {
                    SalidadExtracurricularDto SalidadExtracurricularDto = new()
                    {
                        SalidaExtracurricularId = ci.SalidaExtracurricularId,
                        NombreSalidadEvento = ci.NombreSalidadEvento,
                        Direccion = ci.Direccion,
                        ResponsableEvento = ci.ResponsableEvento,
                        FechaSalidadEvento = ci.FechaSalidadEvento,
                        FechaRegresoEvento = ci.FechaRegresoEvento

                    };
                    listarSalidadExtracurricularDto.Add(SalidadExtracurricularDto);
                });
            return listarSalidadExtracurricularDto;
        }

        //Guardar Inf salidad extracurricular
        public async Task GuardarSalidadExtracurricular(SalidadExtracurricularDto salidadExtracurricularDto)
        {
            SalidaExtracurricular salidadExtracurricular = new()
            {
                SalidaExtracurricularId = salidadExtracurricularDto.SalidaExtracurricularId,
                NombreSalidadEvento = salidadExtracurricularDto.NombreSalidadEvento,
                Direccion = salidadExtracurricularDto.Direccion,
                ResponsableEvento = salidadExtracurricularDto.ResponsableEvento,
                DocumentoResponsable = salidadExtracurricularDto.DocumentoResponsable,
                EstadoEvento = salidadExtracurricularDto.EstadoEvento,
                FechaSalidadEvento = salidadExtracurricularDto.FechaSalidadEvento,
                FechaRegresoEvento = salidadExtracurricularDto.FechaRegresoEvento
            };
            _context.Add(salidadExtracurricular);
            await _context.SaveChangesAsync();
        }


        public async Task<SalidaExtracurricular> ObtenerSalidadExtracurricularID(int id)
        {
            var s = await _context.SalidaExtracurriculars.Include(p => p.DetalleSalidas).Include(pr => pr.Preinscripcion).Where(se => se.SalidaExtracurricularId == id).FirstAsync();
            SalidaExtracurricular salidadExtracurricular= new()
            {
                SalidaExtracurricularId = s.SalidaExtracurricularId,
                
                NombreSalidadEvento = s.NombreSalidadEvento,
                Direccion = s.Direccion,
                ResponsableEvento = s.ResponsableEvento,
                DocumentoResponsable = s.DocumentoResponsable,
                EstadoEvento = s.EstadoEvento,
                FechaSalidadEvento = s.FechaSalidadEvento,
                FechaRegresoEvento = s.FechaRegresoEvento

            };
            return salidadExtracurricular;
        }

        //Editar salida extracurricular
        public async Task EditarSalidadExtracurricular(SalidadExtracurricularDto salidadExtracurricularDto)
        {
            SalidaExtracurricular salidadExtracurricular = new()
            {
                SalidaExtracurricularId = salidadExtracurricularDto.SalidaExtracurricularId,
                
                NombreSalidadEvento = salidadExtracurricularDto.NombreSalidadEvento,
                Direccion = salidadExtracurricularDto.Direccion,
                ResponsableEvento = salidadExtracurricularDto.ResponsableEvento,
                DocumentoResponsable = salidadExtracurricularDto.DocumentoResponsable,
                EstadoEvento = salidadExtracurricularDto.EstadoEvento,
                FechaSalidadEvento = salidadExtracurricularDto.FechaSalidadEvento,
                FechaRegresoEvento = salidadExtracurricularDto.FechaRegresoEvento
            };
            _context.Update(salidadExtracurricular);
            await _context.SaveChangesAsync();
        }


        public IEnumerable<DetalleDto> ListarBeneficiarioDetalleSalidaDto(int id)
        {
            List<DetalleDto> listaDetalleDto = new();
            _context.DetalleSalidas.Include(pr => pr.Preinscripcions).Include(se => se.SalidaExtracurricular).Where(sex => sex.SalidaExtracurricularId == id).OrderByDescending(ds => ds.DetalleSalidaId).ToList().ForEach(
                t => {
                    DetalleDto detalleDto = new()
                    {
                        DetalleId = t.DetalleSalidaId,
                        SalidaExtracurricularId = t.SalidaExtracurricularId,
                        NombreBeneficiario = t.Preinscripcions.NombreCompleto,
                        AutorizacionSalidaExtracurricular = t.AutorizacionSalidaExtracurricular


                    };
                    listaDetalleDto.Add(detalleDto);
                });
            return listaDetalleDto;
        }





        public async Task<DetalleDto> ObtenerDetalleID(int id)
        {
            var s = await _context.DetalleSalidas.Where(se => se.DetalleSalidaId == id).FirstAsync();
            DetalleDto detalleDto = new()
            {
                DetalleId = s.DetalleSalidaId
            };
            return detalleDto;
        }
        
        public async Task EliminarDetalleSalida(DetalleSalida detalleSalida)
        {
            try
            {
                _context.Remove(detalleSalida);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }

        } 


























    }
}
