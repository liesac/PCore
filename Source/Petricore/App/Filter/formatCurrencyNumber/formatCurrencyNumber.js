var formatCurrencyNumberFilter = function () {
    /**
     * @params float number: number for apply filter
     * @params char thousandsSeparator: character for thousand separator
     * @params char decimalSeparator: character for decimal separator
     * @params int numberDecimals: number of decimals for displaying
     * @params char currencySymbol: currency to be displayed
     * @params blank char symbolSep: blank space between currencySymbol and number
     * @params boolean takeSymbolSep: boolean for choose if symbolSep apply
     *                  -> true: dont apply symbolSep, false: apply symbolSep
     * @param boolean inFront: display currencySymbol in front or behind of the number
     */
    return function (number, numberDecimals, thousandsSeparator, decimalSeparator, currencySymbol, symbolSep,
                     takeSymbolSep, inFront) {
        thousandsSeparator = thousandsSeparator || ',';
        decimalSeparator = decimalSeparator || '.';
        currencySymbol = currencySymbol || '';
        symbolSep = symbolSep || '';
        takeSymbolSep = takeSymbolSep || false;

        if (number == undefined) {
            return number;
        }

        if (numberDecimals != undefined && number != undefined) {
            number = parseFloat(number).toFixed(numberDecimals);
        }

        if (takeSymbolSep) {
            symbolSep = '';
        }

        return (function (num) {
            num += '';
            var splitStr = num.split('.');
            var splitLeft = splitStr[0];
            var splitRight = '';
            if (splitStr.length > 1) {
                splitRight = decimalSeparator + splitStr[1];
            }

            var regx = /(\d+)(\d{3})/;
            while (regx.test(splitLeft)) {
                splitLeft = splitLeft.replace(regx, '$1' + thousandsSeparator + '$2');
            }

            if (inFront) {
                return currencySymbol + symbolSep + splitLeft + splitRight;
            } else {
                return splitLeft + splitRight + symbolSep + currencySymbol;
            }

        })(number);

    };
};

module.exports = formatCurrencyNumberFilter;