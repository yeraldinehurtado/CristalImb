using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Web.Models.Entities
{
    public class Empleado
    {
        [Key]
        public int EmpleadoId { get; set; }

        [DisplayName("Identificación")]
        [Required(ErrorMessage = "La identificación es obligatoria")]
        [Range(1, 9999999999999, ErrorMessage = "El documento es requerido")]
        public int Identificacion { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string Apellido { get; set; }

        [DisplayName("Teléfono")]
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        public int Telefono { get; set; }

        [DisplayName("Dirección")]
        [Required(ErrorMessage = "La dirección es obligatoria")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        public bool Estado { get; set; }

        [Required(ErrorMessage = "El cargo es obligatorio")]
        public string Cargo { get; set; }
    }
}
