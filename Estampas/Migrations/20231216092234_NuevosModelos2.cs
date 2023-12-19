using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estampas.Migrations
{
    /// <inheritdoc />
    public partial class NuevosModelos2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsCarrito_Carritos_CarritoId",
                table: "ItemsCarrito");

            migrationBuilder.DropTable(
                name: "Carritos");

            migrationBuilder.DropIndex(
                name: "IX_ItemsCarrito_CarritoId",
                table: "ItemsCarrito");

            migrationBuilder.DropColumn(
                name: "CarritoId",
                table: "ItemsCarrito");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarritoId",
                table: "ItemsCarrito",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Carritos",
                columns: table => new
                {
                    CarritoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carritos", x => x.CarritoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemsCarrito_CarritoId",
                table: "ItemsCarrito",
                column: "CarritoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsCarrito_Carritos_CarritoId",
                table: "ItemsCarrito",
                column: "CarritoId",
                principalTable: "Carritos",
                principalColumn: "CarritoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
