using CristalImb.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalImb.Business.Abstract
{
    public interface IEmpleadoService
    {
        Task<IEnumerable<Empleado>> ObtenerEmpleado();
        Task GuardarEmpleado(Empleado empleado);
        Task<Empleado> ObtenerEmpleadoId(int id);
        Task EditarEmpleado(Empleado empleado);
        Task EliminarEmpleado(int id);
    }
}