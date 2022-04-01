using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Web.ViewModels.Citas
{
    public class CitaViewModel
    {
        public int CitaId { get; set; }

        [DisplayName("Identificación")]
        [Required(ErrorMessage = "El documento es obligatorio")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Ingrese valores numéricos")]
        [Range(1, 9999999999, ErrorMessage = "Máximo 10 números")]
        public int Identificacion { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\u00f1\u00d1\s]+$", ErrorMessage = "Ingrese caracteres")]
        [StringLength(35, ErrorMessage = "Máximo 35 caracteres")]
        public string Nombre { get; set; }

        [DisplayName("Apellido")]
        [Required(ErrorMessage = "El apellido es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\u00f1\u00d1\s]+$", ErrorMessage = "Ingrese caracteres")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string Apellido { get; set; }

        [DisplayName("Teléfono")]
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Ingrese valores numéricos")]
        [Range(1, 9999999999, ErrorMessage = "Máximo 10 números")]
        public int Telefono { get; set; }

        [DisplayName("Correo")]
        [Required(ErrorMessage = "El correo es obligatorio")]
        [RegularExpression(@"^[a-zA-Z]+.+$", ErrorMessage = "Ingrese caracteres")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string Correo { get; set; }

        [DisplayName("Dirección")]
        [Required(ErrorMessage = "La dirección es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\u00f1\u00d1\s\0-9]+$", ErrorMessage = "Ingrese caracteres")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "La fecha y hora de la cita es obligatoria")]
        public string FechaHora { get; set; }


    }
}
