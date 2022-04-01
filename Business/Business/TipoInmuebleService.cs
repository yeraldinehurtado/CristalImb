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
    public class TipoInmuebleService: ITipoInmuebleService
    {
        private readonly AppDbContext _context;
        public TipoInmuebleService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoInmuebles>> ObtenerTipos()
        {
            return await _context.tipoInmuebles.ToListAsync();
        }
        public async Task<IEnumerable<TipoInmuebles>> ObtenerListaTiposEstado()
        {
            return await _context.tipoInmuebles.Where(s => s.Estado == true).ToListAsync();
        }

        public async Task GuardarTipoInmueble(TipoInmuebles tipoInmuebles)
        {
            _context.Add(tipoInmuebles);
            await _context.SaveChangesAsync();
        }

        public async Task<TipoInmuebles> ObtenerTipoInmuebleId(int id)
        {
            return await _context.tipoInmuebles.FirstOrDefaultAsync(x => x.TipoInmuebleId == id);
        }

        public async Task EditarTipoInmueble(TipoInmuebles tipoInmuebles)
        {
            _context.Update(tipoInmuebles);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarTipoInmueble(int id)
        {
            var tipoInmuebles = await ObtenerTipoInmuebleId(id);
            _context.Remove(tipoInmuebles);
            await _context.SaveChangesAsync();
        }

        public async Task<TipoInmuebles> nombreTipoExiste(string nombre)
        {
            return await _context.tipoInmuebles.FirstOrDefaultAsync(x => x.NombreTipoInm == nombre);
        }
        public async Task<TipoInmuebles> nombreTipoExisteEditar(string nombre, int id)
        {
            return await _context.tipoInmuebles.FirstOrDefaultAsync(x => x.NombreTipoInm == nombre && x.TipoInmuebleId != id);
        }
    }
}
