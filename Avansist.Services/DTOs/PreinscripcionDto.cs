using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansist.Services.DTOs
{
    public class PreinscripcionDto
    {
        public int PreinscripcionId { get; set; }

        //Inf Personal Beneficiario
        [DisplayName("Primer nombre beneficiario")]
        [Required(ErrorMessage = "El primer nombre del beneficiario es requerido")]
        [StringLength(45, MinimumLength = 3)]
        public string PrimerNombreBeneficiario { get; set; }
        [DisplayName("Segundo nombre beneficiario")]
        [StringLength(45, MinimumLength = 3)]
        public string SegundoNombreBeneficiario { get; set; }
        [DisplayName("Primer apellido beneficiario")]
        [Required(ErrorMessage = "El primer apellido del beneficiario es requerido")]
        [StringLength(45, MinimumLength = 3)]
        public string PrimerApellidoBeneficiario { get; set; }
        [DisplayName("Segundo apellido beneficiario")]
        [Required(ErrorMessage = "El segundo apellido del beneficiario es requerido")]
        [StringLength(45, MinimumLength = 3)]
        public string SegundoApellidoBeneficiario { get; set; }
        [DisplayName("Fecha de nacimiento")]
        [Required(ErrorMessage = "La fecha de nacimiento del beneficiario es requerida")]
        public DateTime FechaNacimiento { get; set; }
        [DisplayName("Lugar de nacimiento")]
        [Required(ErrorMessage = "El lugar de nacimiento del beneficiario es requerido")]
        [StringLength(45, MinimumLength = 3)]
        public string LugarNacimiento { get; set; }
        [DisplayName("Edad")]
        [Required(ErrorMessage = "La edad del beneficiario es requerida")]
        [StringLength(3, MinimumLength = 1)]
        public string Edad { get; set; }
        [DisplayName("Genero")]
        [Required(ErrorMessage = "La genero del beneficiario es requerido")]
        public int GeneroId { get; set; }
        [DisplayName("Tipo Documento")]
        [Required(ErrorMessage = "El tipo de documento es requerido")]
        public int TipoDocumentoId { get; set; }
        [DisplayName("Número Documento")]
        [Required(ErrorMessage = "El numero de docuemnto del beneficiario es requerido")]
        [StringLength(20, MinimumLength = 3)]
        public string NumeroDocumento { get; set; }
        [DisplayName("Expedición del documento")]
        [Required(ErrorMessage = "El lugar de expedición del docmuento del beneficiario es requerido")]
        [StringLength(45, MinimumLength = 3)]
        public string LugarExpedicionDocumento { get; set; }
        [DisplayName("Dirección residencia")]
        [StringLength(45, MinimumLength = 3)]
        public string DireccionResidencia { get; set; }
        [DisplayName("Municipio")]
        [Required(ErrorMessage = "El municipio es requerido")]
        public string Municipio { get; set; }

        //Inf Medica y Psicologica
        [DisplayName("Grupo sanguineo")]
        [Required(ErrorMessage = "El grupo sanguineo del beneficiario es requerido")]
        public int GrupoSanguineoId { get; set; }
        [DisplayName("Nombre Eps")]
        public string NombreEps { get; set; }
        [DisplayName("Grupo sisben")]
        public string GrupoSisben { get; set; }
        [DisplayName("Antecedentes medicos")]
        public bool AntecedenteMedico { get; set; }
        [DisplayName("Descripción de enfermedad")]
        [StringLength(500, MinimumLength = 3)]
        public string DescripcionEnfermedad { get; set; }
        [DisplayName("Antecedente psicologico")]
        public bool AntecedentePsicologico { get; set; }
        [DisplayName("Descripción de enfermedad psicologica")]
        [StringLength(500, MinimumLength = 3)]
        public string DescripcionPsicologica { get; set; }

        //Inf Matricula
        [DisplayName("Institución educativa actual")]
        [StringLength(50, MinimumLength = 3)]
        public string InstitucionEducativa { get; set; }
        [DisplayName("Escolaridad")]
        [StringLength(20, MinimumLength = 3)]
        public string NivelEscolaridad { get; set; }
        [DisplayName("Jornada")]
        [Required(ErrorMessage = "La jornada es requerido")]
        public int JornadaId { get; set; }
        [DisplayName("Fecha de Matricula")]
        public DateTime FechaMatricula { get; set; }

        //Inf Retiro
        [DisplayName("Fecha de retiro")]
        public DateTime FechaRetiro { get; set; }
        [DisplayName("Descripción del retiro")]
        [StringLength(500, MinimumLength = 3)]
        public string ObservacionRetiro { get; set; }

        //Otra Inf Beneficiario
        [DisplayName("Talla camiseta")]
        [StringLength(10, MinimumLength = 1)]
        public string TallaCamisa { get; set; }
        [DisplayName("Talla pantalon")]
        [StringLength(10, MinimumLength = 1)]
        public string TallaPantalon { get; set; }
        [DisplayName("Talla zapatos")]
        [StringLength(10, MinimumLength = 1)]
        public string TallaZapatos { get; set; }
        [DisplayName("Modalidad")]
        [Required(ErrorMessage = "La modalidad del beneficiario es requerida")]
        public int ModalidadId { get; set; }
        [DisplayName("Etnia")]
        [Required(ErrorMessage = "La etnia es requerida")]
        public int EtniaId { get; set; }
        [DisplayName("Custodia")]
        [Required(ErrorMessage = "La custodia es requerido")]
        public string CustodiaBeneficiario { get; set; }

        //Inf Padrino
        [DisplayName("Padrino")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public int PadrinoId { get; set; }
        [DisplayName("Aporte economico")]
        public double AporteEconomicoPadrino { get; set; }

        //Info Madre
        [DisplayName("Nombre de la madre")]
        [StringLength(45, MinimumLength = 3)]
        public string NombreMadre { get; set; }
        [DisplayName("Apellido de la madre")]
        [StringLength(45, MinimumLength = 3)]
        public string ApellidoMadre { get; set; }
        [DisplayName("Número documento")]
        [StringLength(20, MinimumLength = 3)]
        public string NumeroDocumentoMadre { get; set; }
        [DisplayName("Expedición del documento")]
        [StringLength(45, MinimumLength = 3)]
        public string LugarExpedicionDocumentoMadre { get; set; }
        [DisplayName("Ocupación")]
        [StringLength(30, MinimumLength = 3)]
        public string OcupacionMadre { get; set; }
        [DisplayName("Escolaridad")]
        [StringLength(30, MinimumLength = 3)]
        public string NivelEscolaridadMadre { get; set; }
        [DisplayName("Teléfono")]
        [StringLength(15, MinimumLength = 3)]
        public string TelefonoMadre { get; set; }
        [DisplayName("Dirección")]
        [StringLength(45, MinimumLength = 3)]
        public string DireccionMadre { get; set; }
        [DisplayName("Barrio")]
        [StringLength(45, MinimumLength = 3)]
        public string BarrioMadre { get; set; }
        [DisplayName("Municipio")]
        [StringLength(45, MinimumLength = 3)]
        public string MunicipioMadre { get; set; }
        [DisplayName("Ingreso economico")]
        public double IngresoEconomicoMadre { get; set; }

        //Inf Padre
        [DisplayName("Nombre del padre")]
        [StringLength(45, MinimumLength = 3)]
        public string NombrePadre { get; set; }
        [DisplayName("Apellido del padre")]
        [StringLength(45, MinimumLength = 3)]
        public string ApellidoPadre { get; set; }
        [DisplayName("Número documento")]
        [StringLength(20, MinimumLength = 3)]
        public string NumeroDocumentoPadre { get; set; }
        [DisplayName("Expedición del documento")]
        [StringLength(45, MinimumLength = 3)]
        public string LugarExpedicionDocumentoPadre { get; set; }
        [DisplayName("Ocupación")]
        [StringLength(30, MinimumLength = 3)]
        public string OcupacionPadre { get; set; }
        [DisplayName("Escolaridad")]
        [StringLength(30, MinimumLength = 3)]
        public string NivelEscolaridadPadre { get; set; }
        [DisplayName("Teléfono")]
        [StringLength(15, MinimumLength = 3)]
        public string TelefonoPadre { get; set; }
        [DisplayName("Dirección")]
        [StringLength(45, MinimumLength = 3)]
        public string DireccionPadre { get; set; }
        [DisplayName("Barrio")]
        [StringLength(45, MinimumLength = 3)]
        public string BarrioPadre { get; set; }
        [DisplayName("Municipio")]
        [StringLength(45, MinimumLength = 3)]
        public string MunicipioPadre { get; set; }
        [DisplayName("Ingreso economico")]
        public double IngresoEconomicoPadre { get; set; }

        //Inf Acudiente
        [DisplayName("Nombre del acudiente")]
        [StringLength(45, MinimumLength = 3)]
        public string NombreAcudiente { get; set; }
        [DisplayName("Apellido del acudiente")]
        [StringLength(45, MinimumLength = 3)]
        public string ApellidoAcudiente { get; set; }
        [DisplayName("Número documento")]
        [StringLength(20, MinimumLength = 3)]
        public string NumeroDocumentoAcudiente { get; set; }
        [DisplayName("Expedición del documento")]
        [StringLength(45, MinimumLength = 3)]
        public string LugarExpedicionDocumentoAcudiente { get; set; }
        [DisplayName("Ocupación")]
        [StringLength(30, MinimumLength = 3)]
        public string OcupacionAcudiente { get; set; }
        [DisplayName("Escolaridad")]
        [StringLength(30, MinimumLength = 3)]
        public string NivelEscolaridadAcudiente { get; set; }
        [DisplayName("Teléfono")]
        [StringLength(15, MinimumLength = 3)]
        public string TelefonoAcudiente { get; set; }
        [DisplayName("Dirección")]
        [StringLength(45, MinimumLength = 3)]
        public string DireccionAcudiente { get; set; }
        [DisplayName("Barrio")]
        [StringLength(45, MinimumLength = 3)]
        public string BarrioAcudiente { get; set; }
        [DisplayName("Municipio")]
        [StringLength(45, MinimumLength = 3)]
        public string MunicipioAcudiente { get; set; }
        [DisplayName("Ingreso economico")]
        public double IngresoEconomicoAcudiente { get; set; }

        //Complementarios
        [DisplayName("Fecha de registro")]
        [Required(ErrorMessage = "La fecha de registro del beneficiario es requerida")]
        public DateTime FechaRegistro { get; set; }
        [DisplayName("Estado")]
        public int EstadoId { get; set; }

        //Autorizacion publicacion de fotos y recoleccion de datos --------------- Falta
        [DisplayName("Autorización de la foto")]
        public bool AutorizacionFoto { get; set; }
        [DisplayName("Autorización de los datos")]
        public bool AutorizacionData { get; set; }

        //Documentos y foto -------- falta para adjuntar los documentos
        public string NombreImagen { get; set; }
        public IFormFile Imagen { get; set; }

        //Traidas por medio de foraneas
        public string NombreEstado { get; set; }
        public string NombreModalidad { get; set; }
        public string NombreTipoDocumento { get; set; }
    }
}
