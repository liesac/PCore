require('./homeStyle.scss');

var angular = require('angular');


var mainController = require('./homeController');
var HeaderComponent = require('../Header/header.component');

module.exports = angular.module('Petricore.Main.Home', [])
	.controller('HomeController', mainController)
    .component('header', HeaderComponent);