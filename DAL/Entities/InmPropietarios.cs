using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalImb.Model.Entities
{
    public class InmPropietarios
    {
        [Key]
        public int InmProId { get; set; }

        [DisplayName("Inmueble")]
        public int InmuebleId { get; set; }

        [DisplayName("Propietario")]
        public int PropietarioId { get; set; }

        [DisplayName("Fecha de inicio")]
        public DateTime FechaInicio { get; set; }

        [DisplayName("Fecha final")]
        public DateTime FechaFin { get; set; }

        public bool Estado { get; set; }

        public string asociado { get; set; }

        public virtual Inmueble Inmueble { get; set; }

        public virtual Propietario Propietario { get; set; }
    }
}
