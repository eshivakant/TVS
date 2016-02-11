(function () {
    'use strict';

    angular
        .module('tvsApp')
        .controller('landlordDashboardController', landlordDashboardController);
        
    landlordDashboardController.$inject = ['$scope'];

    function landlordDashboardController($scope) {
       
        $scope.verifyTenants=function() {
            window.location = "/Reviews/Tenant";
        }
    }
})();
