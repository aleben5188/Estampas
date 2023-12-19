using Estampas.Models;
using Microsoft.EntityFrameworkCore;

namespace Estampas.Contexto
{
    public class EstampasDatabaseContext : DbContext
    {
        public EstampasDatabaseContext(DbContextOptions<EstampasDatabaseContext> options) : base(options)
        {
        }
        public DbSet<ItemCarrito> ItemsCarrito { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }


    }
}
