using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proiect_Medii_Programare.Migrations
{
    public partial class descriere : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descriere",
                table: "Cameră",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descriere",
                table: "Cameră");
        }
    }
}
