using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Web.ViewModels.Roles
{
    public class RolViewModels
    {

        public IEnumerable<Microsoft.AspNetCore.Identity.IdentityRole> m1 { get; set; }
        public IEnumerable<CristalImb.Model.Entities.Rol> m2 { get; set; }
    }
}
