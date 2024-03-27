angular.module('Notification')
    .factory('Notification.webApi', ['$resource', function ($resource) {
        return $resource('api/notification');
    }]);
