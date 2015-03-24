var userService = function($http) {
    var userLogin = function(user) {
        return $http.post("http://forceful-fireball-82-165054.apne1.nitrousbox.com/api/user/login", "userName="+user.userName+"&password="+user.password, {
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            }
        }).then(function (res) {
            return res.data;
        });

        //var req = {
        //    method: 'POST',
        //    url: 'http://forceful-fireball-82-165054.apne1.nitrousbox.com/api/user/login',
        //    headers: {
        //        'Content-Type': 'application/x-www-form-urlencoded'
        //    },
        //    data: 'myData='+JSON.stringify(user),
        //}

        //return $http(req).then(function(res) {
        //    return res.data;
        //});
    };

    var admin = function() {
        return $http.get("http://forceful-fireball-82-165054.apne1.nitrousbox.com/api/user/admin").then(function(res) {
            return res.data;
        });
    };

    return {
        userLogin: userLogin,
        admin: admin
    };
};

var app = angular.module('InterestingThings');
app.factory("userService", userService);