angular.module('Module.Login', ['ngRoute'])
.controller('LoginCtrl', function ($scope, $http, $rotasService, $erroServidor) {

    $scope.usuarioViewModel =
    {
        Login: '',
        Senha: ''
    };

    $scope.entrar = function () {
        $rotasService.login.autenticar.post($scope.usuarioViewModel)
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


