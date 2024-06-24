using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuitarStore.Migrations
{
    /// <inheritdoc />
    public partial class SimplifyProductManufacturerAssoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductManufacturers");

            migrationBuilder.DeleteData(
                table: "ClassAttributes",
                keyColumn: "Id",
                keyValue: new Guid("962e7227-e1f1-424a-b338-62323c41a295"));

            migrationBuilder.CreateTable(
                name: "ManufacturerProduct",
                columns: table => new
                {
                    ManufacturersId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductsId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturerProduct", x => new { x.ManufacturersId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_ManufacturerProduct_Manufacturers_ManufacturersId",
                        column: x => x.ManufacturersId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManufacturerProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClassAttributes",
                columns: new[] { "Id", "DepositAmount", "MaxActiveRents", "MaxCommissionRate", "MaxRentDays" },
                values: new object[] { new Guid("c6a5f924-29f8-460d-bb37-4c8d2229b736"), 1000f, 5, 10, 30 });

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturerProduct_ProductsId",
                table: "ManufacturerProduct",
                column: "ProductsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManufacturerProduct");

            migrationBuilder.DeleteData(
                table: "ClassAttributes",
                keyColumn: "Id",
                keyValue: new Guid("c6a5f924-29f8-460d-bb37-4c8d2229b736"));

            migrationBuilder.CreateTable(
                name: "ProductManufacturers",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ManufacturerId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductManufacturers", x => new { x.ProductId, x.ManufacturerId });
                    table.ForeignKey(
                        name: "FK_ProductManufacturers_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductManufacturers_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClassAttributes",
                columns: new[] { "Id", "DepositAmount", "MaxActiveRents", "MaxCommissionRate", "MaxRentDays" },
                values: new object[] { new Guid("962e7227-e1f1-424a-b338-62323c41a295"), 1000f, 5, 10, 30 });

            migrationBuilder.CreateIndex(
                name: "IX_ProductManufacturers_ManufacturerId",
                table: "ProductManufacturers",
                column: "ManufacturerId");
        }
    }
}
