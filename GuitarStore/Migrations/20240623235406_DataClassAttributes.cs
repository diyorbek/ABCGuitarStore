using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuitarStore.Migrations
{
    /// <inheritdoc />
    public partial class DataClassAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ClassAttributes",
                columns: new[] { "Id", "DepositAmount", "MaxActiveRents", "MaxCommissionRate", "MaxRentDays" },
                values: new object[] { new Guid("962e7227-e1f1-424a-b338-62323c41a295"), 1000f, 5, 10, 30 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClassAttributes",
                keyColumn: "Id",
                keyValue: new Guid("962e7227-e1f1-424a-b338-62323c41a295"));
        }
    }
}
