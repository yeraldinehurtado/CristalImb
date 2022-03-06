using CristalImb.Business.Abstract;
using CristalImb.Model.DAL;
using CristalImb.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Business.Business
{
    public class ServiciosInmuebleService: IServiciosInmuebleService
    {
        private readonly AppDbContext _context;
        public ServiciosInmuebleService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiciosInmueble>> ObtenerServicios()
        {
            return await _context.serviciosInmueble.ToListAsync();
        }
        public async Task<IEnumerable<ServiciosInmueble>> ObtenerListaServiciosEstado()
        {
            return await _context.serviciosInmueble.Where(s => s.Estado == true).ToListAsync();
        }

        public async Task GuardarServiciosInmueble(ServiciosInmueble serviciosInmueble)
        {
            _context.Add(serviciosInmueble);
            await _context.SaveChangesAsync();
        }

        public async Task<ServiciosInmueble> ObtenerServiciosInmuebleId(int id)
        {
            return await _context.serviciosInmueble.FirstOrDefaultAsync(x => x.ServicioInmuebleId == id);
        }

        public async Task EditarServiciosInmueble(ServiciosInmueble serviciosInmueble)
        {
            _context.Update(serviciosInmueble);
            await _context.SaveChangesAsync();
        }
        public async Task<ServiciosInmueble> nombreTipoExiste(string nombre)
        {
            return await _context.serviciosInmueble.FirstOrDefaultAsync(x => x.Nombre == nombre);
        }
    }
}
