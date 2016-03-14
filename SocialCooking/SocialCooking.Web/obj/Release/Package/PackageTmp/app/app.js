    var app = angular.module('socialCookingApp', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar']);
    app.config(function ($routeProvider) {
        var appBaseUri = 'http://kduszynski.pl/socialcooking';
        $routeProvider.when("/home", {
            controller: "homeController",
            templateUrl: appBaseUri+"/app/home/views/home.html"
        });

        $routeProvider.when("/login", {
            controller: "loginController",
            templateUrl: appBaseUri+"/app/auth/views/login.html"
        });

        $routeProvider.when("/signup", {
            controller: "signupController",
            templateUrl: appBaseUri+"/app/auth/views/signup.html"
        });

        $routeProvider.when("/tokens", {
            controller: "tokensManagerController",
            templateUrl: appBaseUri+"/app/auth/views/tokens.html"
        });

        $routeProvider.when("/associate", {
            controller: "associateController",
            templateUrl: appBaseUri+"/app/auth/views/associate.html"
        });

        $routeProvider.when("/dish", {
            controller: "dishController",
            templateUrl: appBaseUri+"/app/dish/views/addDish.html"
        });

        $routeProvider.otherwise({ redirectTo: "/home" });
    });
    app.constant('ngAuthSettings', {
        appBaseUri: 'http://kduszynski.pl/socialcooking',
        apiServiceBaseUri: 'http://socialcookingapi.azurewebsites.net/',
        clientId: 'ngApp'
    });

    app.config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptorService');
    });

    app.run(['authService', function (authService) {
        authService.fillAuthData();
    }]);