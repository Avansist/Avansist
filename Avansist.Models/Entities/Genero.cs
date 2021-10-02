using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansist.Models.Entities
{
    public class Genero
    {
        [Key]
        public int GeneroId { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string NombreGenero { get; set; }

        //Llave foranea
        public virtual List<Preinscripcion> Preinscripcions  { get; set; }
    }
}
