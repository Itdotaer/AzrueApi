(function () {
    var app = angular.module('InterestingThings');

    var allUsersController = function ($scope, $state, userService, logger) {
        $scope.isLoading = true;

        $scope.dblClick = function (userId) {
            $state.go('users.getUser', { id: userId });
        };

        $scope.deleteUser = function (userId) {
            logger.log("Deleting user by its id[" + userId + "].");
            userService.deleteUser(userId).then(function (data) {
                $scope.users = [];
                $scope.getAllUsers();
                logger.log("Deleting user by its id[" + userId + "].");
            }, function(reason) {
                logger.logError(reason);
            });
        };

        $scope.selected = function(userId) {
            $scope.selectedRowId = userId;
        };

        logger.log("Getting all users from db.");
        userService.getAllUsers().then(function (data) {
            $scope.users = data;
            logger.log("Got all users from db.");
            $scope.isLoading = false;
        }, function (reason) {
            logger.logError(reason);
        });
    }

    app.controller('allUsersController', allUsersController);
})();