using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalImb.Model.Entities
{
    public class ZonaInmueble
    {
        [Key]
        public int ZonaId { get; set; }
        public string Nombre { get; set; }
    }
}
