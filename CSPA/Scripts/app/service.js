app.service("APIService", function ($http) {

    this.getRecentActivities = function () {
        return $http({
            method: 'get',            
            url: 'api/ActivityAPI'
        });
    }
    this.getActivityDetail = function (activityId) {
        return $http({
            method: 'get',
            url: 'api/ActivityAPI/Get/' + activityId
        });
    }
    this.getActivityTrack = function (activityId) {
        return $http({
            method: 'get',
            url: 'api/ActivityAPI/GetTrackData/' + activityId
        });
    }
    this.getRiderProfile = function () {
        return $http({
            method: 'get',
            url: 'api/RiderAPI/Get'
        });
    }
    this.saveSubscriber = function (sub) {
        return $http({
            method: 'post',
            data: sub,
            url: 'api/Subscriber'
        });
    }
    this.updateSubscriber = function (sub) {
        return $http({
            method: 'put',
            data: sub,
            url: 'api/Subscriber'
        });
    }
    this.deleteSubscriber = function (subID) {
        var url = 'api/Subscriber/' + subID;
        return $http({
            method: 'delete',
            data: subID,
            url: url
        });
    }
});