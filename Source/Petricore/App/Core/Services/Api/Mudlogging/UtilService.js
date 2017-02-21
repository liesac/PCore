function utilService(baseService, appSettings) {

    var getMudLoggingUnits = function (params, callback, callbackError) {
        var processedUrl = baseService.setParams(params, appSettings.mudLoggingApiUrl, 'mudloggingunits');
        return baseService.getResource(processedUrl, callback, callbackError);
    };

    var getUnitSystems = function (params, callback, callbackError) {
        var processedUrl = baseService.setParams(params, appSettings.mudLoggingApiUrl, 'unitsystems');
        return baseService.getResource(processedUrl, callback, callbackError);
    };


    return {
        getMudLoggingUnits: getMudLoggingUnits,
        getUnitSystems: getUnitSystems
    };

}

utilService.$inject = ['baseService', 'appSettings'];

module.exports = utilService;