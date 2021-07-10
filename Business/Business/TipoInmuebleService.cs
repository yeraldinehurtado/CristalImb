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

        public async Task<IEnumerable<TipoInmueble>> ObtenerTipos()
        {
            return await _context.tipoInmuebles.ToListAsync();
        }
    }
}
