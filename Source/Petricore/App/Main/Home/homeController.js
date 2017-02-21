function MainController($scope, $log, $location, $window) {

    $scope.go = function (path) {
        $location.path(path);
    };

    var init = function () {
        $log.info('Controller for Home function loaded');
    };

    init();

    var stopRKey = function (evt) {
        evt = (evt) ? evt : ((event) ? event : null);
        var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
        if ((evt.keyCode == 13) && (node.type == 'text' || node.type == 'checkbox')) {
            return false;
        }
    };

    document.onkeypress = stopRKey;

    $scope.onExit = function () {
        return ('Confirm close tab.');
    };

    $window.onbeforeunload = $scope.onExit;
}

MainController.$inject = ['$scope', '$log', '$location', '$window'];
module.exports = MainController;