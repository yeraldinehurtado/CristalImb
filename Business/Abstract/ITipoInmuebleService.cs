using CristalImb.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalImb.Business.Abstract
{
    public interface ITipoInmuebleService
    {
        Task<IEnumerable<TipoInmuebles>> ObtenerTipos();
        Task<IEnumerable<TipoInmuebles>> ObtenerListaTiposEstado();
        Task GuardarTipoInmueble(TipoInmuebles tipoInmuebles);
        Task<TipoInmuebles> ObtenerTipoInmuebleId(int id);
        Task EditarTipoInmueble(TipoInmuebles tipoInmuebles);
        Task EliminarTipoInmueble(int id);
    }
}
