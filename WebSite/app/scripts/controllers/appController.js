(function () {
    var app = angular.module('InterestingThings');

    var appController = function ($scope) {
        var now = new Date();
        $scope.sysYear = now.getFullYear();
    }

    app.controller('appController', appController);
})();