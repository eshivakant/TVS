(function () {
    'use strict';

    angular
        .module('tvsApp')
        .controller('peopleController', peopleController);

    peopleController.$inject = ['$scope', 'NewPerson'];

    function peopleController($scope, NewPerson) {
       
        $scope.newPerson = NewPerson.query();
    }
})();
