using CristalImb.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalImb.Business.Abstract
{
    public interface IInmuebleService
    {
        Task<IEnumerable<Inmueble>> ObtenerInmueble();
        Task GuardarInmueble(Inmueble inmueble);
        Task<Inmueble> ObtenerInmuebleId(int id);
        Task EditarInmueble(Inmueble inmueble);
        Task EliminarInmueble(int id);

    }
}
