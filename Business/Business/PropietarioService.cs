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
    public class PropietarioService: IPropietarioService
    {
        private readonly AppDbContext _context;
        public PropietarioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Propietario>> ObtenerPropietario()
        {
            return await _context.propietarios.ToListAsync();
        }

        public async Task GuardarPropietario(Propietario propietario)
        {
            _context.Add(propietario);
            await _context.SaveChangesAsync();
        }

        public async Task<Propietario> ObtenerPropietarioId(int id)
        {
            return await _context.propietarios.FirstOrDefaultAsync(x => x.PropietarioId == id);
        }

        public async Task EditarPropietario(Propietario propietario)
        {
            _context.Update(propietario);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarPropietario(int id)
        {
            var propietario = await ObtenerPropietarioId(id);
            _context.Remove(propietario);
            await _context.SaveChangesAsync();
        }

        public async Task<Propietario> identificacionPropExiste(int identificacion)
        {
            return await _context.propietarios.FirstOrDefaultAsync(x => x.Identificacion == identificacion);
        }
        public async Task<IEnumerable<Propietario>> identificacionPropExisteEditar(int identificacion)
        {
            return await _context.propietarios.Where(c => c.Identificacion == identificacion).ToListAsync();
        }
    }
}
