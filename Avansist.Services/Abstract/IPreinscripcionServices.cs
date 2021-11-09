using Avansist.Models.Entities;
using Avansist.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansist.Services.Abstract
{
    public interface IPreinscripcionServices
    {
        //Preinscripción
        Task EditarBeneficiario(Preinscripcion preinscripcion);
        Task GuardarBeneficiario(Preinscripcion preinscripcion);
        IEnumerable<BeneficiarioResumenDto> ListarBeneficiarioResumenDto();
        Task<Preinscripcion> ObtenerBeneficiarioPorId(int id);
        Task<Preinscripcion> ObtenerBeneficiarioPorDocumentoYEstado(string doc);

        //--------------------------------------------------
        Task<IEnumerable<Estado>> ObtenerListaEstados();
        Task<IEnumerable<TipoDocumento>> ObtenerListaTipoDocumento();
        Task<IEnumerable<Padrino>> ObtenerListaPadrinos();
        Task<IEnumerable<Modalidad>> ObtenerListaModalidad();
        Task<IEnumerable<Jornada>> ObtenerListaJornada();
        Task<IEnumerable<GrupoSanguineo>> ObtenerListaGrupoSanguineo();
        Task<IEnumerable<Genero>> ObtenerListaGenero();
        Task<IEnumerable<Etnia>> ObtenerListaEtnia();
        Task<IEnumerable<Estado>> ObtenerEstadoMatricula();

        //Agenda beneficiario
        Task GuardarAgendaBeneficiario(AgendaBeneficiarioDto agendaBeneficiarioDto);
        Task<PreinscripcionDto> BuscarBeneficiarioPorId(int id);

        //Inscripción
        IEnumerable<BeneficiarioResumenDto> ListarBeneficiarioResumenDtoInscritos();
        Task GuardarMatricula(Preinscripcion preinscripcion);

        //Matricula
        IEnumerable<BeneficiarioResumenDto> ListarMatriculaDto();
        Task EditarMatricula(Preinscripcion preinscripcion);
        Task GuardarRetiro(PreinscripcionDto preinscripcionDto);

        //Retiro
        IEnumerable<BeneficiarioResumenDto> ListarRetiroDto();
        Task EditarRetiro(PreinscripcionDto preinscripcionDto);
    }
}
