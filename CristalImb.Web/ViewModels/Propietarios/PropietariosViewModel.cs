using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Web.ViewModels.Propietarios
{
    public class PropietariosViewModel
    {
        public int PropietarioId { get; set; }

        [DisplayName("Identificación")]
        [Required(ErrorMessage = "El documento es obligatorio")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Ingrese valores numéricos")]
        [StringLength(10, ErrorMessage = "Máximo 10 caracteres")]
        public int Identificacion { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Ingrese caracteres")]
        [StringLength(35, ErrorMessage = "Máximo 35 caracteres")]
        public string Nombre { get; set; }

        [DisplayName("Apellido")]
        [Required(ErrorMessage = "El apellido es obligatorio")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Ingrese caracteres")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string Apellido { get; set; }

        [DisplayName("Teléfono")]
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Ingrese valores numéricos")]
        [StringLength(10, ErrorMessage = "Máximo 10 caracteres")]
        public int Telefono { get; set; }

        [DisplayName("Correo")]
        [Required(ErrorMessage = "El correo es obligatorio")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string Correo { get; set; }

        public bool Estado { get; set; }
    }
}
