var app = angular.module('InterestingThings', ['ui.router', 'ui.bootstrap', 'breeze.angular', 'angularFileUpload', 'InterestingThings.users']);

//app.config(['$httpProvider', function($httpProvider) {

//    $httpProvider.defaults.useXDomain = true;
//    delete $httpProvider.defaults.headers.common['X-Requested-With'];
//}]);

app.config(function($stateProvider, $urlRouterProvider) {

    $stateProvider
        .state("index", {
            url: "/",
            templateUrl: "/app/views/main.html"
        })
        .state("users", {
            url: "/users",
            templateUrl: "/app/views/user/users.html",
            controller: 'usersController'
        })
        .state("users.getUsers", {
            url: "/getUsers",
            templateUrl: "/app/views/user/allUsers.html",
            controller: 'allUsersController'
        })
        .state("users.addUser", {
            url: "/addUser",
            templateUrl: "/app/views/user/addUser.html",
            controller: "userController"
        })
        .state("users.getUser", {
            url: "/getUser/{id}",
            templateUrl: "/app/views/user/addUser.html",
            controller: "userController"
        })
        .state("users.updateUser", {
            url: "/updateUser/{id}",
            templateUrl: "/app/views/user/addUser.html",
            controller: "userController"
        })
        //Blobs
        .state("blobs", {
            url: "/blobs",
            templateUrl: "/app/views/blob/blobs.html",
            controller: "blobsController"
        })
        .state("addBlob", {
            url: "/addBlob",
            templateUrl: "/app/views/blob/addBlob.html",
            controller: "blobController"
        })
        .state("updateBlob", {
            url: "/updateBlob/{id}",
            templateUrl: "/app/views/blob/addBlob.html",
            controller: "blobController"
        })
        .state('demoGame', {
            url: "/demoGame",
            templateUrl: '/app/views/demoGame.html',
            controller: 'demoController'
        })
        .state('fileUpload', {
            url: "/fileUpload",
            templateUrl: "/app/views/fileUpload/fileUpload.html",
            controller: "fileUploadController",
            controllerAs: "vm"
        })
        .state('test', {
            url: '/test',
            templateUrl: '/app/views/test/test.html',
            controller: 'testController',
            controllerAs: 'vm'
        });

    $urlRouterProvider.otherwise("/");
});

app.config(['$httpProvider', function ($httpProvider) {
    //Reset headers to avoid OPTIONS request (aka preflight)
    $httpProvider.defaults.headers.common = {};
    $httpProvider.defaults.headers.post = {};
    $httpProvider.defaults.headers.put = {};
    $httpProvider.defaults.headers.patch = {};
}]);

app.constant("DEBUG", true);