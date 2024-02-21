using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;


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

        [EnumDataType(typeof(Dibujo))]
        public Dibujo Licencia { get; set; }
        
        [EnumDataType(typeof(Categoria))]
        public Categoria Tipo { get; set; }


    }
}
