var app = angular.module('socialCookingApp', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar']);
app.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "/app/home/views/home.html"
    });

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/app/auth/views/login.html"
    });

    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "/app/auth/views/signup.html"
    });

    $routeProvider.when("/tokens", {
        controller: "tokensManagerController",
        templateUrl: "/app/auth/views/tokens.html"
    });

    $routeProvider.when("/associate", {
        controller: "associateController",
        templateUrl: "/app/auth/views/associate.html"
    });


    $routeProvider.otherwise({ redirectTo: "/home" });
});
app.constant('ngAuthSettings', {
    apiServiceBaseUri: 'http://localhost:82/',
    clientId: 'ngApp'
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);