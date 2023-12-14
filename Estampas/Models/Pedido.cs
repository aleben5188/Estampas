using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Estampas.Models
{
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PedidoId { get; set; }

        //Relaciones con otras entidades

        public ICollection<Producto>? Productos { get; set; }
        public int? CarritoId { get; set; }
        public Carrito? Carrito { get; set; }

    }
}
