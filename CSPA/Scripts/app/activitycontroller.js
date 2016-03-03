app.controller('ActivityController', function ($scope, APIService) {
    getAll();
    function getAll() {
        
    }
    //$scope.saveSubs = function () {
    //    var sub = {
    //        MailID: $scope.mailid,
    //        SubscribedDate: new Date()
    //    };
    //    var saveSubs = APIService.saveSubscriber(sub);
    //    saveSubs.then(function (d) {
    //        getAll();
    //    }, function (error) {
    //        console.log('Oops! Something went wrong while saving the data.')
    //    })
    //};
    
});