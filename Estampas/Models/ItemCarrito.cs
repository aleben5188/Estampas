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

        //Relaciones con otras entidades
        public int ProductoId { get; set; }
        public virtual Producto Producto { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public string ImagePath {  get; set; }
        public bool Activo { get; set; }


    }
}
