using Microsoft.EntityFrameworkCore.Migrations;

namespace CristalImb.Model.Migrations
{
    public partial class cambioCitaInmueble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "citas");

            migrationBuilder.DropColumn(
                name: "Servicio",
                table: "citas");

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                table: "citas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServicioInmuebleId",
                table: "citas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstadoId",
                table: "citas");

            migrationBuilder.DropColumn(
                name: "ServicioInmuebleId",
                table: "citas");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "citas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Servicio",
                table: "citas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
