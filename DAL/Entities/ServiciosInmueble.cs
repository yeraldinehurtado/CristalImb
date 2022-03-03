using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalImb.Model.Entities
{
    public class ServiciosInmueble
    {
        [Key]
        [DisplayName("ServicioId")]
        public int ServicioInmuebleId { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        
    }
}
