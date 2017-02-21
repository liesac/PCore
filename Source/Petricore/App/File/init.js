var angular = require('angular');
require('./Export/init');
require('./Import/init');
require('./Print/init');

module.exports = angular.module('Petricore.File', ['Petricore.File.Export', 'Petricore.File.Import', 'Petricore.File.Print']);