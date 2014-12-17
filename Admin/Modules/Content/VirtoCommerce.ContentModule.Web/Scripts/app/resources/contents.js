angular.module('virtoCommerce.content.resources.contents', [])
.factory('contents', ['$resource', function ($resource) {

    return $resource('api/contents/:id', { id: '@id' }, {
        getCollections: { method: 'GET', url: 'api/contents/collections', isArray: true },
        getItems: { method: 'GET', url: 'api/contents/collections/:collectionId/items', isArray: true },
        getItem: { method: 'GET', url: 'api/contents/collections/:collectionId/items/:itemId', isArray: false },
    });
}]);

