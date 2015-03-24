(function() {
    var blobService = function ($http, sysSettings) {
        var uploadBlob = function (file) {
            var formData = new FormData();
            formData.append('file', file);
            return $http.post(sysSettings.BaseUrl() + "/api/BlobAzureStorage", formData, {
                transformRequest: angular.identity,
                headers: {
                    'Content-Type': undefined
                }
            }).then(function (response) {
                return response.data;
            });
        };

        var addBlob = function (blob) {
            return $http.post(sysSettings.BaseUrl() + "/api/Blobs", JSON.stringify(blob), {
                headers: {
                    'Content-Type': 'application/json'
                }
            }).then(function (res) {
                return res.data;
            });
        };

        var updateBlob = function (blob) {
            return $http.put(sysSettings.BaseUrl() + "/api/Blobs/" + blob.Id, JSON.stringify(blob), {
                headers: {
                    'Content-Type': 'application/json'
                }
            }).then(function (res) {
                return res.data;
            });
        };

        var deleteBlob = function (blobId) {
            //console.log("Come into core service");
            return $http.delete(sysSettings.BaseUrl() + "/api/Blobs/" + blobId, {
                headers: {
                    'Content-Type': 'application/json'
                }
            }).then(function (res) {
                return res.data;
            });
        };

        var getAllBlobs = function () {
            return $http.get(sysSettings.BaseUrl() + "/api/Blobs", {
                headers: {
                    'Content-Type': 'application/json'
                }
            }).then(function (res) {
                return res.data;
            });
        };

        var getBlobById = function (blobId) {
            return $http.get(sysSettings.BaseUrl() + "/api/Blobs/" + blobId, {
                hearders: {
                    'Content-Type': 'application/json'
                }
            }).then(function (res) {
                return res.data;
            });
        };

        return {
            uploadBlob: uploadBlob,
            updateBlob: updateBlob,
            getAllBlobs: getAllBlobs,
            addBlob: addBlob,
            deleteBlob: deleteBlob,
            getBlobById: getBlobById
        };
    };

    var app = angular.module('InterestingThings');
    app.factory("blobService", blobService);
})();