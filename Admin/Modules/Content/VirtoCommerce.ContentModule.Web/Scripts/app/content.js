//Call this to register our module to main application
var moduleName = "virtoCommerce.content";
var tempateRoot = "Modules/Content/VirtoCommerce.ContentModule.Web/Scripts/app";
var navigationId = "contents";

if (AppDependencies != undefined) {
    AppDependencies.push(moduleName);
}

angular.module(moduleName, [
    'virtoCommerce.content.blades.contentList'
])
.config(
  ['$stateProvider', function ($stateProvider) {
      $stateProvider
          .state('workspace.content', {
              url: '/' + navigationId,
              templateUrl: tempateRoot + '/home.tpl.html',
              controller: [
                  '$scope', 'bladeNavigationService', function ($scope, bladeNavigationService) {
                      var blade = {
                          id: navigationId,
                          title: 'Content Publishing',
                          subtitle: 'Content Publishing',
                          controller: 'contentsListController',
                          template: tempateRoot + '/blades/content-list.tpl.html',
                          isClosingDisabled: true
                      };
                      bladeNavigationService.showBlade(blade);
                  }
              ]
          });
  }]
)
.run(
  ['$rootScope', 'mainMenuService', 'widgetService', function ($rootScope, mainMenuService, widgetService) {
      //Register module in main menu
      var menuItem = {
          path: 'browse/' + navigationId,
          icon: 'glyphicon glyphicon-cog',
          title: 'Contents',
          priority: 200,
          state: 'workspace.content',
          permission: 'contentsMenuPermission'
      };
      mainMenuService.addMenuItem(menuItem);
  }])
;
