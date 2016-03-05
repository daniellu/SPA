app.controller('ActivityDetailController', function ($scope, $routeParams, ShareData, APIService, NgMap) {
    var activityId = $routeParams.activityId;
    var vm = this;
    var polyline = null;

    var getActivityDetailSub = APIService.getActivityDetail(activityId);
    getActivityDetailSub.then(function (d) {
        $scope.ActivityDetail = d.data;

        var centerpoint = new google.maps.LatLng($scope.ActivityDetail.centerLat, $scope.ActivityDetail.centerLng);
        vm.map.setCenter(centerpoint);
    }, function (error) {
        console.log('Oops! Something went wrong while fetching activity detail data.')
    });

    NgMap.getMap().then(function (evtMap) {
        var map = evtMap;
        vm.map = map;

        //clear the cache in the angular factory
        if (ShareData.DetailMapTrack != null) {
            ShareData.DetailMapTrack.setMap(null);
            ShareData.DetailMapTrack = null;
        }
        console.log('loading track data');

        var getActivityTrackSub = APIService.getActivityTrack(activityId);

        getActivityTrackSub.then(function (d) {
            var trackData = d.data;
            var coordinates = trackData.coordinates;
            polyline = new google.maps.Polyline({
                path: coordinates,
                geodesic: true,
                strokeColor: '#FF0000',
                strokeOpacity: 1.0,
                strokeWeight: 2
            });

            //set data to the angular factory
            ShareData.DetailMapTrack = polyline;
            polyline.setMap(map);

        }, function (error) {
            console.log('Oops! Something went wrong while fetching activity track data.')
        });


    });

});

app.directive('fullScreenToggle', function ($timeout) {
    return {
        controller: 'ActivityDetailController',
        link: function (scope, e, a, ctrl) {
            var fullScreenClick = function () {
                e.parent().toggleClass('full-screen');
                e.text(e.parent().hasClass('full-screen') ? 'Exit Full Screen' : 'Full Screen');
                google.maps.event.trigger(scope.map, 'resize');
            };
            e.on('click', fullScreenClick);
        }
    }
});