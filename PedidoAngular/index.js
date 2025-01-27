// index.js
angular.module('app', [])
    .controller('PedidoController', function($scope, PedidoService) {
        // Lista de pedidos
        $scope.pedidos = [];

        // Função para carregar os pedidos
        $scope.carregarPedidos = function() {
            PedidoService.getPedidos().then(function(response) {
                $scope.pedidos = response.data;
            }, function(error) {
                console.error('Erro ao carregar pedidos:', error);
            });
        };

        // Função para criar um novo pedido
        $scope.criarPedido = function(novoPedido) {
            PedidoService.criarPedido(novoPedido).then(function(response) {
                // Adiciona o pedido criado à lista de pedidos
                $scope.pedidos.push(response.data);
                $scope.novoPedido = {}; // Limpa o formulário
            }, function(error) {
                console.error('Erro ao criar pedido:', error);
            });
        };

        // Carregar os pedidos ao iniciar o controlador
        $scope.carregarPedidos();
    })
    .service('PedidoService', function($http) {
        // Função para buscar todos os pedidos
        this.getPedidos = function() {
            return $http.get('http://localhost:5000/api/pedidos'); // URL da sua API
        };

        // Função para criar um novo pedido
        this.criarPedido = function(novoPedido) {
            return $http.post('http://localhost:5000/api/pedidos', novoPedido); // URL para criar pedido na API
        };
    });
