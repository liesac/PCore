require('./homeStyle.scss');

var angular = require('angular');


var mainController = require('./homeController');

module.exports = angular.module('Petricore.Main.Home', [])
	.controller('HomeController', mainController);