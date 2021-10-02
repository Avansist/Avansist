using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansist.Models.Entities
{
    public class Estado
    {
        [Key]
        public int EstadoId { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string NombreEstado { get; set; }

        //Llave Foranea
        public virtual List<Preinscripcion> Preinscripcions { get; set; }
    }
}
