app.controller('ChartController', function ($scope) {
    // Item List Arrays
    $scope.Items = [
        { TimeSeriesName: '', ChartType: '', Data: ''}
    ];

    $scope.chartData = null;
    
    $scope.addTimeSeries = function () {
        $scope.Items.push({ TimeSeriesName: '', ChartType: '', Data: '' });
    };

    $scope.generateChart = function () {
        // create the chart
        var seriesData = [];
        for (var i = 0; i < $scope.Items.length; i++)
        {
            seriesData.push({
                name: $scope.Items[i].TimeSeriesName,
                type: $scope.Items[i].ChartType,
                data: JSON.parse($scope.Items[i].Data)
            });
        }

        $('#graphContainer').highcharts('StockChart', {


            title: {
                text: 'Price Data'
            },
            rangeSelector: {
                enabled: false
            },
            xAxis: {
                type: 'datetime',
                dateTimeLabelFormats: {
                    second: '%Y-%m-%d<br/>%H:%M:%S',
                    minute: '%Y-%m-%d<br/>%H:%M',
                    hour: '%Y-%m-%d<br/>%H:%M',
                    day: '%Y<br/>%m-%d',
                    week: '%Y<br/>%m-%d',
                    month: '%Y-%m',
                    year: '%Y'
                }
            },
            series: seriesData
        });//end of chart

    };//end of generateChart

});