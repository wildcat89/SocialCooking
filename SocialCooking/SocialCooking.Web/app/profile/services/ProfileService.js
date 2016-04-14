'use strict';
app.factory('profileService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {
    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var profileService = {};

    var getProfileById = function (userId) {

        return $http.get(serviceBase + 'api/profile/' + userId).then(function (results) {
            return results;
        });
    };
   

    profileService.getProfileById = getProfileById;

    return profileService;

}]);