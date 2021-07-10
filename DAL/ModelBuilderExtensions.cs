using CristalImb.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CristalImb.Model
{
    public static class ModelBuilderExtensions
    {
        public static void seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoInmueble>().HasData(
                new TipoInmueble
                {
                    TipoId = 1,
                    Nombre = "Casa"
                },
                new TipoInmueble
                {
                    TipoId = 2,
                    Nombre = "Apartamento"
                },
                new TipoInmueble
                {
                    TipoId = 3,
                    Nombre = "Lote"
                },
                new TipoInmueble
                {
                    TipoId = 4,
                    Nombre = "Bodega"
                }
                );

            modelBuilder.Entity<ServiciosInmueble>().HasData(
                new ServiciosInmueble
                {
                    ServicioInmuebleId = 1,
                    Nombre = "Venta"
                },
                new ServiciosInmueble
                {
                    ServicioInmuebleId = 2,
                    Nombre = "Arriendo"
                }
                );

            modelBuilder.Entity<ZonaInmueble>().HasData(
                new ZonaInmueble
                {
                    ZonaId = 1,
                    Nombre = "Laureles"
                },
                new ZonaInmueble
                {
                    ZonaId = 2,
                    Nombre = "Villa Hermosa"
                },
                new ZonaInmueble
                {
                    ZonaId = 3,
                    Nombre = "Aranjuez"
                },
                new ZonaInmueble
                {
                    ZonaId = 4,
                    Nombre = "Castilla"
                },
                new ZonaInmueble
                {
                    ZonaId = 5,
                    Nombre = "Poblado"
                }
                );

            modelBuilder.Entity<Cargo>().HasData(
                new Cargo
                {
                    CargoId = 1,
                    Nombre = "Administrador"
                },
                new Cargo
                {
                    CargoId = 2,
                    Nombre = "Analista"
                },
                new Cargo
                {
                    CargoId = 3,
                    Nombre = "Secretaria"
                }
                );

            modelBuilder.Entity<EstadoCita>().HasData(
               new EstadoCita
               {
                   EstadoId = 1,
                   Nombre = "Por confirmar"
               },
               new EstadoCita
               {
                   EstadoId = 2,
                   Nombre = "Confirmado"
               },
               new EstadoCita
               {
                   EstadoId = 3,
                   Nombre = "Ejecutado"
               },
               new EstadoCita
               {
                   EstadoId = 4,
                   Nombre = "Cerrado"
               },
               new EstadoCita
               {
                   EstadoId = 5,
                   Nombre = "Cancelado"
               }
               );

        }

        
    }
}
