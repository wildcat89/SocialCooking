'use strict';
app.factory('tokensManagerService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {

    var serviceBase = ngAuthSettings.apiServiceBaseUri;

    var tokenManagerServiceFactory = {};

    var getRefreshTokens = function () {

        return $http.get(serviceBase + 'api/refreshtokens').then(function (results) {
            return results;
        });
    };

    var deleteRefreshTokens = function (tokenid) {

        return $http.delete(serviceBase + 'api/refreshtokens/?tokenid=' + tokenid).then(function (results) {
            return results;
        });
    };

    tokenManagerServiceFactory.deleteRefreshTokens = deleteRefreshTokens;
    tokenManagerServiceFactory.getRefreshTokens = getRefreshTokens;

    return tokenManagerServiceFactory;

}]);