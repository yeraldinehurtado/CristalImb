using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Model.Entities
{
    public class Inmueble
    {
        [Key]
        public int InmuebleId { get; set; }
        [Required(ErrorMessage = "El código es obligatorio")]
        [DisplayName("Código")]
        public string Codigo { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El tipo es obligatorio")]
        public int TipoId { get; set; }

        [Required(ErrorMessage = "El estado de inmueble es obligatorio")]
        public int IdEstadoInm { get; set; }
        public int ZonaId { get; set; }

        [Required(ErrorMessage = "El servicio es obligatorio")]
        public int ServicioInmuebleId { get; set; }

        [Required(ErrorMessage = "El valor es obligatorio")]
        public long Valor { get; set; }

        [DisplayName("Área")]
        [Required(ErrorMessage = "El area es obligatorio")]
        public string Area { get; set; }
        [Required(ErrorMessage = "la zona es obligatoria")]

        public bool oferta { get; set; }


        [Required(ErrorMessage = "El estado es obligatorio")]
        public bool Estado { get; set; }

        public virtual EstadosInmueble EstadosInmueble { get; set; }
        public virtual TipoInmuebles TipoInmuebles { get; set; }
        public virtual Zona Zona { get; set; }
        public virtual ServiciosInmueble ServiciosInmueble { get; set; }
        public virtual List<InmPropietarios> InmPropietario { get; set; }
        public virtual List<Cita> citas { get; set; }
    }
}
