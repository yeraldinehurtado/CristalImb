using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Web.ViewModels.Usuarios
{
    public class UsuarioViewModel
    {
        [DisplayName("Identificación")]
        [Required(ErrorMessage = "La identificación es requerida")]
        public int Identificacion { get; set; }

        [DisplayName("Nombre de usuario")]
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "El email es requerido")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El rol es requerido")]
        public int Rol { get; set; }

        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "La contraseña es requerida")]
        [StringLength(16, ErrorMessage = "El {0} debe tener al menos {2} y maximo {1} caracteres.", MinimumLength = 10)]
        public string Password { get; set; }

        
    }
}
