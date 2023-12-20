using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Medii_Programare.Migrations
{
    public partial class specie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specie",
                table: "Rezervare");

            migrationBuilder.AddColumn<int>(
                name: "SpecieID",
                table: "Rezervare",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Specie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecieAnimal = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specie", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rezervare_SpecieID",
                table: "Rezervare",
                column: "SpecieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervare_Specie_SpecieID",
                table: "Rezervare",
                column: "SpecieID",
                principalTable: "Specie",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervare_Specie_SpecieID",
                table: "Rezervare");

            migrationBuilder.DropTable(
                name: "Specie");

            migrationBuilder.DropIndex(
                name: "IX_Rezervare_SpecieID",
                table: "Rezervare");

            migrationBuilder.DropColumn(
                name: "SpecieID",
                table: "Rezervare");

            migrationBuilder.AddColumn<string>(
                name: "Specie",
                table: "Rezervare",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
