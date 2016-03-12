app.controller('EarnDateController', function ($scope, APIService) {    
    $scope.queryEarnDate = function () {        
        var querySubs = APIService.queryEarnDate($scope.queryString);
        querySubs.then(function (d) {
            $scope.earnDateData = d.data;
        }, function (error) {
            console.log('Oops! Something went wrong while querying earn date data.')
        })
    };

});