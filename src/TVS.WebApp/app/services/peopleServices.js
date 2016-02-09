(function () {
    'use strict';
    var personServices = angular.module('peopleServices', ['ngResource', 'ngMaterial', 'angularMoment']);

    
    personServices.factory('NewTenant', ['$resource',
     function ($resource) {
         return $resource('/api/Tenant/', {}, {
             query: { method: 'GET', params: { role: 'Tenant' }, isArray: false }
         });
     }]);

    personServices.factory('SaveTenant', ['$http', '$q',
      function ($http, $q) {
          return function (person) {

              var deferredObject = $q.defer();

              $http.post(
                  '/api/Tenant', person
              ).
              success(function (data) {
                  if (data == true) {
                      deferredObject.resolve({ success: true });
                  } else {
                      deferredObject.resolve({ success: false });
                  }
              }).
              error(function () {
                  deferredObject.resolve({ success: false });
              });

              return deferredObject.promise;
          }
      }]);





    personServices.factory('NewLandlord', ['$resource',
     function ($resource) {
         return $resource('/api/Landlord/', {}, {
             query: { method: 'GET', params: { role: 'Landlord' }, isArray: false }
         });
     }]);

    personServices.factory('SaveLandlord', ['$http', '$q',
      function ($http, $q) {
          return function (person) {

              var deferredObject = $q.defer();

              $http.post(
                  '/api/Landlord', person
              ).
              success(function (data) {
                  if (data == true) {
                      deferredObject.resolve({ success: true });
                  } else {
                      deferredObject.resolve({ success: false });
                  }
              }).
              error(function () {
                  deferredObject.resolve({ success: false });
              });

              return deferredObject.promise;
          }
      }]);


    personServices.factory('SaveLandlords', ['$http', '$q',
      function ($http, $q) {
          return function (landlords) {

              var deferredObject = $q.defer();
              
              for (var i = 0; i < landlords.length; i++) {

                  $http.post(
                          '/api/Landlord', landlords[i]
                      ).
                      success(function(data) {
                          if (data == true) {
                              deferredObject.resolve({ success: true });
                          } else {
                              deferredObject.resolve({ success: false });
                          }
                      }).
                      error(function() {
                          deferredObject.resolve({ success: false });
                      });

              }

              return deferredObject.promise;
          }
      }]);

    personServices.factory('SaveTenants', ['$http', '$q',
     function ($http, $q) {
         return function (tenants) {

             var deferredObject = $q.defer();

             for (var i = 0; i < tenants.length; i++) {

                 $http.post(
                         '/api/Tenant', tenants[i]
                     ).
                     success(function (data) {
                         if (data == true) {
                             deferredObject.resolve({ success: true });
                         } else {
                             deferredObject.resolve({ success: false });
                         }
                     }).
                     error(function () {
                         deferredObject.resolve({ success: false });
                     });

             }

             return deferredObject.promise;
         }
     }]);

})();