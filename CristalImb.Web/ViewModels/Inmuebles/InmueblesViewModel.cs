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
        [RegularExpression(@"^[a-zA-Z\u00f1\u00d1\s\0-9]+$", ErrorMessage = "Ingrese caracteres")]
        [DisplayName("Código")]
        public string Codigo { get; set; }

        [DisplayName("Descripción")]
        [RegularExpression(@"^[a-zA-Z\u00f1\u00d1\s\0-9]+$", ErrorMessage = "Ingrese caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El tipo es obligatorio")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Ingrese valores numéricos")]
        [Range(1, 9999999999)]
        public int TipoId { get; set; }

        [Required(ErrorMessage = "El estado de inmueble es obligatorio")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Ingrese valores numéricos")]
        [Range(1, 9999999999)]
        public int IdEstadoInm { get; set; }
        [Required(ErrorMessage = "La zona del inmueble es obligatoria")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Ingrese valores numéricos")]
        [Range(1, 9999999999)]
        public int ZonaId { get; set; }

        [Required(ErrorMessage = "El servicio es obligatorio")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Ingrese valores numéricos")]
        [Range(1, 9999999999)]
        public int ServicioInmuebleId { get; set; }

        [Required(ErrorMessage = "El valor es obligatorio")]
        [UIHint("Currency")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Ingrese valores numéricos")]
        public long Valor { get; set; }

        [DisplayName("Área")]
        [Required(ErrorMessage = "El area es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\u00f1\u00d1\s\0-9]+$", ErrorMessage = "Ingrese caracteres")]
        public string Area { get; set; }

        [DisplayName("Dirección")]  
        [Required(ErrorMessage = "La dirección es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\u00f1\u00d1\s\0-9]+$", ErrorMessage = "Ingrese caracteres")]
        public string Direccion { get; set; }

        public bool oferta { get; set; }


        
        public bool Estado { get; set; }
    }
}
