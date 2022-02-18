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
        Task<IEnumerable<Zona>> ObtenerListaZonaEstado();
        Task GuardarZona(Zona zona);
        Task<Zona> ObtenerZonaId(int id);
        Task EditarZona(Zona zona);
        Task EliminarZona(int id);
        Task<Zona> nombreZonaExiste(string nombre);
        Task<IEnumerable<Zona>> nombreZonaExisteEditar(string nombre);
    }
}
