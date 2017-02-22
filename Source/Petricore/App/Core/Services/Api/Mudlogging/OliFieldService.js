function oilFieldsService(baseService, appSettings) {

    var getOilFields = function (params, callback, callbackError) {
        var processedUrl = baseService.setParams(params, appSettings.mudLoggingApiUrl, 'oilfields');
        return baseService.getResource(processedUrl, callback, callbackError);
    };

    var getOilFieldsById = function (params, callback, callbackError) {
        var processedUrl = baseService.setParams(params, appSettings.mudLoggingApiUrl, 'oilfields/:id');
        return baseService.getResource(processedUrl, callback, callbackError);
    };

    return {
        getOilFields: getOilFields,
        getOilFieldsById: getOilFieldsById
    };

}

oilFieldsService.$inject = ['baseService', 'appSettings'];

module.exports = oilFieldsService;