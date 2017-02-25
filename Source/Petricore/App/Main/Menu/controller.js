function MainController($scope, $rootScope, $log, $location, $state, sessionStorageService) {

    $scope.routes = {
        appointments: 'home.searchAppointments',
        reports: 'home.reports'
    };

    $scope.navigateTo = function (route) {
        $scope.actualRoute = route;
        $state.go(route);
        $scope.toggle();
    };
    
    $scope.toggle = function () {
        angular.element(document.querySelector('#wrapper')).toggleClass('toggled');
    };
	
    var init = function () {
        $scope.menuImg = [
            {
                name: 'file', 
                im: '/../../Assets/img/drilling_view_1.svg'
            },
            {
                name: 'config',
                im: './Assets/img/config.svg'
            },
            {
                name: 'well',
                im: '../../../Assets/img/well.svg'
            },
            {
                name: 'signals',
                im: '../../../Assets/img/signals.svg'
            },
            {
                name: 'alarms',
                im: '../../../Assets/img/alarms.svg'
            },
            {
                name: 'drilling',
                im: '../../../Assets/img/drilling_view.svg'
            },
            {
                name: 'data',
                im: '../../../Assets/img/data.svg'
            },
            {
                name: 'wits',
                im: '../../../Assets/img/wits.svg'
            },
            {
                name: 'utility',
                im: '../../../Assets/img/utility.svg'
            },
            {
                name: 'admin',
                im: '../../../Assets/img/admin.svg'
            }
        ];
        $scope.menuOptions = sessionStorageService.getRoleMenu();
        $log.log('$scope.menuOptions', $scope.menuOptions);
        $log.info('Controller for Menu  function loaded');
    };

    init();

    //Section Cancel Modal
    $rootScope.$on('$stateChangeStart', function (event, toState, toParams, fromState) {
        $rootScope.$broadcast('rootChange', {
            event: event,
            toState: toState,
            fromState: fromState
        });
    });
	
}

MainController.$inject = ['$scope', '$rootScope', '$log', '$location', '$state', 'sessionStorageService'];
module.exports = MainController;