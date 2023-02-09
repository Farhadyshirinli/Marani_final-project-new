using Microsoft.EntityFrameworkCore.Migrations;

namespace Marani.WebUI.Migrations
{
    public partial class ProductQualityVolume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductQuality");

            migrationBuilder.AddColumn<decimal>(
                name: "Volume",
                table: "ProductQuality",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Volume",
                table: "ProductQuality");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductQuality",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
