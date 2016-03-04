app.controller('RiderController', function ($scope, APIService) {
    getUserProfile();
    function getUserProfile() {
        var userId = 123;
        var getProfileSub = APIService.getRiderProfile(userId);
        getProfileSub.then(function (d) {
            $scope.Profile = d.data;
        }, function (error) {
            console.log('Oops! Something went wrong while fetching user profile data.')
        });
    }
});