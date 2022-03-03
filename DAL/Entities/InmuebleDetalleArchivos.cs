using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalImb.Model.Entities
{
    public class InmuebleDetalleArchivos
    {
        [Key]
        public int InmuebleDetalleId { get; set; }

        [Required]
        [ForeignKey("Inmueble")]

        public int InmuebleId { get; set; }

        [Required]
        public string NombreArchivo { get; set; }

        public virtual Inmueble Inmueble { get; set; }

    }
}
