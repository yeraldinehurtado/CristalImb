using CristalImb.Model.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalImb.Model.DAL
{
    public class AppDbContext: IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base(options)
        {

        }
        public DbSet<Rol> roles { get; set; }
        public DbSet<Propietario> propietarios { get; set; }

        public DbSet<UsuarioIdentity> usuarios { get; set; }
    }
}
