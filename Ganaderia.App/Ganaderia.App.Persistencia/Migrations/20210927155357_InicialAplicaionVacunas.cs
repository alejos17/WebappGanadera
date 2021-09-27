using Microsoft.EntityFrameworkCore.Migrations;

namespace Ganaderia.App.Persistencia.Migrations
{
    public partial class InicialAplicaionVacunas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AplicacionVacunas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idGanadero = table.Column<int>(type: "int", nullable: false),
                    idVacuna = table.Column<int>(type: "int", nullable: false),
                    idEjemplar = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AplicacionVacunas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AplicacionVacunas");
        }
    }
}
