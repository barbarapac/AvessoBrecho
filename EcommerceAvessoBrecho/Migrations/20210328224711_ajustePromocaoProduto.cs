using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceAvessoBrecho.Migrations
{
    public partial class ajustePromocaoProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PrecoPromocional",
                table: "Produto",
                type: "decimal(8,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "SubDescricao",
                table: "Produto",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoPromocional",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "SubDescricao",
                table: "Produto");
        }
    }
}
