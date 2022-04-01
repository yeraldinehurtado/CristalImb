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
    public class ZonaService: IZonaService
    {
        private readonly AppDbContext _context;
        public ZonaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Zona>> ObtenerZonas()
        {
            return await _context.zonas.ToListAsync();
        }

        public async Task<IEnumerable<Zona>> ObtenerListaZonaEstado()
        {
            return await _context.zonas.Where(s => s.Estado == true).ToListAsync();
        }

        public async Task GuardarZona(Zona zona)
        {
            _context.Add(zona);
            await _context.SaveChangesAsync();
        }

        public async Task<Zona> ObtenerZonaId(int id)
        {
            return await _context.zonas.FirstOrDefaultAsync(x => x.ZonaId == id);
        }

        public async Task EditarZona(Zona zona)
        {
            _context.Update(zona);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarZona(int id)
        {
            var zona = await ObtenerZonaId(id);
            _context.Remove(zona);
            await _context.SaveChangesAsync();
        }
        public async Task<Zona> nombreZonaExiste(string nombre)
        {
            return await _context.zonas.FirstOrDefaultAsync(x => x.NombreZona == nombre);
        }
        public async Task<Zona> nombreZonaExisteEditar(string nombre, int id)
        {
            return await _context.zonas.FirstOrDefaultAsync(x => x.NombreZona == nombre && x.ZonaId != id);
        }
    }
}
