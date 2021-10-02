using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansist.Models.Entities
{
    public class AgendaBeneficiario
    {
        [Key]
        public int AgendaBeneficiarioId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string NombreEvento { get; set; }
        public int PreinscripcionId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string EmpleadoEncargado { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string NumeroDocumento { get; set; }
        [Column(TypeName = "nvarchar(15)")]
        public string Telefono { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string Direccion { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaInicioEvento { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaFinEvento { get; set; }

        //Llave Foranea
        public virtual Preinscripcion Preinscripcion { get; set; }
    }
}
