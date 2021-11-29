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
            Usuarios = new List<string>();
        }

        [Required(ErrorMessage = "El nombre del rol es requerido")]
        public string NombreRol { get; set; }
        public List<string> Usuarios { get; set; }
    }
}
