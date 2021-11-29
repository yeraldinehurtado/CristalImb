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
        Task<Rol> ObtenerRolPorId(string id);
        Task GuardarRol(Rol rol1);
        Task EditarRol(Rol rol1);
    }
}
