using Avansist.Models.Entities;
using Avansist.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansist.Services.Abstract
{
    public interface IPadrinoServices
    {
        Task EditarPadrino(PadrinoDto padrinoDto);
        Task GuardarPadrino(PadrinoDto padrinoDto);
        IEnumerable<PadrinoResumenDto> ListarPadrinoResumenDto();
        Task<PadrinoDto> ObtenerPadrinoPorId(int id);
        Task<IEnumerable<TipoDocumento>> ObtenerListaTipoDocumento();
    }
}
