using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Marani.WebUI.Migrations
{
    public partial class ProductRegions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCatalog_ProductSizes_ProductSizeId",
                table: "ProductCatalog");

            migrationBuilder.DropTable(
                name: "ProductSizes");

            migrationBuilder.RenameColumn(
                name: "ProductSizeId",
                table: "ProductCatalog",
                newName: "ProductRegionId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCatalog_ProductSizeId",
                table: "ProductCatalog",
                newName: "IX_ProductCatalog_ProductRegionId");

            migrationBuilder.CreateTable(
                name: "ProductRegions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmallName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRegions", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCatalog_ProductRegions_ProductRegionId",
                table: "ProductCatalog",
                column: "ProductRegionId",
                principalTable: "ProductRegions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCatalog_ProductRegions_ProductRegionId",
                table: "ProductCatalog");

            migrationBuilder.DropTable(
                name: "ProductRegions");

            migrationBuilder.RenameColumn(
                name: "ProductRegionId",
                table: "ProductCatalog",
                newName: "ProductSizeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCatalog_ProductRegionId",
                table: "ProductCatalog",
                newName: "IX_ProductCatalog_ProductSizeId");

            migrationBuilder.CreateTable(
                name: "ProductSizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SmallName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSizes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCatalog_ProductSizes_ProductSizeId",
                table: "ProductCatalog",
                column: "ProductSizeId",
                principalTable: "ProductSizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
