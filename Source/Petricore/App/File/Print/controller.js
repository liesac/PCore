function MainController($scope, $log, $location) {

    $scope.go = function (path) {
        $location.path(path);
    };

    var init = function () {
        $log.info('Controller for File Print function loaded');
    };

    init();
}

MainController.$inject = ['$scope', '$log', '$location'];
module.exports = MainController;