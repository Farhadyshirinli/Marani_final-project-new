using Microsoft.EntityFrameworkCore.Migrations;

namespace Marani.WebUI.Migrations
{
    public partial class ProductColorType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Hex",
                table: "ProductColors",
                newName: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "ProductColors",
                newName: "Hex");
        }
    }
}
