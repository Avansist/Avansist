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
        Task<ControlAsistencia> ObtenerBeneficiarioPorIdYSalidaPorDefecto(int idBeneficiario);
        IEnumerable<SalidadExtracurricularDto> ListarSalidadExtracurricularDto();
        Task GuardarSalidadExtracurricular(SalidadExtracurricularDto salidadExtracurricularDto);
        Task<SalidaExtracurricular> ObtenerSalidadExtracurricularID(int id);
        Task EditarSalidadExtracurricular(SalidadExtracurricularDto salidadExtracurricularDto);

        IEnumerable<DetalleDto> ListarBeneficiarioDetalleSalidaDto(int id);
        Task<DetalleDto> ObtenerDetalleID(int id);
        Task EliminarDetalleSalida(DetalleSalida detalleSalida);



    }
}
