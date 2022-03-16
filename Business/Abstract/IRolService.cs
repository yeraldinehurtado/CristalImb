using CristalImb.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalImb.Business.Abstract
{
    public interface IRolService
    {
        Task<IEnumerable<Rol>> ObtenerListaRoles();
        Task<Rol> ObtenerRolId(string id);
        Task EditarRol(Rol rol);
        Task GuardarUsuario(Rol rol);
    }
}
