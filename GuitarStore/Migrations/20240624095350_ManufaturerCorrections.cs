using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuitarStore.Migrations
{
    /// <inheritdoc />
    public partial class ManufaturerCorrections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClassAttributes",
                keyColumn: "Id",
                keyValue: new Guid("c6a5f924-29f8-460d-bb37-4c8d2229b736"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Manufacturers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.InsertData(
                table: "ClassAttributes",
                columns: new[] { "Id", "DepositAmount", "MaxActiveRents", "MaxCommissionRate", "MaxRentDays" },
                values: new object[] { new Guid("b17b5b6e-0512-4835-86cb-8bfe8492f159"), 1000f, 5, 10, 30 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ClassAttributes",
                keyColumn: "Id",
                keyValue: new Guid("b17b5b6e-0512-4835-86cb-8bfe8492f159"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Manufacturers",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "ClassAttributes",
                columns: new[] { "Id", "DepositAmount", "MaxActiveRents", "MaxCommissionRate", "MaxRentDays" },
                values: new object[] { new Guid("c6a5f924-29f8-460d-bb37-4c8d2229b736"), 1000f, 5, 10, 30 });
        }
    }
}
