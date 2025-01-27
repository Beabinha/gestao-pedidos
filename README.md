# gestao-pedidos
Este é um sistema de gestão de pedidos desenvolvido em C# com uma API ASP.NET Core e um frontend em AngularJS com o objetivo de manipular dados SQLSERVER.

## Estrutura do Projeto

O projeto está dividido em três partes principais:

1. **ApiPedido**: Contém a API desenvolvida em ASP.NET Core. A api nao foi completada
2. **PedidoAngular**: Contém o frontend desenvolvido em AngularJS. Nao foi possivel anipular o pedido de mudança de cor
3. **SistemaPagamento**: Contém scripts SQL para manipulação do banco de dados. eu baixei o SQLSERVER (mssql) para auxiliar com a conexão da api e para manipular os dados do banco de dados usei o SQLSERVER Management Studio (SSMS) que é uma ferramenta para manipulação do banco de dados junto com Sql server configuration manager.

## Funcionalidades

### API (ApiPedido)

- **Endpoints**:
  - `GET /api/pedidos`: Retorna todos os pedidos.
  - `GET /pedidos`: Endpoint customizado para retornar pedidos com status de vencimento e aplicar descontos.

- **Modelos**:
  - [`Pedido`](ApiPedido/Models/Pedido.cs): Representa um pedido com propriedades como `IdPedido`, `IdCliente`, `IdProduto`, `NomeProduto`, `Quantidade`, `Valor`, `Desconto`, `DataVencimento`, `DataAtual`, `Cliente`, e `Produto`.
  - [`Cliente`](ApiPedido/Models/Cliente.cs): Representa um cliente com propriedades como `IdCliente`, `NomeCliente`, `Email`, `Telefone`, `DataCadastro`, e uma lista de `Pedidos`.
  - [`Produto`](ApiPedido/Models/Produto.cs): Representa um produto com propriedades como `IdProduto`, `NomeProduto`, `Preco`, `Estoque`, e uma lista de `Pedidos`.

- **Banco de Dados**:
  - Utiliza SQL Server para armazenar dados.
  - Configurado com Entity Framework Core para mapeamento objeto-relacional.

### Frontend (PedidoAngular)

- **Serviços**:
  - [`PedidosService`](PedidoAngular/pedidos.service.ts): Serviço Angular para comunicação com a API.

- **Controladores**:
  - [`PedidoController`](PedidoAngular/app/controllers/PedidosController.js): Controlador AngularJS para gerenciar pedidos no frontend.

## Configuração

### API

1. **Instalar Dependências**:
   ```sh
   dotnet restore
   dotnet build
   dotnet run
   dotnet watch run