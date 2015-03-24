(function () {
    var app = angular.module('InterestingThings');

    var blobsController = function ($scope, $state,blobService) {
        $scope.blobs = [];
        $scope.isLoading = true;

        blobService.getAllBlobs().then(function (data) {
            $scope.isLoading = false;
            $scope.blobs = data;
            console.log(data);
        }, function(reason) {
            console.log(reason.message);
        });

        $scope.updateBlob = function(blobId) {
            $state.go("updateBlob", { id: blobId });
        };

        $scope.deleteBlob = function (blobId) {
            blobService.deleteBlob(blobId).then(function (successed) {
                //console.log("Successed");
                blobService.getAllBlobs().then(function (data) {
                    $scope.blobs = data;
                    console.log(data);
                }, function (reason) {
                    console.log(reason.message);
                });
            }, function(reason) {
                console.log(reason.message);
            });
        };
    };

    app.controller('blobsController', blobsController);
})();