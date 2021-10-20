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
            return await _context.estados.ToListAsync();
        }
    }
}
