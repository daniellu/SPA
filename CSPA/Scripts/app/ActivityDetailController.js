app.controller('ActivityDetailController', function ($scope, $routeParams, APIService) {
    var activityId = $routeParams.activityId;
    
    $scope.activityId = activityId;
});