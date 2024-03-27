// Call this to register your module to main application
var moduleName = 'Notification';

if (AppDependencies !== undefined) {
    AppDependencies.push(moduleName);
}

angular.module(moduleName, [])
    .config(['$stateProvider',
        function ($stateProvider) {
            $stateProvider
                .state('workspace.NotificationState', {
                    url: '/Notification',
                    templateUrl: '$(Platform)/Scripts/common/templates/home.tpl.html',
                    controller: [
                        'platformWebApp.bladeNavigationService',
                        function (bladeNavigationService) {
                            var newBlade = {
                                id: 'blade1',
                                controller: 'Notification.helloWorldController',
                                template: 'Modules/$(LinkTSP.Notification)/Scripts/blades/hello-world.html',
                                isClosingDisabled: true,
                            };
                            bladeNavigationService.showBlade(newBlade);
                        }
                    ]
                });
        }
    ])
    .run(['platformWebApp.mainMenuService', '$state',
        function (mainMenuService, $state) {
            //Register module in main menu
            var menuItem = {
                path: 'browse/Notification',
                icon: 'fa fa-cube',
                title: 'Notification',
                priority: 100,
                action: function () { $state.go('workspace.NotificationState'); },
                permission: 'Notification:access',
            };
            mainMenuService.addMenuItem(menuItem);
        }
    ]);
