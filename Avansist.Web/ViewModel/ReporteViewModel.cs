using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Avansist.Web.ViewModel
{
    public class ReporteViewModel
    {
        [DisplayName("Fecha de inicio del reporte")]
        [Required(ErrorMessage = "Campo requerido")]
        public DateTime FechaInicioReporte { get; set; }

        [DisplayName("Fecha de finalización del reporte")]
        [Required(ErrorMessage = "Campo requerido")]
        public DateTime FechaFinReporte { get; set; }
    }
}
