using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansist.Services.DTOs
{
    public class DetalleSalidaDto
    {
        public int DetalleSalidaId { get; set; }
        public int SalidaExtracurricularId { get; set; }
        public int PreinscripcionId { get; set; }
        public bool AutorizacionSalidaExtracurricular { get; set; }
    }
}
