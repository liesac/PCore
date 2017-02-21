function utilObjectService() {

    var cloneObject = function (dataObj) {
        var cloneDataObj = JSON.stringify(dataObj);
        var cloneDataObj = JSON.parse(cloneDataObj);
        return cloneDataObj;
    };

    return {
        cloneObject: cloneObject
    };
}

module.exports = utilObjectService;