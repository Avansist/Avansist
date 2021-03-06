using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansist.Services.DTOs
{
    public class AgendaDto
    {
        public int AgendaId { get; set; }
        [DisplayName("Nombre del Evento")]
        [Required(ErrorMessage = "El nombre del evento es requerido")]
        [StringLength(45, ErrorMessage = "El {0} debe tener al menos {2} y maximo {1} caracteres.", MinimumLength = 3)]
        public string NombreEvento { get; set; }
        [DisplayName("Empleado Encargado")]
        [Required(ErrorMessage = "El nombre del empleado encargado es requerido")]
        [StringLength(45, ErrorMessage = "El {0} debe tener al menos {2} y maximo {1} caracteres.", MinimumLength = 3)]
        public string EmpleadoEncargado { get; set; }
        [DisplayName("Número Documento")]
        [Required(ErrorMessage = "El numero de documento del empleado encargado es requerido")]
        [StringLength(20, ErrorMessage = "El {0} debe tener al menos {2} y maximo {1} caracteres.", MinimumLength = 3)]
        public string NumeroDocumento { get; set; }
        [DisplayName("Teléfono")]
        [StringLength(15, ErrorMessage = "El {0} debe tener al menos {2} y maximo {1} caracteres.", MinimumLength = 3)]
        [Required(ErrorMessage = "El teléfono es requerido")]
        public string Telefono { get; set; }
        [DisplayName("Dirección del Evento")]
        [Required(ErrorMessage = "La dirección del evento es requerida")]
        [StringLength(45, ErrorMessage = "El {0} debe tener al menos {2} y maximo {1} caracteres.", MinimumLength = 3)]
        public string Direccion { get; set; }

        [DataType(DataType.Time)]
        [DisplayName("Hora de Inicio Evento")]
        [Required(ErrorMessage = "La hora del inicio del evento es requerida")]
        public string HoraInicioEvento { get; set; }
        [DataType(DataType.Time)]
        [DisplayName("Hora fin Evento")]
        [Required(ErrorMessage = "La hora del fin del evento es requerida")]
        public string HoraFinEvento { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Fecha del evento")]
        [Required(ErrorMessage = "La fecha del inicio del evento es requerida")]
        public DateTime FechaInicioEvento { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayName("Fecha de Fin Evento")]
        //[Required(ErrorMessage = "La fecha de finalización del evento es requerida")]
        //public DateTime FechaFinEvento { get; set; }
    }
}
