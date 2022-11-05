using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APC.DAL.Migrations
{
    public partial class AddAccountCompanyBridgeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountCompany",
                columns: table => new
                {
                    AccountsId = table.Column<int>(type: "int", nullable: false),
                    CompaniesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountCompany", x => new { x.AccountsId, x.CompaniesId });
                    table.ForeignKey(
                        name: "FK_AccountCompany_Account_AccountsId",
                        column: x => x.AccountsId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountCompany_Company_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountCompany_CompaniesId",
                table: "AccountCompany",
                column: "CompaniesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountCompany");
        }
    }
}
