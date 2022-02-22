using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CristalImb.Web.ViewModels.EstadoCita
{
    public class EstadoCitaViewModel
    {
        public int EstadoCitaId { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [RegularExpression(@"^[a-zA-Z\u00f1\u00d1\s]+$", ErrorMessage = "Ingrese caracteres")]
        [StringLength(70, ErrorMessage = "Máximo 70 caracteres")]
        public string Nombre { get; set; }
        public bool Estado { get; set; }
    }
}
