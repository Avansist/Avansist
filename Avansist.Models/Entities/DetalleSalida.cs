using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansist.Models.Entities
{
    public class DetalleSalida
    {
        [Key]
        public int DetalleSalidaId { get; set; }
        public int SalidaExtracurricularId { get; set; }
        public int PreinscripcionId { get; set; }
        public bool AutorizacionSalidaExtracurricular { get; set; }

        //Llave Foranea
        public virtual Preinscripcion Preinscripcion { get; set; }
        public virtual SalidaExtracurricular SalidaExtracurricular { get; set; }
    }
}
