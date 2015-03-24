(function() {
    angular.module("InterestingThings").factory("dataContext", dataContext);

    dataContext.$inject = ['logger', 'breeze', 'sysSettings'];

    function dataContext(logger, breeze, sysSettings) {
        var dataService = new breeze.DataService({
            serviceName: sysSettings.BaseUrl() + '/api',
            hasServerMetadata: false,
        });

        var manager = new breeze.EntityManager({ dataService: dataService });

        var service = {
            getUser: getUser,
            save: save,
            reset: reset
        };

        return service;

        function getUser(userId) {
            if (userId) {
                return breeze.EntityQuery.from("Users").where('Id', '==', userId)
                        .using(manager).execute().then(success).catch(function (err) { logger.logError(err); });
            }

            return breeze.EntityQuery.from("Users")
                .using(manager).execute().then(success).catch(function(err) { logger.logError(err); });

            function success(data) {
                logger.log("Successed.Length:" + data.results.length);

                return data.results;
            }
        }

        function save() {
            
        }

        function reset() {
            
        }
    }
})();