using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PedidoApi.Models;
using PedidoApi.Data;

namespace PedidoApi.Data
{
    public class PedidoContext : DbContext
    {
        // Não há necessidade de inicializar Pedidos aqui
        public PedidoContext(DbContextOptions<PedidoContext> options) : base(options) { }

        // Tornando a propriedade Pedidos anulável
        public DbSet<Pedido>? Pedidos { get; set; }

        // Configurações Adicionais
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurando relacionamento entre Pedido e Cliente
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Cliente) // Um Pedido tem um Cliente
                .WithMany(c => c.Pedidos) // Um Cliente tem muitos Pedidos
                .HasForeignKey(p => p.IdCliente) // A chave estrangeira é IdCliente
                .OnDelete(DeleteBehavior.Restrict); // Impede que a exclusão de Cliente exclua automaticamente os Pedidos

            // Configurando relacionamento entre Pedido e Produto
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Produto) // Um Pedido tem um Produto
                .WithMany() // Produto não tem um relacionamento explícito com Pedidos, então deixamos vazio
                .HasForeignKey(p => p.IdProduto) // A chave estrangeira é IdProduto
                .OnDelete(DeleteBehavior.Restrict); // Impede que a exclusão de Produto exclua automaticamente os Pedidos

            // Se você quiser que Produto tenha um relacionamento reverso explícito com Pedido
            modelBuilder.Entity<Produto>()
                .HasMany(p => p.Pedidos)  // Um Produto pode ter muitos Pedidos
                .WithOne(p => p.Produto)  // Cada Pedido tem um Produto
                .HasForeignKey(p => p.IdProduto)
                .OnDelete(DeleteBehavior.Restrict); // Impede que a exclusão de Produto exclua automaticamente os Pedidos
        }
    }
}
