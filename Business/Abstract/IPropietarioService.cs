using CristalImb.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalImb.Business.Abstract
{
    public interface IPropietarioService
    {
        Task<IEnumerable<Propietario>> ObtenerPropietario();
        Task GuardarPropietario(Propietario propietario);
        Task<Propietario> ObtenerPropietarioId(int id);
        Task EditarPropietario(Propietario propietario);
        Task EliminarPropietario(int id);
        Task<Propietario> identificacionPropExiste(int identificacion);
        Task<IEnumerable<Propietario>> identificacionPropExisteEditar(int identificacion);
    }
}
