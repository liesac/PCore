function onlyNumbers () {
    return {
        restrict: 'A',
        link: function (scope, element, attrs)
        {
            var transformText = function (text)
            {
                var tres = -1;
                var result = '';
                for (var i = text.length - 1; i >= 0; i--)
                {
                    tres++;
                    if (tres === 3)
                    {
                        result += ',' + text[i];
                        tres = 0;
                    }
                    else
                    {
                        result += text[i];
                    }
                }
                return result.split('').reverse().join('');
            };
            element.on('keypress', function (event)
            {
                var text = event.currentTarget.value;
                var indexPoint = text.indexOf('.');
                var indexMinus = text.indexOf('-');
                //fin scespedesz
                if (attrs.onlyNumbers.indexOf('minus') !== -1)
                {
                    //fin scespedesz
                    if (text.length === 0 && (event.which < 48 || event.which > 57) && event.which !== 46 && event.which !== 45)
                    {
                        event.preventDefault();
                        return;
                    }
                    if ((event.which < 48 || event.which > 57) && event.which !== 46 && text.length > 0)
                    {
                        event.preventDefault();
                        return;
                    }
                } else{
                    //Start murregop: se agrega el caso para no permitir valores negativos en el input asociado
                    if (attrs.onlyNumbers.indexOf('onlyPositive') !== -1)
                    {
                        if (event.which < 48 || event.which > 57){
                            return false;
                        }
                        return true;
                    } //End murregop: se agrega el caso para no permitir valores negativos en el input asociado
                    else {
                        if ((event.which < 48 || event.which > 57) && event.which !== 46)
                        {
                            event.preventDefault();
                            return;
                        }
                    }
                }

                if (indexMinus >= 0 && event.which === 45)
                {
                    event.preventDefault();
                    return;
                }
                if (indexPoint < 0)
                {
                    if (text.length >= 10)
                    {
                        if (48 <= event.which && event.which <= 57)
                        {
                            event.preventDefault();
                            return;
                        }
                    }
                }
                else
                {
                    var integerDigits = text.substring(0, indexPoint);
                    var decimalDigits = text.substring(indexPoint + 1, text.length);
                    if (integerDigits.length === 10 && decimalDigits.length === 2)
                    {
                        event.preventDefault();
                        return;
                    }
                    else
                    {
                        if (48 <= event.which && event.which <= 57)
                        {
                            return;
                        }
                    }
                }
                if (indexPoint < 0)
                {
                    if (text.length >= 11)
                    {
                        event.preventDefault();
                        return;
                    }
                }
                else
                {
                    var integer = text.substring(0, indexPoint);
                    if (integer.length >= 11)
                    {
                        event.preventDefault();
                        return;
                    }
                }
            });
            element.on('keyup', function (event)
            {
                if (attrs.onlyNumbers.indexOf('currency') !== -1)
                {
                    if (event.which >= 96 && event.which <= 105 || event.which >= 48 && event.which <= 57 ||
                        event.which === 110 || event.which === 8 || event.which === 46)
                    {
                        var cursor = event.currentTarget.selectionStart;
                        var text = event.currentTarget.value;
                        var comaCountInital = (text.match(/,/g) || []).length;
                        text = text.replace(/,/g, '');
                        var indexMinus = text.indexOf('-');
                        var hasMinus = false;
                        if (indexMinus >= 0)
                        {
                            text = text.replace(/-/g, '');
                            hasMinus = true;
                        }
                        var indexPoint = text.indexOf('.');
                        if (indexPoint >= 0)
                        {
                            text =
                                transformText(text.substring(0, indexPoint)) + '.' + text.substring(indexPoint + 1, indexPoint + 3);
                        }
                        else
                        {
                            text = transformText(text);
                        }
                        if (hasMinus)
                        {
                            text = '-' + text;
                        }
                        var finalComaCount = (text.match(/,/g) || []).length;
                        if (comaCountInital !== finalComaCount && !(event.which === 8 || event.which === 46))
                        {
                            cursor++;
                        }
                        event.currentTarget.value = text;
                        event.currentTarget.selectionStart = event.currentTarget.selectionEnd = cursor;
                    }
                }
            });
            element.on('paste', function (event)
            {
                event.preventDefault();
            });
        }
    };
}

onlyNumbers.inject = [''];

module.exports = onlyNumbers;

