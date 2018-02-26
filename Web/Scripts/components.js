window.$components = function () {

    return {

        toast: function (title, msg, type, timeout) {

            var $toastlast;

            toastr.options = {
                "closeButton": true,
                "debug": false,
                "positionClass": "toast-top-right",
                "onclick": null,
                "showDuration": "1000",
                "hideDuration": "1000",
                "timeOut": timeout == undefined ? "5000" : timeout,
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }

            switch (type) {
                case TipoMensagem.Erro:
                    title = i18n.textogeral.Erro;
                    type = 'error';
                    break;
                case TipoMensagem.Sucesso:
                    title = i18n.textogeral.Sucesso;
                    type = 'success';
                    break;
                case TipoMensagem.Alerta:
                    title = i18n.textogeral.Alerta;
                    type = 'warning';
                    break;
                case TipoMensagem.Informacao:
                    title = i18n.textogeral.Informacao;
                    type = 'info';
                    break;
            }

            var $toast = toastr[type](msg, title);
            $toastlast = $toast;
        },
        dialog: function (options) {

            var optionsDefault = {
                size: 'large',
                message: "I am a custom dialog",
                title: "Custom title",
                buttons: {
                    success: {
                        label: "Success!",
                        className: "green",
                        callback: function () {
                            alert("great success");
                        }
                    },
                    danger: {
                        label: "Danger!",
                        className: "red",
                        callback: function () {
                            alert("uh oh, look out!");
                        }
                    },
                    main: {
                        label: "Click ME!",
                        className: "blue",
                        callback: function () {
                            alert("Primary button");
                        }
                    }
                }
            };

            $.extend(optionsDefault, options);

            bootbox.dialog(optionsDefault);
        }
    };
}();

window.TipoMensagem = {
    Erro: 0,
    Sucesso: 1,
    Alerta: 2,
    Informacao: 3
}