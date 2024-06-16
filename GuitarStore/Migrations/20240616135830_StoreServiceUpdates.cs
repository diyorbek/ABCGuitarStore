using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuitarStore.Migrations
{
    /// <inheritdoc />
    public partial class StoreServiceUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Stores",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Stores");
        }
    }
}
