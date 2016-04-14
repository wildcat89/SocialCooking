    var app = angular.module('socialCookingApp', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar', 'ngFileUpload']);
    app.config(function ($routeProvider) {
        var appBaseUri = 'http://localhost/SocialCooking.Web';
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

        $routeProvider.when("/profile", {
            controller: "profileDetailsController",
            templateUrl: appBaseUri + "/app/profile/views/ProfileDetails.html",
            controllerAs: 'vm'
        });

        $routeProvider.otherwise({ redirectTo: "/home" });
    });
    //app.constant('ngAuthSettings', {
    //    appBaseUri: 'http://kduszynski.pl/socialcooking',
    //    apiServiceBaseUri: 'http://socialcookingapi.azurewebsites.net/',
    //    clientId: 'ngApp'
    //});

    app.constant('ngAuthSettings', {
        appBaseUri: 'http://localhost/SocialCooking.Web',
        apiServiceBaseUri: 'http://localhost:82/',
        clientId: 'ngApp'
    });

    app.config(function ($httpProvider, $compileProvider) {
        $httpProvider.interceptors.push('authInterceptorService');
        $compileProvider.imgSrcSanitizationWhitelist(/^\s*(https?|local|data|file):/);
    });

    app.run(['authService', function (authService) {
        authService.fillAuthData();
    }]);