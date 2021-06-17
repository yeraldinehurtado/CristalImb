using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Web.Models.Entities
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [DisplayName("Nombre de usuario")]
        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Debe elegir un rol")]
        public int Rol { get; set; }

        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "Debe escribir una contraseña")]
        public string Contrasena { get; set; }

        [DisplayName("Confirmar contraseña")]
        [Required(ErrorMessage = "Debe confirmar la contraseña")]
        public string ConfirmarContrasena { get; set; }
    }
}
