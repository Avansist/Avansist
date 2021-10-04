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
                .OrderByDescending(c => c.ControlAsistenciaId).ToList().ForEach(ci =>
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
    }
}
