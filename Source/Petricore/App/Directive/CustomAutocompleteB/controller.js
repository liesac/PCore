var _ = require('underscore');

function MainController($scope, $log, $location, baseService, appSettings) {

    $scope.go = function (path) {
        $location.path(path);
    };

    var init = function () {
        $log.info('Controller for Autocomplete Directive loaded');

        var processedUrl = baseService.setParams('', appSettings.laApiUrl, $scope.apiConfig.url);

        return baseService.getResource(processedUrl, callback, callbackError);

    };

    //loader saved Data

    //    Events handlers

    $scope.$watch('modelValue', function () {
        if ($scope.modelValue === '') {
            $scope.idEntity = '';
        }
    });

    $scope.onSelect = function ($item, $model) {
        $scope.modelValue = $model.id;

        $scope.inputChanged($model.id);
    };

    $scope.lostFocus = function () {

        if ($scope.idEntity != null && !angular.isObject($scope.idEntity)) {

            var item = inputOnSearch();

            if (item.length == 0) {
                $scope.idEntity = '';
                $scope.modelValue = '';

                $scope.inputChanged(undefined);
            } else if (item.length > 0) {
                $scope.idEntity = item[0].name;
                $scope.modelValue = item[0].id;
                $scope.inputChanged(item[0].id);
            }
        }
    };

    var inputOnSearch = function () {
        return _.filter($scope.itemList, function (item) {
            return item.name == $scope.idEntity;
        });
    };

    //    End Events handlers
    //    Callbacks
    var callback = function (data) {
        $scope.itemList = _.map(data[$scope.apiConfig.dataField], function (dataItem) {
            return {
                id: dataItem[$scope.apiConfig.propertyId],
                name: dataItem[$scope.apiConfig.propertyToShow]
            };
        });
        $scope.itemList = _.sortBy($scope.itemList, 'name');
        
        if ($scope.ngModel) {
            var defaultItem = _.filter($scope.itemList, function (item) {
                return item.id == $scope.ngModel;
            });

            $scope.idEntity = defaultItem[0].name;
        }
    };

    var callbackError = function () {
        //TODO
    };

    //    End of Callbacks

    //    API 

    $scope.apiObject = {
        resetValue: function () {
            $scope.idEntity = '';
        },
        reload: function() {
            init();
        }
    };
    //    END OF API
    
    init();
}

MainController.$inject = ['$scope', '$log', '$location', 'baseService', 'appSettings'];
module.exports = MainController;