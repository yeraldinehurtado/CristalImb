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
    public class EstadosInmuebleService : IEstadosInmuebleService
    {
        private readonly AppDbContext _context;
        public EstadosInmuebleService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EstadosInmueble>> ObtenerEstadosInm()
        {
            return await _context.estadosInmueble.ToListAsync();
        }
        public async Task<IEnumerable<EstadosInmueble>> ObteneEstadosInmueblesEstado()
        {
            return await _context.estadosInmueble.Where(s => s.Estado == true).ToListAsync();
        }

        public async Task GuardarEstadoInm(EstadosInmueble estadosInmueble)
        {
            _context.Add(estadosInmueble);
            await _context.SaveChangesAsync();
        }

        public async Task<EstadosInmueble> ObtenerEstadosInmId(int id)
        {
            return await _context.estadosInmueble.FirstOrDefaultAsync(x => x.IdEstadoInm == id);
        }

        public async Task EditarEstadoInm(EstadosInmueble estadosInmueble)
        {
            _context.Update(estadosInmueble);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarEstadoInm(int id)
        {
            var estadosInmueble = await ObtenerEstadosInmId(id);
            _context.Remove(estadosInmueble);
            await _context.SaveChangesAsync();
        }


    }
}
