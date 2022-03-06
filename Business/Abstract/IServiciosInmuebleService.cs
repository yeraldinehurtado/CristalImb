using CristalImb.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalImb.Business.Abstract
{
    public interface IServiciosInmuebleService
    {
        Task<IEnumerable<ServiciosInmueble>> ObtenerServicios();
        Task<IEnumerable<ServiciosInmueble>> ObtenerListaServiciosEstado();
        Task GuardarServiciosInmueble(ServiciosInmueble serviciosInmueble);
        Task<ServiciosInmueble> ObtenerServiciosInmuebleId(int id);
        Task EditarServiciosInmueble(ServiciosInmueble serviciosInmueble);
        Task<ServiciosInmueble> nombreTipoExiste(string nombre);
    }
}
