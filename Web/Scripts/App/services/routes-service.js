App.factory('$rotasService', function ($http) {
    var toQuerystring = function (object) {

        var data = [];

        function walk(object, path) {

            for (var p in object) {

                if (typeof object[p] === "object") {

                    walk(object[p], /^\d+$/.test(p) ? path + "[" + p + "]" : (path ? path + "." + p : p));

                } else {

                    var key = /^\d+$/.test(p)
                            ? path + "[" + p + "]"
                            : (path ? path + "." + p : p);

                    data.push(
                        key
                      + "="
                      + encodeURIComponent(object[p])
                    );
                }
            }
        };

        walk(object, "");

        return data.join("&");
    }

    var post = function (url, data, options) {
       
        var defaultOptions = {
            cache: false,
            method: "POST",
            url: $rootUrl + url,
            data: data
        };

        $.extend(defaultOptions, options);

        return $http(defaultOptions);
    };

    var get = function (url, data, options) {

        var defaultOptions = {
            cache: false,
            method: "GET",
            url: data == undefined ? $rootUrl + url : $rootUrl + url + "?" + toQuerystring(data)
        };

        $.extend(defaultOptions, options);

        return $http(defaultOptions);
    }

    return {
        notacompra: {
            index: {
                get: function (data) { return get('notacompra/index', data); }
            },
            listar: {
                get: function (data) { return get('notacompra/listar', data); }
            },
            visto: {
                get: function (data) { return get('notacompra/visto', data); }
            },
            aprovacao: {
                get: function (data) { return get('notacompra/aprovacao', data); }
            }
        },
        login: {
            autenticar: {
                post: function (data) { return get('login/autenticar', data); }
            },
            sair: {
                get: function (data) { return get('login/sair', data); }
            }
        }
    };
});
