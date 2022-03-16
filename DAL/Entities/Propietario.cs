using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Model.Entities
{
    public class Propietario
    {
        [Key]
        public int PropietarioId { get; set; }

        [DisplayName("Identificación")]
        [Required(ErrorMessage = "La identificación es obligatoria")]
        public int Identificacion { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string Apellido { get; set; }

        [DisplayName("Teléfono")]
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        public int Telefono { get; set; }

        [DisplayName("Celular")]
        public string Celular { get; set; } = null;

        [Required(ErrorMessage = "El correo es obligatorio")]
        public string Correo { get; set; }



        public bool Estado { get; set; }

        public virtual List<InmPropietarios> InmPropietario { get; set; }

    }
}
