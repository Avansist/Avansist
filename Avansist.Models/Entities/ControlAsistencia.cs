using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansist.Models.Entities
{
    public class ControlAsistencia
    {
        [Key]
        public int ControlAsistenciaId { get; set; }

        //Inf Ingreso
        public int PreinscripcionId { get; set; }
        [Column(TypeName = "date")] // Cambiarlo a datetime
        public DateTime FechaIngreso { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string ObservacionIngreso { get; set; }

        //Inf Salida
        [Column(TypeName = "date")]
        public DateTime FechaSalida { get; set; }
        public bool AutorizacionSalida { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string ObservacionSalida { get; set; }

        //Llave Foranea
        public virtual Preinscripcion Preinscripcion { get; set; }

    }
}
