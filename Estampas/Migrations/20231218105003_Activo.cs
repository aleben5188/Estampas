using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estampas.Migrations
{
    /// <inheritdoc />
    public partial class Activo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "ItemsCarrito",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activo",
                table: "ItemsCarrito");
        }
    }
}
