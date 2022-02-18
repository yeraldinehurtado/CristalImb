using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace CristalImb.Web.ViewModels.Inmuebles
{
    public class InmueblesViewModel
    {

        public int InmuebleId { get; set; }
        [Required(ErrorMessage = "El código es obligatorio")]
        [DisplayName("Código")]
        [StringLength(15, ErrorMessage = "Máximo 15 caracteres")]
        public string Codigo { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El tipo es obligatorio")]
        public int TipoId { get; set; }

        [Required(ErrorMessage = "El estado de inmueble es obligatorio")]
        public int IdEstadoInm { get; set; }
        [Required(ErrorMessage = "La zona del inmueble es obligatoria")]
        public int ZonaId { get; set; }

        [Required(ErrorMessage = "El servicio es obligatorio")]
        public int ServicioInmuebleId { get; set; }

        [Required(ErrorMessage = "El valor es obligatorio")]
        [UIHint("Currency")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Ingrese valores numéricos")]
        public long Valor { get; set; }

        [DisplayName("Área")]
        [Required(ErrorMessage = "El area es obligatorio")]
        public string Area { get; set; }

        [DisplayName("Dirección")]
        [Required(ErrorMessage = "La dirección es obligatorio")]
        public string Direccion { get; set; }

        public bool oferta { get; set; }


        [Required(ErrorMessage = "El estado es obligatorio")]
        public bool Estado { get; set; }
    }
}
