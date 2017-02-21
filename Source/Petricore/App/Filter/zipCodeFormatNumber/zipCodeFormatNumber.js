var zipCodeFormatNumber = function () {
    // The format parameter must represent the NO separator chacarter as 'X'

    return function (input) {

        if (!input) {
            return input;
        }
        if (input.toString().length === 9) {
            return input.toString().slice(0, 5) + '-' + input.toString().slice(5);
        } else if (input.toString().length === 5) {
            return input.toString();
        } else {
            return input;
        }
    };
};

module.exports = zipCodeFormatNumber;