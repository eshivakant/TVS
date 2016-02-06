(function () {
    'use strict';
    var booksServices = angular.module('peopleServices', ['ngResource']);

    booksServices.factory('NewPerson', ['$resource',
      function ($resource) {
          return $resource('/api/Person/', {}, {
              query: { method: 'GET', params: {role:'Tenant'}, isArray: false }
          });
      }]);

})();