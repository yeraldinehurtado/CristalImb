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
    public class EstadoCitaService:IEstadoCitaService
    {
        private readonly AppDbContext _context;
        public EstadoCitaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EstadoCita>> ObtenerCitas()
        {
            return await _context.estadoCitas.ToListAsync();
        }
        public async Task<IEnumerable<EstadoCita>> ObtenerEstadosCitaEstado()
        {
            return await _context.estadoCitas.Where(s => s.Estado == true).ToListAsync();
        }
        public async Task GuardarEstadoCita(EstadoCita estadoCita)
        {
            _context.Add(estadoCita);
            await _context.SaveChangesAsync();
        }

        public async Task<EstadoCita> ObtenerEstadoCitaId(int id)
        {
            return await _context.estadoCitas.FirstOrDefaultAsync(x => x.EstadoCitaId == id);
        }

        public async Task EditarEstadoCita(EstadoCita estadoCita)
        {
            _context.Update(estadoCita);
            await _context.SaveChangesAsync();
        }

        public async Task<EstadoCita> nombreEstadoCitaExiste(string nombre)
        {
            return await _context.estadoCitas.FirstOrDefaultAsync(x => x.Nombre == nombre);
        }
    }
}
    

