App.factory("$erroServidor", function ($rotasService, $sce) {
    return function (serverData, scope) {
        this.data = {};

        if (serverData && serverData.data) {
            this.data = serverData.data;
        } else {
            this.data = serverData;
        }

        this.exibirMensagensDeErro = function () {
            $components.toast('Atenção!',this.data.Mensagem, 0);
        }
    };
});