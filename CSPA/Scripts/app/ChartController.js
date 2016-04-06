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

        $('#graphContainer').highcharts().xAxis[0].setExtremes(
				seriesData[0].data[0][0],
				seriesData[0].data[50][0]
			);

    };//end of generateChart

    $('#button').click(function () {
        var chart = $('#graphContainer').highcharts();

        var currentExtreme = chart.xAxis[0].getExtremes();

        var newRange = DecideNewTimeRange(currentExtreme.min, currentExtreme.max, JSON.parse($scope.Items[0].Data));

        if (newRange != null) {
            chart.xAxis[0].setExtremes(
				newRange[0],
				newRange[1]
			);
        }

    });

    function DecideNewTimeRange(currentStartTime, currentEndTime, allData) {
        var resultRange = [];
        var startIndex = null;
        var endIndex = null;

        for (var i = 0; i < allData.length; i++) {
            if ((allData[i][0] <= currentStartTime && allData[i + 1][0] >= currentStartTime)) {
                startIndex = i;
            }
            if ((allData[i][0] <= currentEndTime && allData[i + 1][0] >= currentEndTime)) {
                endIndex = i;
            }
        }

        if ((endIndex == allData.length - 1)) {
            alert('On the extreme');
            resultRange[0] = currentStartTime;
            resultRange[1] = currentEndTime;
        }
        else {
            resultRange[0] = allData[startIndex + 1][0];
            resultRange[1] = allData[endIndex + 1][0];
        }

        return resultRange;
    }//end of DecideNewTimeRange

});