SELECT name FROM sys.databases;
-- Visualizar Todas as Tabelas:
-- SELECT * FROM Cliente
-- SELECT * FROM Produto
-- SELECT * FROM Pedido

-- Ordenar a tabela:
-- SELECT * FROM dbo.Cliente 
-- WHERE nome_cliente= 'Ana Costa' OR data_cadastro = '2025-01-22'
-- ORDER BY email, data_cadastro

-- Excluir a Tabela, se já existir
-- DROP TABLE IF EXISTS ----- ;


-- Funcao Data de Vencimento e Desconto
SELECT 
    id_pedido,
    id_cliente,
    nome_produto,
    quantidade,
    valor,
    CASE 
        WHEN data_vencimento < CAST(GETDATE() AS DATE) THEN 0  -- Sem desconto para pedidos vencidos
        ELSE valor * 0.10  -- Aplica 10% de desconto para pedidos válidos
    END AS desconto,  -- Aplica o desconto apenas para pedidos não vencidos
    data_vencimento,
    data_atual,
    CASE 
        WHEN data_vencimento < CAST(GETDATE() AS DATE) THEN 'Vencido'
        WHEN DATEDIFF(DAY, CAST(GETDATE() AS DATE), data_vencimento) <= 3 THEN 'Quase Vencendo'
        WHEN data_vencimento > DATEADD(DAY, 3, CAST(GETDATE() AS DATE)) THEN 'Válido'
    END AS status_vencimento
FROM 
    Pedido;
