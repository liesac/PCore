var _ = require('underscore');

function MainController($scope, $log, $location, baseService, appSettings) {

    $scope.go = function (path) {
        $location.path(path);
    };

    var init = function () {
        $log.info('Controller for Autocomplete Directive loaded');

        var params = [{
            Name: 'mode',
            Value: 'all'
        }];
        var processedUrl = baseService.setParams(params, appSettings.laApiUrl, $scope.apiConfig.url);

        return baseService.getResource(processedUrl, callback, callbackError);

    };

    //loader saved Data

    //    Events handlers

    $scope.inputChangeHandler = function (str) {

        if ($scope.inputChanged) {
            str = $scope.inputChanged(str);
        }
        return str;
    };

    //    End Events handlers
    //    Callbacks
    var callback = function (data) {
        $scope.payload = _.sortBy(data[$scope.apiConfig.dataField], $scope.apiConfig.orderBy);

        if ($scope.ngModel) {
            var defaultState = _.filter($scope.payload, function (state) {
                return state.idState == $scope.ngModel;
            });
            if (defaultState) {
                $scope.idEntity = defaultState[0].abbrState;
                $scope.idSelected = defaultState[0].idState;
            }
        }
    };

    var callbackError = function () {
        //TODO
    };

    //    End of Callbacks

    //    API 

    $scope.apiObject = {
        retrieveIdSelected: function () {
            return $scope.idSelected;
        }
    };

    //    END OF API

    init();
}

MainController.$inject = ['$scope', '$log', '$location', 'baseService', 'appSettings'];
module.exports = MainController;