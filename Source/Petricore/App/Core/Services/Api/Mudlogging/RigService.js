function rigService(baseService, appSettings) {

    var getRigs = function (params, callback, callbackError) {
        var processedUrl = baseService.setParams(params, appSettings.mudLoggingApiUrl, 'rigs');
        return baseService.getResource(processedUrl, callback, callbackError);
    };

    return {
        getRigs: getRigs
    };

}

rigService.$inject = ['baseService', 'appSettings'];

module.exports = rigService;