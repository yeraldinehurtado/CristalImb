using CristalImb.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalImb.Business.Abstract
{
    public interface IEstadosInmuebleService
    {
        Task<IEnumerable<EstadosInmueble>> ObtenerEstadosInm();
        Task<IEnumerable<EstadosInmueble>> ObteneEstadosInmueblesEstado();
        Task GuardarEstadoInm(EstadosInmueble estadosInmueble);
        Task<EstadosInmueble> ObtenerEstadosInmId(int id);
        Task EditarEstadoInm(EstadosInmueble estadosInmueble);
        Task EliminarEstadoInm(int id);
    }
}
