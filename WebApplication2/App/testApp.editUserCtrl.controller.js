(function () {

    angular.module('testApp').controller("editUserCtrl", editUserCtrl);

    function editUserCtrl($scope, $stateParams, $state, userSportComplex) {
        var userId = $stateParams.id;

        $scope.user = userSportComplex.get({ id: userId });

        $scope.saveSportComplex = function(user) {
            user.$save(function() {
                $state.go('list');
            });

        }
    }
})();