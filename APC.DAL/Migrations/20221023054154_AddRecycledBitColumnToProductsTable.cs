using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APC.DAL.Migrations
{
    public partial class AddRecycledBitColumnToProductsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Recycled",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Recycled",
                table: "Products");
        }
    }
}
