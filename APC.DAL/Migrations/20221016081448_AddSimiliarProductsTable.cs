using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APC.DAL.Migrations
{
    public partial class AddSimiliarProductsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SimilarProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TheProductid = table.Column<int>(type: "int", nullable: false),
                    SimiliarProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimilarProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SimilarProducts_Products_SimiliarProductId",
                        column: x => x.SimiliarProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SimilarProducts_Products_TheProductid",
                        column: x => x.TheProductid,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SimilarProducts_SimiliarProductId",
                table: "SimilarProducts",
                column: "SimiliarProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SimilarProducts_TheProductid",
                table: "SimilarProducts",
                column: "TheProductid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SimilarProducts");
        }
    }
}
