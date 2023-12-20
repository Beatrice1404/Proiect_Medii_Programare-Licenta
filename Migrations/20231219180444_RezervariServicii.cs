using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Medii_Programare.Migrations
{
    public partial class RezervariServicii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RezervareServiciu");

            migrationBuilder.DropColumn(
                name: "ServiciuID",
                table: "Rezervare");

            migrationBuilder.CreateTable(
                name: "RezervăriServicii",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RezervareID = table.Column<int>(type: "int", nullable: false),
                    ServiciuID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezervăriServicii", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RezervăriServicii_Rezervare_RezervareID",
                        column: x => x.RezervareID,
                        principalTable: "Rezervare",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RezervăriServicii_Serviciu_ServiciuID",
                        column: x => x.ServiciuID,
                        principalTable: "Serviciu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RezervăriServicii_RezervareID",
                table: "RezervăriServicii",
                column: "RezervareID");

            migrationBuilder.CreateIndex(
                name: "IX_RezervăriServicii_ServiciuID",
                table: "RezervăriServicii",
                column: "ServiciuID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RezervăriServicii");

            migrationBuilder.AddColumn<int>(
                name: "ServiciuID",
                table: "Rezervare",
                type: "int",
                nullable: true);

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
    }
}
