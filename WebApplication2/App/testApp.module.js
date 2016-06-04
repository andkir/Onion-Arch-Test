(function () {

    var app = angular.module("testApp", ['ui.router', 'ngResource']);

    app.config(function ($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise("/list");

        $stateProvider
          .state('list', {
              url: "/list",
              templateUrl: "../App/templates/list.html",
              controller: 'listUserCtrl'
          })
         .state('edit', {
              url: "/edit/:id",
              templateUrl: "../App/templates/edit.html",
              controller: 'editUserCtrl'
          });
    });

})();