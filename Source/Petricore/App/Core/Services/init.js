var angular = require('angular');

module.exports = angular.module('Petricore.Core.Services', [])
    .factory('baseService', require('./Api/baseService'))
    .factory('utilService', require('./utilService'))
    .factory('validationService', require('./validationService'))
    .factory('sessionStorageService', require('./sessionStorageService'))
    //Security
    .factory('securityApplicationService', require('./Api/Security/securityApplicationService'))
    //MudLogging
    .factory('oilFieldsService', require('./Api/Mudlogging/OliFieldService'))
    .factory('rigService', require('./Api/Mudlogging/RigService'))
    .factory('utilService', require('./Api/Mudlogging/UtilService'))
    .factory('wellService', require('./Api/Mudlogging/WellService'));