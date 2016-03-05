using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSPA.Models
{
    public class ActivityDetailViewModel : ActivityListViewModel
    {
        public float AverageSpeed { get; set; }
        public float MaxSpeed { get; set; }
        public float CenterLat { get; set; }
        public float CenterLng { get; set; }
    }
}