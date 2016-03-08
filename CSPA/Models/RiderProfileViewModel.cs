using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSPA.Models
{
    public class RiderProfileViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ProfileSmallImage { get; set; }
        public string ProfileLargeImage { get; set; }
        public int TotalActivitiesCount { get; set; }        
    }
}