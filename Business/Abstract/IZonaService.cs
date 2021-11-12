using CristalImb.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalImb.Business.Abstract
{
    public interface IZonaService
    {
        Task<IEnumerable<Zona>> ObtenerZonas();
        Task GuardarZona(Zona zona);
        Task<Zona> ObtenerZonaId(int id);
        Task EditarZona(Zona zona);
        Task EliminarTipoInmueble(int id);
    }
}
