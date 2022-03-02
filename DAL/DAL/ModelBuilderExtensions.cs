using CristalImb.Model.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalImb.Model.DAL
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rol>().HasData(

                new Rol
                {
                    Id = "FD713788-B5AE-49FF-8B2C-F311B9CB0CC4",
                    Name = "Administrador",
                    ConcurrencyStamp = "1",
                    NormalizedName = "Admin",
                    Estado = true
                },
                new Rol
                {
                    Id = "64B512E7-46AE-4989-A049-A446118099C4",
                    Name = "Empleado",
                    ConcurrencyStamp = "2",
                    NormalizedName = "Empleado",
                    Estado = true
                },
                new Rol
                {
                    Id = "376D45C8-659D-4ACE-B249-CFBF4F231915",
                    Name = "Cliente",
                    ConcurrencyStamp = "3",
                    NormalizedName = "Client",
                    Estado = true
                }
            );
            modelBuilder.Entity<UsuarioIdentity>().HasData(

                new UsuarioIdentity
                {
                    Id = "FD713799-B5AE-49FF-8B2C-F311B9CB0CC4",
                    Identificacion = "1000438288",
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    LockoutEnabled = false,
                    PhoneNumber = "1234567890",
                    Estado = true
                }
                
            );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(

                new IdentityUserRole<string>()
                {
                    RoleId = "FD713788-B5AE-49FF-8B2C-F311B9CB0CC4", UserId = "FD713799-B5AE-49FF-8B2C-F311B9CB0CC4"
                }

            );
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
                    NombreZona = "Boston",
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
    }
}
