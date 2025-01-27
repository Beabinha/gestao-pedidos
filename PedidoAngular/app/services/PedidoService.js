// PedidoService.js
angular.module('app').service('PedidoService', ['$http', function($http) {
    var apiUrl = 'http://localhost:5000/api/pedidos';  // Ajuste para a URL correta da sua API

    // Função para buscar pedidos
    this.getPedidos = function() {
        return $http.get(apiUrl);  // Faz uma requisição GET para listar os pedidos
    };

    // Função para criar um novo pedido
    this.criarPedido = function(novoPedido) {
        return $http.post(apiUrl, novoPedido);  // Faz uma requisição POST para criar o pedido
    };
}]);
