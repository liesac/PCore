var _ = require('underscore');

function sessionStorageService() {

    var activeLocalStorage = false;

    var objectSession = [];

    var setObjectSession = function (nameObject, data) {
        if (activeLocalStorage == true) {
            if (data == null) {
                localStorage.removeItem(nameObject);
            } else {
                localStorage.setItem(nameObject, JSON.stringify(data));
            }

        } else {
            if (data == null) {
                objectSession = _.filter(objectSession, function (item) {
                    return item.nameParameter != nameObject;
                });
            } else {
                var indexOfObject = _.findIndex(objectSession, {
                    nameParameter: nameObject
                });
                if (indexOfObject !== -1) {
                    objectSession.splice(indexOfObject, 1);
                }
                objectSession.push({
                    nameParameter: nameObject,
                    valueParameter: JSON.stringify(data)
                });

            }
        }
    };

    var getObjectSession = function (nameObject) {
        if (activeLocalStorage == true) {
            return JSON.parse(localStorage.getItem(nameObject));
        } else {
            var resultParameter = _.find(objectSession, function (item) {
                return item.nameParameter == nameObject;
            });

            if (resultParameter != undefined) {
                return JSON.parse(resultParameter.valueParameter);
            }
        }

        return null;
    };

    var setApplicationTicket = function (data) {
        setObjectSession('ApplicationTicket', data);
    };

    var getApplicationTicket = function () {
        return getObjectSession('ApplicationTicket');
    };

    var setApplicationId = function (data) {
        setObjectSession('ApplicationId', data);
    };

    var getApplicationId = function () {
        return getObjectSession('ApplicationId');
    };

    var setUserApplication = function (data) {
        setObjectSession('UserApplication', data);
    };

    var getUserApplication = function () {
        return getObjectSession('UserApplication');
    };

    var setRoleUserApplication = function (data) {
        setObjectSession('RoleUserApplication', data);
    };

    var getRoleUserApplication = function () {
        return getObjectSession('RoleUserApplication');
    };

    var setRoleMenu = function (data) {
        setObjectSession('RoleMenu', data);
    };

    var getRoleMenu = function () {
        return getObjectSession('RoleMenu');
    };

    var setBreadcrumb = function (data) {
        setObjectSession('Breadcrumb', data);
    };

    var getBreadcrumb = function () {
        return getObjectSession('Breadcrumb');
    };


    return {
        setApplicationTicket: setApplicationTicket,
        getApplicationTicket: getApplicationTicket,
        setApplicationId: setApplicationId,
        getApplicationId: getApplicationId,
        setUserApplication: setUserApplication,
        getUserApplication: getUserApplication,
        setRoleUserApplication: setRoleUserApplication,
        getRoleUserApplication: getRoleUserApplication,
        setRoleMenu: setRoleMenu,
        getRoleMenu: getRoleMenu,
        setBreadcrumb: setBreadcrumb,
        getBreadcrumb: getBreadcrumb
    };
}

//sessionStorageService.$inject = ['$log'];
module.exports = sessionStorageService;