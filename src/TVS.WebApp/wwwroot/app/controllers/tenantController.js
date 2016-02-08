(function () {
    'use strict';

    angular
        .module('tvsApp')
        .controller('tenantController', tenantController);
        
    tenantController.$inject = ['$scope', 'NewTenant','NewLandlord', 'SaveTenant'];

    function tenantController($scope, NewTenant,NewLandlord, SaveTenant) {
       
        $scope.newPerson = NewTenant.query();
        $scope.registrationFailure = false;
        $scope.registrationSuccess = false;

        $scope.savePerson=function(person) {
            SaveTenant(person)
            .then(function (result) {
                if (result.success) {
                    $scope.registrationSuccess = true;
                    $scope.registrationFailure = false;
                    for (var i = 0; i < person.AddressOccupations.length; i++) {
                        person.AddressOccupations[i].previousLandlord = NewLandlord.query();
                    }

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

            var newOccpuation= new function() {
                this.OccupiedFrom = $scope.addNewAddressOccpationOccupiedFrom;
                this.OccupiedTo = $scope.addNewAddressOccpationOccupiedTo;
                this.Address = newAddress;
            }

            $scope.newPerson.AddressOccupations.push(newOccpuation);
            
        }
    }
})();
