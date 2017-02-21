var angular = require('angular');
require('./Role/init');
require('./User/init');


module.exports = angular.module('Petricore.Login', ['Petricore.Login.User','Petricore.Login.Role']);