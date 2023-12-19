namespace Estampas.Models
{
    public class Pedido
    {

        public int PedidoId { get; set; }
        public ICollection<ItemCarrito>? Items { get; set; }
        public string Email { get; set; }

    }
}
