using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalImb.Business.Dtos.Usuarios
{
    public class UsuarioDto
    {
        [DisplayName("Identificación")]
        [Required(ErrorMessage = "La identificación es requerida")]
        [StringLength(10, ErrorMessage = "Máximo 10 caracteres")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Ingrese valores numéricos")]

        public string Identificacion { get; set; }

        [DisplayName("Nombre de usuario")]
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "El email es requerido")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get; set; }
       
    }
}
