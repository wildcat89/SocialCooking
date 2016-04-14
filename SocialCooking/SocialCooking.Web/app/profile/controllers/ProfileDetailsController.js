'use strict';
app.controller('profileDetailsController', ['$routeParams', '$scope', 'authService', 'profileService', 'Upload', 'ngAuthSettings', function ($routeParams, $scope, authService, profileService, Upload, ngAuthSettings) {
    var vm = this;
    vm.authentication = authService.authentication;
    var profileId = $routeParams;
    vm.profile = {};
     

    function init() {
        profileService.getProfileById(vm.authentication.userName).then(function(results) {
            vm.profile = results.data;
        }, (function(data, status, headers, config) {
            alert(data + " status: " + status);
        }));
    }

    init();

    vm.upload = function (file) {Upload.upload({
        url: ngAuthSettings.apiServiceBaseUri + '/api/profile/UploadImage',
        method: "POST",
        file: file,
        data: { "username": vm.authentication.userName }
    }).progress(function(evt) {
        // get upload percentage
        console.log('percent: ' + parseInt(100.0 * evt.loaded / evt.total));
    }).success(function(data, status, headers, config) {
        // file is uploaded successfully
        console.log(data);
        profileService.getProfileById(vm.authentication.userName).then(function (results) {
            vm.profile = results.data;
        }, (function (data, status, headers, config) {
            alert(data + " status: " + status);
        }));
    }).error(function(data, status, headers, config) {
        // file failed to upload
        console.log(data);
    });}
}]);