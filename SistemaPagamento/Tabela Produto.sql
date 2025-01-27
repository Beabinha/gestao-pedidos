-- Excluir a Tabela Produto, se j� existir
DROP TABLE IF EXISTS Produto;

-- Cria��o da Tabela Produto
CREATE TABLE Produto (
    id_produto INT IDENTITY(1,1) PRIMARY KEY,      -- Identificador �nico do produto
    nome_produto NVARCHAR(255) NOT NULL,           -- Nome do produto
    preco DECIMAL(10,2) NOT NULL,                  -- Pre�o unit�rio do produto
    estoque INT NOT NULL                           -- Quantidade em estoque
);

-- Inser��o de dados na Tabela Produto
INSERT INTO Produto VALUES ('Macarr�o Parafuso', 5.00, 100);
INSERT INTO Produto VALUES ('Leite Integral', 4.25, 200);
INSERT INTO Produto VALUES ('Feij�o Preto', 6.25, 150);
INSERT INTO Produto VALUES ('Arroz Branco', 5.00, 120);
INSERT INTO Produto VALUES ('A��car Cristal', 3.50, 80);
INSERT INTO Produto VALUES ('�leo de Soja', 4.00, 60);
INSERT INTO Produto VALUES ('Caf� Torrado', 5.30, 50);
INSERT INTO Produto VALUES ('Farinha de Trigo', 2.00, 75);
INSERT INTO Produto VALUES ('Papel Higi�nico', 2.50, 100);
INSERT INTO Produto VALUES ('Sab�o em P�', 3.00, 90);

SELECT * FROM Produto