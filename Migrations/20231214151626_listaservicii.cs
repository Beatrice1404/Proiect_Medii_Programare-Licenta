using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Medii_Programare.Migrations
{
    public partial class listaservicii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervare_Serviciu_ServiciuID",
                table: "Rezervare");

            migrationBuilder.DropIndex(
                name: "IX_Rezervare_ServiciuID",
                table: "Rezervare");

            migrationBuilder.CreateTable(
                name: "RezervareServiciu",
                columns: table => new
                {
                    RezervăriID = table.Column<int>(type: "int", nullable: false),
                    ServiciiID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezervareServiciu", x => new { x.RezervăriID, x.ServiciiID });
                    table.ForeignKey(
                        name: "FK_RezervareServiciu_Rezervare_RezervăriID",
                        column: x => x.RezervăriID,
                        principalTable: "Rezervare",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RezervareServiciu_Serviciu_ServiciiID",
                        column: x => x.ServiciiID,
                        principalTable: "Serviciu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RezervareServiciu_ServiciiID",
                table: "RezervareServiciu",
                column: "ServiciiID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RezervareServiciu");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervare_ServiciuID",
                table: "Rezervare",
                column: "ServiciuID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervare_Serviciu_ServiciuID",
                table: "Rezervare",
                column: "ServiciuID",
                principalTable: "Serviciu",
                principalColumn: "ID");
        }
    }
}
