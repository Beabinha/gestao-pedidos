// PedidoController.js
angular.module('app').controller('PedidoController', ['$scope', 'PedidoService', function($scope, PedidoService) {
    // Lista de pedidos
    $scope.pedidos = [];
    $scope.novoPedido = {}; // Inicializa o objeto para novo pedido

    // Função para carregar os pedidos
    $scope.carregarPedidos = function() {
        PedidoService.getPedidos().then(function(response) {
            $scope.pedidos = response.data;
        }, function(error) {
            console.error('Erro ao carregar pedidos:', error);
            $scope.erro = 'Erro ao carregar pedidos. Tente novamente mais tarde.';
        });
    };

    // Função para criar um novo pedido
    $scope.criarPedido = function(novoPedido) {
        // Validação simples do objeto
        if (!novoPedido || !novoPedido.id_cliente || !novoPedido.id_produto || !novoPedido.quantidade || !novoPedido.valor || !novoPedido.data_vencimento) {
            $scope.erro = 'Todos os campos são obrigatórios!';
            return;
        }

        PedidoService.criarPedido(novoPedido).then(function(response) {
            // Adiciona o pedido criado à lista de pedidos
            $scope.pedidos.push(response.data);
            $scope.novoPedido = {}; // Limpa o formulário
            $scope.sucesso = 'Pedido criado com sucesso!';
        }, function(error) {
            console.error('Erro ao criar pedido:', error);
            $scope.erro = 'Erro ao criar pedido. Tente novamente mais tarde.';
        });
    };

    // Carregar os pedidos ao iniciar o controlador
    $scope.carregarPedidos();
}]);
