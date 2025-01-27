using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient; // Use apenas esta linha
using System;
using System.Collections.Generic;

namespace ApiPedido.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private string connectionString = "Server=DESKTOP-LU6JGTC\\SQLEXPRESS;Database=GestaoProdutos;Trusted_Connection=True;";

        [HttpGet]
        public IActionResult GetPedidos()
        {
            string query = @"
                SELECT 
                    id_pedido,
                    id_cliente,
                    nome_produto,
                    quantidade,
                    valor,
                    desconto,
                    data_vencimento,
                    data_atual
                FROM 
                    Pedido
                WHERE 
                    data_vencimento >= CAST(GETDATE() AS DATE)
                ORDER BY 
                    data_vencimento;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                var pedidos = new List<object>();

                while (reader.Read())
                {
                    var pedido = new
                    {
                        id_pedido = reader["id_pedido"],
                        nome_produto = reader["nome_produto"],
                        valor = reader["valor"],
                        data_vencimento = reader["data_vencimento"],
                        status_vencimento = GetStatusVencimento(Convert.ToDateTime(reader["data_vencimento"])),
                        valor_com_desconto = AplicarDesconto(Convert.ToDecimal(reader["valor"]), Convert.ToDateTime(reader["data_vencimento"]))
                    };

                    pedidos.Add(pedido);
                }

                return Ok(pedidos);
            }
        }

        // Método para calcular o status do vencimento
        private string GetStatusVencimento(DateTime dataVencimento)
        {
            if (dataVencimento < DateTime.Now.Date)
            {
                return "Vencido";
            }
            else if ((dataVencimento - DateTime.Now.Date).Days <= 3)
            {
                return "Quase Vencendo";
            }
            else
            {
                return "Válido";
            }
        }

        // Método para aplicar desconto (10% se não estiver vencido)
        private decimal AplicarDesconto(decimal valor, DateTime dataVencimento)
        {
            if (dataVencimento >= DateTime.Now.Date)
            {
                return valor - (valor * 0.10m); // Aplica 10% de desconto
            }
            return valor; // Se estiver vencido, não aplica desconto
        }
    }
}