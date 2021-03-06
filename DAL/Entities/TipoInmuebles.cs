using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalImb.Model.Entities
{
    public class TipoInmuebles
    {
        [Key]
        public int TipoInmuebleId { get; set; }

        [Required(ErrorMessage = "El tipo de inmuebles es requerido.")]
        [DisplayName("Tipo de inmueble")]
        public string NombreTipoInm { get; set; }
        public bool Estado { get; set; }
        

    }
}
