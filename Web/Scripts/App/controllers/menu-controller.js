
//Add Employee Controller
angular.module('Module.Menu', ['ngRoute'])
.controller('MenuCtrl', function ($scope, $http, $rotasService, $erroServidor) {

    $scope.sair = function () {

        $rotasService.login.sair.get()
        .then(function (retorno) {

            if (retorno.status == 200) {
                window.location = '/';
            }

        }, function (retorno) {
            var serverError = new $erroServidor(retorno.data, $scope);
            serverError.exibirMensagensDeErro();
        });
    };
});


