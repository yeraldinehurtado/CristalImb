using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CristalImb.Web.ViewModels.Zonas
{
    public class ZonasViewModel
    {
        public int ZonaId { get; set; }

        [DisplayName("Nombre tipo de inmueble")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [RegularExpression(@"^[a-zA-Z-ZñÑáéíóúÁÉÍÓÚ\u00f1\u00d1\s]+$", ErrorMessage = "Ingrese caracteres")]
        [StringLength(70, ErrorMessage = "Máximo 70 caracteres")]
        public string NombreZona { get; set; }
        public bool Estado { get; set; }
    }
}
