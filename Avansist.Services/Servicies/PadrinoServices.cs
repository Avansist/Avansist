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
    public class PadrinoServices : IPadrinoServices
    {
        private readonly AvansistDbContext _context;

        public PadrinoServices(AvansistDbContext context)
        {
            _context = context;
        }
        public async Task EditarPadrino(PadrinoDto padrinoDto)
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
            _context.Update(padrino);
            await _context.SaveChangesAsync();
        }

        public async Task GuardarPadrino(PadrinoDto padrinoDto)
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
            _context.Add(padrino);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<PadrinoResumenDto> ListarPadrinoResumenDto()
        {
            List<PadrinoResumenDto> listaPadrinoDto = new();
            _context.Padrinos.Include(t => t.TipoDocumento).OrderByDescending(p => p.PadrinoId).ToList().ForEach(pa => {
                PadrinoResumenDto padrinoDto = new()
                {
                    PadrinoId = pa.PadrinoId,
                    NombreTipoDocumento = pa.TipoDocumento.NombreTipoDocumento,
                    NumeroDocumento = pa.NumeroDocumento,
                    NombrePadrino = pa.NombrePadrino,
                    ApellidoPadrino = pa.ApellidoPadrino,
                    Ocupacion = pa.Ocupacion
                };
                listaPadrinoDto.Add(padrinoDto);
            });
            return listaPadrinoDto;
        }

        public async Task<IEnumerable<TipoDocumento>> ObtenerListaTipoDocumento()
        {
            return await _context.TipoDocumentos.ToListAsync();
        }

        public async Task<PadrinoDto> ObtenerPadrinoPorId(int id)
        {
            var pa = await _context.Padrinos.Where(p => p.PadrinoId == id).FirstAsync();
            PadrinoDto padrinoDto = new()
            {
                PadrinoId = pa.PadrinoId,
                NombrePadrino = pa.NombrePadrino,
                ApellidoPadrino = pa.ApellidoPadrino,
                TipoDocumentoId = pa.TipoDocumentoId,
                NumeroDocumento = pa.NumeroDocumento,
                Ocupacion = pa.Ocupacion,
                Telefono = pa.Telefono,
                CorreoElectronico = pa.CorreoElectronico
            };
            return padrinoDto;
        }
    }
}
