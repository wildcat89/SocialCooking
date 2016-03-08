'use strict';
app.factory('dishService', ['$http', function ($http) {
    var serviceBase = 'http://localhost:82/api/dish/', factory = {};

    factory.addDish = function(dish) {
        return $http.post(serviceBase + 'addDish/', dish).then(function(results) {
            return results.data;

        });
    }

    return factory;
}]);