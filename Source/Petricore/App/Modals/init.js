var angular = require('angular');

var modalCancelController = require('./ModalTemplate/modalController');

module.exports = angular.module('Petricore.Modals', [])
    .controller('ModalCancelController', modalCancelController);