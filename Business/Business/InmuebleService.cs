using System;
using CristalImb.Business.Abstract;
using CristalImb.Model.DAL;
using CristalImb.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb. Business.Business
{
    public class InmuebleService : IInmuebleService
    {
        private readonly AppDbContext _context;
        public InmuebleService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Inmueble>> ObtenerInmueble()
        {
            return await _context.inmuebles.ToListAsync();
        }

        public async Task GuardarInmueble(Inmueble inmueble)
        {
            _context.Add(inmueble);
            await _context.SaveChangesAsync();
        }

        public async Task<Inmueble> ObtenerInmuebleId(int id)
        {
            return await _context.inmuebles.FirstOrDefaultAsync(x => x.InmuebleId == id);
        }

        public async Task EditarInmueble(Inmueble inmueble)
        {
            _context.Update(inmueble);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarInmueble(int id)
        {
            var inmueble = await ObtenerInmuebleId(id);
            _context.Remove(inmueble);
            await _context.SaveChangesAsync();
        }

        
    }
}
