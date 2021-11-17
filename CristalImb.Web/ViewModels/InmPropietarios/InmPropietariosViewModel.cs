using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CristalImb.Model.Entities;

namespace CristalImb.Web.ViewModels.InmPropietarios
{
    public class InmPropietariosViewModel
    {
        public int PropietarioId { get; set; }
        public List<ListaInmPropietarios> inmProp { get; set; }
    }

    public class ListaInmPropietarios
    {
        public int InmProId { get; set; }

        [DisplayName("Inmueble")]
        public int InmuebleId { get; set; }

        [DisplayName("Fecha de inicio")]
        public DateTime FechaInicio { get; set; }

        [DisplayName("Fecha final")]
        public DateTime FechaFin { get; set; }
    }
}
