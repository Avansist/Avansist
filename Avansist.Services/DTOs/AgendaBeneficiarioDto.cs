using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansist.Services.DTOs
{
    public class AgendaBeneficiarioDto
    {
        public int AgendaBeneficiarioId { get; set; }
        [DisplayName("Nombre del Evento")]
        [Required(ErrorMessage = "El nombre del evento es requerido")]
        [StringLength(45, MinimumLength = 3)]
        public string NombreEvento { get; set; }
        [DisplayName("Nombre del Empleado Encargado")]
        [Required(ErrorMessage = "El nombre del empleado encargado es requerido")]
        [StringLength(45, MinimumLength = 3)]
        public string EmpleadoEncargado { get; set; }
        [DisplayName("Número Documento")]
        [Required(ErrorMessage = "El numero de docuemnto del empleado encargado es requerido")]
        [StringLength(20, MinimumLength = 3)]
        public string NumeroDocumento { get; set; }
        [DisplayName("Teléfono")]
        [StringLength(15, MinimumLength = 3)]
        public string Telefono { get; set; }
        [DisplayName("Dirección del Evento")]
        [Required(ErrorMessage = "La dirección del evento es requerida")]
        [StringLength(45, MinimumLength = 3)]
        public string Direccion { get; set; }
        [DisplayName("Fecha de Inicio Evento")]
        [Required(ErrorMessage = "La fecha del inicio del evento es requerida")]
        public DateTime FechaInicioEvento { get; set; }
        [DisplayName("Fecha de Fin Evento")]
        [Required(ErrorMessage = "La fecha de finalización del evento es requerida")]
        public DateTime FechaFinEvento { get; set; }
        [DisplayName("Beneficiario")]
        public int PreinscripcionId { get; set; }

        //Traida Por Foranea
        public string NombreBeneficiario { get; set; }
    }
}
