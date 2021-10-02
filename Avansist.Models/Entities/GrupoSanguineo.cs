using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansist.Models.Entities
{
    public class GrupoSanguineo
    {
        [Key]
        public int GrupoSanguineoId { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        public string Rh { get; set; }

        //Llave Foranea
        public virtual List<Preinscripcion> Preinscripcions  { get; set; }
    }
}
