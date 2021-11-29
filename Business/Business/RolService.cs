using CristalImb.Business.Abstract;
using CristalImb.Model.DAL;
using CristalImb.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<Rol> ObtenerRolPorId(string id)
        {
            return await _context.roles.FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task GuardarRol(Rol rol1)
        {
            _context.Add(rol1);
            await _context.SaveChangesAsync();
        }

        public async Task EditarRol(Rol rol1)
        {
            _context.Update(rol1);
            await _context.SaveChangesAsync();
        }
    }
}
