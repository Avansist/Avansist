using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansist.Services.DTOs
{
    public class PadrinoDto
    {
        public int PadrinoId { get; set; }
        [DisplayName("Nombre padrino")]
        [Required(ErrorMessage = "El primer nombre del padrino es requerido")]
        [StringLength(45, MinimumLength = 3)]
        public string NombrePadrino { get; set; }
        [DisplayName("Apellido padrino")]
        [Required(ErrorMessage = "El primer nombre del beneficiario es requerido")]
        [StringLength(45, MinimumLength = 3)]
        public string ApellidoPadrino { get; set; }
        [DisplayName("Tipo documento")]
        [Required(ErrorMessage = "Campo requerido")]
        public int TipoDocumentoId { get; set; }
        [DisplayName("Número documento")]
        [Required(ErrorMessage = "Número documento requerido")]
        [StringLength(15, MinimumLength = 3)]
        public string NumeroDocumento { get; set; }
        [DisplayName("Ocupación")]
        [Required(ErrorMessage = "La ocupación es requerida")]
        [StringLength(25, MinimumLength = 3)]
        public string Ocupacion { get; set; }
        [DisplayName("Telefono")]
        [Required(ErrorMessage = "El número de telefono es requerido")]
        [StringLength(15, MinimumLength = 3)]
        public string Telefono { get; set; }
        [DisplayName("Correo Electronico")]
        [Required(ErrorMessage = "El correo es requerido")]
        [StringLength(45, MinimumLength = 3)]
        
        public string CorreoElectronico { get; set; }
    }
}
