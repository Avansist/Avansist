using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Avansist.Web.ViewModel
{
    public class EditarRolViewModel
    {
        public string Id { get; set; }
        public EditarRolViewModel()
        {
            Notificaciones = new List<string>();
            Usuarios = new List<string>();
        }

        [Required(ErrorMessage = "El nombre es requerido")]
        [Display(Name = "Nombre del rol")]
        [RegularExpression(@"^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$", ErrorMessage = "Utilice caracteres solamente")]
        [StringLength(25, ErrorMessage = "El {0} debe tener al menos {2} y maximo {1} caracteres.", MinimumLength = 2)]
        public string NombreRol { get; set; }
        public List<string> Notificaciones { get; set; }
        public List<string> Usuarios { get; set; }
    }
}
