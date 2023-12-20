using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Medii_Programare.Migrations
{
    public partial class Camere : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preț",
                table: "Rezervare");

            migrationBuilder.AddColumn<int>(
                name: "CamerăID",
                table: "Rezervare",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cameră",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipCameră = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrețPeNoapte = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cameră", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rezervare_CamerăID",
                table: "Rezervare",
                column: "CamerăID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervare_Cameră_CamerăID",
                table: "Rezervare",
                column: "CamerăID",
                principalTable: "Cameră",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervare_Cameră_CamerăID",
                table: "Rezervare");

            migrationBuilder.DropTable(
                name: "Cameră");

            migrationBuilder.DropIndex(
                name: "IX_Rezervare_CamerăID",
                table: "Rezervare");

            migrationBuilder.DropColumn(
                name: "CamerăID",
                table: "Rezervare");

            migrationBuilder.AddColumn<decimal>(
                name: "Preț",
                table: "Rezervare",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
