using Microsoft.EntityFrameworkCore.Migrations;

namespace CristalImb.Model.Migrations
{
    public partial class nuevasTablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "estados",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estados", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "serviciosInmueble",
                columns: table => new
                {
                    ServicioInmuebleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviciosInmueble", x => x.ServicioInmuebleId);
                });

            migrationBuilder.CreateTable(
                name: "tipoInmuebles",
                columns: table => new
                {
                    TipoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoInmuebles", x => x.TipoId);
                });

            migrationBuilder.CreateTable(
                name: "zonas",
                columns: table => new
                {
                    ZonaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zonas", x => x.ZonaId);
                });

            migrationBuilder.InsertData(
                table: "cargos",
                columns: new[] { "CargoId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 2, "Analista" },
                    { 3, "Secretaria" }
                });

            migrationBuilder.InsertData(
                table: "estados",
                columns: new[] { "EstadoId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Por confirmar" },
                    { 2, "Confirmado" },
                    { 3, "Ejecutado" },
                    { 4, "Cerrado" },
                    { 5, "Cancelado" }
                });

            migrationBuilder.InsertData(
                table: "serviciosInmueble",
                columns: new[] { "ServicioInmuebleId", "Nombre" },
                values: new object[,]
                {
                    { 2, "Arriendo" },
                    { 1, "Venta" }
                });

            migrationBuilder.InsertData(
                table: "tipoInmuebles",
                columns: new[] { "TipoId", "Nombre" },
                values: new object[,]
                {
                    { 1, "Casa" },
                    { 2, "Apartamento" },
                    { 3, "Lote" },
                    { 4, "Bodega" }
                });

            migrationBuilder.InsertData(
                table: "zonas",
                columns: new[] { "ZonaId", "Nombre" },
                values: new object[,]
                {
                    { 4, "Castilla" },
                    { 1, "Laureles" },
                    { 2, "Villa Hermosa" },
                    { 3, "Aranjuez" },
                    { 5, "Poblado" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cargos");

            migrationBuilder.DropTable(
                name: "estados");

            migrationBuilder.DropTable(
                name: "serviciosInmueble");

            migrationBuilder.DropTable(
                name: "tipoInmuebles");

            migrationBuilder.DropTable(
                name: "zonas");
        }
    }
}
