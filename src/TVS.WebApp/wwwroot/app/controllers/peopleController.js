(function () {
    'use strict';

    angular
        .module('tvsApp')
        .controller('peopleController', peopleController);

    peopleController.$inject = ['$scope', 'NewPerson','SavePerson'];

    function peopleController($scope, NewPerson, SavePerson) {
       
        $scope.newPerson = NewPerson.query();

        $scope.savePerson=function(person) {
            var result = SavePerson(person);

        }

        $scope.addNewAddressOccpation = function () {
            var newAddress = new function () {
                this.AddressLine1 = $scope.newAddressLine1;
                this.AddressLine2 = $scope.newAddressLine2;
                this.AddressLine3 = $scope.newAddressLine3;
                this.City = $scope.newCity;
                this.State = $scope.newState;
                this.PostCode = $scope.newPostCode;
            }

            var newOccpuation= new function() {
                this.OccupiedFrom = $scope.addNewAddressOccpationOccupiedFrom;
                this.OccupiedTo = $scope.addNewAddressOccpationOccupiedTo;
                this.Address = newAddress;
            }

            $scope.newPerson.AddressOccupations.push(newOccpuation);
            
        }
    }
})();
