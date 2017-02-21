function securityApplicationService(baseService, appSettings) {

    var getSharedSecret = function (params, callback, callbackError) {

        var processedUrl = baseService.setParams(params, appSettings.securityApiUrl, 'SecurityApplication/GetSharedSecret');
        return baseService.getResource(processedUrl, callback, callbackError);
    };
    
    var getAuthentication = function (params, callback, callbackError) {

        var processedUrl = baseService.setParams(params, appSettings.securityApiUrl, 'SecurityApplication/GetAuthentication');
        return baseService.getResource(processedUrl, callback, callbackError);
    };
    
    var getApplicationUserRole = function (params, callback, callbackError) {

        var processedUrl = baseService.setParams(params, appSettings.securityApiUrl, 'SecurityApplication/GetApplicationUserRole');
        return baseService.getResource(processedUrl, callback, callbackError);
    };
    
    var getApplicationUserRoleMenu = function (params, callback, callbackError) {

        var processedUrl = baseService.setParams(params, appSettings.securityApiUrl, 'SecurityApplication/GetApplicationUserRoleMenu');
        return baseService.getResource(processedUrl, callback, callbackError);
    };

    return {
        getSharedSecret: getSharedSecret,
        getAuthentication: getAuthentication,
        getApplicationUserRole: getApplicationUserRole,
        getApplicationUserRoleMenu: getApplicationUserRoleMenu
    };

}

securityApplicationService.$inject = ['baseService', 'appSettings'];

module.exports = securityApplicationService;