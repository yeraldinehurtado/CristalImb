﻿using System;
using CristalImb.Business.Abstract;
using CristalImb.Model.DAL;
using CristalImb.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CristalImb.Business.Business
{
    public class RolService : IRolService
    {

        private readonly AppDbContext _context;
        public RolService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Rol> ObtenerRolId(Guid id)
        {
            return await _context.roles.FirstOrDefaultAsync(x => x.Id == id.ToString());
        }

        public async Task EditarRol(Rol rol)
        {
            _context.Update(rol);
            await _context.SaveChangesAsync();
        }

        public async Task GuardarUsuario(Rol rol)
        {
            _context.Add(rol);
            await _context.SaveChangesAsync();
        }





    }
}
