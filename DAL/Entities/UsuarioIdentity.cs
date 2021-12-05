﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalImb.Model.Entities
{
    public class UsuarioIdentity:IdentityUser
    {
        [DisplayName("Identificación")]
      //  [Range(0,11, ErrorMessage = "Ingresar máximo 10 digitos")]
        [RegularExpression("^\\d+", ErrorMessage = "Documento incorrecto")]
        [Required(ErrorMessage = "La identificación es obligatoria")]
        public int Identificacion { get; set; }

        [Required(ErrorMessage = "Debe elegir un rol")]
        public int Rol { get; set; }
    }
}
