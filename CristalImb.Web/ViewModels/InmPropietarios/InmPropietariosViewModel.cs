using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalImb.Web.ViewModels.InmPropietarios
{
    public class InmPropietariosViewModel
    {
        public int InmProId { get; set; }

        [DisplayName("Inmueble")]
        public int InmuebleId { get; set; }

        [DisplayName("Propietario")]
        public int PropietarioId { get; set; }

        [DisplayName("Fecha de inicio")]
        public DateTime FechaInicio { get; set; }

        [DisplayName("Fecha final")]
        public DateTime FechaFin { get; set; }

    }
}
