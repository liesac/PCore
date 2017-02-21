var angular = require('angular');
var customValidation = require('./CustomValidation/customValidation');
var uppercase = require('./CustomUppercase/customUppercase');
var customFormat = require('./CustomFormat/customFormat');
var autocomplete = require('./CustomAutocomplete/autocomplete');
var autocompleteB = require('./CustomAutocompleteB/autocompleteB');
var customValidationCeo = require('./CustomValidationCeo/customValidationCeo');
//new objects from directives will be placed here

module.exports = angular.module('Petricore.Directives', [])
    .directive('customValidation', customValidation)
    .directive('customUppercase', uppercase)
    .directive('customFormat', customFormat)
    .directive('customAutocomplete', autocomplete)
    .directive('customAutocompleteB', autocompleteB)
    .directive('customValidationCeo', customValidationCeo);

