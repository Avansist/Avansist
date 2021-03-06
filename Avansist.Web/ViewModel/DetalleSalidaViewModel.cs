using Avansist.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Avansist.Web.ViewModel
{
    public class DetalleSalidaViewModel
    {
        [DisplayName("Beneficiario")]
        public string PreinscripcionId { get; set; }

        [DisplayName("Nombre del evento")]
        [Required(ErrorMessage = "El nombre del evento es requerido")]
        [StringLength(45, MinimumLength = 3)]
        public string NombreSalidadEvento { get; set; }

        [DisplayName("Dirrección del evento")]
        [Required(ErrorMessage = "La direccion del evento es requerida")]
        [StringLength(45, MinimumLength = 3)]
        public string Direccion { get; set; }

        [DisplayName("Nombre del responsable")]
        [Required(ErrorMessage = "El nombre del responsable es requerido")]
        [StringLength(45, MinimumLength = 3)]
        public string ResponsableEvento { get; set; }
        [DisplayName("Numero de documento")]
        [Required(ErrorMessage = "El documento es requerido")]
        [StringLength(45, MinimumLength = 3)]
        public string DocumentoResponsable { get; set; }
        public bool EstadoEvento { get; set; }

        [DisplayName("Fecha salida del evento")]
        [Required(ErrorMessage = "La fecha de salidad es requerido")]
        public DateTime FechaSalidadEvento { get; set; }

        [DisplayName("Fecha regreso del evento")]
        [Required(ErrorMessage = "La fecha de regreso es requerido")]
        public DateTime FechaRegresoEvento { get; set; }

        public List<PreinscripcionViewModel> Preinscripcions { get; set; }
    }
}
