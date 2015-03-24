(function() {
    var sysSettings = function () {
        var BaseUrl = function () {
            return "http://eco-azureapi.chinacloudsites.cn";
            //Debug in local environment
            //return "http://localhost:30762";
        }

        return {
            BaseUrl: BaseUrl
        };
    }

    var module = angular.module('InterestingThings');
    module.factory("sysSettings", sysSettings);
})();