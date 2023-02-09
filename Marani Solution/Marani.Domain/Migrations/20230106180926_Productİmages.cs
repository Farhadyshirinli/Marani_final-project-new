using Microsoft.EntityFrameworkCore.Migrations;

namespace Marani.WebUI.Migrations
{
    public partial class Productİmages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Products_ProductId",
                table: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "ProductsImages");

            migrationBuilder.RenameIndex(
                name: "IX_Images_ProductId",
                table: "ProductsImages",
                newName: "IX_ProductsImages_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsImages",
                table: "ProductsImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsImages_Products_ProductId",
                table: "ProductsImages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsImages_Products_ProductId",
                table: "ProductsImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsImages",
                table: "ProductsImages");

            migrationBuilder.RenameTable(
                name: "ProductsImages",
                newName: "Images");

            migrationBuilder.RenameIndex(
                name: "IX_ProductsImages_ProductId",
                table: "Images",
                newName: "IX_Images_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Products_ProductId",
                table: "Images",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
