function CustomUppercase() {

    return {
        restrict: 'A',
        require: 'ngModel',
        link: function (scope, element, attrs, modelCtrl) {
            var uppercase = function (inputValue) {
                if (inputValue != undefined) {
                    var input = inputValue.toUpperCase();
                    modelCtrl.$setViewValue(input);
                    modelCtrl.$render();
                    return input;
                }
            };
            modelCtrl.$parsers.push(uppercase);
            scope[attrs.ngModel] = uppercase(scope[attrs.ngModel]); // capitalize initial value
        }
    };
}

CustomUppercase.$inject = [];

module.exports = CustomUppercase;