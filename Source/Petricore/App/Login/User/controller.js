var CryptoJS = require('crypto-js');
var _ = require('underscore');

function MainController($scope, $log, $location, $state, validationService, sessionStorageService, securityApplicationService) {

    $scope.go = function (path) {
        $location.path(path);
    };

    var navigate = function (hash) {
        $state.go(hash);
    };

    var init = function (configValidation) {
        $scope.addFormClicked = false;

        $scope.configValidation = configValidation == null ? [] : configValidation;

        $scope.user = 'admin.petricore';
        $scope.password = '123456';
        
        sessionStorageService.setApplicationId(null);
        sessionStorageService.setApplicationTicket(null);
        sessionStorageService.setUserApplication(null);
        sessionStorageService.setRoleUserApplication(null);

        $log.info('Controller for Login User loaded');
    };

    //Actions
    $scope.onLogin = function () {
        $scope.addFormClicked = true;
        if ($scope.loginForm.$valid) {
            //execute call
            securityApplicationService.getSharedSecret([{
                Name: 'textPlain',
                Value: $scope.user + '|' + CryptoJS.MD5($scope.password)
            }], onSharedSecretComplete, onError);
        }
    };

    //End Actions

    //Callbacks

    var onSharedSecretComplete = function (data) {
        $log.info('Secret Key Data', data);
        securityApplicationService.getAuthentication([
            {
                Name: 'userName',
                Value: data[0]
            },
            {
                Name: 'password',
                Value: data[1]
            }
        ], onAuthenticationComplete, onError);
    };

    var onAuthenticationComplete = function (data) {
        $log.info('Autehntication Data', data);
        if (data.AuthenticationCod == 1) { //OK{

            var application = _.find(data.ListApplication, function (application) {
                return application.IdApplication == 2; //Corresponde a Petricore
            });

            if (application) {
                sessionStorageService.setUserApplication(data.UserApplication);
                sessionStorageService.setApplicationTicket(application.Ticket);
                sessionStorageService.setApplicationId(application.IdApplication);
                navigate('loginRole');
            }
        }
    };

    var onError = function () {
        $log.info('Error');
    };

    //EndCallbacks

    //Validations
    $scope.configCustomValidation = function (config, executeValidation) {
        $scope.configValidation[config.id] = config;

        if (executeValidation == true) {
            $scope.loginForm[config.id].$validate();
        }
    };

    $scope.validation = function ($value, elementId) {
        $scope.configValidation[elementId].value = $value;
        var confValidator = $scope.configValidation[elementId];
        var resultValidation = validationService.validation(confValidator);
        $scope.configValidation[elementId].messageError = resultValidation.Error.message;
        return resultValidation.Error.isValid;
    };

    $scope.markedAsRequired = function (elementId) {
        var errorControl = $scope.configValidation[elementId].messageError;
        var isInvalid = errorControl.trim().length > 0;
        if (isInvalid && ($scope.loginForm[elementId].$pristine == false || $scope.addFormClicked == true)) {
            return true;
        }

        return false;
    };
    //End Validations

    init();
}

MainController.$inject = ['$scope', '$log', '$location', '$state', 'validationService', 'sessionStorageService', 'securityApplicationService'];
module.exports = MainController;