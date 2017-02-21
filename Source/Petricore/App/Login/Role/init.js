require('./createStyle.scss');
var angular = require('angular');
var mainController = require('./controller');

module.exports = angular.module('Petricore.Login.Role', [])
	.controller('RoleController', mainController);