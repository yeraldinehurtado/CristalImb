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
                    Id = "FD713788-B5AE-49FF-8B2C-F311B9CB0CC4",
                    Name = "Administrador",
                    Estado = true
                },
                new Rol
                {
                    Id = "64B512E7-46AE-4989-A049-A446118099C4",
                    Name = "Empleado",
                    Estado = true
                },
                new Rol
                {
                    Id = "376D45C8-659D-4ACE-B249-CFBF4F231915",
                    Name = "Cliente",
                    Estado = true
                }
            );
        }
    }
}
