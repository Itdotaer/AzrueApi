(function () {
    var app = angular.module('InterestingThings');

    var userController = function($scope, $state, $stateParams, userService, sysSettings, logger, DEBUG) {
        $scope.baseUrl = sysSettings.BaseUrl();
        $scope.user = {};
        $scope.isLoading = false;

        //Local private methods
        var getUser = function(id) {
            $scope.user = {};
            logger.log("Getting user by its id[" + id + "].");
            userService.getUserById(id).then(function(data) {
                $scope.user = data;
                logger.log("Got user by its id[" + id + "].");
                $scope.isLoading = false;
            }, function(reason) {
                console.logError(reason);
                $scope.isLoading = false;
            });
        };

        $scope.currentState = $state.current.name;
        var userId = $stateParams["id"];
        switch ($scope.currentState) {
        case "users.addUser":
            //Add user
            if (DEBUG === true)logger.log("Go to add user");
            $scope.user = {};

            break;
        case "users.updateUser":
            $scope.isLoading = true;
            logger.log("Go to update user");
            //Update user
            if (userId) {
                getUser(userId);
            } else {
                console.log("No user id.");
            }
            break;

        case "users.getUser":
            //console.log("Get user");
            $scope.isLoading = true;
            logger.log("Go to get user by id");
            //Get user
            if (userId) {
                getUser(userId);
            } else {
                logger.logError("No user id");
            }
            break;
        default:
            logger.logError("Nothing!(State:" + $scope.currentState + ")");
            break;
        };

        $scope.addUser = function() {
            if ($scope.user) {
                //console.log($scope.user);
                logger.log("Adding user");
                userService.addUser($scope.user).then(function(data) {
                    $scope.user = data;
                    logger.log("Add user successed");
                }, function(reason) {
                    logger.logError(reason);
                    //console.log(reason);
                });
            }
        };

        $scope.resetUser = function() {
            logger.log("Reseting user");
            $scope.user = {};
            logger.log("Reset user successed");
        };

        $scope.updateUser = function() {
            //console.log("Come");
            if ($scope.user) {
                logger.log("Updating user");
                userService.updateUser($scope.user).then(function(data) {
                    logger.log("Update user successed");
                    getUser($scope.user.Id);
                    $state.go("users.getUsers");
                }, function(reason) {
                    logger.logError(reason);
                });
            }
        };
    };

    app.controller('userController', userController);
})();