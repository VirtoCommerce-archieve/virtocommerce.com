angular.module('virtoCommerce.content.blades.itemDetails', [
    'virtoCommerce.content.resources.contents',
    'codemwnci.markdown-edit-preview'
])
.controller('contentItemDetailsController', ['$rootScope', '$scope', 'bladeNavigationService', 'dialogService', 'contents', function ($rootScope, $scope, bladeNavigationService, dialogService, contents) {
    $scope.selectedEntityId = null;
    $scope.textarea = '**Welcome, I am some Bold Markdown text**';
    $scope.liveedit = 'I am *ready* to be edited!';

    //alert($scope.blade.currentEntity.id);
    $scope.blade.refresh = function () {
        $scope.blade.isLoading = true;

        contents.getItem(
        {
            collectionId: $scope.blade.collectionId,
            itemId: $scope.blade.itemId
        }, function (results) {
            $scope.blade.isLoading = false;
            $scope.blade.currentEntities = results;
        });
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

    $scope.bladeToolbarCommands = [
        {
            name: "Publish", icon: 'icon-floppy',
            executeMethod: function () {
                openAddEntityBlade();
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
