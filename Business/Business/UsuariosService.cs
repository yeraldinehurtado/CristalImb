using System;
using CristalImb.Business.Abstract;
using CristalImb.Model.DAL;
using CristalImb.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Business.Business
{
    public class UsuariosService:IUsuariosService
    {

        private readonly AppDbContext _context;
        public UsuariosService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UsuarioIdentity> ObtenerUsuarioId(Guid id)
        {
            return await _context.usuarioIdentity.FirstOrDefaultAsync(x => x.Id == id.ToString());
        }

        public async Task EditarUsuario(UsuarioIdentity usuarioIdentity)
        {
            _context.Update(usuarioIdentity);
            await _context.SaveChangesAsync();
        }

        public async Task GuardarUsuario(UsuarioIdentity usuarioIdentity)
        {
            _context.Add(usuarioIdentity);
            await _context.SaveChangesAsync();
        }


        

        
    }
}
    

