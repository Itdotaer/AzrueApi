(function () {
    var app = angular.module('InterestingThings');

    var fileUploadController = function ($upload, $state, sysSettings, logger, DEBUG) {
        var vm = this;

        vm.baseUrl = sysSettings.BaseUrl();
        vm.files = null;
        vm.upload = upload;
        vm.initProcessBar = initProcessBar;
        vm.initProcessBar();

        function upload() {
            console.log("Come to upload");

            if (vm.files && vm.files.length) {
                for (var i = 0; i < vm.files.length; i++) {
                    var file = vm.files[i];
                    $upload.upload({
                        url: vm.baseUrl + "/api/FileUpload",
                        file: file
                    }).progress(function(evt) {
                        vm.progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
                        console.log("progress:" + vm.progressPercentage + "%" + evt.config.file.name);
                    }).success(function(data, status, headers, config) {
                        console.log('file ' + config.file.name + 'uploaded. Response: ' + data);
                    });
                }
            } else {
                logger.logError("Please you had selected at least one files.");
            }
        }

        function initProcessBar() {
            vm.progressPercentage = 0;
        }
    }

    app.controller('fileUploadController', fileUploadController);
})();