using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Avansist.Web.ViewModel
{
    public class RolClaimsViewModel
    {
        public RolClaimsViewModel()
        {
            Claims = new List<RolClaim>();
        }

        public string idUsuario { get; set; }
        public List<RolClaim> Claims { get; set; }
    }
}
