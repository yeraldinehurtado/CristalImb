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
        Task<IEnumerable<Inmueble>> ObtenerListaInmueblesEstado();
        Task<IEnumerable<Inmueble>> ObtenerListaInmueblesOferta();
        Task GuardarInmueble(Inmueble inmueble);
        Task<Inmueble> ObtenerInmuebleId(int id);
        Task EditarInmueble(Inmueble inmueble);
        Task EliminarInmueble(int id);
        Task AgregarInmProp(Propietario propietario, Inmueble inmueble);
        Task<Inmueble> CodigoExiste(string codigo);
        Task<IEnumerable<Inmueble>> CodigoExisteEditar(string codigo);

    }
}
