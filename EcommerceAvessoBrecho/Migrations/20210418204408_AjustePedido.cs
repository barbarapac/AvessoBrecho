using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceAvessoBrecho.Migrations
{
    public partial class AjustePedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "VlDesconto",
                table: "Pedido",
                type: "decimal(8,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VlDesconto",
                table: "Pedido");
        }
    }
}
