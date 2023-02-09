using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Marani.WebUI.Migrations
{
    public partial class faqs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCatalogItem_ProductColors_ProductColorId",
                table: "ProductCatalogItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCatalogItem_ProductMaterials_ProductMaterialId",
                table: "ProductCatalogItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCatalogItem_Products_ProductId",
                table: "ProductCatalogItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCatalogItem_ProductSizes_ProductSizeId",
                table: "ProductCatalogItem");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCatalogItem_ProductTypes_ProductTypeId",
                table: "ProductCatalogItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCatalogItem",
                table: "ProductCatalogItem");

            migrationBuilder.RenameTable(
                name: "ProductCatalogItem",
                newName: "ProductCatalog");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCatalogItem_ProductTypeId",
                table: "ProductCatalog",
                newName: "IX_ProductCatalog_ProductTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCatalogItem_ProductSizeId",
                table: "ProductCatalog",
                newName: "IX_ProductCatalog_ProductSizeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCatalogItem_ProductMaterialId",
                table: "ProductCatalog",
                newName: "IX_ProductCatalog_ProductMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCatalogItem_ProductColorId",
                table: "ProductCatalog",
                newName: "IX_ProductCatalog_ProductColorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCatalog",
                table: "ProductCatalog",
                columns: new[] { "ProductId", "ProductSizeId", "ProductTypeId", "ProductMaterialId", "ProductColorId" });

            migrationBuilder.CreateTable(
                name: "Faqs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faqs", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCatalog_ProductColors_ProductColorId",
                table: "ProductCatalog",
                column: "ProductColorId",
                principalTable: "ProductColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCatalog_ProductMaterials_ProductMaterialId",
                table: "ProductCatalog",
                column: "ProductMaterialId",
                principalTable: "ProductMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCatalog_Products_ProductId",
                table: "ProductCatalog",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCatalog_ProductSizes_ProductSizeId",
                table: "ProductCatalog",
                column: "ProductSizeId",
                principalTable: "ProductSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCatalog_ProductTypes_ProductTypeId",
                table: "ProductCatalog",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCatalog_ProductColors_ProductColorId",
                table: "ProductCatalog");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCatalog_ProductMaterials_ProductMaterialId",
                table: "ProductCatalog");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCatalog_Products_ProductId",
                table: "ProductCatalog");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCatalog_ProductSizes_ProductSizeId",
                table: "ProductCatalog");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCatalog_ProductTypes_ProductTypeId",
                table: "ProductCatalog");

            migrationBuilder.DropTable(
                name: "Faqs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCatalog",
                table: "ProductCatalog");

            migrationBuilder.RenameTable(
                name: "ProductCatalog",
                newName: "ProductCatalogItem");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCatalog_ProductTypeId",
                table: "ProductCatalogItem",
                newName: "IX_ProductCatalogItem_ProductTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCatalog_ProductSizeId",
                table: "ProductCatalogItem",
                newName: "IX_ProductCatalogItem_ProductSizeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCatalog_ProductMaterialId",
                table: "ProductCatalogItem",
                newName: "IX_ProductCatalogItem_ProductMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCatalog_ProductColorId",
                table: "ProductCatalogItem",
                newName: "IX_ProductCatalogItem_ProductColorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCatalogItem",
                table: "ProductCatalogItem",
                columns: new[] { "ProductId", "ProductSizeId", "ProductTypeId", "ProductMaterialId", "ProductColorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCatalogItem_ProductColors_ProductColorId",
                table: "ProductCatalogItem",
                column: "ProductColorId",
                principalTable: "ProductColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCatalogItem_ProductMaterials_ProductMaterialId",
                table: "ProductCatalogItem",
                column: "ProductMaterialId",
                principalTable: "ProductMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCatalogItem_Products_ProductId",
                table: "ProductCatalogItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCatalogItem_ProductSizes_ProductSizeId",
                table: "ProductCatalogItem",
                column: "ProductSizeId",
                principalTable: "ProductSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCatalogItem_ProductTypes_ProductTypeId",
                table: "ProductCatalogItem",
                column: "ProductTypeId",
                principalTable: "ProductTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
