using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansist.Services.DTOs
{
    public class ControlAsistenciaDto
    {
        public int ControlAsistenciaId { get; set; }

        //Inf Ingreso
        [DisplayName("Nombre Beneficiario")]
        [Required(ErrorMessage = "Es requerido seleccionar el beneficiario")]
        public int PreinscripcionId { get; set; }
        [DisplayName("Fecha y Hora de Ingreso")]
        [Required(ErrorMessage = "La fecha del inicio del evento es requerida")]
        public DateTime FechaIngreso { get; set; }
        [DisplayName("Descripción del ingreso")]
        [StringLength(500, MinimumLength = 3)]
        [Required(ErrorMessage = "La observacion es requerida")]
        public string ObservacionIngreso { get; set; }

        //Inf Salida
        [DisplayName("Fecha y Hora de Salida")]
        public DateTime FechaSalida { get; set; }
        [DisplayName("Autorización Salida")]
        public bool AutorizacionSalida { get; set; }
        [DisplayName("Descripción de la salida")]

        [StringLength(500, MinimumLength = 0)]

        [Required(ErrorMessage = "La observacion es requerida")]
        public string ObservacionSalida { get; set; }
    }
}
