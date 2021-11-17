using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avansist.Models.Entities
{
    public class UsuarioIdentity : IdentityUser
    {
        [Column(TypeName = "nvarchar(50)")]
        public string Nombre { get; set; }
        public bool CambiarEstado { get; set; }
    }
}
