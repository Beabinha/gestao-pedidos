-- Excluir a Tabela Pedido, se j� existir
DROP TABLE IF EXISTS Pedido;

-- Cria��o da Tabela Pedido
CREATE TABLE Pedido (
    id_pedido INT IDENTITY(1,1) PRIMARY KEY,       -- Identificador �nico do pedido
	id_cliente INT,                                 -- Refer�ncia ao cliente que fez o pedido
    id_produto INT NOT NULL,                       -- Refer�ncia ao produto
    nome_produto NVARCHAR(100) NOT NULL,           -- Nome do produto no pedido
    quantidade INT NOT NULL,                       -- Quantidade do produto no pedido
    valor DECIMAL(10,2) NOT NULL,                  -- Valor total do pedido
	desconto DECIMAL(10,2) DEFAULT 0,               -- Desconto aplicado no pedido
    data_vencimento DATE NOT NULL,                 -- Data de vencimento do pagamento
	data_atual DATETIME2,                           -- Data da cria��o ou atualiza��o do pedido
    FOREIGN KEY (id_produto) REFERENCES Produto(id_produto), -- Chave estrangeira
	FOREIGN KEY (id_cliente) REFERENCES Cliente(id_cliente)  -- Chave estrangeira para garantir integridade referencial
);

-- Inser��o de dados na Tabela Pedido
INSERT INTO Pedido VALUES (1, 1, 'Macarr�o Parafuso', 3, 15.00, 0, '2025-01-24', GETDATE());
INSERT INTO Pedido VALUES (2, 2, 'Leite Integral', 2, 8.50, 0, '2025-01-30', GETDATE());
INSERT INTO Pedido VALUES (3, 3, 'Arroz Branco', 5, 25.00, 0, '2025-02-05', GETDATE());
INSERT INTO Pedido VALUES (4, 4, 'Feij�o Preto', 3, 18.75, 0, '2025-02-07', GETDATE());
INSERT INTO Pedido VALUES (5, 5, 'A��car Cristal', 10, 35.00, 0, '2025-02-10', GETDATE());
INSERT INTO Pedido VALUES (6, 6, 'Macarr�o Espaguete', 4, 12.00, 0, '2025-02-12', GETDATE());
INSERT INTO Pedido VALUES (7, 7, '�leo de Soja', 6, 24.00, 0, '2025-02-15', GETDATE());
INSERT INTO Pedido VALUES (8, 8, 'Caf� Torrado', 3, 15.90, 0, '2025-02-18', GETDATE());
INSERT INTO Pedido VALUES (9, 9, 'Farinha de Trigo', 8, 16.00, 0, '2025-01-01', GETDATE());
INSERT INTO Pedido VALUES (10, 10, 'Papel Higi�nico', 12, 30.00, 0, '2025-02-22', GETDATE());

--ALTER TABLE Pedido
--ADD valor_com_desconto DECIMAL(10,2) NULL;

SELECT * FROM Pedido