using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Web.Models.Entities
{
    public class Inmueble
    {
        [Key]
        public int InmuebleId { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El tipo es obligatorio")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "El servicio es obligatorio")]
        public string Servicio { get; set; }

        [Required(ErrorMessage = "El valor es obligatorio")]
        public int Valor { get; set; }

        [DisplayName("Área")]
        [Required(ErrorMessage = "El area es obligatorio")]
        public string Area { get; set; }

        [Required(ErrorMessage = "La zona es obligatoria")]
        public string Zona { get; set; }

        public bool oferta { get; set; }

        public string RutaImagen { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        public string Estado { get; set; }
    }
}
