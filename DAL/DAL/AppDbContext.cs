﻿using CristalImb.Model.Entities;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }

        public DbSet<Rol> roles { get; set; }
        public DbSet<Propietario> propietarios { get; set; }

        public DbSet<Inmueble> inmuebles { get; set; }

        public DbSet<UsuarioIdentity> usuarios { get; set; }
        public DbSet<Empleado> empleados { get; set; }
        public DbSet<Cita> citas { get; set; }
        public DbSet<TipoInmuebles> tipoInmuebles { get; set; }
        public DbSet<ServiciosInmueble> serviciosInmueble { get; set; }
        public DbSet<InmPropietarios> InmPropietarios { get; set; }
        public DbSet<Zona> zonas { get; set; }
        public DbSet<Cargo> cargos { get; set; }
        public DbSet<EstadoCita> estadoCitas { get; set; }
        public DbSet<EstadosInmueble> estadosInmueble { get; set; }
        public DbSet<UsuarioIdentity> usuarioIdentity { get; set; }
    }
}
