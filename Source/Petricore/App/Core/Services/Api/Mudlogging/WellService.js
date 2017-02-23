function wellService(baseService, appSettings) {

    var getClassificationWells = function (params, callback, callbackError) {
        var processedUrl = baseService.setParams(params, appSettings.mudLoggingApiUrl, 'clasificationwells');
        return baseService.getResource(processedUrl, callback, callbackError);
    };

    var getWellOperators = function (params, callback, callbackError) {
        var processedUrl = baseService.setParams(params, appSettings.mudLoggingApiUrl, 'welloperators');
        return baseService.getResource(processedUrl, callback, callbackError);
    };

    var getWellStatus = function (params, callback, callbackError) {
        var processedUrl = baseService.setParams(params, appSettings.mudLoggingApiUrl, 'wellstatus');
        return baseService.getResource(processedUrl, callback, callbackError);
    };

    var getWells = function (params, callback, callbackError) {
        var processedUrl = baseService.setParams(params, appSettings.mudLoggingApiUrl, 'wells');
        return baseService.getResource(processedUrl, callback, callbackError);
    };

    var postWell = function (params, dataReq, callback, callbackError) {
        var processedUrl = baseService.setParams(params, appSettings.mudLoggingApiUrl, 'wells');
        return baseService.saveResource(processedUrl, null, dataReq, callback, callbackError);
    };

    var getWellById = function (params, callback, callbackError) {
        var processedUrl = baseService.setParams(params, appSettings.mudLoggingApiUrl, 'wells/:id');
        return baseService.getResource(processedUrl, callback, callbackError);
    };

    var putWell = function (params, callback, callbackError) {
        var processedUrl = baseService.setParams(params, appSettings.mudLoggingApiUrl, 'wells' );
        return baseService.updateResource(processedUrl, callback, callbackError);
    };

    return {
        getClassificationWells: getClassificationWells,
        getWellOperators: getWellOperators,
        getWellStatus: getWellStatus,
        getWellById: getWellById,
        postWell: postWell,
        getWells: getWells,
        putWell: putWell
    };

}

wellService.$inject = ['baseService', 'appSettings'];

module.exports = wellService;