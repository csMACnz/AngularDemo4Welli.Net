appModule.controller('ListCtrl', [
    '$scope', 'blogService',
    function ($scope, blogService) {
        
        $scope.posts = blogService.query(function () {
            
        for (var i = 0; i < $scope.posts.length; i++) {

            $scope.posts[i].modThreeFill = false;
            $scope.posts[i].modTwoFill = false;
            if (i != 0) {
                if (i % 3 === 0) {
                    $scope.posts[i].modThreeFill = true;
                }
                if (i % 2 === 0) {
                    $scope.posts[i].modTwoFill = true;
                }
            }
        }
        });
    }
]);