using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estampas.Migrations
{
    /// <inheritdoc />
    public partial class NuevosModelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsCarrito_Carritos_CarritoId",
                table: "ItemsCarrito");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemsCarrito_Productos_ProductoId",
                table: "ItemsCarrito");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Pedidos_PedidoId",
                table: "Productos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Carritos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_PedidoId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_ItemsCarrito_CarritoId",
                table: "ItemsCarrito");

            migrationBuilder.DropIndex(
                name: "IX_ItemsCarrito_ProductoId",
                table: "ItemsCarrito");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "CarritoId",
                table: "ItemsCarrito");

            migrationBuilder.DropColumn(
                name: "PrecioTotal",
                table: "ItemsCarrito");

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "ItemsCarrito",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Puntuaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    NombreCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puntuaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Puntuaciones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductoId",
                table: "ItemsCarrito",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CarritoId",
                table: "ItemsCarrito",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PrecioTotal",
                table: "ItemsCarrito",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

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

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarritoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PedidoId);
                    table.ForeignKey(
                        name: "FK_Pedidos_Carritos_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "Carritos",
                        principalColumn: "CarritoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_PedidoId",
                table: "Productos",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsCarrito_CarritoId",
                table: "ItemsCarrito",
                column: "CarritoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsCarrito_ProductoId",
                table: "ItemsCarrito",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_CarritoId",
                table: "Pedidos",
                column: "CarritoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsCarrito_Carritos_CarritoId",
                table: "ItemsCarrito",
                column: "CarritoId",
                principalTable: "Carritos",
                principalColumn: "CarritoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsCarrito_Productos_ProductoId",
                table: "ItemsCarrito",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Pedidos_PedidoId",
                table: "Productos",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "PedidoId");
        }
    }
}
