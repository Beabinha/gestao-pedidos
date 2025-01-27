using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using PedidoApi.Data; // Adicione este 'using' para o PedidoContext
using System;
using System.Collections.Generic;

var builder = WebApplication.CreateBuilder(args);

// Configura o servidor para escutar somente HTTP
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5000); // Garante que o Kestrel escute na porta HTTP 5000
});

// Adiciona os serviços ao contêiner
builder.Services.AddControllers(); // Registra os controllers

// Obtém a string de conexão e verifica se ela não é nula
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("A string de conexão 'DefaultConnection' não foi encontrada.");
}

// Configura o DbContext para usar SQL Server com a string de conexão
builder.Services.AddDbContext<PedidoContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 

var app = builder.Build();

// Configuração para o uso do Swagger (apenas em ambiente de desenvolvimento)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configuração para exceções
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Habilita o roteamento
app.UseRouting();

// Mapeia os controllers
app.MapControllers(); 

// Caso queira definir uma rota personalizada:
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); // Rota padrão

// Aqui vamos criar um endpoint que manipula a conexão com o banco de dados diretamente
app.MapGet("/pedidos", async () =>
{
    // Recupera a string de conexão
    string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    
    if (string.IsNullOrEmpty(connectionString))
    {
        return Results.BadRequest("A string de conexão 'DefaultConnection' não foi encontrada.");
    }

    try
    {
        // Cria a conexão com o banco de dados
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            await connection.OpenAsync();

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

            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                var pedidos = new List<object>();

                while (await reader.ReadAsync())
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

                return Results.Ok(pedidos);
            }
        }
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});

// Método para calcular o status do vencimento
string GetStatusVencimento(DateTime dataVencimento)
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
decimal AplicarDesconto(decimal valor, DateTime dataVencimento)
{
    if (dataVencimento >= DateTime.Now.Date)
    {
        return valor - (valor * 0.10m); // Aplica 10% de desconto
    }
    return valor; // Se estiver vencido, não aplica desconto
}
app.MapGet("/test", () => "Testando o Program.cs!");
app.Run();
