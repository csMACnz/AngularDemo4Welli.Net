appModule.controller('NewEntryCtrl', [
    '$scope', '$routeParams', 'blogService', '$location',
    function($scope, $routeParams, blogService, $location) {
        $scope.post = {};

        $scope.savePost = function () {
            var post = new blogService($scope.post);

            post.$save(function (u) {
                $location.path(u.slug);
            });
        };
    }]);