# Gestao-Pedidos

Este é um sistema de gestão de pedidos desenvolvido em C# com o objetivo de manipular dados em um banco de dados SQL Server. Inicialmente, manipulei dados dentro do banco de dados SQL Server com o SQL Server Management Studio, criando 3 tabelas: **Clientes**, **Produtos** e **Pedidos**, que são essenciais para o desenvolvimento da API. Realizei a conexão do banco de dados, configurando o Firewall, e o SQL Server Configuration Manager, ativando o Browser e deixando o SQL Express aberto. Depois de fazer manipulções fui para Visual Studio Code para desenvolver uma API em C# com o framework ASP.NET Core. Nesse processo houve conflictos com a conexão para visualizar localmente. O projeto ainda está em desenvolvimento.

## Estrutura do Projeto

O projeto está dividido em três partes principais:

1. **SistemaPagamento**: Contém scripts SQL para manipulação do banco de dados. Utilizei o **SQL Server (MSSQL)** para auxiliar com a conexão da API, e o **SQL Server Management Studio (SSMS)** para manipulação do banco de dados.
2. **ApiPedido**: Contém a API desenvolvida em ASP.NET Core. A API ainda não foi completada, pois há conflitos nas conexões.
3. **PedidoAngular**: Contém o frontend desenvolvido em AngularJS. Não foi possível implementar a funcionalidade de alteração de cor dos pedidos.

## Tecnologias Utilizadas

- **C#**: Linguagem utilizada para o backend da API.
- **ASP.NET Core**: Framework para desenvolvimento da API.
- **SQL Server**: Sistema de gerenciamento de banco de dados utilizado.
- **Entity Framework Core**: Biblioteca ORM para integração com o banco de dados SQL Server.
- **AngularJS**: Framework JavaScript utilizado para o desenvolvimento do frontend.
- **SQL Server Management Studio (SSMS)**: Ferramenta utilizada para administração e manipulação do banco de dados SQL Server.

## Funcionalidades

### Banco de Dados (SistemaPagamento)

- **SQL Server**: Utiliza o **SQL Server** para armazenar dados do sistema.
- **Scripts SQL**: Contém scripts SQL para criar as tabelas necessárias no banco de dados.
- **Entity Framework Core**: Configurado para comunicação entre o banco de dados e a API via **Entity Framework Core**, realizando o mapeamento objeto-relacional.

### API (ApiPedido)

- **Endpoints**:
  - `GET /api/pedidos`: Retorna todos os pedidos.
  - `GET /pedidos`: Endpoint customizado para retornar pedidos com status de vencimento e aplicar descontos.

- **Modelos**:
  - [`Pedido`](ApiPedido/Models/Pedido.cs): Representa um pedido com propriedades como `IdPedido`, `IdCliente`, `IdProduto`, `NomeProduto`, `Quantidade`, `Valor`, `Desconto`, `DataVencimento`, `DataAtual`, `Cliente`, e `Produto`.
  - [`Cliente`](ApiPedido/Models/Cliente.cs): Representa um cliente com propriedades como `IdCliente`, `NomeCliente`, `Email`, `Telefone`, `DataCadastro`, e uma lista de `Pedidos`.
  - [`Produto`](ApiPedido/Models/Produto.cs): Representa um produto com propriedades como `IdProduto`, `NomeProduto`, `Preco`, `Estoque`, e uma lista de `Pedidos`.

- **Banco de Dados**:
  - Utiliza o **SQL Server** para armazenar dados.
  - Configurado com **Entity Framework Core** para mapeamento objeto-relacional.

### Frontend (PedidoAngular)

- **Serviços**:
  - [`PedidosService`](PedidoAngular/pedidos.service.ts): Serviço Angular para comunicação com a API.

- **Controladores**:
  - [`PedidoController`](PedidoAngular/app/controllers/PedidosController.js): Controlador AngularJS para gerenciar pedidos no frontend.

## Configuração

### Banco de Dados (SistemaPagamento)

1. **Instalar SQL Server**:
   Certifique-se de ter o **SQL Server** instalado e configurado corretamente.
   
2. **Criar Banco de Dados**:
   Utilize o **SQL Server Management Studio (SSMS)** para rodar os scripts SQL incluídos no repositório e criar as tabelas e o banco de dados.

3. **Configuração de Conexão**:
   Após configurar o banco de dados, altere a string de conexão no arquivo `appsettings.json` da API para refletir a configuração do seu servidor SQL.

### API (ApiPedido)

1. **Instalar Dependências**:
   Após clonar o repositório, instale as dependências da API com os seguintes comandos:

   ```sh
   dotnet restore
   dotnet build
   dotnet run
   dotnet watch run
