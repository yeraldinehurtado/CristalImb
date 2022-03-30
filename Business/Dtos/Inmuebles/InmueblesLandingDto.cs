using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalImb.Business.Dtos.Inmuebles
{
    public class InmueblesLandingDto
    {
        public string InmuebleId { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public string direccion { get; set; }
        public string valor { get; set; }
        public string zona { get; set; }
        public string TipoInmueble { get; set; }
        public string Servicio { get; set; }
        public string Area { get; set; }
        public string NombreArchivo { get; set; }
    }
}
