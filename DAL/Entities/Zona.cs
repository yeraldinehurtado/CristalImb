using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalImb.Model.Entities
{
    public class Zona
    {
        [Key]
        public int ZonaId { get; set; }

        [Required(ErrorMessage = "La zona es requerida.")]
        [DisplayName("Barrio")]
        public string NombreZona { get; set; }
        public bool Estado { get; set; }
        

    }
}
