function MainController($log, $scope, $state, $uibModalInstance, sessionStorageService) {

    var init = function () {
        $log.info('Controller for Modal JETS function loaded');       
        
        $scope.dataInfo = sessionStorageService.getUrlChangeObject();
    };

    $scope.onClickModalChangeYes = function () {
        $state.go($scope.dataInfo.toState.name);
        $uibModalInstance.close();
    };

    $scope.onClickModalChangeCancel = function () {
        sessionStorageService.setUrlChangeObject(null);
        $uibModalInstance.close();
    };
    
    init();
}

MainController.$inject = ['$log', '$scope', '$state', '$uibModalInstance', 'sessionStorageService'];
module.exports = MainController;