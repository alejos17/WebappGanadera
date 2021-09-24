using Microsoft.EntityFrameworkCore.Migrations;

namespace Ganaderia.App.Persistencia.Migrations
{
    public partial class InicialVeterinario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Registro",
                table: "Personas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Veterinario_Latitude",
                table: "Personas",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Veterinario_Longitude",
                table: "Personas",
                type: "real",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Registro",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Veterinario_Latitude",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Veterinario_Longitude",
                table: "Personas");
        }
    }
}
