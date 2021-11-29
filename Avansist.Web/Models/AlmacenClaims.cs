using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Avansist.Web.Models
{
    public class AlmacenClaims
    {
        public static List<Claim> todosLosClaims = new()
        {
            new Claim("Crear Rol","Crear Rol"),
            new Claim("Editar Role","Editar Rol"),
            new Claim("Borrar Rol", "Borrar Rol")
        };
    }
}
