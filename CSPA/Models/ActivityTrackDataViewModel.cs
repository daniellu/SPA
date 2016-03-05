using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSPA.Models
{
    public class ActivityTrackDataViewModel
    {
        public long Id { get; set; }
        public IEnumerable<Coordinate> Coordinates { get; set; }
    }
}