(function () {
    'use strict';

    angular
        .module('tvsApp')
        .controller('landlordController', landlordController);
        
    landlordController.$inject = ['$scope', 'NewLandlord','SaveLandlord'];

    function landlordController($scope, NewLandlord, SaveLandlord) {
       
        $scope.newPerson = NewLandlord.query();
        $scope.registrationFailure = false;
        $scope.registrationSuccess = false;

        $scope.savePerson=function(person) {
            SaveLandlord(person)
            .then(function (result) {
                if (result.success) {
                    $scope.registrationSuccess = true;
                    $scope.registrationFailure = false;
                } else {
                    $scope.registrationSuccess = false;
                    $scope.registrationFailure = true;
                }
            });

        }

        $scope.reset=function() {
             $scope.registrationSuccess = false;
             $scope.registrationFailure = false;
             $scope.$apply();
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

            var newOwnership= new function() {
                this.OwnedFrom = $scope.addNewAddressOccpationOwnedFrom;
                this.OwnedTo = $scope.addNewAddressOwnershipOwnedTo;
                this.Address = newAddress;
            }

            $scope.newPerson.AddressOwnerships.push(newOwnership);
            
        }
    }
})();
