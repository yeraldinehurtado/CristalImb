using Microsoft.EntityFrameworkCore.Migrations;

namespace CristalImb.Model.Migrations
{
    public partial class cambiosInmueble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Servicio",
                table: "inmuebles");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "inmuebles");

            migrationBuilder.AddColumn<int>(
                name: "ServicioInmuebleId",
                table: "inmuebles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoId",
                table: "inmuebles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServicioInmuebleId",
                table: "inmuebles");

            migrationBuilder.DropColumn(
                name: "TipoId",
                table: "inmuebles");

            migrationBuilder.AddColumn<string>(
                name: "Servicio",
                table: "inmuebles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "inmuebles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
