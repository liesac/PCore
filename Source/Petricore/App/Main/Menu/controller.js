function MainController($scope, $rootScope, $log, $location, $state, sessionStorageService) {

    $scope.routes = {
        appointments: 'home.searchAppointments',
        reports: 'home.reports'
    };

    $scope.navigateTo = function (route) {
        $scope.actualRoute = route;
        $state.go(route);
    };

    var init = function () {
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