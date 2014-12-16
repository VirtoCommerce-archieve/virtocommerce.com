angular.module('virtoCommerce.content.resources.contents', [])
.factory('contents', ['$resource', function ($resource) {

    return $resource('api/contents/:id', { id: '@id' }, {
        getCollections: { method: 'GET', url: 'api/contents/collections', isArray: true },
        get: { method: 'GET', url: 'api/modules/:id', isArray: false },
    });
}]);

