var angular = require('angular');
require('./CreateUpdate/init');

module.exports = angular.module('Petricore.Well', ['Petricore.Well.CreateUpdate']);