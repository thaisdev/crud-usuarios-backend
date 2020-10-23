using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudUsuarios.Migrations
{
    public partial class FixEscolaridadeField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "escolaridade",
                table: "User",
                newName: "Escolaridade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Escolaridade",
                table: "User",
                newName: "escolaridade");
        }
    }
}
