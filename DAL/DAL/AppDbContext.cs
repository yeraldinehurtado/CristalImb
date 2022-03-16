using CristalImb.Model.Entities;
using Microsoft.AspNetCore.Identity;
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
            /*
            modelBuilder.Entity<Seguimiento>()
           .HasOne(p => p.Entrada)
           .WithMany(b => b.Seguimientos).
            HasForeignKey(e => e.EntradasId);
            */

            


            base.OnModelCreating(modelBuilder);
            this.SeedUsers(modelBuilder);
            this.SeedRoles(modelBuilder);
            this.SeedUserRole(modelBuilder);
            this.SeedTipoInmueble(modelBuilder);
            this.SeedZona(modelBuilder);
            this.SeedServiciosInmueble(modelBuilder);
            this.SeedEstadoCita(modelBuilder);
            this.SeedEstadosInmueble(modelBuilder);
        }

        private void SeedEstadosInmueble(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstadosInmueble>().HasData(

                new EstadosInmueble
                {
                    IdEstadoInm = 1,
                    NombreEstado = "Sobre planos",
                    Estado = true
                },
                new EstadosInmueble
                {
                    IdEstadoInm = 2,
                    NombreEstado = "En reparación",
                    Estado = true
                },
                new EstadosInmueble
                {
                    IdEstadoInm = 3,
                    NombreEstado = "Libre",
                    Estado = true
                },
                new EstadosInmueble
                {
                    IdEstadoInm = 4,
                    NombreEstado = "Ocupado",
                    Estado = true
                }

            );
        }

        private void SeedEstadoCita(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstadoCita>().HasData(

                new EstadoCita
                {
                    EstadoCitaId = 1,
                    Nombre = "Confirmada",
                    Estado = true
                },
                new EstadoCita
                {
                    EstadoCitaId = 2,
                    Nombre = "Por confirmar",
                    Estado = true
                },
                new EstadoCita
                {
                    EstadoCitaId = 3,
                    Nombre = "En curso",
                    Estado = true
                },
                new EstadoCita
                {
                    EstadoCitaId = 4,
                    Nombre = "Finalizada",
                    Estado = true
                }

            );
        }

        private void SeedServiciosInmueble(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ServiciosInmueble>().HasData(

                new ServiciosInmueble
                {
                    ServicioInmuebleId = 1,
                    Nombre = "Venta",
                    Estado = true
                },
                new ServiciosInmueble
                {
                    ServicioInmuebleId = 2,
                    Nombre = "Arriendo",
                    Estado = true
                },
                new ServiciosInmueble
                {
                    ServicioInmuebleId = 3,
                    Nombre = "Avalúo",
                    Estado = true
                }

            );
        }

        private void SeedZona(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zona>().HasData(

                new Zona
                {
                    ZonaId = 1,
                    NombreZona = "El poblado",
                    Estado = true
                },
                new Zona
                {
                    ZonaId = 2,
                    NombreZona = "Belén",
                    Estado = true
                },
                new Zona
                {
                    ZonaId = 3,
                    NombreZona = "Boston",
                    Estado = true
                },
                new Zona
                {
                    ZonaId = 4,
                    NombreZona = "San Diego",
                    Estado = true
                },
                new Zona
                {
                    ZonaId = 5,
                    NombreZona = "Laureles",
                    Estado = true
                },
                new Zona
                {
                    ZonaId = 6,
                    NombreZona = "Estadio",
                    Estado = true
                },
                new Zona
                {
                    ZonaId = 7,
                    NombreZona = "Manrique",
                    Estado = true
                },
                new Zona
                {
                    ZonaId = 8,
                    NombreZona = "Aranjuez",
                    Estado = true
                },
                new Zona
                {
                    ZonaId = 9,
                    NombreZona = "Villa Hermosa",
                    Estado = true
                },
                new Zona
                {
                    ZonaId = 10,
                    NombreZona = "Campo Valdés",
                    Estado = true
                },
                new Zona
                {
                    ZonaId = 11,
                    NombreZona = "Las palmas",
                    Estado = true
                },
                new Zona
                {
                    ZonaId = 12,
                    NombreZona = "Ciudad del Rio",
                    Estado = true
                },
                new Zona
                {
                    ZonaId = 13,
                    NombreZona = "Prado",
                    Estado = true
                }

            );
        }

        private void SeedTipoInmueble(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoInmuebles>().HasData(

                new TipoInmuebles
                {
                    TipoInmuebleId = 1,
                    NombreTipoInm = "Casa",
                    Estado = true
                },
                new TipoInmuebles
                {
                    TipoInmuebleId = 2,
                    NombreTipoInm = "Apartamento",
                    Estado = true
                }
            );
        }

        private void SeedUserRole(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(

                new IdentityUserRole<string>()
                {
                    RoleId = "FD713788-B5AE-49FF-8B2C-F311B9CB0CC4",
                    UserId = "FD713799-B5AE-49FF-8B2C-F311B9CB0CC4"
                }

                );
        }

        private void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(

                new IdentityRole
                {
                    Id = "FD713788-B5AE-49FF-8B2C-F311B9CB0CC4",
                    Name = "Administrador",
                    ConcurrencyStamp = "1",
                    NormalizedName = "Admin"
                },
                new IdentityRole
                {
                    Id = "64B512E7-46AE-4989-A049-A446118099C4",
                    Name = "Empleado",
                    ConcurrencyStamp = "2",
                    NormalizedName = "Empleado"
                },
                new IdentityRole
                {
                    Id = "376D45C8-659D-4ACE-B249-CFBF4F231915",
                    Name = "Cliente",
                    ConcurrencyStamp = "3",
                    NormalizedName = "Client"
                }
            );


        }

        private void SeedUsers(ModelBuilder modelBuilder)
        {
            IdentityUser user = new IdentityUser()
            {
                Id = "FD713799-B5AE-49FF-8B2C-F311B9CB0CC4",
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                LockoutEnabled = false,
                PhoneNumber = "1234567890"
            };

            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "admin12345");

            modelBuilder.Entity<IdentityUser>().HasData(user);

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

        public DbSet<InmuebleDetalleArchivos> inmuebleDetalleArchivos { get; set; }
    }
}
