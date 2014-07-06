appModule.controller('EditEntryCtrl', [
    '$scope', '$routeParams', 'blogService', '$location',
    function($scope, $routeParams, blogService, $location) {
        $scope.post = blogService.get({ "slug": $routeParams.slug });

        $scope.savePost = function () {
            $scope.post.$update(function (u) {
                $location.path(u.slug);
            });
        };
    }]);