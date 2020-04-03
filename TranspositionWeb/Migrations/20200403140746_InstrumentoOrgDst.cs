using Microsoft.EntityFrameworkCore.Migrations;

namespace TranspositionWeb.Migrations
{
    public partial class InstrumentoOrgDst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InstrumentoDestino",
                table: "notas",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InstrumentoOrigen",
                table: "notas",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstrumentoDestino",
                table: "notas");

            migrationBuilder.DropColumn(
                name: "InstrumentoOrigen",
                table: "notas");
        }
    }
}
