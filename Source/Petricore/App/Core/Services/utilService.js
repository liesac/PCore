function utilService() {


    var getYesOrNoList = function () {
        return [{
            id: 1,
            value: true,
            text: 'Yes'
        }, {
            id: 0,
            value: false,
            text: 'No'
        }];
    };



    var getmonthList = function () {
        return [{
            id: 1,
            value: 'Jan',
            text: 'January'
        }, {
            id: 2,
            value: 'Feb',
            text: 'February'
        }, {
            id: 3,
            value: 'Mar',
            text: 'March'
        }, {
            id: 4,
            value: 'Apr',
            text: 'April'
        }, {
            id: 5,
            value: 'May',
            text: 'May'
        }, {
            id: 6,
            value: 'Jun',
            text: 'June'
        }, {
            id: 7,
            value: 'Jul',
            text: 'July'
        }, {
            id: 8,
            value: 'Aug',
            text: 'August'
        }, {
            id: 9,
            value: 'Sep',
            text: 'September'
        }, {
            id: 10,
            value: 'Oct',
            text: 'October'
        }, {
            id: 11,
            value: 'Nov',
            text: 'November'
        }, {
            id: 12,
            value: 'Dec',
            text: 'December'
        }];
    };


    return {
        getYesOrNoList: getYesOrNoList,
        getmonthList: getmonthList
    };
}

utilService.$inject = [];

module.exports = utilService;