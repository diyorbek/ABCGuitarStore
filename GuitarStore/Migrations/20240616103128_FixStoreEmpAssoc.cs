using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuitarStore.Migrations
{
    /// <inheritdoc />
    public partial class FixStoreEmpAssoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeStores");

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "Accounts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_StoreId",
                table: "Accounts",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Stores_StoreId",
                table: "Accounts",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Stores_StoreId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_StoreId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Accounts");

            migrationBuilder.CreateTable(
                name: "EmployeeStores",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    StoreId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeStores", x => new { x.EmployeeId, x.StoreId });
                    table.ForeignKey(
                        name: "FK_EmployeeStores_Accounts_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeStores_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeStores_StoreId",
                table: "EmployeeStores",
                column: "StoreId");
        }
    }
}
