using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Model.Entities
{
    public class Cita
    {
        [Key]
        public int CitaId { get; set; }

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

        [Required(ErrorMessage = "El correo es obligatorio")]
        public string Correo { get; set; }

        [DisplayName("Dirección")]
        [Required(ErrorMessage = "La dirección es obligatoria")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "La fecha de la cita es obligatoria")]
        public DateTime FechaHora { get; set; }

        [ForeignKey("Inmuebles")]
        public int InmuebleId { get; set; }

        public int ServicioInmuebleId { get; set; }

        [ForeignKey("EstadoCita")]
        public int EstadoCitaId { get; set; }


        public virtual Inmueble Inmuebles { get; set; }

        public virtual ServiciosInmueble ServiciosInmueble { get; set; }
        public virtual EstadoCita EstadoCita { get; set; }


    }
}
