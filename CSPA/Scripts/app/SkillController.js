app.controller('SkillController', function ($scope, APIService) {
    function entry(start, end, quadrant, position, position_angle, direction, direction_angle) {
        return {
            // start date that this entry applies for
            start: start,
            // end date for the entry 
            end: end,
            // the quadrant label
            quadrant: quadrant,
            // position is within the total of horizons.
            position: position,
            // angles are fractions of pi/2 (ie of a quadrant)
            position_angle: position_angle,
            // the learning end point with the total of horizons.
            direction: direction,
            // angles are fractions of pi/2 (ie of a quadrant)
            direction_angle: direction_angle
        };
    }
    radar('#radar',
        // radar data
        {
            horizons: ['discover', 'assess', 'learn', 'use'],
            quadrants: ['languages', 'frameworks', 'tools', 'big data', 'statistics', 'others'],
            width: 850,
            height: 850,
            data: [
                {
                    name: 'd3',
                    description: 'The d3 library for producing visualisation and data driven documents',
                    links: ['http://d3js.org'],
                    history: [
                        entry(new Date(2013, 1, 29), new Date(2013, 9, 29), 'frameworks', 0.8, 0.5, 0.6, 0.5),
                        entry(new Date(2013, 9, 29), null, 'frameworks', 0.6, 0.5, 0.2, 0.5)
                    ]
                }
            ]
        });

});