(function () {
    var app = angular.module('InterestingThings');

    var blobController = function ($scope, $state, blobService, $stateParams) {
        $scope.blob = {};
        $scope.isLoading = false;

        $scope.currentState = $state.current.name;

        switch ($scope.currentState) {
            case "updateBlob":
                $scope.isLoading = true;
                var id = $stateParams["id"];
                blobService.getBlobById(id).then(function (data) {
                    $scope.isLoading = false;
                    $scope.blob = data;
                }, function(reason) {
                    console.log(reason.message);
                });
        }

        $scope.resetBlob = function () {
            //console.log($scope.blob);
            $scope.blob = {};
        };

        $scope.uploadBlob = function() {
            var files = document.getElementById("Upload").files;

            if (files) {
                var uploadBlob = files[0];
                //console.log($scope.files);
                if (uploadBlob) {
                    blobService.uploadBlob(uploadBlob).then(function(data) {
                        if (data.result == "fail") {
                            console.log("Upload field failed.");
                        }
                        if (data.result == "success") {
                            $scope.blob.BlobUrl = data.returnUrl;
                        }
                    }, function(reason) {
                        console.log(reason.message);
                    });
                }
            } else {
                console.log("No fiels.");
            }
        };

        $scope.addBlob = function() {
            if ($scope.blob) {
                blobService.addBlob($scope.blob).then(function(data) {
                    $state.go("blobs");
                }, function(reason) {
                    console.log(reason.message);
                });
            } else {
                console.log("No blob exists.");
            }
        };

        $scope.updateBlob = function () {
            blobService.updateBlob($scope.blob).then(function (data) {
                $state.go("blobs");
            }, function (reason) {
                console.log(reason.message);
            });
        };
    };

    app.controller('blobController', blobController);
})();