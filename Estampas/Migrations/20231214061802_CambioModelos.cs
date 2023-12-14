using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estampas.Migrations
{
    /// <inheritdoc />
    public partial class CambioModelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carrito_Cliente_ClienteId",
                table: "Carrito");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemCarrito_Carrito_CarritoId",
                table: "ItemCarrito");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemCarrito_Producto_ProductoId",
                table: "ItemCarrito");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Cliente_ClienteId",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Producto_Pedido_PedidoId",
                table: "Producto");

            migrationBuilder.DropTable(
                name: "AdministradorProducto");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Administrador");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Producto",
                table: "Producto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pedido",
                table: "Pedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemCarrito",
                table: "ItemCarrito");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carrito",
                table: "Carrito");

            migrationBuilder.RenameTable(
                name: "Producto",
                newName: "Productos");

            migrationBuilder.RenameTable(
                name: "Pedido",
                newName: "Pedidos");

            migrationBuilder.RenameTable(
                name: "ItemCarrito",
                newName: "ItemsCarrito");

            migrationBuilder.RenameTable(
                name: "Carrito",
                newName: "Carritos");

            migrationBuilder.RenameIndex(
                name: "IX_Producto_PedidoId",
                table: "Productos",
                newName: "IX_Productos_PedidoId");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Pedidos",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedidos",
                newName: "IX_Pedidos_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemCarrito_ProductoId",
                table: "ItemsCarrito",
                newName: "IX_ItemsCarrito_ProductoId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemCarrito_CarritoId",
                table: "ItemsCarrito",
                newName: "IX_ItemsCarrito_CarritoId");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "Carritos",
                newName: "UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Carrito_ClienteId",
                table: "Carritos",
                newName: "IX_Carritos_UsuarioId");

            migrationBuilder.AddColumn<int>(
                name: "CarritoId",
                table: "Pedidos",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Productos",
                table: "Productos",
                column: "ProductoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pedidos",
                table: "Pedidos",
                column: "PedidoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemsCarrito",
                table: "ItemsCarrito",
                column: "ItemCarritoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carritos",
                table: "Carritos",
                column: "CarritoId");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Dni = table.Column<int>(type: "int", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_CarritoId",
                table: "Pedidos",
                column: "CarritoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carritos_Usuarios_UsuarioId",
                table: "Carritos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId");

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
                name: "FK_Pedidos_Carritos_CarritoId",
                table: "Pedidos",
                column: "CarritoId",
                principalTable: "Carritos",
                principalColumn: "CarritoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Usuarios_UsuarioId",
                table: "Pedidos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Pedidos_PedidoId",
                table: "Productos",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "PedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carritos_Usuarios_UsuarioId",
                table: "Carritos");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemsCarrito_Carritos_CarritoId",
                table: "ItemsCarrito");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemsCarrito_Productos_ProductoId",
                table: "ItemsCarrito");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Carritos_CarritoId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Usuarios_UsuarioId",
                table: "Pedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Pedidos_PedidoId",
                table: "Productos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Productos",
                table: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pedidos",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_CarritoId",
                table: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemsCarrito",
                table: "ItemsCarrito");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carritos",
                table: "Carritos");

            migrationBuilder.DropColumn(
                name: "CarritoId",
                table: "Pedidos");

            migrationBuilder.RenameTable(
                name: "Productos",
                newName: "Producto");

            migrationBuilder.RenameTable(
                name: "Pedidos",
                newName: "Pedido");

            migrationBuilder.RenameTable(
                name: "ItemsCarrito",
                newName: "ItemCarrito");

            migrationBuilder.RenameTable(
                name: "Carritos",
                newName: "Carrito");

            migrationBuilder.RenameIndex(
                name: "IX_Productos_PedidoId",
                table: "Producto",
                newName: "IX_Producto_PedidoId");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Pedido",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Pedidos_UsuarioId",
                table: "Pedido",
                newName: "IX_Pedido_ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemsCarrito_ProductoId",
                table: "ItemCarrito",
                newName: "IX_ItemCarrito_ProductoId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemsCarrito_CarritoId",
                table: "ItemCarrito",
                newName: "IX_ItemCarrito_CarritoId");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Carrito",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Carritos_UsuarioId",
                table: "Carrito",
                newName: "IX_Carrito_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Producto",
                table: "Producto",
                column: "ProductoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pedido",
                table: "Pedido",
                column: "PedidoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemCarrito",
                table: "ItemCarrito",
                column: "ItemCarritoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carrito",
                table: "Carrito",
                column: "CarritoId");

            migrationBuilder.CreateTable(
                name: "Administrador",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdministradorId = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    User = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrador", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apellido = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dni = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    User = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "AdministradorProducto",
                columns: table => new
                {
                    AdministradorProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdministradorId = table.Column<int>(type: "int", nullable: true),
                    ProductoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdministradorProducto", x => x.AdministradorProductoId);
                    table.ForeignKey(
                        name: "FK_AdministradorProducto_Administrador_AdministradorId",
                        column: x => x.AdministradorId,
                        principalTable: "Administrador",
                        principalColumn: "UsuarioId");
                    table.ForeignKey(
                        name: "FK_AdministradorProducto_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "ProductoId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdministradorProducto_AdministradorId",
                table: "AdministradorProducto",
                column: "AdministradorId");

            migrationBuilder.CreateIndex(
                name: "IX_AdministradorProducto_ProductoId",
                table: "AdministradorProducto",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carrito_Cliente_ClienteId",
                table: "Carrito",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCarrito_Carrito_CarritoId",
                table: "ItemCarrito",
                column: "CarritoId",
                principalTable: "Carrito",
                principalColumn: "CarritoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemCarrito_Producto_ProductoId",
                table: "ItemCarrito",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Cliente_ClienteId",
                table: "Pedido",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Producto_Pedido_PedidoId",
                table: "Producto",
                column: "PedidoId",
                principalTable: "Pedido",
                principalColumn: "PedidoId");
        }
    }
}
