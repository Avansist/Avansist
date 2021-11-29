using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Avansist.Web.ViewModel
{
    public class ResetPassViewModel
    {
        [Required(ErrorMessage = "El correo es requerido")]
        [RegularExpression(@"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$", ErrorMessage = "Correo incorrecto")]
        [EmailAddress(ErrorMessage = "Correo invalido")]
        [DisplayName("Correo Electrónico")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [DisplayName("Contraseña")]
        [StringLength(16, ErrorMessage = "El {0} debe tener al menos {2} y maximo {1} caracteres.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmar la contraseña es requerido")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        [StringLength(16, ErrorMessage = "El {0} debe tener al menos {2} y maximo {1} caracteres.", MinimumLength = 8)]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmPassword { get; set; }

        public string Token { get; set; }
    }
}
