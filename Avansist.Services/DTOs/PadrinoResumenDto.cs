using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansist.Services.DTOs
{
    public class PadrinoResumenDto
    {
        public int PadrinoId { get; set; }
        [DisplayName("Nombre")]
        public string NombrePadrino { get; set; }
        [DisplayName("Apellido")]
        public string ApellidoPadrino { get; set; }
        [DisplayName("Tipo documento")]
        public string NombreTipoDocumento { get; set; }
        [DisplayName("Número documento")]
        public string NumeroDocumento { get; set; }
        [DisplayName("Ocupación")]
        public string Ocupacion { get; set; }
    }
}
