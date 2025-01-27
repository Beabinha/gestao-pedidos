using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;

namespace PedidoApi.Models
{
    public class Cliente
    {
        [Key] // Definindo a chave primária
        public int IdCliente { get; set; }

        public required string NomeCliente { get; set; } // Nome do cliente (não pode ser nulo)
        public string? Email { get; set; } // Email do cliente (opcional)
        public string? Telefone { get; set; } // Telefone do cliente (opcional)
        public DateTime DataCadastro { get; set; } = DateTime.Now; // Data de cadastro (automaticamente definida como data atual)

        // Relacionamento com os pedidos (1 Cliente pode ter muitos Pedidos)
        public List<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
