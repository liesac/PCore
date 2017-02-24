var swal = require('sweetalert2');
var moment = require('moment');
require('sweetalert2/dist/sweetalert2.css');

function MainController($scope, $log, $location, $rootScope, appSettings, oilFieldsService, rigService, utilService, wellService, validationService) {

    $scope.go = function (path) {
        $location.path(path);
    };

    var init = function (configValidation) {
        $scope.addFormClicked = false;
        $scope.configValidation = configValidation == null ? [] : configValidation;
        $scope.isUpdateWell = $location.path().search('update') >= 0;
        $scope.models = {};
        populateForm();
        setConstants();
        $rootScope.$emit('breadcrumbChange', {
            breadcrumb: $scope.isUpdateWell ? ['WELL', 'UPDATE WELL'] : ['WELL', 'CREATE WELL']
        });
        $log.info('Controller for CreateUpdate Well function loaded');
    };

    /*CallBacks*/

    var onGetClassificationWells = function (data) {
        $scope.models.classificationWell = data;
    };

    var onGetWellOperators = function (data) {
        $scope.models.wellOperator = data;
    };

    var onGetWellStatus = function (data) {
        $scope.models.wellStatus = data;
    };

    var onGetMudLoggingUnits = function (data) {
        $scope.models.mudLoggingUnit = data;
    };

    var onGetUnitSystems = function (data) {
        $scope.models.unitSystem = data;
    };

    var onGetRigs = function (data) {
        $scope.models.rig = data;
    };

    var onGetOilFields = function (data) {
        $scope.models.oilFields = data;
    };

    var onGetOilFieldsById = function (data) {
        $scope.models.timeZone = data.Location.Country.TimeZone.Description;
        $scope.models.country = data.Location.Country.DisplayName;
        $scope.models.location = data.Location.Name;
    };

    var onGetWellListDropDowns = function (data) {
        $scope.models.wellList = data;
    };

    var onGetWellById = function (data) {
        $scope.models.wellId = data.IdWell;
        $scope.models.wellName = data.NameWell;
        $scope.models.oilFieldId = data.OilField.Id;
        $scope.models.unitSystemId = data.UnitSystem.Id;
        $scope.models.wellStatusId = data.WellStatus.Id;
        $scope.models.intervalTime = data.IntervalTime;
        $scope.models.intervalDepth = data.IntervalDepth;
        $scope.models.intervalDepthUnitId = '';
        $scope.models.initializeDepth = data.InitializeDepth;
        $scope.models.spudDate = data.SpudDate ? moment(data.SpudDate).format('MM/DD/YYYY') : '';
        $scope.models.classificationWellId = data.ClasificationWell.Id;
        $scope.models.wellOperatorId = data.WellOperator.Id;
        $scope.models.rigId = data.Rig.Id;
        $scope.models.mudLoggingUnitId = data.MudLoggingUnit.Id;
        $scope.models.comments = data.Comments;
        $scope.models.latitude = data.Latitude;
        $scope.models.longitude = data.Longitude;
        $scope.models.groundElevation = data.GroundElevation;
        $scope.models.KBElevation = data.KbElevation;
        $scope.getOilFieldInfo();
        $scope.getUnitSystem();
    };

    var onGetUnitSystemById = function (data) {
        $scope.models.intervalDepthUnit = data;
        if (data.length === 1) {
            $scope.models.intervalDepthUnitId = data[0].Id;
        }
    };

    var onSaveWell = function () {
        swal({
            text: 'Well created correctly',
            type: 'success',
            confirmButtonText: 'Close'
        });
    };

    var onSaveWellError = function (error) {
        if (error.data.Message) {
            swal({
                text: error.data.Message,
                type: 'error',
                confirmButtonText: 'Close'
            });
        } else if (error.status === 409) {
            swal({
                text: error.data,
                type: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Confirm',
                cancelButtonText: 'Cancel'
            }).then(function () {
                $scope.saveWell(true);
            });
        }
    };

    var onPutWell = function () {
        swal({
            text: 'Well updated correctly',
            type: 'success',
            confirmButtonText: 'Close'
        });
        getWellListDropDowns();
    };

    var onUpdateError = function (error) {
        if (error.status === 409) {
            swal({
                text: error.data,
                type: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Confirm',
                cancelButtonText: 'Cancel'
            }).then(function () {
                $scope.updateWell(true);
            });
        }
    };

    var onError = function (error) {
        $log.info('error', error);
    };

    /*EndCallbacks*/

    var getWellsDropDowns = function () {
        wellService.getClassificationWells(null, onGetClassificationWells, onError);
        wellService.getWellOperators(null, onGetWellOperators, onError);
        wellService.getWellStatus(null, onGetWellStatus, onError);
    };

    var getUtilDropDowns = function () {
        utilService.getMudLoggingUnits(null, onGetMudLoggingUnits, onError);
        utilService.getUnitSystems(null, onGetUnitSystems, onError);
    };

    var getRigDropDowns = function () {
        rigService.getRigs(null, onGetRigs, onError);
    };

    var getOilFieldDropDowns = function () {
        oilFieldsService.getOilFields(null, onGetOilFields, onError);
    };

    var getWellListDropDowns = function () {
        wellService.getWells(null, onGetWellListDropDowns, onError);
    };

    var getConstants = function () {
        //TODO
    };

    var populateForm = function () {
        getWellsDropDowns();
        getUtilDropDowns();
        getRigDropDowns();
        getOilFieldDropDowns();
        getConstants();

        if ($scope.isUpdateWell) {
            getWellListDropDowns();
        }
    };

    var getModelsData = function (forceLogging) {
        return {
            Comments: $scope.models.comments,
            GroundElevation: $scope.models.groundElevation,
            IdClasificationWell: $scope.models.classificationWellId,
            IdMudloggingUnit: $scope.models.mudLoggingUnitId,
            IdOilField: $scope.models.oilFieldId,
            IdRig: $scope.models.rigId,
            IdUnitSystem: $scope.models.unitSystemId,
            IdWell: $scope.models.wellId,
            IdWellOperator: $scope.models.wellOperatorId,
            IdStatus: $scope.models.wellStatusId,
            InitializeDepth: $scope.models.initializeDepth,
            IntervalDepth: $scope.models.intervalDepth,
            IdUnitIntervalDepth: $scope.models.intervalDepthUnitId,
            IntervalTime: $scope.models.intervalTime,
            kbElevation: $scope.models.KBElevation,
            Latitude: $scope.models.latitude,
            Longitude: $scope.models.longitude,
            NameWell: $scope.models.wellName,
            SpudDate: $scope.models.spudDate ? moment($scope.models.spudDate, 'MM/DD/YYYY').format() : null,
            ChangeStatus: forceLogging ? forceLogging : false
        };
    };

    var setConstants = function () {
        $scope.models.intervalTime = $scope.models.intervalTime ? $scope.models.intervalTime : appSettings.petricoreConstants.intervalTime;
        $scope.models.intervalDepth = $scope.models.intervalDepth ? $scope.models.intervalDepth : appSettings.petricoreConstants.intervalDepth;
    };

    var resetModels = function () {
        for (var model in $scope.models) {
            $scope.models[model] = '';
        }
    };

    $scope.getOilFieldInfo = function () {
        var urlParameters = [{
            Name: 'id',
            Value: $scope.models.oilFieldId
        }];
        oilFieldsService.getOilFieldsById(urlParameters, onGetOilFieldsById, onError);
    };

    $scope.getWellInfo = function () {
        if ($scope.models.wellListId) {
            var urlParameters = [{
                Name: 'id',
                Value: $scope.models.wellListId
            }];
            wellService.getWellById(urlParameters, onGetWellById, onError);
        } else {
            resetModels();
        }

    };

    $scope.getUnitSystem = function () {
        if ($scope.models.unitSystemId !== undefined) {
            var urlParameters = [{
                Name: 'id',
                Value: $scope.models.unitSystemId
            }];
            utilService.getUnitSystemById(urlParameters, onGetUnitSystemById, onError);
        } else {
            $scope.models.intervalDepthUnit = [];
        }
    };

    $scope.saveWell = function (forceLogging) {
        $scope.addFormClicked = true;
        if ($scope.wellForm.$valid) {
            var data = getModelsData(forceLogging);
            wellService.postWell(null, data, onSaveWell, onSaveWellError);
        }
    };

    $scope.updateWell = function (forceLogging) {
        $scope.addFormClicked = true;
        if ($scope.wellForm.$valid) {
            var urlParameters = [{
                Name: 'id',
                Value: $scope.models.wellListId,
                data: getModelsData(forceLogging)
            }];
            wellService.putWell(urlParameters, onPutWell, onUpdateError);
        }
    };

    $scope.dismissModal = function () {
        $scope.modalInstance.dismiss();
    };

    //Validations
    $scope.configCustomValidation = function (config, executeValidation) {
        $scope.configValidation[config.id] = config;

        if (executeValidation == true) {
            $scope.wellForm[config.id].$validate();
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
        if (isInvalid && ($scope.wellForm[elementId].$pristine == false || $scope.addFormClicked == true)) {
            return true;
        }

        return false;
    };
    //End Validations

    init();

}

MainController.$inject = ['$scope', '$log', '$location', '$rootScope', 'appSettings', 'oilFieldsService', 'rigService', 'utilService', 'wellService', 'validationService'];
module.exports = MainController;