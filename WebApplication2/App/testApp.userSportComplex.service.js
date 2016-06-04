(function () {

    angular.module('testApp').factory('userSportComplex', function ($resource) {
        return $resource('/api/userSportComplex/:id', { id: '@Id' });
    });

})();