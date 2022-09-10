using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderManagement.Infrastructure.Persistence.EF.Migrations
{
    public partial class Add_ProductId_ToOrderItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "OrderItem",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "OrderItem");
        }
    }
}
