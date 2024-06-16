using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuitarStore.Migrations
{
    /// <inheritdoc />
    public partial class RentItemTrustedRentAssoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RentStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ScheduledEndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActualEndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    RentableItemId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TrustedCustomerId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rent_Accounts_TrustedCustomerId",
                        column: x => x.TrustedCustomerId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Rent_RentableItems_RentableItemId",
                        column: x => x.RentableItemId,
                        principalTable: "RentableItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rent_RentableItemId",
                table: "Rent",
                column: "RentableItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Rent_TrustedCustomerId",
                table: "Rent",
                column: "TrustedCustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rent");
        }
    }
}
