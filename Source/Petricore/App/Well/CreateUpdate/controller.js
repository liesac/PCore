var swal = require('sweetalert2');
require('sweetalert2/dist/sweetalert2.css');

function MainController($scope, $log, $location, $rootScope, oilFieldsService, rigService, utilService, wellService, sessionStorageService, validationService) {

    $scope.go = function (path) {
        $location.path(path);
    };

    var init = function (configValidation) {
        $scope.addFormClicked = false;
        $scope.configValidation = configValidation == null ? [] : configValidation;
        populateDropDowns();
        $scope.models = {};
        $scope.isUpdateWell = $location.path().search('update') >= 0;
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
        $scope.models.wellId = data.idWell;
        $scope.models.wellName = data.nameWell;
        $scope.models.oilFieldId = data.oilfield.id;
        $scope.models.timeZone = data.oilfield.location.country.timezone.description;
        $scope.models.unitSystemId = data.unitsystem.id;
        $scope.models.wellStatusId = data.wellstatus.id;
        $scope.models.country = data.oilfield.location.country.displayName;
        $scope.models.location = data.oilfield.location.name;
        $scope.models.intervalTime = data.intervalTime;
        $scope.models.intervalDepth = data.intervalDepth;
        $scope.models.intervalDepthUnitId = '';
        $scope.models.initializeDepth = data.initializeDepth;
        $scope.models.spudDate = data.spudDate;
        $scope.models.classificationWellId = data.clasificationwell.id;
        $scope.models.wellOperatorId = data.welloperator.id;
        $scope.models.rigId = data.rig.id;
        $scope.models.mudLoggingUnitId = data.mudloggingunit.id;
        $scope.models.comments = data.comments;
        $scope.models.latitude = data.latitude;
        $scope.models.longitude = data.longitude;
        $scope.models.groundElevation = data.groundElevation;
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

        if ($scope.isUpdate) {
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
        var parameters = [{
            Name: 'id',
            Value: $scope.models.oilFieldId
        }];
        oilFieldsService.getOilFieldsById(parameters, onGetOilFieldsById, onError);
    };

    $scope.getWellInfo = function () {
        wellService.getWellById($scope.models.wellId, onGetWellById, onError);
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