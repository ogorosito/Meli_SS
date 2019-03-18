using Microsoft.EntityFrameworkCore.Migrations;

namespace ML.SistemaSolar.Migrations
{
    public partial class MLSistemaSolarEFCondicionClimaticaContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CondicionesClimaticas",
                columns: table => new
                {
                    Dia = table.Column<int>(nullable: false),
                    HayCondicionesOptimasDeTemperatura = table.Column<bool>(nullable: false),
                    EsPeriodoDeSequia = table.Column<bool>(nullable: false),
                    EsPeriodoDeLluvia = table.Column<bool>(nullable: false),
                    PerimetroTriangulo = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CondicionesClimaticas", x => x.Dia);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CondicionesClimaticas");
        }
    }
}
