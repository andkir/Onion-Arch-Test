(function () {

    angular.module('testApp').controller("listUserCtrl", sportCtrl);

    function sportCtrl($scope, userSportComplex) {
        $scope.users = userSportComplex.query();
    }
})();