using Microsoft.EntityFrameworkCore.Migrations;

namespace Enterwell_Faruk_Obradovic.Data.Migrations
{
    public partial class last : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CijenaBezPDV",
                table: "FakturaStavka");

            migrationBuilder.DropColumn(
                name: "Opis",
                table: "FakturaStavka");

            migrationBuilder.AddColumn<double>(
                name: "CijenaBezPDV",
                table: "Stavka",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Opis",
                table: "Stavka",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CijenaBezPDV",
                table: "Stavka");

            migrationBuilder.DropColumn(
                name: "Opis",
                table: "Stavka");

            migrationBuilder.AddColumn<double>(
                name: "CijenaBezPDV",
                table: "FakturaStavka",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Opis",
                table: "FakturaStavka",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
