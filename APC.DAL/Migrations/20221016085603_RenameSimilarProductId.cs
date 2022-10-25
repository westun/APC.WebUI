using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APC.DAL.Migrations
{
    public partial class RenameSimilarProductId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SimilarProducts_Products_SimiliarProductId",
                table: "SimilarProducts");

            migrationBuilder.RenameColumn(
                name: "SimiliarProductId",
                table: "SimilarProducts",
                newName: "SimilarProductId");

            migrationBuilder.RenameIndex(
                name: "IX_SimilarProducts_SimiliarProductId",
                table: "SimilarProducts",
                newName: "IX_SimilarProducts_SimilarProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SimilarProducts_Products_SimilarProductId",
                table: "SimilarProducts",
                column: "SimilarProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SimilarProducts_Products_SimilarProductId",
                table: "SimilarProducts");

            migrationBuilder.RenameColumn(
                name: "SimilarProductId",
                table: "SimilarProducts",
                newName: "SimiliarProductId");

            migrationBuilder.RenameIndex(
                name: "IX_SimilarProducts_SimilarProductId",
                table: "SimilarProducts",
                newName: "IX_SimilarProducts_SimiliarProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SimilarProducts_Products_SimiliarProductId",
                table: "SimilarProducts",
                column: "SimiliarProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
