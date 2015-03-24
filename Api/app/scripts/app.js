var app = angular.module('InterestingThings', ['ui.router']);

app.config(function($stateProvider, $urlRouterProvider) {

    $stateProvider
        .state("index", {
            url: "/",
            templateUrl: "/app/views/main.html"
        }).
        state('demoGame', {
            url: "/demoGame",
            templateUrl: '/app/views/demoGame.html',
            controller: 'demoController'
        });

    //.state("detailIaForm", {
    //    url: "/detailia/:iaId",
    //    templateUrl: "/app/views/iadetail.html",
    //    controller: "iaController"
    //})
    //.state("detailIaForm.general", {
    //    url: "/general",
    //    templateUrl: "/app/views/ia/general.html",
    //    controller: "generalController"
    //})
    //.state("detailIaForm.triggers", {
    //    url: "/triggers",
    //    templateUrl: "/app/views/ia/triggers.html",
    //    controller: "triggersController"
    //})
    //.state("detailIaForm.steps", {
    //    url: "/steps",
    //    templateUrl: "/app/views/ia/steps.html",
    //    controller: "stepsController"
    //})
    //.state("detailIaForm.history", {
    //    url: "/history",
    //    templateUrl: "/app/views/ia/history.html",
    //    controller: "historyController"
    //})
    //.state("createIaForm", {
    //    url: "/createia?Clients&SelectedStepType",
    //    templateUrl: "/app/views/iadetail.html",
    //    controller: "iaController"
    //})
    //.state("createIaForm.general", {
    //    url: "/general",
    //    templateUrl: "/app/views/ia/general.html",
    //    controller: "generalController"
    //})
    //.state("createIaForm.triggers", {
    //    url: "/triggers",
    //    templateUrl: "/app/views/ia/triggers.html",
    //    controller: "triggersController"
    //})
    //.state("createIaForm.steps", {
    //    url: "/steps",
    //    templateUrl: "/app/views/ia/steps.html",
    //    controller: "stepsController"
    //});

    $urlRouterProvider.otherwise("/");
});

app.config(['$httpProvider', function ($httpProvider) {
    //Reset headers to avoid OPTIONS request (aka preflight)
    $httpProvider.defaults.headers.common = {};
    $httpProvider.defaults.headers.post = {};
    $httpProvider.defaults.headers.put = {};
    $httpProvider.defaults.headers.patch = {};
}]);