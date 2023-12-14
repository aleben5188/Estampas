using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Estampas.Models
{
    public class ItemCarrito
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemCarritoId { get; set; }
        public int Cantidad { get; set; }
        public double PrecioTotal { get; set; }

        //Relaciones con otras entidades
        public int? CarritoId { get; set; }
        public Carrito? Carrito { get; set; }
        public int? ProductoId { get; set; }
        public Producto? Producto { get; set; }
    }
}
