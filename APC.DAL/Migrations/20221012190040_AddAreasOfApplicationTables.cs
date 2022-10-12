using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APC.DAL.Migrations
{
    public partial class AddAreasOfApplicationTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreasOfApplication",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasOfApplication", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AreasOfApplicationProduct",
                columns: table => new
                {
                    AreasOfApplicationsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasOfApplicationProduct", x => new { x.AreasOfApplicationsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_AreasOfApplicationProduct_AreasOfApplication_AreasOfApplicationsId",
                        column: x => x.AreasOfApplicationsId,
                        principalTable: "AreasOfApplication",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AreasOfApplicationProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AreasOfApplicationProduct_ProductsId",
                table: "AreasOfApplicationProduct",
                column: "ProductsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreasOfApplicationProduct");

            migrationBuilder.DropTable(
                name: "AreasOfApplication");
        }
    }
}
