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
