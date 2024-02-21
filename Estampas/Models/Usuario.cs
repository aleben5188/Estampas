using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Estampas.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UsuarioId { get; set; }
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public string? Contrasenia { get; set; } // Ruta de la imagen almacenada
    }
}
