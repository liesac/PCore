require('./Core/init');
require('./Filter/init');
require('./Directive/init');
require('./File/init');
require('./Login/init');
require('./Main/init');
require('./Modals/init');
require('./Well/init');
require('angular-ui-bootstrap');
require('angular-ui-validate');
require('angular-ui-mask');

angular.module('Petricore', ['Petricore.Core',
    'Petricore.Filters',
    'Petricore.Directives',
    'Petricore.File',
    'Petricore.Login',
    'Petricore.Main',
    'Petricore.Modals',
    'Petricore.Well',
    'ui.bootstrap',
    'ui.validate',
    'ui.mask'])
    .constant('appSettings', require('./appSettings'))
    .constant('enums', require('./enums'));