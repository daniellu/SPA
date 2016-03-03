var app = angular.module("ApplicationModule", ["ngRoute"]);

app.factory("ShareData", function () {
    return { value: 0 }
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
    $routeProvider.otherwise(
                        {
                            redirectTo: '/'
                        });
        
}]);