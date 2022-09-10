using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderManagement.Infrastructure.Persistence.EF.Migrations
{
    public partial class Add_ProductId_ToOrderItem_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "OrderItem",
                newName: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrderItem",
                newName: "Value");
        }
    }
}
