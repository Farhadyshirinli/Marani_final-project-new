using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Marani.WebUI.Migrations
{
    public partial class ProductQuality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCatalog_ProductMaterials_ProductMaterialId",
                table: "ProductCatalog");

            migrationBuilder.DropTable(
                name: "ProductMaterials");

            migrationBuilder.RenameColumn(
                name: "ProductMaterialId",
                table: "ProductCatalog",
                newName: "ProductQualityId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCatalog_ProductMaterialId",
                table: "ProductCatalog",
                newName: "IX_ProductCatalog_ProductQualityId");

            migrationBuilder.CreateTable(
                name: "ProductQuality",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductQuality", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCatalog_ProductQuality_ProductQualityId",
                table: "ProductCatalog",
                column: "ProductQualityId",
                principalTable: "ProductQuality",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCatalog_ProductQuality_ProductQualityId",
                table: "ProductCatalog");

            migrationBuilder.DropTable(
                name: "ProductQuality");

            migrationBuilder.RenameColumn(
                name: "ProductQualityId",
                table: "ProductCatalog",
                newName: "ProductMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCatalog_ProductQualityId",
                table: "ProductCatalog",
                newName: "IX_ProductCatalog_ProductMaterialId");

            migrationBuilder.CreateTable(
                name: "ProductMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMaterials", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCatalog_ProductMaterials_ProductMaterialId",
                table: "ProductCatalog",
                column: "ProductMaterialId",
                principalTable: "ProductMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
