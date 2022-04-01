using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Business.Dtos.Inmuebles
{
    public class InmuebleDto
    {
        public int InmuebleId { get; set; }
        [Required(ErrorMessage = "El código es obligatorio")]
        [DisplayName("Código")]
        public string Codigo { get; set; }

        [DisplayName("Descripción")]
        [RegularExpression(@"^[a-zA-Z-ZñÑáéíóúÁÉÍÓÚ\u00f1\u00d1\s]+$", ErrorMessage = "Ingrese caracteres")]
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
        public int ServicioInmuebleId { get; set; }



        [DisplayName("Zona inmueble")]
        [Required(ErrorMessage = "La zona del inmueble es obligatoria")]
        public int ZonaId { get; set; }


        [DisplayName("Tipo de inmueble")]
        [Required(ErrorMessage = "El tipo es obligatorio")]
        public int TipoId { get; set; }


        [DisplayName("Estado inmueble")]
        [Required(ErrorMessage = "El estado de inmueble es obligatorio")]

        public int IdEstadoInm { get; set; }
        //public List<IFormFile> Files { get; set; }
        public List<IFormFile> Files { get; set; }
        public string AlertaPropietario { get; set; }


    }
}
