var customValidation = function () {

    function customValidationController() {
        //TODO
    }

    function readConfigValidation(scope, element, attributes, executeValidation) {
        var idControl = attributes.id;
        var dataIsRequire = attributes.isrequired != undefined ? attributes.isrequired : false;
        var typeValidation = attributes.typevalidation != undefined ? attributes.typevalidation : '';
        var lenghtArray = attributes.lengtharray != undefined ? JSON.parse(attributes.lengtharray) : undefined;
        var startDateValidation = attributes.startdatevalidation != undefined ? attributes.startdatevalidation : '';
        var endDateValidation = attributes.enddatevalidation != undefined ? attributes.enddatevalidation : '';
        var minValueValidation = attributes.minvalue != undefined ? attributes.minvalue : 0;
        var maxValueValidation = attributes.maxvalue != undefined ? attributes.maxvalue : 0;

        var confValidator = {
            id: idControl,
            value: scope.modelValue, //controlValue,
            isRequired: dataIsRequire,
            type: typeValidation,
            lengthArray: lenghtArray,
            datesRange: [startDateValidation, endDateValidation],
            numeralRange: [minValueValidation, maxValueValidation],
            messageError: ''
        };

        scope.cuvConfig(confValidator, executeValidation);
    }

    function customValidationLink(scope, element, attributes) {

        readConfigValidation(scope, element, attributes, false);

        scope.$watch(function () {
            return element.attr('data-startDateValidation');
        }, function (newValue, oldValue) {
            if (newValue !== oldValue) {
                readConfigValidation(scope, element, attributes);
            }
        });

        scope.$watch(function () {
            return element.attr('data-isRequired');
        }, function (newValue, oldValue) {
            if (newValue !== oldValue) {
                readConfigValidation(scope, element, attributes, true);
            }
        });
    }

    return {
        restrict: 'A',
        scope: {
            cuvConfig: '=',
            modelValue: '=ngModel'
        },
        controller: ['$scope', customValidationController],
        link: customValidationLink
    };
};

module.exports = customValidation;