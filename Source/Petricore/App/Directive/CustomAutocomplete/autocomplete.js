require('./styles.scss');

function Autocomplete() {

    function link(scope, element, attrs, ngModel) {

        var inputField = element.find('input');
        var dataList = element.find('datalist');

        inputField.on('input', onSelected);
        inputField.on('change', onChanged);

        function onSelected() {
            var options = dataList[0].options;
            var val = inputField.val();
            scope.idSelected = '';
            for (var i = 0; i < options.length; i++) {

                if (options[i].value === val) {
                    scope.idSelected = options[i].id;
                    if (scope.selectedObject != undefined) {
                        scope.selectedObject(scope.idSelected);
                    }
                    break;
                }
            }
        }

        function onChanged() {
            if (scope.idSelected == '') {
                inputField.val('');
                scope.idEntity = '';
            }
            ngModel.$setViewValue(scope.idSelected);
        }
    }


    return {

        template: require('html!../CustomAutocomplete/template.html'),
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
            inputChanged: '='

        },

        controller: require('./controller'),
        link: link,
        require: 'ngModel'
    };
}

Autocomplete.$inject = [];

module.exports = Autocomplete;