-- Excluir a Tabela Produto, se já existir
DROP TABLE IF EXISTS Produto;

-- Criação da Tabela Produto
CREATE TABLE Produto (
    id_produto INT IDENTITY(1,1) PRIMARY KEY,      -- Identificador único do produto
    nome_produto NVARCHAR(255) NOT NULL,           -- Nome do produto
    preco DECIMAL(10,2) NOT NULL,                  -- Preço unitário do produto
    estoque INT NOT NULL                           -- Quantidade em estoque
);

-- Inserção de dados na Tabela Produto
INSERT INTO Produto VALUES ('Macarrão Parafuso', 5.00, 100);
INSERT INTO Produto VALUES ('Leite Integral', 4.25, 200);
INSERT INTO Produto VALUES ('Feijão Preto', 6.25, 150);
INSERT INTO Produto VALUES ('Arroz Branco', 5.00, 120);
INSERT INTO Produto VALUES ('Açúcar Cristal', 3.50, 80);
INSERT INTO Produto VALUES ('Óleo de Soja', 4.00, 60);
INSERT INTO Produto VALUES ('Café Torrado', 5.30, 50);
INSERT INTO Produto VALUES ('Farinha de Trigo', 2.00, 75);
INSERT INTO Produto VALUES ('Papel Higiênico', 2.50, 100);
INSERT INTO Produto VALUES ('Sabão em Pó', 3.00, 90);

SELECT * FROM Produto