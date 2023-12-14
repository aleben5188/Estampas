using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Estampas.Models
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductoId { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? ImagePath { get; set; } // Ruta de la imagen almacenada
        public double Precio { get; set; }

        //Relaciones con otras entidades
        public int? PedidoId { get; set; }
        public Pedido? Pedido { get; set; }
    }
}
