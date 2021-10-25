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
        public string NombreEstado { get; set; }
    }
}
