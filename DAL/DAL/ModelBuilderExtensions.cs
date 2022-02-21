using CristalImb.Model.Entities;
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
                    Id = "1",
                    Name = "Administrador",
                    Estado = true
                },
                new Rol
                {
                    Id = "2",
                    Name = "Empleado",
                    Estado = true
                }
            );
        }
    }
}
