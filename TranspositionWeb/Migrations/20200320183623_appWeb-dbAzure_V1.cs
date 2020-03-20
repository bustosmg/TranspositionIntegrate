using Microsoft.EntityFrameworkCore.Migrations;

namespace TranspositionWeb.Migrations
{
    public partial class appWebdbAzure_V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "acordes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcordesCromaticas = table.Column<string>(nullable: false),
                    acordesCromaticasMayores = table.Column<string>(nullable: true),
                    acordesCromaticasMenores = table.Column<string>(nullable: true),
                    acordesSeptimaMayor = table.Column<string>(nullable: true),
                    acordesSeptimaMenor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_acordes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "notas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    notasCromaticas = table.Column<string>(nullable: false),
                    IsChecked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "acordes");

            migrationBuilder.DropTable(
                name: "notas");
        }
    }
}
