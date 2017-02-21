function MainController($scope, $log, $location, oilFieldsService, rigService, utilService, wellService) {

    $scope.go = function (path) {
        $location.path(path);
    };

    var onError = function (error) {
        $log.info('error', error);
    };

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
            comments: $scope.models.comments,
            groundElevation: $scope.models.groundElevation,
            idClasificationWell: $scope.models.classificationWellId,
            idMudloggingUnit: $scope.models.mudLoggingUnitId,
            idOilField: $scope.models.oilFieldId,
            idRig: $scope.models.rigId,
            idUnitSystem: $scope.models.unitSystemId,
            idWell: $scope.models.wellId,
            idWellOperator: $scope.models.wellOperatorId,
            idWellStatus: $scope.models.wellStatusId,
            initializeDepth: $scope.models.initializeDepth,
            intervalDepth: $scope.models.intervalDepth,
            intervalTime: $scope.models.intervalTime,
            kbElevation: $scope.models.KBElevation,
            latitude: $scope.models.latitude,
            longitude: $scope.models.longitude,
            nameWell: $scope.models.wellName,
            spudDate: $scope.models.spudDate
        };
    };

    $scope.getOilFieldInfo = function () {
        oilFieldsService.getOilFieldsById($scope.models.oilFieldId, onGetOilFieldsById, onError);
    };

    $scope.getWellInfo = function () {
        wellService.getWellById($scope.models.wellId, onGetWellById, onError);
    };

    $scope.saveWell = function () {
        var data = getModelsData();
        wellService.postWell([data], onSaveWell, onError);
    };

    $scope.updateWell = function () {
        var data = getModelsData();
        wellService.putWell([data], onPutWell, onError);
    };

    var init = function () {
        populateDropDowns();
        $scope.isUpdateWell = $location.path().search('update') >= 0;
        $log.info('Controller for CreateUpdate Well function loaded');
    };

    init();

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
        $scope.models.timeZone = data.location.country.timezone.description;
        $scope.models.country = data.location.country.displayName;
        $scope.models.location = data.location.name;
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
        //TODO
    };

    var onPutWell = function () {
        //TODO
    };
}

MainController.$inject = ['$scope', '$log', '$location', 'oilFieldsService', 'rigService', 'utilService', 'wellService'];
module.exports = MainController;