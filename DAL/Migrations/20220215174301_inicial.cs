using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CristalImb.Model.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Permisos = table.Column<int>(type: "int", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Identificacion = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cargos",
                columns: table => new
                {
                    CargoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargos", x => x.CargoId);
                });

            migrationBuilder.CreateTable(
                name: "empleados",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificacion = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empleados", x => x.EmpleadoId);
                });

            migrationBuilder.CreateTable(
                name: "estadoCitas",
                columns: table => new
                {
                    EstadoCitaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estadoCitas", x => x.EstadoCitaId);
                });

            migrationBuilder.CreateTable(
                name: "estadosInmueble",
                columns: table => new
                {
                    IdEstadoInm = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estadosInmueble", x => x.IdEstadoInm);
                });

            migrationBuilder.CreateTable(
                name: "propietarios",
                columns: table => new
                {
                    PropietarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificacion = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_propietarios", x => x.PropietarioId);
                });

            migrationBuilder.CreateTable(
                name: "serviciosInmueble",
                columns: table => new
                {
                    ServicioInmuebleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviciosInmueble", x => x.ServicioInmuebleId);
                });

            migrationBuilder.CreateTable(
                name: "tipoInmuebles",
                columns: table => new
                {
                    TipoInmuebleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTipoInm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoInmuebles", x => x.TipoInmuebleId);
                });

            migrationBuilder.CreateTable(
                name: "zonas",
                columns: table => new
                {
                    ZonaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreZona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zonas", x => x.ZonaId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inmuebles",
                columns: table => new
                {
                    InmuebleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoId = table.Column<int>(type: "int", nullable: false),
                    IdEstadoInm = table.Column<int>(type: "int", nullable: false),
                    ZonaId = table.Column<int>(type: "int", nullable: false),
                    ServicioInmuebleId = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<long>(type: "bigint", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    oferta = table.Column<bool>(type: "bit", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    EstadosInmuebleIdEstadoInm = table.Column<int>(type: "int", nullable: true),
                    TipoInmueblesTipoInmuebleId = table.Column<int>(type: "int", nullable: true),
                    ServiciosInmuebleServicioInmuebleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inmuebles", x => x.InmuebleId);
                    table.ForeignKey(
                        name: "FK_inmuebles_estadosInmueble_EstadosInmuebleIdEstadoInm",
                        column: x => x.EstadosInmuebleIdEstadoInm,
                        principalTable: "estadosInmueble",
                        principalColumn: "IdEstadoInm",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inmuebles_serviciosInmueble_ServiciosInmuebleServicioInmuebleId",
                        column: x => x.ServiciosInmuebleServicioInmuebleId,
                        principalTable: "serviciosInmueble",
                        principalColumn: "ServicioInmuebleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inmuebles_tipoInmuebles_TipoInmueblesTipoInmuebleId",
                        column: x => x.TipoInmueblesTipoInmuebleId,
                        principalTable: "tipoInmuebles",
                        principalColumn: "TipoInmuebleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_inmuebles_zonas_ZonaId",
                        column: x => x.ZonaId,
                        principalTable: "zonas",
                        principalColumn: "ZonaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "citas",
                columns: table => new
                {
                    CitaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InmuebleId = table.Column<int>(type: "int", nullable: false),
                    ServicioInmuebleId = table.Column<int>(type: "int", nullable: false),
                    EstadoCitaId = table.Column<int>(type: "int", nullable: false),
                    Identificacion = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<int>(type: "int", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    serviciosInmuebleServicioInmuebleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_citas", x => x.CitaId);
                    table.ForeignKey(
                        name: "FK_citas_estadoCitas_EstadoCitaId",
                        column: x => x.EstadoCitaId,
                        principalTable: "estadoCitas",
                        principalColumn: "EstadoCitaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_citas_inmuebles_InmuebleId",
                        column: x => x.InmuebleId,
                        principalTable: "inmuebles",
                        principalColumn: "InmuebleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_citas_serviciosInmueble_serviciosInmuebleServicioInmuebleId",
                        column: x => x.serviciosInmuebleServicioInmuebleId,
                        principalTable: "serviciosInmueble",
                        principalColumn: "ServicioInmuebleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InmPropietarios",
                columns: table => new
                {
                    InmProId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InmuebleId = table.Column<int>(type: "int", nullable: false),
                    PropietarioId = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InmPropietarios", x => x.InmProId);
                    table.ForeignKey(
                        name: "FK_InmPropietarios_inmuebles_InmuebleId",
                        column: x => x.InmuebleId,
                        principalTable: "inmuebles",
                        principalColumn: "InmuebleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InmPropietarios_propietarios_PropietarioId",
                        column: x => x.PropietarioId,
                        principalTable: "propietarios",
                        principalColumn: "PropietarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_citas_EstadoCitaId",
                table: "citas",
                column: "EstadoCitaId");

            migrationBuilder.CreateIndex(
                name: "IX_citas_InmuebleId",
                table: "citas",
                column: "InmuebleId");

            migrationBuilder.CreateIndex(
                name: "IX_citas_serviciosInmuebleServicioInmuebleId",
                table: "citas",
                column: "serviciosInmuebleServicioInmuebleId");

            migrationBuilder.CreateIndex(
                name: "IX_InmPropietarios_InmuebleId",
                table: "InmPropietarios",
                column: "InmuebleId");

            migrationBuilder.CreateIndex(
                name: "IX_InmPropietarios_PropietarioId",
                table: "InmPropietarios",
                column: "PropietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_inmuebles_EstadosInmuebleIdEstadoInm",
                table: "inmuebles",
                column: "EstadosInmuebleIdEstadoInm");

            migrationBuilder.CreateIndex(
                name: "IX_inmuebles_ServiciosInmuebleServicioInmuebleId",
                table: "inmuebles",
                column: "ServiciosInmuebleServicioInmuebleId");

            migrationBuilder.CreateIndex(
                name: "IX_inmuebles_TipoInmueblesTipoInmuebleId",
                table: "inmuebles",
                column: "TipoInmueblesTipoInmuebleId");

            migrationBuilder.CreateIndex(
                name: "IX_inmuebles_ZonaId",
                table: "inmuebles",
                column: "ZonaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "cargos");

            migrationBuilder.DropTable(
                name: "citas");

            migrationBuilder.DropTable(
                name: "empleados");

            migrationBuilder.DropTable(
                name: "InmPropietarios");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "estadoCitas");

            migrationBuilder.DropTable(
                name: "inmuebles");

            migrationBuilder.DropTable(
                name: "propietarios");

            migrationBuilder.DropTable(
                name: "estadosInmueble");

            migrationBuilder.DropTable(
                name: "serviciosInmueble");

            migrationBuilder.DropTable(
                name: "tipoInmuebles");

            migrationBuilder.DropTable(
                name: "zonas");
        }
    }
}
