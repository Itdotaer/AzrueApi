var userService = function ($http, sysSettings, dataContext) {
    var getAllUsers = function () {
        return $http.get(sysSettings.BaseUrl() + "/api/Users", {
            headers: {
                'Content-Type':'application/json'
            }
        }).then(function(res) {
            return res.data;
        });

        //return dataContext.getUser();
    };

    var getUserById = function (id) {
        return $http.get(sysSettings.BaseUrl() + "/api/Users/"+ id).then(function(res) {
            return res.data;
        });

        //return dataContext.getUser(id).then(function (res) {
        //    return res;
        //});
    };

    var addUser = function(user) {
        return $http.post(sysSettings.BaseUrl() + "/api/Users", JSON.stringify(user), {
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(function (response) {
                return response.data;
            });
    };

    var updateUser = function (user) {
        return $http.put(sysSettings.BaseUrl() + "/api/Users/" + user.Id, JSON.stringify(user), {
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(function(res) {
            return res.data;
        });
    };

    var deleteUser = function(userId) {
        return $http.delete(sysSettings.BaseUrl() + "/api/Users/" + userId, {
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(function (response) {
            return response.data;
        });
    };

    return {
        getAllUsers: getAllUsers,
        getUserById: getUserById,
        addUser: addUser,
        updateUser: updateUser,
        deleteUser: deleteUser
    };
};

var app = angular.module('InterestingThings');
app.factory("userService", userService);