using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalImb.Model.Entities
{
    public class EstadosInmueble
    {
        [Key]
        public int IdEstadoInm { get; set; }

        [Required(ErrorMessage = "El estado de inmueble es requerido.")]
        [DisplayName("Estado de inmueble")]
        public string NombreEstado { get; set; }
        public bool Estado { get; set; }
        public virtual List<Inmueble> Inmueble { get; set; }


    }
}
