var appModule = angular.module('angularApp', ['ngRoute', 'ngResource', 'ngSanitize', 'ui.ace']);

appModule.filter('markdownToHtml', [
        '$window', '$sce', function($window, $sce) {
        return function(input) {
            if (input) {

                var html = $window.marked(input);
                var htmlSafe = $sce.trustAsHtml(html);
                return htmlSafe;

            };
            return '';
        };
    }
    ]);

appModule.config([
    '$routeProvider', '$locationProvider', function($routeProvider, $locationProvider) {
        $routeProvider.
            when('/', {
                templateUrl: '/scripts/app/ListView.html',
                controller: 'ListCtrl'
            }).
            when('/newpost/', {
                templateUrl: '/scripts/app/EditEntryView.html',
                controller: 'NewEntryCtrl'
            }).
            when('/:slug/edit', {
                templateUrl: '/scripts/app/EditEntryView.html',
                controller: 'EditEntryCtrl'
            }).
            when('/:slug', {
                templateUrl: '/scripts/app/ViewEntryView.html',
                controller: 'ViewEntryCtrl'
            }).
            otherwise({
                redirectTo: '/'
            });

        $locationProvider.html5Mode(true);
        $locationProvider.hashPrefix('!');
    }
]);

appModule.service("blogService", [
    '$resource',
    function($resource) {
        return $resource(
            '/api/Blog/:slug',
            { slug: "@slug" },
            {
                "save": { method: "POST" },
                "update": { method: "PUT" }
            });
    }
]);