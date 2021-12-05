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
       // [Range(0, 11, ErrorMessage = "Ingresar máximo 10 digitos")]
        [RegularExpression("^\\d+", ErrorMessage = "Documento incorrecto")]
        [Required(ErrorMessage = "La identificación es requerida")]
        public int Identificacion { get; set; }

        [DisplayName("Nombre de usuario")]
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "El email es requerido")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [Display(Name = "Contraseña", Order = -9,
        Prompt = "Ingrese la contraseña", Description = "Contraseña")]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "La contraseña debe tener al menos {2} y maximo {1} caracteres.", MinimumLength = 4)]
        public string Password { get; set; }

        [Required(ErrorMessage = "La confirmación de contraseña es requerida")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña", Order = -9,
        Prompt = "Confirme la contraseña", Description = "Confirme la contraseña")]
        [Compare("Password",
            ErrorMessage = "El Password y confirmar password debe coincidir")]
        public string ConfirmarPassword { get; set; }



    }
}
