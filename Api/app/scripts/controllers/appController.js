(function () {
    var app = angular.module('InterestingThings');

    var appController = function ($scope) {
        var now = new Date();
        $scope.sysYear = now.getYear();
        console.log(now);
    }

    app.controller('appController', appController);
}());