using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansist.Models.Entities
{
    public class Preinscripcion
    {
        [Key]
        public int PreinscripcionId { get; set; }

        //Inf Personal Beneficiario
        [Column(TypeName = "nvarchar(50)")]
        public string PrimerNombreBeneficiario { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string SegundoNombreBeneficiario { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string PrimerApellidoBeneficiario { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string SegundoApellidoBeneficiario { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string LugarNacimiento { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string Edad { get; set; }
        public int GeneroId { get; set; }
        public int TipoDocumentoId { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string NumeroDocumento { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string LugarExpedicionDocumento { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string DireccionResidencia { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Municipio { get; set; }

        //Inf Medica y Psicologica
        public int GrupoSanguineoId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string NombreEps { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string GrupoSisben { get; set; }
        public bool AntecedenteMedico { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string DescripcionEnfermedad { get; set; }
        public bool AntecedentePsicologico { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string DescripcionPsicologica { get; set; }

        //Inf Matricula
        [Column(TypeName = "nvarchar(50)")]
        public string InstitucionEducativa { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string NivelEscolaridad { get; set; }
        public int JornadaId { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaMatricula { get; set; }

        //Inf Retiro
        [Column(TypeName = "date")]
        public DateTime FechaRetiro { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string ObservacionRetiro { get; set; }

        //Otra Inf Beneficiario
        [Column(TypeName = "nvarchar(10)")]
        public string TallaCamisa { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string TallaPantalon { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string TallaZapatos { get; set; }
        public int ModalidadId { get; set; }
        public int EtniaId { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string CustodiaBeneficiario { get; set; }

        //Inf Padrino
        public int PadrinoId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public double AporteEconomicoPadrino { get; set; }

        //Info Madre
        [Column(TypeName = "nvarchar(50)")]
        public string NombreMadre { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string ApellidoMadre { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string NumeroDocumentoMadre { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string LugarExpedicionDocumentoMadre { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string OcupacionMadre { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string NivelEscolaridadMadre { get; set; }
        [Column(TypeName = "nvarchar(45)")]
        public string TelefonoMadre { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string DireccionMadre { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string BarrioMadre { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string MunicipioMadre { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public double IngresoEconomicoMadre { get; set; }

        //Inf Padre
        [Column(TypeName = "nvarchar(50)")]
        public string NombrePadre { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string ApellidoPadre { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string NumeroDocumentoPadre { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string LugarExpedicionDocumentoPadre { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string OcupacionPadre { get; set; }
        [Column(TypeName = "nvarchar(45)")]
        public string NivelEscolaridadPadre { get; set; }
        [Column(TypeName = "nvarchar(45)")]
        public string TelefonoPadre { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string DireccionPadre { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string BarrioPadre { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string MunicipioPadre { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public double IngresoEconomicoPadre { get; set; }

        //Inf Acudiente
        [Column(TypeName = "nvarchar(50)")]
        public string NombreAcudiente { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string ApellidoAcudiente { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string NumeroDocumentoAcudiente { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string LugarExpedicionDocumentoAcudiente { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string OcupacionAcudiente { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string NivelEscolaridadAcudiente { get; set; }
        [Column(TypeName = "nvarchar(45)")]
        public string TelefonoAcudiente { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string DireccionAcudiente { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string BarrioAcudiente { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string MunicipioAcudiente { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public double IngresoEconomicoAcudiente { get; set; }

        //Complementarios
        [Column(TypeName = "date")]
        public DateTime FechaRegistro { get; set; }
        public int EstadoId { get; set; }

        //Autorizacion publicacion de fotos y recoleccion de datos --------------- Falta
        public bool AutorizacionFoto { get; set; }
        public bool AutorizacionData { get; set; }

        //Documentos y foto -------- falta para adjuntar los documentos
        public string NombreImagen { get; set; }

        //Foraneas
        public virtual Etnia Etnia { get; set; }
        public virtual Genero Genero { get; set; }
        public virtual GrupoSanguineo GrupoSanguineo { get; set; }
        public virtual Jornada Jornada { get; set; }
        public virtual Modalidad Modalidad { get; set; }
        public virtual Padrino Padrino { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }
        public virtual List<ControlAsistencia> ControlAsistencias { get; set; }
        public virtual List<DetalleSalida> DetalleSalidas { get; set; }
        public virtual List<AgendaBeneficiario> AgendaBeneficiarios { get; set; }
    }
}
