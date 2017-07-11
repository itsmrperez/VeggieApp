(function () {

    'use strict';
    angular.module('VeggiesApp').controller('peopleController', PeopleController);

    PeopleController.$inject = ['$scope', 'peopleService', '$uibModal'];
    function PeopleController($scope, peopleService, $uibModal) {
        var vm = this;
        vm.$scope = $scope;
        vm.peopleService = peopleService;
        vm.$uibModal = $uibModal;

        vm.displayBodyContent = false;
        vm.selectAll = _selectAll;
        vm.createPerson = _createPerson;
        vm.save = _save;
        vm.cancel = _cancel;
        vm.editUser = _editUser;
        vm.deleteUser = _deleteUser;
        vm.openModal = _openModal;

        vm.items = [];
        vm.selectedItem = null;
        vm.itemToDelete = null;
        vm.message = "Welcome to the People page!!!";
        vm.heading = "Create a new Person";

        vm.$onInit = _render;
        function _render() {
            vm.selectAll();
        };

        function _selectAll() {
            vm.peopleService.selectAll(onSelectAllSuccess, onError);
            vm.displayBodyContent = true;
        };

        function _createPerson() {
            vm.selectedItem = {};
            console.log("New person has been created!");
        };

        function _save() {
            if (vm.selectedItem.Id) {
                vm.peopleService.update(vm.selectedItem, onUpdateSuccess, onError);
            } else {
                vm.peopleService.save(vm.selectedItem, onSaveSuccess, onError);
            }
        };

        function _cancel() {
            vm.selectedItem = null;
        };

        function _editUser(aSelectedItem) {
                    vm.$scope.$apply(function () {
                        vm.selectedItem = vm.items[i];
                    });
        };

        function _deleteUser(itemToDelete) {
            
            for (var i = 0; i < vm.items.length; i++) {
                if (vm.items[i].Id === itemToDelete.Id) {
                    vm.peopleService.delete(itemToDelete.Id, onDeleteSuccess, onError);
                    break;
                }
            }
        };

        function _openModal(selectedItem) {
            //vm.$dialog.dialog({}).open('modalContent.html');
            var modalInstance = vm.$uibModal.open({
                animation: true
                , templateUrl: "modalContent.html"
                , controller: "modalController as mc"
                , size: "md"
                , resolve: {
                    item: function () {
                        vm.backup = angular.copy(vm.data);
                        if (selectedItem !== null) {
                            return {
                                data: selectedItem
                            }
                        }
                        else {
                            return {
                                item: {}
                            }
                        }
                    }
                }
            });

            modalInstance.result.then(function (selectedItem) {
                vm.modalSelected = selectedItem;
            });
        };

        function onSelectAllSuccess(data) {
            vm.$scope.$apply(function () {
                vm.items = data.Items
            });
        };

        function onSaveSuccess(data) {
            vm.selectedItem.Id = data.Item;
            vm.$scope.$apply(function () {
                vm.items.push(vm.selectedItem)
            });
            vm.selectedItem = null;
        };

        
        function onDeleteSuccess(responseData, sentData) {
            var arrayLength = vm.items.length
            for (var i = 0; i < arrayLength; i++)
            {
                if(vm.items[i].Id === sentData)
                {
                    vm.$scope.$apply(function () {
                        vm.items.splice(i, 1)
                    });
                    break;
                }
            }
        };

        function onError(xhr, ajaxOptions, thrownError) {
            console.log(xhr.responseText);
        };
    };

})();

(function () {
    angular.module('VeggiesApp').controller("modalController", ModalController)
    ModalController.$inject = ['$scope', '$uibModalInstance', 'peopleService', 'item']

    function ModalController($scope, $uibModalInstance, peopleService, item) {

        var vm = this;
        // Dependencies
        vm.$scope = $scope;
        vm.$uibModalInstance = $uibModalInstance;
        vm.data = item.data;
        vm.peopleService = peopleService;

        vm.update = _update;
        vm.cancel = _cancel;

        //vm.$onInit = _setUp;
    

        function _setUp() {

        }
                          
        function _update() {
            vm.peopleService.update(vm.data, onUpdateSuccess, onError);
        }

        function _cancel() {
            vm.$uibModalInstance.dismiss("cancel");
        }

        function onSaveSuccess(data) {
            
        };

        function onUpdateSuccess(data) {
            
            //for (var i = 0; i < trArray.length; index++) {
            //    var id = $(trArray[index]).find('.id').text();
            //    if (vm.selectedItem.id == parseInt($(trArray[index]).find('.id').text())) {
            //        $(trArray[index]).find('.firstName').text(vm.selectedItem.firstName);
            //        $(trArray[index]).find('.lastName').text(vm.selectedItem.lastName);
            //        $(trArray[index]).find('.middleInitial').text(vm.selectedItem.middleInitial);
            //        break;
            //    }
            //}

            vm.$scope.$apply(function () {
                item.data = vm.data
            });
            vm.selectedItem = null;
            vm.$uibModalInstance.dismiss("cancel");

        };

        function onError(error) {
            console.log(error);
        }

        function _getUserSettingsError(error) {
            console.log(error);
        }

    }

})();