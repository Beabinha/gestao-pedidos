-- Excluir a Tabela Cliente, se j� existir
DROP TABLE IF EXISTS Cliente;

-- Cria��o da Tabela Cliente com DataCadastro
CREATE TABLE Cliente (
    id_cliente INT IDENTITY(1,1) PRIMARY KEY,  -- Gera valores autom�ticos
    nome_cliente NVARCHAR(255) NOT NULL,       -- Nome � obrigat�rio
    email NVARCHAR(100) NULL,                  -- Email � opcional
    telefone NVARCHAR(20) NULL,                -- Telefone � opcional
    data_cadastro DATETIME2 NULL                -- Data de cadastro (inser��o manual)
	-- DataCadastro DATETIME2 DEFAULT GETDATE()   -- Data de cadastro com valor padr�o de GETDATE()
);
GO

--Inser��o de Dados na Tabela Cliente
INSERT INTO Cliente VALUES ('Ken S�nchez', 'email@email.com', '(11) 99999-9999', '2025-01-22');
INSERT INTO Cliente VALUES ('Jo�o Oliveira', 'joao.oliveira@email.com', '(21) 88888-8888', '2025-01-24');
INSERT INTO Cliente VALUES ('Maria Souza', 'maria.souza@email.com', '(31) 98888-8888', '2025-01-23');
INSERT INTO Cliente VALUES ('Lucas Almeida', 'lucas.almeida@email.com', '(41) 97777-7777', '2025-01-21');
INSERT INTO Cliente VALUES ('Ana Costa', 'ana.costa@email.com', '(61) 96666-6666', '2025-01-22');
INSERT INTO Cliente VALUES ('Carlos Martins', 'carlos.martins@email.com', '(51) 95555-5555', '2025-01-21');
INSERT INTO Cliente VALUES ('Patr�cia Lima', 'patricia.lima@email.com', '(71) 94444-4444', '2025-01-21');
INSERT INTO Cliente VALUES ('Fernanda Pinto', 'fernanda.pinto@email.com', '(81) 93333-3333', '2025-01-20');
INSERT INTO Cliente VALUES ('Ricardo Santos', 'ricardo.santos@email.com', '(91) 92222-2222', '2025-01-20');
INSERT INTO Cliente VALUES ('Rafael Pereira', 'rafael.pereira@email.com', '(71) 91111-1111', '2025-01-19');