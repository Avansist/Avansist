using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansist.Services.DTOs
{
    public class ControlAsistenciaResumenDto
    {
        public int ControlAsistenciaId { get; set; }
        [DisplayName("Nombre")]
        public string NombreBeneficiario { get; set; }
        [DisplayName("Apellido")]
        public string ApellidoBeneficiario { get; set; }
        [DisplayName("F.H Ingreso")]
        public DateTime FechaIngreso { get; set; }
        [DisplayName("A. Salida")]
        public bool AutorizacionSalida { get; set; }
        [DisplayName("F.H Salida")]
        public DateTime FechaSalida { get; set; }
    }
}
