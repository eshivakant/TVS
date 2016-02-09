(function () {
    'use strict';

    angular
        .module('tvsApp')
        .controller('landlordController', landlordController);
        
    landlordController.$inject = ['$scope', 'NewLandlord', 'NewTenant', 'SaveLandlord', 'SaveTenants'];

    function landlordController($scope, NewLandlord, NewTenant, SaveLandlord, SaveTenants) {
       
        $scope.newPerson = NewLandlord.query();
        $scope.registrationFailure = false;
        $scope.registrationSuccess = false;

        $scope.savePerson=function(person) {
            SaveLandlord(person)
            .then(function (result) {
                if (result.success) {
                    $scope.registrationSuccess = true;
                    $scope.registrationFailure = false;
                    for (var i = 0; i < person.AddressOwnerships.length; i++) {
                        person.AddressOwnerships[i].previousTenant = NewTenant.query();
                        person.AddressOwnerships[i].rent = 0;
                    }
                } else {
                    $scope.registrationSuccess = false;
                    $scope.registrationFailure = true;
                }
            });

        }

        $scope.savePreviousTenants = function (person) {
            var tenants = [];
            for (var i = 0; i < person.AddressOwnerships.length; i++) {
                var tenant = person.AddressOwnerships[i].previousTenant;
                tenant.AddressOwnerships = [];
                tenant.PlaceOfBirth = "NA";
                $scope.addNewAddressOccupation(tenant, person.AddressOwnerships[i].Address, person.AddressOwnerships[i].OwnedFrom, person.AddressOwnerships[i].OwnedTo, person.AddressOwnerships[i].rent);
                tenants.push(tenant);
            }

            SaveTenants(tenants)
               .then(function (result) {
                   if (result.success) {
                       $scope.registrationSuccess = true;
                       $scope.registrationFailure = false;
                       window.location = "/Home/LandlordHome";
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


        $scope.addNewAddressOccupation = function (person, address, occupiedFrom, occupiedTo, rent) {
            var newOccupation = new function () {
                this.OccupiedFrom = occupiedFrom;
                this.OccupiedTo = occupiedTo;
                this.Rent = rent;
                this.Address = address;
            }

            person.AddressOccupations.push(newOccupation);

        }


        $scope.addNewAddressOwnership = function () {
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
