var angular = require('angular');
require('angular-ui-router');
require('angular-route');
require('./Services/init');
var router = require('./router');

module.exports = angular.module('Petricore.Core', ['ui.router', 'ngRoute', 'Petricore.Core.Services']).config(router);