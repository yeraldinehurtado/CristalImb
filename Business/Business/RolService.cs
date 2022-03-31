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
    public class RolService : IRolService
    {

        private readonly AppDbContext _context;
        public RolService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Rol>> ObtenerListaRoles()
        {
            return await _context.roles.Include(u => u.IdentityRole).ToListAsync();
        }
        public async Task<Rol> ObtenerRolId(string id)
        {
            return await _context.roles.Include(x => x.IdentityRole).FirstOrDefaultAsync(r => r.RolId == id);
        }

        public async Task<Rol> ObtenerRolNombre(string nombreRol)
        {
            return await _context.roles.Include(x => x.IdentityRole).FirstOrDefaultAsync(r => r.Nombre == nombreRol);
        }

        public async Task EditarRol(Rol rol)
        {
            _context.Update(rol);
            await _context.SaveChangesAsync();
        }

        public async Task GuardarUsuario(Rol rol)
        {
            _context.Add(rol);
            await _context.SaveChangesAsync();
        }





    }
}

