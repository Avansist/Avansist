using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansist.Models.Entities
{
    public class Agenda
    {
        [Key]
        public int AgendaId { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string NombreEvento { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string EmpleadoEncargado { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string NumeroDocumento { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string Telefono { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Direccion { get; set; }

        [DataType(DataType.Time)]
        public string HoraInicioEvento { get; set; }
        [DataType(DataType.Time)]
        public string HoraFinEvento { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaInicioEvento { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaFinEvento { get; set; }        

        //Llave Foranea
        //public virtual List<SalidaExtracurricular> SalidaExtracurriculars { get; set; }
    }
}
