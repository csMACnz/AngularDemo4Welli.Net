appModule.controller('ViewEntryCtrl', [
    '$scope', '$routeParams', 'blogService', '$window', '$sce',
    function ($scope, $routeParams, blogService, $window, $sce) {

        $scope.post = blogService.get({ slug: $routeParams.slug }, function(post) {
            $scope.html = $window.marked(post.content);
            $scope.htmlSafe = $sce.trustAsHtml($scope.html);
        });

        $scope.editLink = $routeParams.slug + "/edit";
    }
]);