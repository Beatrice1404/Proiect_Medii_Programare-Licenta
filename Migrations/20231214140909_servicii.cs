using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Medii_Programare.Migrations
{
    public partial class servicii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiciuID",
                table: "Rezervare",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "PrețPeNoapte",
                table: "Cameră",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "Serviciu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiciiSuplimentare = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serviciu", x => x.ID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervare_Serviciu_ServiciuID",
                table: "Rezervare");

            migrationBuilder.DropTable(
                name: "Serviciu");

            migrationBuilder.DropIndex(
                name: "IX_Rezervare_ServiciuID",
                table: "Rezervare");

            migrationBuilder.DropColumn(
                name: "ServiciuID",
                table: "Rezervare");

            migrationBuilder.AlterColumn<decimal>(
                name: "PrețPeNoapte",
                table: "Cameră",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");
        }
    }
}
