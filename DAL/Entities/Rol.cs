using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Model.Entities
{
    public class Rol:IdentityRole
    {
        [DisplayName("Módulo")]
        [Required(ErrorMessage = "El módulo es obligatorio")]
        public string Modulo { get; set; }

        public int Permisos { get; set; }
        public bool Estado { get; set; }

    }
}
