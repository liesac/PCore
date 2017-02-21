require('./style.scss');

var angular = require('angular');


var mainController = require('./controller');

module.exports = angular.module('Petricore.Main.TopBar', [])
	.controller('TopBarController', mainController);