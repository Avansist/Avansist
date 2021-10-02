using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansist.Models.Entities
{
    public class Padrino
    {
        [Key]
        public int PadrinoId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string NombrePadrino { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string ApellidoPadrino { get; set; }
        public int TipoDocumentoId { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string NumeroDocumento { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        public string Ocupacion { get; set; }
        [Column(TypeName = "nvarchar(15)")]
        public string Telefono { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string CorreoElectronico { get; set; }

        //Llave Foranea
        public virtual TipoDocumento TipoDocumento { get; set; }
        public virtual List<Preinscripcion> Preinscripcions { get; set; }
    }
}
