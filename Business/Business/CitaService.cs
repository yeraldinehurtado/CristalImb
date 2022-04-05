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
    public class CitaService: ICitaService
    {
        private readonly AppDbContext _context;
        public CitaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cita>> ObtenerCita()
        {
            return await _context.citas.Include(p => p.Inmuebles).Include(f => f.EstadoCita).ToListAsync();
        }

        public async Task GuardarCita(Cita cita)
        {
            _context.Add(cita);
            await _context.SaveChangesAsync();
        }

        public async Task<Cita> ObtenerCitaId(int id)
        {
            return await _context.citas.FirstOrDefaultAsync(x => x.CitaId == id);

        }

        public async Task<Cita> ObtenerFechaExistente(string fechahora)
        {
            return await _context.citas.FirstOrDefaultAsync(x => x.FechaHora == fechahora);

        }

        public async Task<Cita> ObtenerFechaExisteEditar(string fechahora, int id)
        {
            return await _context.citas.FirstOrDefaultAsync(x => x.FechaHora == fechahora && x.CitaId != id);
        }

        public async Task EditarCita(Cita cita)
        {
            _context.Update(cita);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarCita(int id)
        {
            var cita = await ObtenerCitaId(id);
            _context.Remove(cita);
            await _context.SaveChangesAsync();
        }
    }
}

    

