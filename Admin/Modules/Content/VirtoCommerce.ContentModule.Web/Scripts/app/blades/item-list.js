angular.module('virtoCommerce.content.blades.itemList', [
    'virtoCommerce.content.resources.contents',
    'virtoCommerce.content.blades.itemDetails'
])
.controller('contentItemsListController', ['$rootScope', '$scope', 'bladeNavigationService', 'dialogService', 'contents', function ($rootScope, $scope, bladeNavigationService, dialogService, contents) {
    $scope.selectedEntityId = null;

    //alert($scope.blade.currentEntity.id);
    $scope.blade.refresh = function () {
        $scope.blade.isLoading = true;

        contents.getItems(
        {
            collectionId: $scope.blade.collectionId
        }, function (results) {
            $scope.blade.isLoading = false;
            $scope.blade.currentEntities = results;
        });
    };

    $scope.selectItem = function (listItem) {
        var newBlade = {
            id: 'itemDetails',
            title: 'Content Item',
            subtitle: 'Modifying "' + listItem.id + '"',
            currentEntity: listItem,
            collectionId: $scope.blade.collectionId,
            itemId: listItem.id,
            controller: 'contentItemDetailsController',
            template: 'Modules/Content/VirtoCommerce.ContentModule.Web/Scripts/app/blades/item-detail.tpl.html'
        };

        bladeNavigationService.showBlade(newBlade, $scope.blade);
    }

    $scope.blade.onClose = function (closeCallback) {
        closeChildrenBlades();
        closeCallback();
    };

    function closeChildrenBlades() {
        angular.forEach($scope.blade.childrenBlades.slice(), function (child) {
            bladeNavigationService.closeBlade(child);
        });
    }

    $scope.bladeToolbarCommands = [
        {
            name: "Add", icon: 'icon-plus',
            executeMethod: function () {
                openAddEntityBlade();
            },
            canExecuteMethod: function () {
                return true;
            }
        }
    ];

    function openAddEntityBlade() {
        closeChildrenBlades();

        var newBlade = {
            id: "moduleInstallWizard",
            title: "Module install",
            // subtitle: '',
            controller: 'installWizardController',
            bladeActions: 'Modules/Packaging/VirtoCommerce.PackagingModule.Web/Scripts/wizards/newModule/install-wizard-actions.tpl.html',
            template: 'Modules/Packaging/VirtoCommerce.PackagingModule.Web/Scripts/wizards/newModule/install-wizard.tpl.html'
        };
        bladeNavigationService.showBlade(newBlade, $scope.blade);
    }

    $scope.blade.refresh();
}]);
