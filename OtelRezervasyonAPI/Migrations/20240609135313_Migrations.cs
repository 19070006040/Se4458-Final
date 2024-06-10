using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtelRezervasyonAPI.Migrations
{
    /// <inheritdoc />
    public partial class Migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Musteris",
                columns: table => new
                {
                    MusteriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyisim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GirisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CikisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OdaNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteris", x => x.MusteriId);
                });

            migrationBuilder.CreateTable(
                name: "Odas",
                columns: table => new
                {
                    OdaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OdaTuru = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Doluluk = table.Column<bool>(type: "bit", nullable: false),
                    OdaNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odas", x => x.OdaId);
                });

            migrationBuilder.CreateTable(
                name: "Otels",
                columns: table => new
                {
                    OtelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OtelAdı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OdaSayısı = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Otels", x => x.OtelId);
                });

            migrationBuilder.CreateTable(
                name: "Rezervasyons",
                columns: table => new
                {
                    RezervasyonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriId = table.Column<int>(type: "int", nullable: false),
                    OdaId = table.Column<int>(type: "int", nullable: false),
                    RezervasyonTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervasyons", x => x.RezervasyonId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Musteris");

            migrationBuilder.DropTable(
                name: "Odas");

            migrationBuilder.DropTable(
                name: "Otels");

            migrationBuilder.DropTable(
                name: "Rezervasyons");
        }
    }
}
