var angular = require('angular');
require('./CreateUpdate/init');

module.exports = angular.module('LA.Locations', ['LA.Locations.CreateUpdate']);