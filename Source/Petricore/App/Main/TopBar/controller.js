function MainController($scope, $log, $rootScope) {


    $scope.logOut = function () {
        //TODO Implementation of the log out routine.
    };

    $rootScope.$on('breadcrumbChange', function (event, data) {
        $scope.breadcrumbs = data.breadcrumb;
    });

    var init = function () {
        $scope.userName = 'User name';
        $log.info('Controller for Top Bar function loaded');
    };

    init();
}

MainController.$inject = ['$scope', '$log', '$rootScope'];
module.exports = MainController;