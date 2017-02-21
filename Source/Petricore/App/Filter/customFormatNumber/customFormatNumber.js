var customFormatNumberFilter = function () {
    // The format parameter must represent the NO separator chacarter as 'X'

    return function (data, format) {

        if (data == undefined) {
            return data;
        } else {
            var indexData = 0;
            var result = '';

            for (var i = 0; i < format.length; i++) {
                if (format[i] === 'X') {
                    result += data[indexData] ? data[indexData] : '';
                    indexData++;
                } else {
                    if (i < data.length) {
                        result += format[i];
                    }
                }
            }
        }
        return result;
    };
};

module.exports = customFormatNumberFilter;