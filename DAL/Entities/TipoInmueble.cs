using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Model.Entities
{
    public class TipoInmueble
    {
        [Key]
        public int TipoId { get; set; }
        public string Nombre { get; set; }
    }
}
