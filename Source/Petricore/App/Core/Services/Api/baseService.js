function baseService($http) {
    // String processor
    var setQueryString = function (parameters) {

        var queryString = '';

        if (parameters != null) {

            for (var i = 0; i < parameters.length; i++) {
                if (parameters[i].Value != null && parameters[i].Value != undefined && parameters[i].Value != 'null' && parameters[i].Value.length != 0) {
                    if (Array.isArray(parameters[i].Value)) {
                        for (var index = 0; index < parameters[i].Value.length; index++) {
                            queryString = queryString + '&' +
                                parameters[i].Name +
                                '[' + index + ']' + '=' +
                                encodeURIComponent(parameters[i].Value[index]);
                        }
                    } else {
                        queryString = queryString + '&' + parameters[i].Name + '=' + encodeURIComponent(parameters[i].Value);
                    }
                }
            }

            if (queryString != '') {
                queryString = '*?*' + queryString;
                queryString = queryString.replace('*?*&', '?');
            }
        }
        return queryString;
    };

    var setUrlParameter = function (parameters, url) {

        if (parameters != null) {

            for (var i = 0; i < parameters.length; i++) {
                if (parameters[i].Value != null) {
                    if (url.search(':' + parameters[i].Name) != -1) {
                        url = url.replace(':' + parameters[i].Name, parameters[i].Value);
                        parameters[i].Value = null;
                    }
                }
            }
        }

        return url;
    };

    var setParams = function (parameters, baseUrl, relativeUrl) {
        var url = baseUrl;
        url = url + setUrlParameter(parameters, relativeUrl);
        url = url + setQueryString(parameters);
        return url;
    };

    //End of String processor

    //API Calls Methods

    var getResource = function (url, callbackGet, callbackGetError) {

        return $http.get(url).then(function successCallback(response) {
            callbackGet(response.data);
        }, function errorCallback(response) {
            callbackGetError(response.data);
        });

    };
    
    var saveResource = function (urlResource, token,dataReq, callback, callbackError) {
        var req = {
            method: 'POST',
            url: urlResource,
            headers: {
                'Authorization': 'Bearer ' + token,
                'Accept': 'application/json',
                'Content-Type': 'application/json; charset=utf-8'
            },
            data: dataReq
        };

        return $http(req).then(function (response) {
            callback(response.data);
        }).catch(function (err) {
            callbackError(err);
        });
    };
    
    var updateResource = function (urlResource, token,dataReq, callback, callbackError) {
        var req = {
            method: 'PUT',
            url: urlResource,
            headers: {
                'Authorization': 'Bearer ' + token,
                'Accept': 'application/json',
                'Content-Type': 'application/json; charset=utf-8'
            },
            data: dataReq
        };

        return $http(req).then(function (response) {
            callback(response.data);
        }).catch(function (err) {
            callbackError(err);
        });
    };

    //End of API Calls Methods

    return {
        setParams: setParams,
        getResource: getResource,
        saveResource: saveResource,
        updateResource:updateResource
    };
}

baseService.$inject = ['$http'];

module.exports = baseService;