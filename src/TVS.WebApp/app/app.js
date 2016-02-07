(function () {

    'use strict';

    angular.module('tvsApp', ['peopleServices'])

        .config(function($mdDateLocaleProvider) {
            $mdDateLocaleProvider.formatDate = function(date) {
                return moment(date).format('DD-MM-YYYY');
            };
        

        $mdDateLocaleProvider.parseDate = function(dateString) {
            var m = moment(dateString, 'DD-MM-YYYY', true);
            return m.isValid() ? m.toDate() : new Date(NaN);
        };
    });

})();