require('./createStyle.scss');
var angular = require('angular');
var mainController = require('./controller');

module.exports = angular.module('Petricore.Main.Footer', [])
	.controller('FooterController', mainController);