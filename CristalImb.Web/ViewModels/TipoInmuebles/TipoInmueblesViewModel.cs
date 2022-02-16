using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CristalImb.Web.ViewModels.TipoInmuebles
{
    public class TipoInmueblesViewModel
    {
        public int TipoInmuebleId { get; set; }

        [DisplayName("Nombre tipo de inmueble")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\u00f1\u00d1\s]+$", ErrorMessage = "Ingrese caracteres")]
        [StringLength(70, ErrorMessage = "Máximo 70 caracteres")]
        public string NombreTipoInm { get; set; }
        public bool Estado { get; set; }
    }
}
