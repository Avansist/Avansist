using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansist.Models.Entities
{
    public class Jornada
    {
        [Key]
        public int JornadaId { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string NombreJornada { get; set; }

        //Llave Foranea
        public virtual List<Preinscripcion> Preinscripcions { get; set; }
    }
}
