'use strict';
function HeaderCtrl($log) {
    var self = this;

    self.$onInit = function(){
        init();
    };
    var init = function() {
        $log.info('header ',self.first, self);
    };
}

HeaderCtrl.$inject = ['$log'];

require('./header.scss');

var HeaderComponent = {
    bindings: {
        first: '@'
    },
    template: require('html!./header.html'),
    controller: HeaderCtrl

};

module.exports = HeaderComponent;
