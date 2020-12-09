using Microsoft.EntityFrameworkCore.Migrations;

namespace Enterwell_Faruk_Obradovic.Data.Migrations
{
    public partial class fakturaStavke : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FakturaStavka_PDV_PorezPDVID",
                table: "FakturaStavka");

            migrationBuilder.DropIndex(
                name: "IX_FakturaStavka_PorezPDVID",
                table: "FakturaStavka");

            migrationBuilder.DropColumn(
                name: "PorezPDVID",
                table: "FakturaStavka");

            migrationBuilder.AddColumn<int>(
                name: "PDVID",
                table: "FakturaStavka",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FakturaStavka_PDVID",
                table: "FakturaStavka",
                column: "PDVID");

            migrationBuilder.AddForeignKey(
                name: "FK_FakturaStavka_PDV_PDVID",
                table: "FakturaStavka",
                column: "PDVID",
                principalTable: "PDV",
                principalColumn: "PDVID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FakturaStavka_PDV_PDVID",
                table: "FakturaStavka");

            migrationBuilder.DropIndex(
                name: "IX_FakturaStavka_PDVID",
                table: "FakturaStavka");

            migrationBuilder.DropColumn(
                name: "PDVID",
                table: "FakturaStavka");

            migrationBuilder.AddColumn<int>(
                name: "PorezPDVID",
                table: "FakturaStavka",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FakturaStavka_PorezPDVID",
                table: "FakturaStavka",
                column: "PorezPDVID");

            migrationBuilder.AddForeignKey(
                name: "FK_FakturaStavka_PDV_PorezPDVID",
                table: "FakturaStavka",
                column: "PorezPDVID",
                principalTable: "PDV",
                principalColumn: "PDVID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
