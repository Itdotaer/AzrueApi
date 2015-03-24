(function () {
    'use strict';

    angular.module('InterestingThings.users')
        .directive('usersPanel', usersPanel);

    function usersPanel() {
        var directive = {
            restrict: 'E',
            scope: {
                usersData:'='
            },
            templateUrl: 'app/scripts/directives/usersPanel/usersPanel.html',
            controller: 'usersPanelController',
            controllerAs: 'usersCtrl'
        };

        return directive;
    };
})();