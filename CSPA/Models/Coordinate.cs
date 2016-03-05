using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSPA.Models
{
    public class Coordinate
    {
        public float lat { get; protected set; }
        public float lng { get; protected set; }

        public Coordinate(float latitude, float longitude)
        {
            lat = latitude;
            lng = longitude;
        }
    }
}