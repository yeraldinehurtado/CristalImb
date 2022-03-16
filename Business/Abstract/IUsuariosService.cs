using CristalImb.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalImb.Business.Abstract
{
    public interface IUsuariosService
    {
        Task<IEnumerable<UsuarioIdentity>> ObtenerListaUsuarios();
        Task<UsuarioIdentity> ObtenerUsuarioId(string id);
        Task EditarUsuario(UsuarioIdentity usuarioIdentity);
        Task GuardarUsuario(UsuarioIdentity usuarioIdentity);
    }
}
