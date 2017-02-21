require('./createStyle.scss');

var angular = require('angular');


var mainController = require('./controller');

module.exports = angular.module('LA.Locations.Create', [])
	.controller('CreateLocationController', mainController);