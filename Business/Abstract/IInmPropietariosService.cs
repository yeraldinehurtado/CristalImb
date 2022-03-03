using CristalImb.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalImb.Business.Abstract
{
    public interface IInmPropietariosService
    {
        Task<IEnumerable<InmPropietarios>> ObtenerInmPropietarios();
        Task<IEnumerable<InmPropietarios>> ObtenerListaInmPropietariosPorId(int id);
        Task GuardarInmPropietario(InmPropietarios inmpropietario);
        Task EditarInmPropietario(InmPropietarios inmPropietarios);
        Task RegistrarInmPropietarios(InmPropietarios inmPropietarios);
        Task<InmPropietarios> ObtenerInmPropietariosId(int id);
        Task<IEnumerable<InmPropietarios>> ObtenerListaInmPropEstado();
        Task EditarInmPropietarios(InmPropietarios inmPropietarios);
        Task EliminarInmPropietarios(int id);
        Task<InmPropietarios> InmuebleExiste(int PropietarioId, int Inmueble);
        Task<IEnumerable<InmPropietarios>> ObtenerListaInmPropietariosPorId2(int id);



    }
}
