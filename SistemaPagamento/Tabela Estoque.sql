-- Excluir a Tabela Desconto, se j� existir
DROP TABLE IF EXISTS Desconto;

-- Cria��o da Tabela Desconto
CREATE TABLE Desconto (
    id_desconto INT IDENTITY(1,1) PRIMARY KEY,
    id_pedido INT,
    tipo_desconto NVARCHAR(50),
    valor DECIMAL(10,2),
    data_inicio DATE,
    data_fim DATE,
    FOREIGN KEY (id_pedido) REFERENCES Pedido(id_pedido)
);

--Inser��o de Dados na Tabela Desconto