﻿// <auto-generated />
using System;
using CristalImb.Model.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CristalImb.Model.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211206022700_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CristalImb.Model.Entities.Cargo", b =>
                {
                    b.Property<int>("CargoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CargoId");

                    b.ToTable("cargos");
                });

            modelBuilder.Entity("CristalImb.Model.Entities.Cita", b =>
                {
                    b.Property<int>("CitaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstadoCitaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<int>("Identificacion")
                        .HasColumnType("int");

                    b.Property<int>("InmuebleId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServicioInmuebleId")
                        .HasColumnType("int");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.Property<int?>("serviciosInmuebleServicioInmuebleId")
                        .HasColumnType("int");

                    b.HasKey("CitaId");

                    b.HasIndex("EstadoCitaId");

                    b.HasIndex("InmuebleId");

                    b.HasIndex("serviciosInmuebleServicioInmuebleId");

                    b.ToTable("citas");
                });

            modelBuilder.Entity("CristalImb.Model.Entities.Empleado", b =>
                {
                    b.Property<int>("EmpleadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<int>("Identificacion")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("EmpleadoId");

                    b.ToTable("empleados");
                });

            modelBuilder.Entity("CristalImb.Model.Entities.EstadoCita", b =>
                {
                    b.Property<int>("EstadoCitaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EstadoCitaId");

                    b.ToTable("estadoCitas");
                });

            modelBuilder.Entity("CristalImb.Model.Entities.EstadosInmueble", b =>
                {
                    b.Property<int>("IdEstadoInm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("NombreEstado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEstadoInm");

                    b.ToTable("estadosInmueble");
                });

            modelBuilder.Entity("CristalImb.Model.Entities.InmPropietarios", b =>
                {
                    b.Property<int>("InmProId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("InmuebleId")
                        .HasColumnType("int");

                    b.Property<int>("PropietarioId")
                        .HasColumnType("int");

                    b.HasKey("InmProId");

                    b.HasIndex("InmuebleId");

                    b.HasIndex("PropietarioId");

                    b.ToTable("InmPropietarios");
                });

            modelBuilder.Entity("CristalImb.Model.Entities.Inmueble", b =>
                {
                    b.Property<int>("InmuebleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<int?>("EstadosInmuebleIdEstadoInm")
                        .HasColumnType("int");

                    b.Property<int>("IdEstadoInm")
                        .HasColumnType("int");

                    b.Property<int>("ServicioInmuebleId")
                        .HasColumnType("int");

                    b.Property<int?>("ServiciosInmuebleServicioInmuebleId")
                        .HasColumnType("int");

                    b.Property<int>("TipoId")
                        .HasColumnType("int");

                    b.Property<int?>("TipoInmueblesTipoInmuebleId")
                        .HasColumnType("int");

                    b.Property<long>("Valor")
                        .HasColumnType("bigint");

                    b.Property<int>("ZonaId")
                        .HasColumnType("int");

                    b.Property<bool>("oferta")
                        .HasColumnType("bit");

                    b.HasKey("InmuebleId");

                    b.HasIndex("EstadosInmuebleIdEstadoInm");

                    b.HasIndex("ServiciosInmuebleServicioInmuebleId");

                    b.HasIndex("TipoInmueblesTipoInmuebleId");

                    b.HasIndex("ZonaId");

                    b.ToTable("inmuebles");
                });

            modelBuilder.Entity("CristalImb.Model.Entities.Propietario", b =>
                {
                    b.Property<int>("PropietarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<int>("Identificacion")
                        .HasColumnType("int");

                    b.Property<string>("Inmuebles")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("PropietarioId");

                    b.ToTable("propietarios");
                });

            modelBuilder.Entity("CristalImb.Model.Entities.ServiciosInmueble", b =>
                {
                    b.Property<int>("ServicioInmuebleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServicioInmuebleId");

                    b.ToTable("serviciosInmueble");
                });

            modelBuilder.Entity("CristalImb.Model.Entities.TipoInmuebles", b =>
                {
                    b.Property<int>("TipoInmuebleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("NombreTipoInm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TipoInmuebleId");

                    b.ToTable("tipoInmuebles");
                });

            modelBuilder.Entity("CristalImb.Model.Entities.Zona", b =>
                {
                    b.Property<int>("ZonaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("NombreZona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ZonaId");

                    b.ToTable("zonas");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CristalImb.Model.Entities.Rol", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Modulo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Permisos")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Rol");
                });

            modelBuilder.Entity("CristalImb.Model.Entities.UsuarioIdentity", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasDiscriminator().HasValue("UsuarioIdentity");
                });

            modelBuilder.Entity("CristalImb.Model.Entities.Cita", b =>
                {
                    b.HasOne("CristalImb.Model.Entities.EstadoCita", "estadoCita")
                        .WithMany("citas")
                        .HasForeignKey("EstadoCitaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CristalImb.Model.Entities.Inmueble", "inmuebles")
                        .WithMany("citas")
                        .HasForeignKey("InmuebleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CristalImb.Model.Entities.ServiciosInmueble", "serviciosInmueble")
                        .WithMany("citas")
                        .HasForeignKey("serviciosInmuebleServicioInmuebleId");

                    b.Navigation("estadoCita");

                    b.Navigation("inmuebles");

                    b.Navigation("serviciosInmueble");
                });

            modelBuilder.Entity("CristalImb.Model.Entities.InmPropietarios", b =>
                {
                    b.HasOne("CristalImb.Model.Entities.Inmueble", "Inmueble")
                        .WithMany("InmPropietario")
                        .HasForeignKey("InmuebleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CristalImb.Model.Entities.Propietario", "Propietario")
                        .WithMany("InmPropietario")
                        .HasForeignKey("PropietarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inmueble");

                    b.Navigation("Propietario");
                });

            modelBuilder.Entity("CristalImb.Model.Entities.Inmueble", b =>
                {
                    b.HasOne("CristalImb.Model.Entities.EstadosInmueble", "EstadosInmueble")
                        .WithMany("Inmuebles")
                        .HasForeignKey("EstadosInmuebleIdEstadoInm");

                    b.HasOne("CristalImb.Model.Entities.ServiciosInmueble", "ServiciosInmueble")
                        .WithMany("Inmuebles")
                        .HasForeignKey("ServiciosInmuebleServicioInmuebleId");

                    b.HasOne("CristalImb.Model.Entities.TipoInmuebles", "TipoInmuebles")
                        .WithMany("Inmuebles")
                        .HasForeignKey("TipoInmueblesTipoInmuebleId");

                    b.HasOne("CristalImb.Model.Entities.Zona", "Zona")
                        .WithMany("Inmuebles")
                        .HasForeignKey("ZonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EstadosInmueble");

                    b.Navigation("ServiciosInmueble");

                    b.Navigation("TipoInmuebles");

                    b.Navigation("Zona");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CristalImb.Model.Entities.EstadoCita", b =>
                {
                    b.Navigation("citas");
                });

            modelBuilder.Entity("CristalImb.Model.Entities.EstadosInmueble", b =>
                {
                    b.Navigation("Inmuebles");
                });

            modelBuilder.Entity("CristalImb.Model.Entities.Inmueble", b =>
                {
                    b.Navigation("citas");

                    b.Navigation("InmPropietario");
                });

            modelBuilder.Entity("CristalImb.Model.Entities.Propietario", b =>
                {
                    b.Navigation("InmPropietario");
                });

            modelBuilder.Entity("CristalImb.Model.Entities.ServiciosInmueble", b =>
                {
                    b.Navigation("citas");

                    b.Navigation("Inmuebles");
                });

            modelBuilder.Entity("CristalImb.Model.Entities.TipoInmuebles", b =>
                {
                    b.Navigation("Inmuebles");
                });

            modelBuilder.Entity("CristalImb.Model.Entities.Zona", b =>
                {
                    b.Navigation("Inmuebles");
                });
#pragma warning restore 612, 618
        }
    }
}