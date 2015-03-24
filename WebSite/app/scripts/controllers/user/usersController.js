(function () {
    var app = angular.module('InterestingThings');

    var usersController = function ($scope, userService, sysSettings, logger) {
        $scope.baseUrl = sysSettings.BaseUrl();
        $scope.logList = logger.logList;
    }

    app.controller('usersController', usersController);
})();