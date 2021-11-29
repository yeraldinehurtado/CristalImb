using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalImb.Model.Entities
{
    public class EstadoCita
    {
        [Key]
        public int EstadoCitaId { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
    }
}
