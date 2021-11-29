using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avansist.Web.ViewModel
{
    public class UsuarioClaimsViewModel
    {
        public UsuarioClaimsViewModel()
        {
            Claims = new List<UsuarioClaim>();
        }

        public string idUsuario { get; set; }
        public List<UsuarioClaim> Claims { get; set; }
    }
}
