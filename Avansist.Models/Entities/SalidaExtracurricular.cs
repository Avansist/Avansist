using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansist.Models.Entities
{
    public class SalidaExtracurricular
    {
        [Key]
        public int SalidaExtracurricularId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string NombreSalidadEvento { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Direccion { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string ResponsableEvento { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string DocumentoResponsable { get; set; }

        public bool EstadoEvento { get; set; }

        [DisplayName("Fecha salida del evento")]
        public DateTime FechaSalidadEvento { get; set; }
        [DisplayName("Fecha regreso del evento")]
        public DateTime FechaRegresoEvento { get; set; }



        //Llave Foranea
        //public virtual Agenda Agenda { get; set; }
        public  ICollection<DetalleSalida>  DetalleSalidas { get; set; }
        public virtual Preinscripcion Preinscripcion { get; set; }


    }
}
