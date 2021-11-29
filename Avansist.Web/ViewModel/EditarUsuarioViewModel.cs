using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Avansist.Web.ViewModel
{
    public class EditarUsuarioViewModel
    {
        public EditarUsuarioViewModel()
        {
            Notificaciones = new List<string>();
            Roles = new List<string>();
        }

        public string Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [DisplayName("Nombre y apellido")]
        [RegularExpression(@"^[a-zA-ZÀ-ÿ\u00f1\u00d1]+(\s*[a-zA-ZÀ-ÿ\u00f1\u00d1]*)*[a-zA-ZÀ-ÿ\u00f1\u00d1]+$", ErrorMessage = "Utilice caracteres solamente")]
        [StringLength(25, ErrorMessage = "El {0} debe tener al menos {2} y maximo {1} caracteres.", MinimumLength = 2)]
        public string NombreUsuario { get; set; }        

        [DisplayName("Estado")]
        public bool CambiarEstado { get; set; }

        public List<string> Notificaciones { get; set; }

        public IList<string> Roles { get; set; }
    }
}
