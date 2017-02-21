var angular = require('angular');
var formatCurrencyNumberFilter = require('./formatCurrencyNumber/formatCurrencyNumber');
var customFormatNumberFilter = require('./customFormatNumber/customFormatNumber');
var zipCodeFormatNumber = require('./zipCodeFormatNumber/zipCodeFormatNumber');

module.exports = angular.module('Petricore.Filters', [])
    .filter('formatCurrencyNumber', formatCurrencyNumberFilter)
    .filter('customFormatNumber', customFormatNumberFilter)
    .filter('zipCodeFormatNumber', zipCodeFormatNumber);