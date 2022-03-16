using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Model.Entities
{
    public class Rol
    {
        [Key, ForeignKey("IdentityRole")]
        public string RolId { get; set; }
        public bool Estado { get; set; }
        public virtual IdentityRole IdentityRole { get; set; }

    }
}
