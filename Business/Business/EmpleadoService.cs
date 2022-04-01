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
    public class EmpleadoService : IEmpleadoService
    {
        private readonly AppDbContext _context;
        public EmpleadoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Empleado>> ObtenerEmpleado()
        {
            return await _context.empleados.ToListAsync();
        }

        public async Task GuardarEmpleado(Empleado empleado)
        {
            _context.Add(empleado);
            await _context.SaveChangesAsync();
        }

        public async Task<Empleado> ObtenerEmpleadoId(int id)
        {
            return await _context.empleados.FirstOrDefaultAsync(x => x.EmpleadoId == id);
        }

        public async Task EditarEmpleado(Empleado empleado)
        {
            _context.Update(empleado);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarEmpleado(int id)
        {
            var empleado = await ObtenerEmpleadoId(id);
            _context.Remove(empleado);
            await _context.SaveChangesAsync();
        }


        public async Task<Empleado> IdentificacionExiste(int identificacion)
        {
            return await _context.empleados.FirstOrDefaultAsync(x => x.Identificacion == identificacion);
        }
        public async Task<Empleado> IdentificacionExisteEditar(int identificacion, int empleadoId)
        {
            return await _context.empleados.FirstOrDefaultAsync(x => x.Identificacion == identificacion && x.EmpleadoId != empleadoId);
        }

    }
}
