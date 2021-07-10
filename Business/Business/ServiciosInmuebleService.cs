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
    }
}
