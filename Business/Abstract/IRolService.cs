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
        Task<Rol> ObtenerRolId(Guid id);
        Task EditarRol(Rol rol);
        Task GuardarUsuario(Rol rol);
    }
}
