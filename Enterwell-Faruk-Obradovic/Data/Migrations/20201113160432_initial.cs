using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Enterwell_Faruk_Obradovic.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adresa",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Grad",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ime",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prezime",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Faktura",
                columns: table => new
                {
                    FakturaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<string>(nullable: true),
                    BrojFakture = table.Column<int>(nullable: false),
                    DatumKreiranja = table.Column<DateTime>(nullable: false),
                    DatumDospijeca = table.Column<DateTime>(nullable: false),
                    UkupnoBezPDV = table.Column<double>(nullable: false),
                    UkupnoSaPDV = table.Column<double>(nullable: false),
                    ImePrezimeKupca = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faktura", x => x.FakturaID);
                    table.ForeignKey(
                        name: "FK_Faktura_AspNetUsers_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PDV",
                columns: table => new
                {
                    PDVID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    VisinaPDV = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PDV", x => x.PDVID);
                });

            migrationBuilder.CreateTable(
                name: "Stavka",
                columns: table => new
                {
                    StavkaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    FakturaID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stavka", x => x.StavkaID);
                    table.ForeignKey(
                        name: "FK_Stavka_Faktura_FakturaID",
                        column: x => x.FakturaID,
                        principalTable: "Faktura",
                        principalColumn: "FakturaID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FakturaStavka",
                columns: table => new
                {
                    FakturaStavkaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StavkaID = table.Column<int>(nullable: false),
                    FakturaID = table.Column<int>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    Kolicina = table.Column<int>(nullable: false),
                    CijenaBezPDV = table.Column<double>(nullable: false),
                    CijenaSaPDV = table.Column<double>(nullable: false),
                    PorezPDVID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FakturaStavka", x => x.FakturaStavkaID);
                    table.ForeignKey(
                        name: "FK_FakturaStavka_Faktura_FakturaID",
                        column: x => x.FakturaID,
                        principalTable: "Faktura",
                        principalColumn: "FakturaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FakturaStavka_PDV_PorezPDVID",
                        column: x => x.PorezPDVID,
                        principalTable: "PDV",
                        principalColumn: "PDVID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FakturaStavka_Stavka_StavkaID",
                        column: x => x.StavkaID,
                        principalTable: "Stavka",
                        principalColumn: "StavkaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Faktura_KorisnikID",
                table: "Faktura",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_FakturaStavka_FakturaID",
                table: "FakturaStavka",
                column: "FakturaID");

            migrationBuilder.CreateIndex(
                name: "IX_FakturaStavka_PorezPDVID",
                table: "FakturaStavka",
                column: "PorezPDVID");

            migrationBuilder.CreateIndex(
                name: "IX_FakturaStavka_StavkaID",
                table: "FakturaStavka",
                column: "StavkaID");

            migrationBuilder.CreateIndex(
                name: "IX_Stavka_FakturaID",
                table: "Stavka",
                column: "FakturaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FakturaStavka");

            migrationBuilder.DropTable(
                name: "PDV");

            migrationBuilder.DropTable(
                name: "Stavka");

            migrationBuilder.DropTable(
                name: "Faktura");

            migrationBuilder.DropColumn(
                name: "Adresa",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Grad",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Ime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Prezime",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
