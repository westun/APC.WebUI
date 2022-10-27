using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APC.DAL.Migrations
{
    public partial class AddCompatibleProductsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompatibleProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TheProductid = table.Column<int>(type: "int", nullable: false),
                    CompatibleProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompatibleProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompatibleProducts_Products_CompatibleProductId",
                        column: x => x.CompatibleProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_CompatibleProducts_Products_TheProductid",
                        column: x => x.TheProductid,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompatibleProducts_CompatibleProductId",
                table: "CompatibleProducts",
                column: "CompatibleProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CompatibleProducts_TheProductid",
                table: "CompatibleProducts",
                column: "TheProductid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompatibleProducts");
        }
    }
}
