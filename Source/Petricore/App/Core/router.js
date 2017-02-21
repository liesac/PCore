function Router($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/');
    $urlRouterProvider.when('/', '/login');

    $stateProvider
        .state('login', {
            url: '/login',
            views: {
                '': {
                    template: require('html!../Login/User/template.html'),
                    controller: 'UserController'
                }
            }
        })
        .state('loginRole', {
            url: '/loginRole',
            views: {
                '': {
                    template: require('html!../Login/Role/template.html'),
                    controller: 'RoleController'
                }
            }
        })
        .state('home', {
            url: '/home',
            views: {
                '': {
                    template: require('html!../Main/Home/homeTemplate.html'),
                    controller: 'HomeController'
                },
                'menu@home': {
                    template: require('html!../Main/Menu/template.html'),
                    controller: 'MenuController'
                },
                'topBar@home': {
                    template: require('html!../Main/TopBar/template.html'),
                    controller: 'TopBarController'
                },
                'footer@home': {
                    template: require('html!../Main/Footer/template.html'),
                    controller: 'FooterController'
                }
            }
        })
        .state('home.file', {
            abstract: true,
            url: '/file',
            template: '<ui-view/>'
        })
        .state('home.file.export', {
            url: '/export',
            template: require('html!../File/Export/template.html'),
            controller: 'ExportFileController'
        })
        .state('home.file.import', {
            url: '/import',
            template: require('html!../File/Import/template.html'),
            controller: 'ImportFileController'
        })
        .state('home.file.print', {
            url: '/print',
            template: require('html!../File/Print/template.html'),
            controller: 'PrintFileController'
        })
        .state('home.well', {
            abstract: true,
            url: '/well',
            template: '<ui-view/>'
        })
        .state('home.well.create', {
            url: '/create',
            template: require('html!../Well/CreateUpdate/template.html'),
            controller: 'CreateUpdateWellController'
        })
        .state('home.well.update', {
            url: '/update',
            template: require('html!../Well/CreateUpdate/template.html'),
            controller: 'CreateUpdateWellController'
        });
}

Router.$inject = ['$stateProvider', '$urlRouterProvider'];

module.exports = Router;