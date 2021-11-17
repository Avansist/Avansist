using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Avansist.Web.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El correo es requerido")]
        [EmailAddress(ErrorMessage = "Correo invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Recordarme")]
        public bool RecordarMe { get; set; }
    }
}
