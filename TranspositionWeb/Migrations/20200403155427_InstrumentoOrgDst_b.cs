using Microsoft.EntityFrameworkCore.Migrations;

namespace TranspositionWeb.Migrations
{
    public partial class InstrumentoOrgDst_b : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "InstrumentoOrigen",
                table: "notas",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");

            migrationBuilder.AlterColumn<int>(
                name: "InstrumentoDestino",
                table: "notas",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "InstrumentoOrigen",
                table: "notas",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "InstrumentoDestino",
                table: "notas",
                type: "nvarchar(1)",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
