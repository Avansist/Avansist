using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansist.Models.Entities
{
    public class SalidaExtracurricular
    {
        [Key]
        public int SalidaExtracurricularId { get; set; }
        public int AgendaId { get; set; }

        //Llave Foranea
        public virtual Agenda Agenda { get; set; }
        public virtual List<DetalleSalida> DetalleSalidas { get; set; }
    }
}
