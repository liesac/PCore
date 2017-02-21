require('./createStyle.scss');

var angular = require('angular');


var mainController = require('./controller');

module.exports = angular.module('Petricore.Well.Update', [])
	.controller('UpdateWellController', mainController);