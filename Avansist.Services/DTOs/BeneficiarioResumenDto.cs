using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansist.Services.DTOs
{
    public class BeneficiarioResumenDto
    {
        public int PreinscripcionId { get; set; }
        [DisplayName("Tipo Doc")]
        public string NombreTipoDocumento { get; set; }
        [DisplayName("No. Documento")]
        public string NumeroDocumento { get; set; }
        [DisplayName("Nombre")]
        public string NombreBeneficiario { get; set; }
        [DisplayName("Apellido")]
        public string ApellidoBeneficiario { get; set; }
        [DisplayName("Estado")]
        public string NombreEstado { get; set; }
        [DisplayName("Modalidad")]
        public string NombreModalidad { get; set; }
    }
}
