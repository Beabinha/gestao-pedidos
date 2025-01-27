-- Excluir a Tabela Desconto, se já existir
DROP TABLE IF EXISTS Desconto;

-- Criação da Tabela Desconto
CREATE TABLE Desconto (
    id_desconto INT IDENTITY(1,1) PRIMARY KEY,
    id_pedido INT,
    tipo_desconto NVARCHAR(50),
    valor DECIMAL(10,2),
    data_inicio DATE,
    data_fim DATE,
    FOREIGN KEY (id_pedido) REFERENCES Pedido(id_pedido)
);

--Inserção de Dados na Tabela Desconto