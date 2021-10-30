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
        Task EditarBeneficiario(PreinscripcionDto preinscripcionDto);
        Task GuardarBeneficiario(PreinscripcionDto preinscripcionDto);
        IEnumerable<BeneficiarioResumenDto> ListarBeneficiarioResumenDto();
        Task<PreinscripcionDto> ObtenerBeneficiarioPorId(int id);
        Task<Preinscripcion> ObtenerBeneficiarioPorDocumentoYEstado(string doc);
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
        Task GuardarMatricula(PreinscripcionDto preinscripcionDto);

        //Matricula
        IEnumerable<BeneficiarioResumenDto> ListarMatriculaDto();
        Task EditarMatricula(PreinscripcionDto preinscripcionDto);
        Task GuardarRetiro(PreinscripcionDto preinscripcionDto);

        //Retiro
        IEnumerable<BeneficiarioResumenDto> ListarRetiroDto();
        Task EditarRetiro(PreinscripcionDto preinscripcionDto);
    }
}
