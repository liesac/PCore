var swal = require('sweetalert2');
require('sweetalert2/dist/sweetalert2.css');

function MainController($scope, $log, $location, $rootScope, oilFieldsService, rigService, utilService, wellService, sessionStorageService, validationService) {

    $scope.go = function (path) {
        $location.path(path);
    };

    var init = function (configValidation) {
        $scope.addFormClicked = false;
        $scope.configValidation = configValidation == null ? [] : configValidation;
        $scope.isUpdateWell = $location.path().search('update') >= 0;
        populateDropDowns();
        $scope.models = {};
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
        $scope.models.oilFieldId = data.Oilfield.Id;
        $scope.models.timeZone = data.Oilfield.Location.Country.TimeZone.Description;
        $scope.models.unitSystemId = data.UnitSystem.Id;
        $scope.models.wellStatusId = data.WellStatus.Id;
        $scope.models.country = data.Oilfield.Location.Country.DisplayName;
        $scope.models.location = data.Oilfield.Location.Name;
        $scope.models.intervalTime = data.IntervalTime;
        $scope.models.intervalDepth = data.IntervalDepth;
        $scope.models.intervalDepthUnitId = '';
        $scope.models.initializeDepth = data.InitializeDepth;
        $scope.models.spudDate = data.SpudDate;
        $scope.models.classificationWellId = data.ClasificationWell.Id;
        $scope.models.wellOperatorId = data.WellOperator.Id;
        $scope.models.rigId = data.Rig.Id;
        $scope.models.mudLoggingUnitId = data.MudloggingUnit.Id;
        $scope.models.comments = data.Comments;
        $scope.models.latitude = data.Latitude;
        $scope.models.longitude = data.Longitude;
        $scope.models.groundElevation = data.GroundElevation;
        $scope.models.KBElevation = data.kbElevation;
    };

    var onSaveWell = function () {
        swal({
            text: 'Well created correctly',
            type: 'success',
            confirmButtonText: 'Close'
        });
    };

    var onSaveWellError = function (response) {
        if (response.data.Message) {
            swal({
                text: response.data.Message,
                type: 'error',
                confirmButtonText: 'Close'
            });
        }
    };

    var onPutWell = function () {
        //TODO
        $log.info('TODO');
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

    var populateDropDowns = function () {
        getWellsDropDowns();
        getUtilDropDowns();
        getRigDropDowns();
        getOilFieldDropDowns();

        if ($scope.isUpdateWell) {
            getWellListDropDowns();
        }
    };

    var getModelsData = function () {
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
            IntervalTime: $scope.models.intervalTime,
            kbElevation: $scope.models.KBElevation,
            Latitude: $scope.models.latitude,
            Longitude: $scope.models.longitude,
            NameWell: $scope.models.wellName,
            SpudDate: $scope.models.spudDate
        };
    };

    $scope.getOilFieldInfo = function () {
        var urlParameters = [{
            Name: 'id',
            Value: $scope.models.oilFieldId
        }];
        oilFieldsService.getOilFieldsById(urlParameters, onGetOilFieldsById, onError);
    };

    $scope.getWellInfo = function () {
        var urlParameters = [{
            Name: 'id',
            Value: $scope.models.wellId
        }];
        wellService.getWellById(urlParameters, onGetWellById, onError);
    };

    $scope.saveWell = function () {
        $scope.addFormClicked = true;
        if ($scope.wellForm.$valid) {
            var data = getModelsData();
            wellService.postWell(null, data, onSaveWell, onSaveWellError);
        }
    };

    $scope.updateWell = function () {
        var data = getModelsData();
        wellService.putWell([data], onPutWell, onError);
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

MainController.$inject = ['$scope', '$log', '$location', '$rootScope', 'oilFieldsService', 'rigService', 'utilService', 'wellService', 'sessionStorageService', 'validationService'];
module.exports = MainController;