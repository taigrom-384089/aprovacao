
//Add Employee Controller
angular.module('Module.NotaCompra', ['ngRoute'])
.controller('NotaCompraCtrl', function ($scope, $http, $rotasService, $erroServidor) {

    $scope.NotasCompra = {};
    $scope.DataEmissao = i18n.textogeral.DataEmissao;
    $scope.ValorMercadoria = i18n.textogeral.ValorMercadoria;
    $scope.ValorDesconto = i18n.textogeral.ValorDesconto;
    $scope.ValorFrete = i18n.textogeral.ValorFrete;
    $scope.ValorTotal = i18n.textogeral.ValorTotal;
    $scope.Status = i18n.textogeral.Status;
    $scope.NenhumRegistro = i18n.textogeral.NenhumRegistro;
    $scope.NotasCompraTitle = i18n.textogeral.NotasCompra;
    $scope.Visto = i18n.textogeral.Visto;
    $scope.Aprovacao = i18n.textogeral.Aprovacao;

    $rotasService.notacompra.listar.get()
    .then(function (retorno) {

        $scope.NotasCompra = retorno.data;

    }, function (retorno) {
        var serverError = new $erroServidor(retorno.data, $scope);
        serverError.exibirMensagensDeErro();
    });

    $scope.notaCompraViewModel =
     {
         DataEmissao: '',
         ValorMercadoria: '',
         ValorDesconto: '',
         ValorFrete: '',
         ValorTotal: '',
         Status: '',
         DataInicial: '',
         DataFinal: ''
     };


    $scope.filtrar = function () {
        
    };

    $scope.visto = function (idNotaCompra) {

        var optionsDefault = {
            title: i18n.textogeral.Atencao,
            message: i18n.textogeral.DesejaEfetuarVisto,
            size: 'small',
            buttons: {
                success: {
                    label: i18n.textogeral.Sim,
                    className: "btn btn-primary",
                    callback: function () {

                        $rotasService.notacompra.visto.get({ idNotaCompra: idNotaCompra })
                        .then(function (retorno) {
                            if (retorno.status == 200){
                                window.location = '/';
                            }

                        }, function (retorno) {
                            var serverError = new $erroServidor(retorno.data, $scope);
                            serverError.exibirMensagensDeErro();
                        });
                    }
                },
                danger: {
                    label: i18n.textogeral.Nao,
                    className: "btn btn-danger",
                    callback: function () {

                    }
                }
            }
        };

        $components.dialog(optionsDefault);
    };

    $scope.aprovacao = function () {
        alert('aprovacao')
    };
});


