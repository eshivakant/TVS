(function () {
    'use strict';
    var personServices = angular.module('peopleServices', ['ngResource', 'ngMaterial', 'angularMoment']);

    personServices.factory('NewPerson', ['$resource',
      function ($resource) {
          return $resource('/api/Tenant/', {}, {
              query: { method: 'GET', params: {role:'Tenant'}, isArray: false }
          });
      }]);

    personServices.factory('SavePerson', ['$http', '$q',
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
})();