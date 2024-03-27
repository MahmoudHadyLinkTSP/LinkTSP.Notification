angular.module('Notification')
    .controller('Notification.helloWorldController', ['$scope', 'Notification.webApi', function ($scope, api) {
        var blade = $scope.blade;
        blade.title = 'Notification';

        blade.refresh = function () {
            api.get(function (data) {
                blade.title = 'Notification.blades.hello-world.title';
                blade.data = data.result;
                blade.isLoading = false;
            });
        };

        blade.refresh();
    }]);
