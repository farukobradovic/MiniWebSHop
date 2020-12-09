using Microsoft.EntityFrameworkCore.Migrations;

namespace Enterwell_Faruk_Obradovic.Data.Migrations
{
    public partial class fakturaStavke2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stavka_Faktura_FakturaID",
                table: "Stavka");

            migrationBuilder.DropIndex(
                name: "IX_Stavka_FakturaID",
                table: "Stavka");

            migrationBuilder.DropColumn(
                name: "FakturaID",
                table: "Stavka");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FakturaID",
                table: "Stavka",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stavka_FakturaID",
                table: "Stavka",
                column: "FakturaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Stavka_Faktura_FakturaID",
                table: "Stavka",
                column: "FakturaID",
                principalTable: "Faktura",
                principalColumn: "FakturaID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
