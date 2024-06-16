using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuitarStore.Migrations
{
    /// <inheritdoc />
    public partial class RentableItemsAssoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RentableItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ItemCode = table.Column<string>(type: "TEXT", nullable: false),
                    RentableProductId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentableItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentableItems_Products_RentableProductId",
                        column: x => x.RentableProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentableItems_RentableProductId",
                table: "RentableItems",
                column: "RentableProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentableItems");
        }
    }
}
