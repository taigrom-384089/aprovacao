var App = angular.module('App', ['Module.Login',
                       'Module.NotaCompra'
])

.config(['$routeProvider', '$locationProvider', '$httpProvider', function ($routeProvider, $locationProvider, $httpProvider) {
    $httpProvider.defaults.headers.common["X-Requested-With"] = 'XMLHttpRequest';
    $routeProvider.when('/Login', {
        templateUrl: '/Login/Index',
        controller: 'LoginCtrl'
    })
    .when('/Login/Sair', {
        templateUrl: '/Login/Index',
        controller: 'LoginCtrl'
    })
    .when('/', {
        templateUrl: 'NotaCompra/Editar',
        controller: 'NotaCompraCtrl'
    })
    .otherwise({
        redirectTo: '/'
    });
    // Specify HTML5 mode (using the History APIs) or HashBang syntax.
    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    }).hashPrefix('');

}]);



