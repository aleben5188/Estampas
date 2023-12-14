using System.ComponentModel.DataAnnotations;

namespace Estampas.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        [MaxLength(40, ErrorMessage = "El máximo permitido para el {0} es el {1}")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        [MaxLength(40, ErrorMessage = "El máximo permitido para el {0} es el {1}")]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [Range(1, 99999999, ErrorMessage = "El valor debe estar entre {1} y {2}")]
        public int Dni { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        public string? Correo { get; set; }

    }
}
