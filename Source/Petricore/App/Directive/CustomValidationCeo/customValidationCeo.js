var customValidationCeo = function ($compile) {

    return {
        restrict: 'A',
        replace: false,
        terminal: true,
        priority: 1000,
        link: function link(scope, element, attributes) {

            if (attributes.cuvConfig == undefined) {
                element.attr('cuv-config', 'configCustomValidation');
            }

            if (attributes.ngClass == undefined) {
                element.attr('ng-class', ' markedAsRequired("' + attributes.id + '") == true ? "required" : ""');
            }

            if (attributes.uiValidate == undefined) {
                element.attr('ui-validate', '{taken : "validation($value, \'' + attributes.id + '\')"}');
            }

            if (attributes.name == undefined) {
                element.attr('name', attributes.id);
            }

            if (attributes.customValidation == undefined) {
                element.attr('custom-Validation', '');
            }

            if (attributes.disableMessage == undefined || attributes.disableMessage == false) {
                var idExpresion = attributes.id;
                if (idExpresion.indexOf('{{') != -1) {
                    idExpresion = idExpresion.replace('}}', '');
                    var res = idExpresion.split('{{');
                    idExpresion = '("' + res[0] + '"+' + res[1] + ')';
                } else {
                    idExpresion = '("' + idExpresion + '")';
                }

                var elementError = $('<span ng-show="markedAsRequired(\'' +
                    attributes.id +
                    '\') == true" class="required">{{configValidation[' +
                    idExpresion +
                    '].messageError}}</span>');

                elementError.insertAfter(element);
                $compile(elementError)(scope);
            }

            element.removeAttr('custom-validation-ceo'); //remove the attribute to avoid indefinite loop
            element.removeAttr('data-custom-validation-ceo');

            $compile(element)(scope);
        }
    };
};
customValidationCeo.$inject = ['$compile'];
module.exports = customValidationCeo;