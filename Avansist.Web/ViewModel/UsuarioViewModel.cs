﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Avansist.Web.ViewModel
{
    public class UsuarioViewModel
    {
        public string Id { get; set; }

        [DisplayName("Correo electrónico")]
        [Required(ErrorMessage = "El correo es requerido")]
        [EmailAddress(ErrorMessage = "Correo invalido")]
        public string Email { get; set; }


        [Required(ErrorMessage = "La contraseña es requerida")]
        [DisplayName("Contraseña")]
        [DataType(DataType.Password)]
        [StringLength(16, ErrorMessage = "El {0} debe tener al menos {2} y maximo {1} caracteres.", MinimumLength = 8)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Confirmar la contraseña es requerido")]
        [DisplayName("Confirmar Contraseña")]
        [DataType(DataType.Password)]
        [StringLength(16, ErrorMessage = "El {0} debe tener al menos {2} y maximo {1} caracteres.", MinimumLength = 8)]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmarPassword { get; set; }


        [Required(ErrorMessage = "El nombre es requerido")]
        [DisplayName("Nombre y apellido")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Utilice caracteres solamente")]
        [StringLength(25, ErrorMessage = "El {0} debe tener al menos {2} y maximo {1} caracteres.", MinimumLength = 2)]
        public string Nombre { get; set; }

        public bool CambiarEstado { get; set; }
    }
}
