using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Estampas.Models
{
    public class Carrito
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CarritoId { get; set; }

        //Relaciones con otras entidades
        public ICollection<ItemCarrito>? ItemsCarrito { get; set; }

    }
}
