using Microsoft.EntityFrameworkCore.Migrations;

namespace Ganaderia.App.Persistencia.Migrations
{
    public partial class InicialVacunas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vacunas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaCompra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaVencimiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Existencia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacunas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vacunas");
        }
    }
}
