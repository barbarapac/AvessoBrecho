using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceAvessoBrecho.Migrations
{
    public partial class ajusteTabelaProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Disponivel",
                table: "Produto",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Promocao",
                table: "Produto",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disponivel",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "Promocao",
                table: "Produto");
        }
    }
}
