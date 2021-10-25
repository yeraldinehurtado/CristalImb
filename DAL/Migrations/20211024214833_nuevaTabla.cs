using Microsoft.EntityFrameworkCore.Migrations;

namespace CristalImb.Model.Migrations
{
    public partial class nuevaTabla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "estadosInmueble",
                columns: table => new
                {
                    IdEstadoInm = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstado = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estadosInmueble", x => x.IdEstadoInm);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "estadosInmueble");
        }
    }
}
