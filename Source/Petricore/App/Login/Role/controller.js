var _ = require('underscore');

function MainController($scope, $log, $location, $state, sessionStorageService, securityApplicationService) {

    $scope.go = function (path) {
        $location.path(path);
    };

    var navigate = function (hash) {
        $state.go(hash);
    };

    var userApplication = null;
    var applicationId = null;
    var ticket = null;


    var init = function () {

        $scope.roles = [];

        userApplication = sessionStorageService.getUserApplication();

        $log.info('userApplication', userApplication);

        applicationId = sessionStorageService.getApplicationId();
        ticket = sessionStorageService.getApplicationTicket();

        securityApplicationService.getApplicationUserRole([
            {
                Name: 'idCompany',
                Value: userApplication.IdCompany
            },
            {
                Name: 'idApplication',
                Value: applicationId
            },
            {
                Name: 'idUserApplication',
                Value: userApplication.IdUserApplication
            },
            {
                Name: 'ticket',
                Value: ticket
            }
        ], onGetAppUserRoleComplete, onError);

        $log.info('Controller for Login Role function loaded');
    };

    //Actions
    $scope.onRoleClicked = function (roleId) {
        var roleSelected = _.find($scope.roles, function (role) {
            return role.IdApplicationRole == roleId;
        });

        $log.info('roleSelected', roleSelected);

        if (roleSelected) {

            sessionStorageService.setRoleUserApplication(roleSelected);
            securityApplicationService.getApplicationUserRoleMenu([
                {
                    Name: 'idCompany',
                    Value: userApplication.IdCompany
                },
                {
                    Name: 'idApplication',
                    Value: applicationId
                },
                {
                    Name: 'idUserApplication',
                    Value: userApplication.IdUserApplication
                },
                {
                    Name: 'ticket',
                    Value: ticket
                },
                {
                    Name: 'idApplicationRole',
                    Value: roleSelected.IdApplicationRole
                }
            ], onGetAppUserRoleMenuComplete, onError);

        } else {
            navigate('login');
        }
    };
    //End Actions

    //Callbacks

    var onGetAppUserRoleMenuComplete = function (data) {
        sessionStorageService.setRoleMenu(data.ListMenu);
        $log.info('App User Role MENU Complete Data', data);

        navigate('home');
    };

    var onGetAppUserRoleComplete = function (data) {
        $log.info('App User Role Complete Data', data);
        $scope.roles = data;
    };

    var onError = function () {
        $log.info('Error');
    };

    //EndCallbacks

    init();
}

MainController.$inject = ['$scope', '$log', '$location', '$state', 'sessionStorageService', 'securityApplicationService'];
module.exports = MainController;