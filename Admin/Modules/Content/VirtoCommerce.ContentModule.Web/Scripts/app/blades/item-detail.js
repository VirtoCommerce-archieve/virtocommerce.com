angular.module('virtoCommerce.content.blades.itemDetails', [
    'virtoCommerce.content.resources.contents',
    'codemwnci.markdown-edit-preview'
])
.controller('contentItemDetailsController', ['$rootScope', '$scope', 'bladeNavigationService', 'dialogService', 'contents', function ($rootScope, $scope, bladeNavigationService, dialogService, contents) {
    $scope.selectedEntityId = null;

    //alert($scope.blade.currentEntity.id);
    $scope.blade.refresh = function () {
        $scope.blade.isLoading = true;

        contents.getItem(
        {
            collectionId: $scope.blade.collectionId,
            itemId: $scope.blade.itemId
        }, function (results) {
            $scope.blade.isLoading = false;
            $scope.blade.currentEntity = angular.copy(results);;
            $scope.blade.origEntity = results;
        });
    };

    function isDirty() {
        return !angular.equals($scope.blade.currentEntity, $scope.blade.origEntity);
    };

    $scope.blade.onClose = function (closeCallback) {
        closeChildrenBlades();
        closeCallback();
    };

    function closeChildrenBlades() {
        angular.forEach($scope.blade.childrenBlades.slice(), function (child) {
            bladeNavigationService.closeBlade(child);
        });
    }

    function saveChanges() {
        $scope.blade.isLoading = true;
        contents.saveItem(
        {
            collectionId: $scope.blade.collectionId,
            itemId: $scope.blade.itemId,
        }, $scope.blade.currentEntity, function (data, headers) {
            $scope.blade.refresh(true);
        });
    };

    function publishChanges() {
        $scope.blade.isLoading = true;
        contents.publishItem(
        {
            collectionId: $scope.blade.collectionId,
            itemId: $scope.blade.itemId,
        }, $scope.blade.currentEntity, function (data, headers) {
            $scope.blade.refresh(true);
        });
    };

    $scope.bladeToolbarCommands = [
        {
            name: "Save", icon: 'icon-floppy',
            executeMethod: function () {
                saveChanges();
            },
            canExecuteMethod: function () {
                return true;
            }
        },
        {
            name: "Publish", icon: 'icon-floppy',
            executeMethod: function () {
                publishChanges();
            },
            canExecuteMethod: function () {
                return true;
            }
        },
        {
            name: "Reset", icon: 'icon-undo',
            executeMethod: function () {
                angular.copy($scope.blade.origEntity, $scope.blade.currentEntity);
            },
            canExecuteMethod: function () {
                return isDirty();
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
