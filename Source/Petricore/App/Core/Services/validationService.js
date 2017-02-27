var _ = require('underscore');
var moment = require('moment');

function validationService() {

    var validation = function (configValidation) {
        var objResult = [];

        if (configValidation.isRequired === true || configValidation.isRequired === 'true') {
            objResult.push(requireValidation(configValidation.value));
        }

        if (configValidation.type) {
            switch (configValidation.type) {
            case 'number':
                objResult.push.apply(objResult, numberValidation(configValidation));
                break;
            case 'text':
                objResult.push.apply(objResult, textValidation(configValidation));
                break;
            case 'date':
                objResult.push.apply(objResult, dateValidation(configValidation));
                break;
            case 'decimal':
                objResult.push.apply(objResult, decimalValidation(configValidation));
                break;
            case 'alphabetical':
                objResult.push.apply(objResult, alphabeticalValidation(configValidation));
                break;
            case 'alphanumeric':
                objResult.push.apply(objResult, alphanumericValidation(configValidation));
                break;
            case 'email':
                objResult.push.apply(objResult, emailValidation(configValidation));
                break;
            case 'lettersAndAllowedSymbols':
                objResult.push.apply(objResult, lettersAndAllowedSymbolsValidation(configValidation));
                break;
            case 'telephoneNumberMasked':
                objResult.push.apply(objResult, telephoneNumberMasked(configValidation));
                break;
            default:
                break;
            }
        }

        var errorObjs = _.filter(objResult, function (error) {
            return error.isValid == false;
        });

        var generalMessage = '';

        _.forEach(errorObjs, function (item) {
            generalMessage = generalMessage + ' ' + item.message;
        });

        //Validate input Validatios return max 1 object
        var errorTypeObjs = _.filter(errorObjs, function (error) {
            return error.validation == 'type';
        });

        var errorValue = errorTypeObjs.length == 1 ? errorTypeObjs[0].value : null;

        var uniqueObjResult = {
            ErrorArray: objResult,
            Error: {
                isValid: !(errorObjs.length > 0),
                message: generalMessage,
                value: errorValue
            }
        };

        return uniqueObjResult;
    };

    var lettersAndAllowedSymbolsValidation = function (configValidation) {
        var result = [];

        //Check, only number digits
        result.push(onlyRegxValidation(configValidation.value, /^[A-Za-z'´-\s]*$/, 'Invalid format.'));

        //Check length
        if (configValidation.lengthArray) {

            if (configValidation.lengthArray.length > 0) {
                result.push(lengthNumberValidation(configValidation.value, configValidation.lengthArray));
            }
        }

        return result;
    };


    var alphabeticalValidation = function (configValidation) {
        var result = [];

        //Check, only number digits
        result.push(onlyRegxValidation(configValidation.value, /^[a-zA-Z\s]*$/, 'Invalid format.'));

        //Check length
        if (configValidation.lengthArray) {

            if (configValidation.lengthArray.length > 0) {
                result.push(lengthNumberValidation(configValidation.value, configValidation.lengthArray));
            }
        }

        return result;
    };

    var alphanumericValidation = function (configValidation) {
        var result = [];

        //Check, only number digits
        result.push(onlyRegxValidation(configValidation.value, /^[a-zA-Z0-9\s]*$/, 'Invalid format.'));

        //Check length
        if (configValidation.lengthArray) {

            if (configValidation.lengthArray.length > 0) {
                result.push(lengthNumberValidation(configValidation.value, configValidation.lengthArray));
            }
        }

        return result;
    };

    var emailValidation = function (configValidation) {
        var result = [];

        //Check, only number digits
        result.push(onlyRegxValidation(configValidation.value,
            /^\w+([\.\+\-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,4})+$/,
            'Invalid email format.'));

        return result;
    };

    var decimalValidation = function (configValidation) {
        var result = [];

        //Check, only number digits
        result.push(onlyRegxValidation(configValidation.value, /^\d+(\.\d{1,2})?$/i, 'Only allow numbers.'));

        //Check length
        if (configValidation.lengthArray) {

            if (configValidation.lengthArray.length > 0) {
                result.push(lengthNumberValidation(configValidation.value, configValidation.lengthArray));
            }
        }

        //Check range
        if (configValidation.numeralRange) {
            if (configValidation.numeralRange[1] > 0) {
                result.push(rangeNumberValidation(configValidation.value, configValidation.numeralRange));
            }
        }

        return result;
    };

    var numberValidation = function (configValidation) {
        var result = [];

        //Check, only number digits
        result.push(onlyRegxValidation(configValidation.value, /^\d+$/, 'Only allow numbers.'));

        //Check length
        if (configValidation.lengthArray) {

            if (configValidation.lengthArray.length > 0) {
                result.push(lengthNumberValidation(configValidation.value, configValidation.lengthArray));
            }
        }

        //Check range
        if (configValidation.numeralRange) {
            if (configValidation.numeralRange[1] > 0) {
                result.push(rangeNumberValidation(configValidation.value, configValidation.numeralRange));
            }
        }

        return result;
    };

    var textValidation = function (configValidation) {
        var result = [];

        //Check length
        if (configValidation.lengthArray) {


            if (configValidation.lengthArray.length > 0) {
                result.push(lengthNumberValidation(configValidation.value, configValidation.lengthArray));
            }
        }

        return result;
    };
    
    var telephoneNumberMasked = function (configValidation) {
         
        configValidation.value = configValidation.value ? configValidation.value.replace('_', '') : configValidation.value;

        return textValidation(configValidation);
    };

    var dateValidation = function (configValidation) {
        var result = [];
        if (configValidation.datesRange[0] == '') {
            configValidation.datesRange[0] = '01/01/1900';
        }

        if (configValidation.datesRange[1] == '') {
            configValidation.datesRange[1] = '12/31/9999';
        }

        var startDate = moment(configValidation.datesRange[0], 'MM/DD/YYYY').isValid() ?
            moment(configValidation.datesRange[0], 'MM/DD/YYYY') : configValidation.datesRange[0];
        var endDate = moment(configValidation.datesRange[1], 'MM/DD/YYYY').isValid() ?
            moment(configValidation.datesRange[1], 'MM/DD/YYYY') : configValidation.datesRange[1];

        //check, date format
        if (configValidation.value) {
            result.push(dateFormatValidation(configValidation.value, 'MM/DD/YYYY'));
        }

        //check, date range
        if (startDate.isValid && endDate.isValid) {
            result.push(dateRangeValidation(configValidation.value, startDate, endDate));
        } else if (startDate.isValid && endDate == 'Adult') {
            var adultYear = moment().subtract(21, 'years');
            result.push(dateRangeValidation(configValidation.value, startDate, adultYear));
        } else if (startDate.isValid && endDate == 'Current') {
            var currentDate = moment();
            result.push(dateRangeValidation(configValidation.value, startDate, currentDate));
        }
        return result;
    };

    var onlyRegxValidation = function (value, regx, messageError) {
        var returnObj = {
            validation: 'type',
            isValid: true,
            message: '',
            value: value
        };

        if (regx.test(value) == false && value) {
            returnObj.isValid = false;
            returnObj.message = messageError;

            var newValue = '';
            angular.forEach(value, function (item) {
                var charValue = item;
                if (regx.test(item) == false) {
                    charValue = '';
                }
                newValue = newValue + charValue;
            });

            returnObj.value = newValue;
        }

        return returnObj;
    };

    var lengthNumberValidation = function (value, lengthArray) {

        var returnObj = {
            validation: 'type',
            isValid: true,
            message: '',
            value: value
        };

        if (lengthArray.length > 0 && value) {
            var isLengthOnArray = _.contains(lengthArray, value.length);
            if (!isLengthOnArray) {
                returnObj.isValid = false;
                returnObj.message = 'Length value is not allowed.';
            }
        }

        return returnObj;
    };

    var rangeNumberValidation = function (value, numeralRange) {

        var returnObj = {
            validation: 'type',
            isValid: true,
            message: '',
            value: value
        };

        if (numeralRange.length > 0 && value) {
            var isBetweenRange = parseFloat(value) >= parseFloat(numeralRange[0]) &&
                parseFloat(value) <= parseFloat(numeralRange[1]);

            if (!isBetweenRange) {
                returnObj.isValid = false;
                returnObj.message = 'Value out of range.';
            }
        }

        return returnObj;
    };

    var requireValidation = function (value) {
        var returnObj = {
            validation: 'isRequired',
            isValid: false,
            message: 'Required'
        };

        if (value != undefined && value.toString().length > 0) {
            returnObj.isValid = true;
            returnObj.message = '';
        }

        return returnObj;
    };

    var dateFormatValidation = function (value, dateformat) {

        var returnObj = {
            validation: 'type',
            isValid: true,
            message: '',
            value: value
        };

        if (dateformat.length > 0 && value) {
            if (!moment(value, 'MM/DD/YYYY', true).isValid()) {
                returnObj.isValid = false;
                returnObj.message = 'Format not valid.';
            }
        }

        return returnObj;
    };

    var dateRangeValidation = function (value, startDate, endDate) {

        var returnObj = {
            validation: 'type',
            isValid: true,
            message: '',
            value: value
        };

        if (endDate && startDate && value) {
            if (moment(value, 'MM/DD/YYYY').isValid()) {
                var isInRange = moment(value, 'MM/DD/YYYY').isBetween(startDate, endDate) ||
                    moment(value, 'MM/DD/YYYY').isSame(startDate) ||
                    moment(value, 'MM/DD/YYYY').isSame(endDate);

                if (!isInRange) {
                    returnObj.isValid = false;
                    returnObj.message = 'Date out of range.';
                }
            }
        }

        return returnObj;
    };

    return {
        validation: validation
    };
}

module.exports = validationService;