var app = angular.module("ApplicationModule", ["ngRoute", 'angularMoment', 'ngMap']);

app.factory("ShareData", function () {
    return { DetailMapTrack : null }
});

//Showing Routing  
app.config(['$routeProvider', '$locationProvider', function ($routeProvider) {
    debugger;
    $routeProvider.when('/rider',
                        {
                            templateUrl: 'Rider/Index',
                            controller: 'RiderController'
                        });
    $routeProvider.when('/listActivity',
                        {
                            templateUrl: 'Activity/Index',
                            controller: 'ActivityController'
                        });
    $routeProvider.when('/activityDetail/:activityId',
                        {
                            templateUrl: 'Activity/Detail',
                            controller: 'ActivityDetailController'
                        });
    $routeProvider.otherwise(
                        {
                            redirectTo: '/'
                        });
        
}]);