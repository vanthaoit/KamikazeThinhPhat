/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('kamikazeThinhPhat',
                    [
                    'kamikazeThinhPhat.slides',
                    'kamikazeThinhPhat.products',
                    'kamikazeThinhPhat.product_categories',
                    'kamikazeThinhPhat.common'])
                    .config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('base', {
            url: '',
            templateUrl: '/app/shared/views/baseView.html',
            abstract: true
        })
        .state(
            "home",{
                url: "/admin",
                parent: "base",
                templateUrl: "/app/components/home/homeView.html",
                controller:"homeController"
            });
        $urlRouterProvider.otherwise("/admin");
    }
})();