(function () {
    'use strict';
    var booksServices = angular.module('peopleServices', ['ngResource', 'ngMaterial', 'angularMoment']);

    booksServices.factory('NewPerson', ['$resource',
      function ($resource) {
          return $resource('/api/Person/', {}, {
              query: { method: 'GET', params: {role:'Tenant'}, isArray: false }
          });
      }]);

})();