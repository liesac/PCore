var angular = require('angular');
require('./Home/init');
require('./Menu/init');
require('./TopBar/init');
require('./Footer/init');


module.exports = angular.module('Petricore.Main', ['Petricore.Main.Home','Petricore.Main.Menu','Petricore.Main.TopBar','Petricore.Main.Footer']);