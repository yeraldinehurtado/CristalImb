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
    public class InmPropietariosService : IInmPropietariosService
    {
        private readonly AppDbContext _context;
        private readonly IPropietarioService _propietarioService;

        public InmPropietariosService(AppDbContext context, IPropietarioService propietarioService)
        {
            _context = context;
            _propietarioService = propietarioService;
        }
        public async Task<IEnumerable<InmPropietarios>> ObtenerInmPropietarios()
        {
            return await _context.InmPropietarios.Include(p => p.Inmueble).Include(c => c.Propietario).ToListAsync();


        }
        public async Task<IEnumerable<InmPropietarios>> ObtenerListaInmPropietariosPorId(int id)
        {
            return await _context.InmPropietarios.Include(p => p.Inmueble).Include(c => c.Propietario).Where(s => s.PropietarioId == id).ToListAsync();
        }
        public async Task RegistrarInmPropietarios(InmPropietarios inmPropietarios)
        {
            _context.Add(inmPropietarios);
            await _context.SaveChangesAsync();
        }
        public async Task<InmPropietarios> ObtenerInmPropietariosId(int id)
        {
            return await _context.InmPropietarios.FirstOrDefaultAsync(e => e.InmProId == id);
        }
        public async Task EditarInmPropietarios(InmPropietarios inmPropietarios)
        {
            _context.Update(inmPropietarios);
            await _context.SaveChangesAsync();
        }
        public async Task EliminarInmPropietarios(int id)
        {
            var inmPropietarios = await ObtenerInmPropietariosId(id);
            _context.Remove(inmPropietarios);
            await _context.SaveChangesAsync();
        }

        public async Task<InmPropietarios> InmuebleExiste(int PropietarioId, int Inmueble)
        {
            return await _context.InmPropietarios.Where(c => c.PropietarioId == PropietarioId).FirstOrDefaultAsync(n => n.InmuebleId == Inmueble);
        }
    }
}
