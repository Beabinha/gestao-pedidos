using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;

namespace PedidoApi.Models
{
    public class Pedido
    {
        [Key]  // Anotação para chave primária
        public int IdPedido { get; set; }

        public int IdCliente { get; set; }
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; } = string.Empty; // Inicializando com valor padrão

        public int Quantidade { get; set; } = 0; // Inicializando com valor padrão
        public decimal Valor { get; set; } = 0.0m; // Inicializando com valor padrão
        public decimal Desconto { get; set; } = 0.0m; // Inicializando com valor padrão
        public DateTime DataVencimento { get; set; } = DateTime.MinValue; // Inicializando com valor padrão
        public DateTime? DataAtual { get; set; }

        // Propriedades de navegação
        public required Cliente Cliente { get; set; }
        public required Produto Produto { get; set; }
    }
}