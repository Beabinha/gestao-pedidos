using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;

namespace PedidoApi.Models
{
    public class Produto
    {
        [Key] // Definindo a chave primária
        public int IdProduto { get; set; }

        public required string NomeProduto { get; set; } // Nome do produto (não pode ser nulo)
        public decimal Preco { get; set; } // Preço do produto
        public int Estoque { get; set; } // Quantidade em estoque

        // Relacionamento com os pedidos (1 Produto pode ser associado a vários Pedidos)
        public List<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
