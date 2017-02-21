var angular = require('angular');

module.exports = angular.module('Petricore.Core.Services', [])
    .factory('baseService', require('./Api/baseService'))
    .factory('utilService', require('./utilService'))
    .factory('validationService', require('./validationService'))
    .factory('sessionStorageService', require('./sessionStorageService'))
    //Security
    .factory('securityApplicationService', require('./Api/Security/securityApplicationService'));