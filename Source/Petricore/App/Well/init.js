var angular = require('angular');
require('./Create/init');
require('./Update/init');


module.exports = angular.module('Petricore.Well', ['Petricore.Well.Create','Petricore.Well.Update']);