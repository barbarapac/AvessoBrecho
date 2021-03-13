using EcommerceAvessoBrecho.Models;
using Microsoft.EntityFrameworkCore;
namespace EcommerceAvessoBrecho.DataBase.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categoria>().HasKey(t => t.Id);

            modelBuilder.Entity<Produto>().HasKey(t => t.Id);

            modelBuilder.Entity<Cliente>().HasKey(t => t.Id);

            modelBuilder.Entity<Pedido>().HasKey(t => t.Id);
            modelBuilder.Entity<Pedido>().HasMany(t => t.ItensPedido)
                .WithOne(t => t.Pedido);
            modelBuilder.Entity<Pedido>().HasOne(t => t.Cliente)
                .WithOne(t => t.Pedido)
                .IsRequired();

            modelBuilder.Entity<ItemPedido>().HasKey(t => t.Id);
            modelBuilder.Entity<ItemPedido>().HasOne(t => t.Pedido);
            modelBuilder.Entity<ItemPedido>().HasOne(t => t.Produto);
        }
    }
}
