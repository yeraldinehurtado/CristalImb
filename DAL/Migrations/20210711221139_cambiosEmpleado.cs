using Microsoft.EntityFrameworkCore.Migrations;

namespace CristalImb.Model.Migrations
{
    public partial class cambiosEmpleado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cargo",
                table: "empleados");

            migrationBuilder.AddColumn<int>(
                name: "CargoId",
                table: "empleados",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CargoId",
                table: "empleados");

            migrationBuilder.AddColumn<string>(
                name: "Cargo",
                table: "empleados",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
