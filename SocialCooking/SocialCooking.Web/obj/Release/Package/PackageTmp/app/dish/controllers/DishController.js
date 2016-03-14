'use strict';
app.controller('dishController', ['$scope', '$location', 'authService', 'dishService', function ($scope, $location, authService, dishService) {
    $scope.authentication = authService.authentication;

    $scope.dish = {};
    $scope.difficultyLevels = {};
    $scope.categories = {};

    function init(

        ) { }

    init();

    $scope.addDish = function () {
        if ($scope.editForm.$valid) {
            dishService.addDish($scope.dish).then(function (results) { }, function (data, status, headers, config) { });
        }
    }
}]);