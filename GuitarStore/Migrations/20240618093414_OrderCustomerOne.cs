using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuitarStore.Migrations
{
    /// <inheritdoc />
    public partial class OrderCustomerOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerOrder");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Accounts_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Accounts_CustomerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "CustomerOrder",
                columns: table => new
                {
                    CustomersId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrdersOrderId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrder", x => new { x.CustomersId, x.OrdersOrderId });
                    table.ForeignKey(
                        name: "FK_CustomerOrder_Accounts_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerOrder_Orders_OrdersOrderId",
                        column: x => x.OrdersOrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrder_OrdersOrderId",
                table: "CustomerOrder",
                column: "OrdersOrderId");
        }
    }
}
