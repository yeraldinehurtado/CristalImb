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
    public class CargoService:ICargoService
    {
        private readonly AppDbContext _context;
        public CargoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cargo>> ObtenerCargos()
        {
            return await _context.cargos.ToListAsync();
        }
    }
}
