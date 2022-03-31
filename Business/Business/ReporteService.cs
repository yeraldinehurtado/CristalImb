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
    public class ReporteService:IReporteService
    {
        private readonly AppDbContext _context;
        public ReporteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CantidadVenta>> ObtenerCantidadVentas(/*DateTime fecha*/)
        {
            return await _context.cantidadVenta.ToListAsync();

            //return await _context.cantidadVenta.Where(c => c.Fecha == fecha).Count();
        }

        public async Task<IEnumerable<CantidadArriendo>> ObtenerCantidadArriendos()
        {
            return await _context.cantidadArriendo.ToListAsync();
        }

    }
}
    

