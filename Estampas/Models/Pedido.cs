using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Estampas.Models
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public ICollection<ItemCarrito>? Items { get; set; }
        public string? Email { get; set; }
        
        public DateTime? Fecha { get; set; }
        [Display(Name = "Comentario")]
        public string? Opinion {  get; set; }

    }
}
