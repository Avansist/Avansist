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
    public class PreinscripcionServices : IPreinscripcionServices
    {
        private readonly AvansistDbContext _context;

        public PreinscripcionServices(AvansistDbContext context)
        {
            _context = context;
        }

        //**********************************|--------------|**********************************
        //**********************************|PREINSCRIPCION|**********************************
        //**********************************|--------------|**********************************
        //Editar Inf Beneficiario de Preinscripcion
        public async Task EditarBeneficiario(PreinscripcionDto preinscripcionDto)
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
                //Matricula
                FechaMatricula = preinscripcionDto.FechaMatricula,
                InstitucionEducativa = preinscripcionDto.InstitucionEducativa,
                NivelEscolaridad = preinscripcionDto.NivelEscolaridad,
                //Retiro
                FechaRetiro = preinscripcionDto.FechaRetiro,
                ObservacionRetiro = preinscripcionDto.ObservacionRetiro
            };            
            _context.Update(preinscripcion);
            await _context.SaveChangesAsync();
        }

        //Guardar Inf Beneficiario de Preinscripcion
        public async Task GuardarBeneficiario (PreinscripcionDto preinscripcionDto)
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
                EstadoId = preinscripcionDto.EstadoId
            };
            _context.Add(preinscripcion);
            await _context.SaveChangesAsync();
        }

        //Listar Inf Beneficiario de Preinscripcion
        public IEnumerable<BeneficiarioResumenDto> ListarBeneficiarioResumenDto()
        {
            List<BeneficiarioResumenDto> listaBeneficiariosDto = new();
            _context.Preinscripcions.Include(t => t.TipoDocumento).Include(m => m.Modalidad).Include(e => e.Estado)
                .OrderByDescending(b => b.PreinscripcionId).ToList().ForEach(be =>
                {
                    BeneficiarioResumenDto beneficiarioDto = new()
                    {
                        PreinscripcionId = be.PreinscripcionId,
                        NombreTipoDocumento = be.TipoDocumento.NombreTipoDocumento,
                        NumeroDocumento = be.NumeroDocumento,
                        NombreBeneficiario = be.PrimerNombreBeneficiario,
                        ApellidoBeneficiario = be.PrimerApellidoBeneficiario,
                        NombreModalidad = be.Modalidad.NombreModalidad,
                        NombreEstado = be.Estado.NombreEstado
                    };
                    listaBeneficiariosDto.Add(beneficiarioDto);
                });
            return listaBeneficiariosDto;
        }

        //Obtener Inf Beneficiario de Preinscripcion
        public async Task<PreinscripcionDto> ObtenerBeneficiarioPorId(int id)
        {
            var b = await _context.Preinscripcions.Where(be => be.PreinscripcionId == id).FirstAsync();
            PreinscripcionDto preinscripcionDto = new()
            {
                PreinscripcionId = b.PreinscripcionId,
                ModalidadId = b.ModalidadId,
                FechaRegistro = b.FechaRegistro,
                PrimerNombreBeneficiario = b.PrimerNombreBeneficiario,
                SegundoNombreBeneficiario = b.SegundoNombreBeneficiario,
                PrimerApellidoBeneficiario = b.PrimerApellidoBeneficiario,
                SegundoApellidoBeneficiario = b.SegundoApellidoBeneficiario,
                GeneroId = b.GeneroId,
                Edad = b.Edad,
                TallaCamisa = b.TallaCamisa,
                TallaPantalon = b.TallaPantalon,
                TallaZapatos = b.TallaZapatos,
                GrupoSanguineoId = b.GrupoSanguineoId,
                FechaNacimiento = b.FechaNacimiento,
                LugarNacimiento = b.LugarNacimiento,
                TipoDocumentoId = b.TipoDocumentoId,
                NumeroDocumento = b.NumeroDocumento,
                LugarExpedicionDocumento = b.LugarExpedicionDocumento,
                NombreEps = b.NombreEps,
                GrupoSisben = b.GrupoSisben,
                EtniaId = b.EtniaId,
                AntecedenteMedico = b.AntecedenteMedico,
                DescripcionEnfermedad = b.DescripcionEnfermedad,
                AntecedentePsicologico = b.AntecedentePsicologico,
                DescripcionPsicologica = b.DescripcionPsicologica,
                JornadaId = b.JornadaId,
                Municipio = b.Municipio,
                CustodiaBeneficiario = b.CustodiaBeneficiario,
                DireccionResidencia = b.DireccionResidencia,
                PadrinoId = b.PadrinoId,
                AporteEconomicoPadrino = b.AporteEconomicoPadrino,
                NombreMadre = b.NombreMadre,
                ApellidoMadre = b.ApellidoMadre,
                NumeroDocumentoMadre = b.NumeroDocumentoMadre,
                LugarExpedicionDocumentoMadre = b.LugarExpedicionDocumentoMadre,
                OcupacionMadre = b.OcupacionMadre,
                NivelEscolaridadMadre = b.NivelEscolaridadMadre,
                TelefonoMadre = b.TelefonoMadre,
                DireccionMadre = b.DireccionMadre,
                BarrioMadre = b.BarrioMadre,
                MunicipioMadre = b.MunicipioMadre,
                IngresoEconomicoMadre = b.IngresoEconomicoMadre,
                NombrePadre = b.NombrePadre,
                ApellidoPadre = b.ApellidoPadre,
                NumeroDocumentoPadre = b.NumeroDocumentoPadre,
                LugarExpedicionDocumentoPadre = b.LugarExpedicionDocumentoPadre,
                OcupacionPadre = b.OcupacionPadre,
                NivelEscolaridadPadre = b.NivelEscolaridadPadre,
                TelefonoPadre = b.TelefonoPadre,
                DireccionPadre = b.DireccionPadre,
                BarrioPadre = b.BarrioPadre,
                MunicipioPadre = b.MunicipioPadre,
                IngresoEconomicoPadre = b.IngresoEconomicoPadre,
                NombreAcudiente = b.NombreAcudiente,
                ApellidoAcudiente = b.ApellidoAcudiente,
                NumeroDocumentoAcudiente = b.NumeroDocumentoAcudiente,
                LugarExpedicionDocumentoAcudiente = b.LugarExpedicionDocumentoAcudiente,
                OcupacionAcudiente = b.OcupacionAcudiente,
                NivelEscolaridadAcudiente = b.NivelEscolaridadAcudiente,
                TelefonoAcudiente = b.TelefonoAcudiente,
                DireccionAcudiente = b.DireccionAcudiente,
                BarrioAcudiente = b.BarrioAcudiente,
                MunicipioAcudiente = b.MunicipioAcudiente,
                IngresoEconomicoAcudiente = b.IngresoEconomicoAcudiente,
                EstadoId = b.EstadoId,
                //Matricula
                FechaMatricula = b.FechaMatricula,
                InstitucionEducativa = b.InstitucionEducativa,
                NivelEscolaridad = b.NivelEscolaridad,
                //Retiro
                FechaRetiro = b.FechaRetiro,
                ObservacionRetiro = b.ObservacionRetiro
            };
            return preinscripcionDto;
        }

        //Obtener Lista De Foraneas Para Preinscripción
        public async Task<IEnumerable<Etnia>> ObtenerListaEtnia()
        {
            return await _context.Etnias.ToListAsync();
        }

        public async Task<IEnumerable<Genero>> ObtenerListaGenero()
        {
            return await _context.Generos.ToListAsync();
        }

        public async Task<IEnumerable<GrupoSanguineo>> ObtenerListaGrupoSanguineo()
        {
            return await _context.GrupoSanguineos.ToListAsync();
        }

        public async Task<IEnumerable<Jornada>> ObtenerListaJornada()
        {
            return await _context.Jornadas.ToListAsync();
        }

        public async Task<IEnumerable<Modalidad>> ObtenerListaModalidad()
        {
            return await _context.Modalidads.ToListAsync();
        }

        public async Task<IEnumerable<Padrino>> ObtenerListaPadrinos()
        {
            return await _context.Padrinos.ToListAsync();
        }

        public async Task<IEnumerable<TipoDocumento>> ObtenerListaTipoDocumento()
        {
            return await _context.TipoDocumentos.ToListAsync();
        }

        public async Task<IEnumerable<Estado>> ObtenerListaEstados()
        {
            return await _context.Estados.ToArrayAsync();
        }

        //**********************************|--------------|**********************************
        //**********************************|AG-BENFICIARIO|**********************************
        //**********************************|--------------|**********************************
        //Crear Agenda Del Beneficiario
        public async Task GuardarAgendaBeneficiario(AgendaBeneficiarioDto agendaBeneficiarioDto)
        {
            AgendaBeneficiario agendaBeneficiario = new()
            {
                AgendaBeneficiarioId = agendaBeneficiarioDto.AgendaBeneficiarioId,
                NombreEvento = agendaBeneficiarioDto.NombreEvento,
                EmpleadoEncargado = agendaBeneficiarioDto.EmpleadoEncargado,
                NumeroDocumento = agendaBeneficiarioDto.NumeroDocumento,
                Telefono = agendaBeneficiarioDto.Telefono,
                Direccion = agendaBeneficiarioDto.Direccion,
                FechaInicioEvento = agendaBeneficiarioDto.FechaInicioEvento,
                FechaFinEvento = agendaBeneficiarioDto.FechaFinEvento,
                PreinscripcionId = agendaBeneficiarioDto.PreinscripcionId
            };

            _context.Add(agendaBeneficiario);
            await _context.SaveChangesAsync();
        }

        //Obtener Foraneas Para Agenda
        public async Task<PreinscripcionDto> BuscarBeneficiarioPorId(int id)
        {
            var b = await _context.Preinscripcions.Where(be => be.PreinscripcionId == id).FirstAsync();
            PreinscripcionDto preinscripcionDto = new()
            {
                PreinscripcionId = b.PreinscripcionId,
            };
            return preinscripcionDto;
        }

        //**********************************|--------------|**********************************
        //**********************************| INSCRIPCION  |**********************************
        //**********************************|--------------|**********************************
        //Lista Inf de Inscripción del Beneficiario
        public IEnumerable<BeneficiarioResumenDto> ListarBeneficiarioResumenDtoInscritos()
        {
            List<BeneficiarioResumenDto> listaBeneficiariosDto = new();

            _context.Preinscripcions.Include(t => t.TipoDocumento).Include(e => e.Estado).Include(m => m.Modalidad).Where(e => e.Estado.NombreEstado == "Inscrito")
                .OrderByDescending(b => b.PreinscripcionId).ToList().ForEach(be => {
                    BeneficiarioResumenDto beneficiarioDto = new()
                    {
                        PreinscripcionId = be.PreinscripcionId,
                        NombreTipoDocumento = be.TipoDocumento.NombreTipoDocumento,
                        NumeroDocumento = be.NumeroDocumento,
                        NombreBeneficiario = be.PrimerNombreBeneficiario,
                        ApellidoBeneficiario = be.PrimerApellidoBeneficiario,
                        NombreModalidad = be.Modalidad.NombreModalidad,
                        NombreEstado = be.Estado.NombreEstado
                    };
                    listaBeneficiariosDto.Add(beneficiarioDto);
                });
            return listaBeneficiariosDto;
        }

        public async Task GuardarMatricula(PreinscripcionDto preinscripcionDto)
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
                NivelEscolaridad = preinscripcionDto.NivelEscolaridad
            };
            _context.Update(preinscripcion);
            await _context.SaveChangesAsync();
        }

        //**********************************|--------------|**********************************
        //**********************************|   MATRICULA  |**********************************
        //**********************************|--------------|**********************************
        //Lista Inf de Matricula del Beneficiario
        public IEnumerable<BeneficiarioResumenDto> ListarMatriculaDto()
        {
            List<BeneficiarioResumenDto> listaBeneficiariosDto = new();

            _context.Preinscripcions.Include(t => t.TipoDocumento).Include(e => e.Estado).Include(m => m.Modalidad).Where(e => e.Estado.NombreEstado == "Matriculado")
                .OrderByDescending(b => b.PreinscripcionId).ToList().ForEach(be => {
                    BeneficiarioResumenDto beneficiarioDto = new()
                    {
                        PreinscripcionId = be.PreinscripcionId,
                        NombreTipoDocumento = be.TipoDocumento.NombreTipoDocumento,
                        NumeroDocumento = be.NumeroDocumento,
                        NombreBeneficiario = be.PrimerNombreBeneficiario,
                        ApellidoBeneficiario = be.PrimerApellidoBeneficiario,
                        NombreModalidad = be.Modalidad.NombreModalidad,
                        NombreEstado = be.Estado.NombreEstado
                    };
                    listaBeneficiariosDto.Add(beneficiarioDto);
                });
            return listaBeneficiariosDto;
        }

        public async Task EditarMatricula(PreinscripcionDto preinscripcionDto)
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
                //Matricula
                FechaMatricula = preinscripcionDto.FechaMatricula,
                InstitucionEducativa = preinscripcionDto.InstitucionEducativa,
                NivelEscolaridad = preinscripcionDto.NivelEscolaridad,
                //Retiro
                FechaRetiro = preinscripcionDto.FechaRetiro,
                ObservacionRetiro = preinscripcionDto.ObservacionRetiro
            };
            _context.Update(preinscripcion);
            await _context.SaveChangesAsync();
        }

        public async Task GuardarRetiro(PreinscripcionDto preinscripcionDto)
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
                //Retiro
                FechaRetiro = preinscripcionDto.FechaRetiro,
                ObservacionRetiro = preinscripcionDto.ObservacionRetiro
            };
            _context.Update(preinscripcion);
            await _context.SaveChangesAsync();
        }


        //**********************************|--------------|**********************************
        //**********************************|    RETIRO    |**********************************
        //**********************************|--------------|**********************************
        //Lista Inf de Retiro del Beneficiario

        public IEnumerable<BeneficiarioResumenDto> ListarRetiroDto()
        {
            List<BeneficiarioResumenDto> listaBeneficiariosDto = new();

            _context.Preinscripcions.Include(t => t.TipoDocumento).Include(e => e.Estado).Include(m => m.Modalidad).Where(e => e.Estado.NombreEstado == "Retirado")
                .OrderByDescending(b => b.PreinscripcionId).ToList().ForEach(be => {
                    BeneficiarioResumenDto beneficiarioDto = new()
                    {
                        PreinscripcionId = be.PreinscripcionId,
                        NombreTipoDocumento = be.TipoDocumento.NombreTipoDocumento,
                        NumeroDocumento = be.NumeroDocumento,
                        NombreBeneficiario = be.PrimerNombreBeneficiario,
                        ApellidoBeneficiario = be.PrimerApellidoBeneficiario,
                        NombreModalidad = be.Modalidad.NombreModalidad,
                        NombreEstado = be.Estado.NombreEstado
                    };
                    listaBeneficiariosDto.Add(beneficiarioDto);
                });
            return listaBeneficiariosDto;
        }

        public async Task EditarRetiro(PreinscripcionDto preinscripcionDto)
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
                //Matricula
                FechaMatricula = preinscripcionDto.FechaMatricula,
                InstitucionEducativa = preinscripcionDto.InstitucionEducativa,
                NivelEscolaridad = preinscripcionDto.NivelEscolaridad,
                //Retiro
                FechaRetiro = preinscripcionDto.FechaRetiro,
                ObservacionRetiro = preinscripcionDto.ObservacionRetiro
            };
            _context.Update(preinscripcion);
            await _context.SaveChangesAsync();
        }
    }
}
