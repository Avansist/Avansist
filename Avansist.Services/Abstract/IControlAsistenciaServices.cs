using Avansist.Models.Entities;
using Avansist.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansist.Services.Abstract
{
    public interface IControlAsistenciaServices
    {
        Task<IEnumerable<Preinscripcion>> ObtenerListaBeneficiario();
        Task<ControlAsistenciaDto> ObtenerIngresoPorId(int id);
        IEnumerable<ControlAsistenciaResumenDto> ListarControlAsistenciaResumenDto();
        Task GuardarIngreso(ControlAsistenciaDto controlAsistenciaDto);
        Task EditarIngreso(ControlAsistenciaDto controlAsistenciaDto);


        IEnumerable<SalidadExtracurricularDto> ListarSalidadExtracurricularDto();
        Task GuardarSalidadExtracurricular(SalidadExtracurricularDto salidadExtracurricularDto);
        Task<SalidaExtracurricular> ObtenerSalidadExtracurricularID(int id);
        Task EditarSalidadExtracurricular(SalidadExtracurricularDto salidadExtracurricularDto);

        IEnumerable<DetalleDto> ListarBeneficiarioDetalleSalidaDto();
        Task<DetalleDto> ObtenerDetalleID(int id);
        Task EliminarDetalleSalida(DetalleSalida detalleSalida);

    }
}
