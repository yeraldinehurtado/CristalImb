using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Column(TypeName = "nvarchar(500)")]
        [StringLength(500, ErrorMessage = "Máximo 500 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El valor es obligatorio")]
        [UIHint("Currency")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public string Valor { get; set; }

        [DisplayName("Área")]
        [Required(ErrorMessage = "El area es obligatorio")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Ingrese valores numéricos")]
        [Range(1, 9999999999, ErrorMessage = "Máximo 10 números")]
        public int Area { get; set; }

        [DisplayName("Dirección")]
        [Required(ErrorMessage = "La dirección es obligatorio")]
        public string Direccion { get; set; }

        public bool oferta { get; set; }

        public bool Estado { get; set; }

        [DisplayName("Servicio inmueble")]
        [Required(ErrorMessage = "El servicio es obligatorio")]
        [ForeignKey("ServiciosInmueble")]
        public int ServicioInmuebleId { get; set; }



        [DisplayName("Zona inmueble")]
        [Required(ErrorMessage = "La zona del inmueble es obligatoria")]
        [ForeignKey("Zona")]
        public int ZonaId { get; set; }


        [DisplayName("Tipo de inmueble")]
        [Required(ErrorMessage = "El tipo es obligatorio")]
        [ForeignKey("TipoInmuebles")]
        public int TipoId { get; set; }


        [DisplayName("Estado inmueble")]
        [Required(ErrorMessage = "El estado de inmueble es obligatorio")]

        [ForeignKey("EstadosInmueble")]
        public int IdEstadoInm { get; set; }
        public string NombreArchivo { get; set; }

        [DisplayName("¿Tiene propietario(s)?")]
        public string AlertaPropietario { get; set; }


        public string Tipo { get; set; }
        public string Servicio { get; set; }

        public string Barrio { get; set; }


        public virtual EstadosInmueble EstadosInmueble { get; set; }

        public virtual TipoInmuebles TipoInmuebles { get; set; }
        
        public virtual Zona Zona { get; set; }
        
        public virtual ServiciosInmueble ServiciosInmueble { get; set; }
        public virtual List<InmPropietarios> InmPropietario { get; set; }


        public virtual List<InmuebleDetalleArchivos> InmuebleDetalleArchivos { get; set; }


    }
}
