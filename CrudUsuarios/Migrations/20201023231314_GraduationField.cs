using Microsoft.EntityFrameworkCore.Migrations;

namespace CrudUsuarios.Migrations
{
    public partial class GraduationField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Escolaridade",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "Graduation",
                table: "User",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Graduation",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "Escolaridade",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
