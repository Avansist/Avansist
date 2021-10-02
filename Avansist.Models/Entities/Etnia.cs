using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansist.Models.Entities
{
    public class Etnia
    {
        [Key]
        public int EtniaId { get; set; }
        [Column(TypeName = "nvarchar(40)")]
        public string NombreEtnia { get; set; }

        //Llave Foranea
        public virtual List<Preinscripcion> Preinscripcions  { get; set; }
    }
}
