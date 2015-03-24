(function () {
    'use strict';

    var app = angular.module('InterestingThings');

    var testController = function ($state, sysSettings, logger, $modal, DEBUG) {
        var vm = this;

        //Date picker
        vm.today = today;
        vm.clear = clear;
        vm.toggleMin = toggleMin;
        vm.open = open;
        vm.disabled = disabled;

        //Rating
        vm.rate = 7;
        vm.max = 50;
        vm.hoveringOver = hoveringOver;

        //Pagination
        vm.bigTotalItems = 12003;
        vm.bigCurrentPage = 2;
        vm.maxSize = 5;
        vm.pageChanged = pageChanged;

        //Modal
        vm.items = ['菜单一', '菜单二', '菜单三'];
        vm.openModal = openModal;

        //Carousel
        vm.defaultInterval = 5000;
        vm.slides = [];

        vm.addSlide = addSlide;

        init();

        function init() {
            vm.dt = null;
            vm.dateOptions = {
                formatYear: 'yy',
                startingDay: 1
            };

            vm.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd.MM.yyyy', 'shortDate'];
            vm.format = vm.formats[0];
            vm.maxDate = '2015-06-22';

            vm.toggleMin();
            vm.today();

            for (var i = 0; i < 4; i++) {
                vm.addSlide();
            }
        }

        function today(){
            vm.dt = new Date();
        }

        function clear() {
            vm.dt = null;
        }

        function disabled(date, mode) {
            return (mode === 'day' && (date.getDay() === 0 || date.getDay() === 6));
        }

        function toggleMin() {
            vm.minDate = vm.minDate ? null : new Date();
        }

        function open($event) {
            $event.preventDefault();
            $event.stopPropagation();

            vm.opened = true;
        }

        //Rating
        function hoveringOver(value) {
            vm.overStar = value;
            vm.percent = Math.floor(100 * (value / vm.max));
        }

        //Pagination
        function pageChanged() {
            logger.log("Page changed.CurrentPage=" + vm.bigCurrentPage);
        }

        //Modal
        function openModal(size) {
            var modalInstance = $modal.open({
                templateUrl: 'myModalContent.html',
                controller: 'ModalInstanceCtrl',
                controllerAs: 'vm',
                size: size,
                backdrop: 'static',
                resolve: {
                    items: function () {
                        return vm.items;
                    }
                }
            });

            modalInstance.result.then(function (selectedItem) {
                vm.selected = selectedItem;
            }, function () {
                logger.logInfo("Modal dismissed at " + new Date());
            });
        }

        //Carousel
        function addSlide() {
            var newWidth = 600 + vm.slides.length + 1;
            vm.slides.push({
                image: 'http://placekitten.com/' + newWidth + '/300',
                text: ['More', 'Extra', 'Lots of', 'Surplus'][vm.slides.length % 4] + ' ' +
        ['Cats', 'Kittys', 'Felines', 'Cutes'][vm.slides.length % 4]
            });
        }
    }


    var ModalInstanceCtrl = function (logger, $modalInstance, items) {
        var vm = this;

        vm.items = items;
        vm.selected = {
            item: vm.items[0]
        };
        vm.ok = ok;
        vm.cancel = cancel;

        function ok() {
            $modalInstance.close(vm.selected.item);
        }

        function cancel() {
            $modalInstance.dismiss('cancel');
        }
    }

    app.controller('testController', testController);
    app.controller('ModalInstanceCtrl', ModalInstanceCtrl);
})();