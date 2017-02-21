require('./styles.scss');

function AutocompleteB() {

    return {

        template: require('html!../CustomAutocompleteB/template.html'),
        restrict: 'E',
        scope: {
            id: '@',
            ngModel: '=',
            apiConfig: '=',
            placeholder: '@',
            minLength: '@',
            maxLength: '@',
            isRequired: '@',
            typeValidation: '@',
            configValidation: '=',
            configCustomValidation: '=',
            validation: '=',
            markedAsRequired: '=',
            selectedObject: '=',
            inputChanged: '=',
            modelValue: '=ngModel',
            apiObject: '=?'
        },

        controller: require('./controller'),
        require: 'ngModel'
    };
}

AutocompleteB.$inject = [];

module.exports = AutocompleteB;