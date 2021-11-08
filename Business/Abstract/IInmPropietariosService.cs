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
        Task<IEnumerable<InmPropietarios>> ObtenerListaInmPropietariosPorId(int Id);
        Task RegistrarInmPropietarios(InmPropietarios inmPropietarios);
        Task<InmPropietarios> ObtenerInmPropietariosId(int Id);
        Task EditarInmPropietarios(InmPropietarios inmPropietarios);
        Task EliminarInmPropietarios(int Id);
        Task<InmPropietarios> InmuebleExiste(int PropietarioId, int Inmueble);



    }
}
